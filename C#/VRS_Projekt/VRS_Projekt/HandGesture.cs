using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput;
using WindowsInput.Native;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Timers;
using System.Threading;
using Timer = System.Timers.Timer;
using System.ComponentModel;
using System.Windows.Input;

namespace VRS_Projekt
{
    class HandGesture
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        InputSimulator sim = new InputSimulator();
        BackgroundWorker worker = new BackgroundWorker();
        Timer timerAction;
        static ReaderWriterLock readerWriter = new ReaderWriterLock();

        public event EventHandler ValueChanged;

        //MODY:
        //Mode 1 - CURSOR
        //Mode 2 - USER

        private int appMode;
        public int AppMode
        {
            get
            {
                return appMode;
            }

            set
            {
                appMode = value;
                OnValueChanged(null);
            }
        }

        private static int mouseSpeedHorizontal = 0;
        private static int mouseSpeedVertical = 0;
        private static int mouseAction = 0;
        public int horizontalGain = 1;
        public int verticalGain = 1;
        public int inkognitoAction = 0;
        public int inkognitoApp = 0;

        public HandGesture()
        {
            setTimer();
            appMode = 1;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.DoWork += Worker_DoWork;
        }

        #region METHODS

        public void executeCommand(object commandObj)
        {
            string command = commandObj.ToString();

            string[] cmd = new string[3];

            try
            {
                cmd = command.Split('_');
            }
            catch(Exception exc)
            {

            }

            //Data consistency
            if (cmd.Length < 4 || cmd[1].Length < 1 || cmd[2].Length < 1 || cmd[3].Length < 1)
            {
                return;
            }
            if (!(int.TryParse(cmd[1], out int speedHorizontal) && int.TryParse(cmd[2], out int speedVertical) && int.TryParse(cmd[3], out int action)))
            {
                return;
            }

            //ACTIONS
            //values[2] ACTION: 0 - default, 1 - RESERVE, 2 - change mode, 3 - key left, 4 - key right, 5 - mouse move, 6 - right mouse click, 7 - left mouse click, 8 - fast action

            //Abort worker
            if (action == 0)
            {
                if (worker.IsBusy)
                {
                    worker.CancelAsync();
                }
            }
            //RESERVE
            else if (action == 1)
            {
            }
            //Change mode
            else if (action == 2)
            {
                if (AppMode == 3) { AppMode = 1; }
                else { AppMode += 1; }
            }
            //Key left
            else if(AppMode == 2 &&  action == 3 && getActiveProcessFileName() != "VRS_Projekt")
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.LEFT);
            }
            //Key right
            else if(AppMode == 2 && action == 4 && getActiveProcessFileName() != "VRS_Projekt")
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
            }
            //Mouse move
            else if(AppMode != 3 && action == 5)
            {
                //Backgroundworker
                writeToResource(10, new int[] { speedHorizontal, speedVertical, action });
                if (!worker.IsBusy)
                {
                    worker .RunWorkerAsync();
                }
            }
            //Right mouse click
            else if(AppMode == 1 && action == 6)
            {
                sim.Mouse.RightButtonClick();
            }

            //Left mouse click
            else if(AppMode == 1 &&  action == 7)
            {
                sim.Mouse.LeftButtonClick();
            }
            //Fast action
            else if (action == 8 && !worker.IsBusy)    
            {                   
                Console.WriteLine(getActiveProcessFileName());
                switch (inkognitoAction)
                {
                    case 1:
                        killForegroundProcess();
                        break;
                    case 2:
                        switchProcess();
                        break;
                    case 3:
                        string appName = "";
                        switch (inkognitoApp)
                        {
                            case 1:
                                appName = "notepad.exe";
                                break;
                            case 2:
                                appName = "microsoft-edge:www.google.com";
                                break;
                            case 3:
                                appName = "mspaint.exe";
                                break;
                            case 4:
                                appName = "explorer";
                                break;
                            default:
                                break;
                        }
                        try
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo(appName);
                            startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                            Process.Start(startInfo);
                        }
                        catch(Exception exc)
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                return;
            }
        }

        public string getActiveProcessFileName()
        {
            Process p = new Process();

            try
            {
                IntPtr hwnd = GetForegroundWindow();
                GetWindowThreadProcessId(hwnd, out uint pid);
                p = Process.GetProcessById((int)pid);
            }
            catch(Exception exc)
            {

            }

            return p.ProcessName;
        }

        public void killForegroundProcess()
        {
            if (getActiveProcessFileName() != "VRS_Projekt" && getActiveProcessFileName() != "explorer")
            {
                try
                {
                    IntPtr hwnd = GetForegroundWindow();
                    GetWindowThreadProcessId(hwnd, out uint pid);
                    Process.GetProcessById((int)pid).Kill();
                }
                catch(Exception exc)
                {

                }
            }
        }

        public void switchProcess()
        {
            if(timerAction.Enabled == false)
            {
                sim.Keyboard.KeyDown(VirtualKeyCode.LMENU);
                sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
                timerAction.Enabled = true;
            }
            else
            {
                timerAction.Stop();
                sim.Keyboard.KeyPress(VirtualKeyCode.RIGHT);
                timerAction.Start();
            }
        }

        static int[] readFromResource(int timeOut)
        {
            int[] retVal = { -1, -1, -1};
        
            try
            {
                readerWriter.AcquireReaderLock(timeOut);
                try
                {
                    retVal[0] = mouseSpeedHorizontal;
                    retVal[1] = mouseSpeedVertical;
                    retVal[2] = mouseAction;
                }
                finally
                {
                    readerWriter.ReleaseReaderLock();
                }
            }
            catch (ApplicationException)
            {

            }

            return retVal;
        }

        static void writeToResource(int timeOut, int[] inVal)
        {
            try
            {
                readerWriter.AcquireWriterLock(timeOut);
                try
                {
                    mouseSpeedHorizontal = (inVal[0] - 3);
                    mouseSpeedVertical = (inVal[1] - 5);
                    mouseAction = inVal[2];
                }
                finally
                {
                    readerWriter.ReleaseWriterLock();
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void setTimer()
        {
            timerAction = new Timer(1800);
            timerAction.Elapsed += actionDone;
            timerAction.AutoReset = true;
            timerAction.Enabled = false;
        }

        #endregion

        #region EVENTS
        public void OnValueChanged(EventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }

            ValueChanged?.Invoke(this, e);
        }

        private void Worker_DoWork(object sender,DoWorkEventArgs e)
        {
            Console.WriteLine("Worker started " + DateTime.Now.TimeOfDay);

            int[] values = { -1, -1, -1 };
            int[] valuesOld = { -1, -1, -1 };
            int sleepTime = 0;

            while (!worker.CancellationPending)
            {
                valuesOld = values;
                values = readFromResource(10);

                if (values[0] == -1 || values[1] == -1 || values[2] == -1)
                {
                    values = valuesOld;
                }

                if (values[2] == 0)
                {
                    return;
                }

                switch (appMode)
                {
                    /* 
                     * CMD_x_x_x
                     * values[0] SPEED_Horizontal: <-3,3> => <0,6>     /Mouse, Zoom
                     * values[1] SPEED_Vertical:   <-5,5> => <0,10>    /Mouse, Scroll
                     * values[2] ACTION:           0 -default, 1 - left mouse click, 2 - change mode, 3 - key left, 4 - key right, 5 - mouse move, 6 - right mouse click, 7 - left mouse click, 8 - process kill, 9 - next process
                     */
                    case 1:
                        sleepTime = 20;

                        sim.Mouse.MoveMouseBy(values[0] * horizontalGain, -1 * values[1] * verticalGain);
                        break;
                    case 2:
                        sleepTime = 150;

                        if(values[0] != 0)
                        {
                            sim.Keyboard.KeyDown(VirtualKeyCode.CONTROL);
                            sim.Mouse.VerticalScroll(Math.Abs(values[0]) / values[0]);
                            sim.Keyboard.KeyUp(VirtualKeyCode.CONTROL);
                        }
                        else if (values[1] != 0)
                        {
                            sim.Mouse.VerticalScroll(Math.Abs(values[1]) / values[1]);
                        }
                        break;
                    case 3:
                        break;
                    default:
                        sleepTime = 0;
                        break;
                }
                Thread.Sleep(sleepTime);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Worker completed " + DateTime.Now.TimeOfDay);
        }

        private void actionDone(object source, ElapsedEventArgs e)
        {
            sim.Keyboard.KeyUp(VirtualKeyCode.LMENU);
            timerAction.Enabled = false;
        }
        #endregion
    }
}
