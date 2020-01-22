using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using System.ComponentModel;

namespace VRS_Projekt
{
    public partial class Form1 : Form
    {
        
        SerialCom com = new SerialCom();
        HandGesture handGesture = new HandGesture();
        Thread communicationThread;

        TextBoxWrite textBoxWriter;
        delegate void TextBoxWrite(string text);
        
        bool activeApp = true;
        bool chartDone = true;

        Queue<double> yValues_1 = new Queue<double>(150);
        Queue<double> yValues_2 = new Queue<double>(150);
        Queue<double> yValues_3 = new Queue<double>(150);
        Queue<double> yValues_4 = new Queue<double>(150);
        Queue<double> xValues_1 = new Queue<double>(150);
        Queue<double> xValues_2 = new Queue<double>(150);
        Queue<double> xValues_3 = new Queue<double>(150);
        Queue<double> xValues_4 = new Queue<double>(150);
        static Timer chartTimer;

        public Form1()
        {
            InitializeComponent();

            //Events
            handGesture.ValueChanged += changeMode_Event;
            com.CommandEvent += receivedCommand;

            setTimer();
            initAxesValues();
            Size = new Size(Size.Width, 375);

            handGesture.AppMode = Properties.Settings.Default.appModeDef;
            horizontalGain.Value = Properties.Settings.Default.horizontalGain;
            verticalGain.Value = Properties.Settings.Default.verticalGain;
            comboBox1.SelectedIndex = Properties.Settings.Default.inkognitoApp;
            radioButton_CheckedChanged(switchRadioButton, new EventArgs());
            horizontalGain_Scroll(new object(), new EventArgs());
            verticalGain_Scroll(new object(), new EventArgs());


            communicationThread = new Thread(com.continuousReceiving);
            communicationThread.IsBackground = true;
            communicationThread.Start();
        }

        private void changeMode_click(object sender, EventArgs e)
        {
            if(sender == modeButton1 || sender == mode1ToolStripMenuItem)
            {
                handGesture.AppMode = 1;
            }
            else if (sender == modeButton2 || sender == mode2ToolStripMenuItem)
            {
                handGesture.AppMode = 2;
            }
            else if (sender == modeButton3 || sender == mode3ToolStripMenuItem)
            {
                handGesture.AppMode = 3;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                showGraphButton_Click("Minimized", new EventArgs());
                Hide();
            }
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                showApplicationToolStripMenuItem_Click(new object(), new EventArgs());
            }
        }

        private void exitApp(object sender, EventArgs e)
        {
            Close();
        }

        private void releaseResources()
        {
            com.CommandEvent -= receivedCommand;
            com.activeCommunication = false;
            notifyIcon1.Visible = false;
            activeApp = false;
        }

        private void setTimer()
        {
            chartTimer = new Timer(100);
            chartTimer.Elapsed += chartRefresh;
            chartTimer.AutoReset = true;
            chartTimer.Enabled = false;
        }

        private void initAxesValues()
        {
            for(int k = 0;k <= 150; k++)
            {
                yValues_1.Enqueue(0);
                yValues_2.Enqueue(0);
                yValues_3.Enqueue(0);
                yValues_4.Enqueue(0);
                xValues_1.Enqueue(k/10.0);
                xValues_2.Enqueue(k / 10.0);
                xValues_3.Enqueue(k / 10.0);
                xValues_4.Enqueue(k / 10.0);
            }
        }

        private void chartRefresh(object source, ElapsedEventArgs e)
        {
            if (activeApp && chart1.Visible)
            {
                BeginInvoke((Action)(() =>
                    {
                        chartDone = false;
                        try
                        {
                            chart1.Series[0].Points.DataBindXY(xValues_1, yValues_1);
                            chart1.Series[1].Points.DataBindXY(xValues_2, yValues_2);
                            chart1.Series[2].Points.DataBindXY(xValues_3, yValues_3);
                            chart1.Series[3].Points.DataBindXY(xValues_4, yValues_4);
                        }
                        catch (Exception exc)
                        {
                            
                        }
                        chartDone = true;
                }));
            }
        }

        public void changeMode_Event(object sender, EventArgs e)
        {
            string actMode = "";
            try
            {
                modeButton1.BackColor = SystemColors.Control;
                modeButton2.BackColor = SystemColors.Control;
                modeButton3.BackColor = SystemColors.Control;
                mode1ToolStripMenuItem.BackColor = SystemColors.Control;
                mode2ToolStripMenuItem.BackColor = SystemColors.Control;
                mode3ToolStripMenuItem.BackColor = SystemColors.Control;

                switch (handGesture.AppMode)
                {
                    case 1:
                        modeButton1.BackColor = Color.LightGreen;
                        mode1ToolStripMenuItem.BackColor = Color.LightGreen;
                        actMode = "Cursor mode";
                        break;
                    case 2:
                        modeButton2.BackColor = Color.LightGreen;
                        mode2ToolStripMenuItem.BackColor = Color.LightGreen;
                        actMode = "User mode";
                        break;
                    case 3:
                        modeButton3.BackColor = Color.LightGreen;
                        mode3ToolStripMenuItem.BackColor = Color.LightGreen;
                        actMode = "Fast action";
                        break;
                    default:
                        break;
                }
                notifyIcon1.BalloonTipText = "Changed to: " + actMode;
                notifyIcon1.ShowBalloonTip(50);
            }
            catch (Exception exc)
            {

            }

            
        }

        private void receivedCommand(object sender, EventArgs e)
        {
            if (Created && !IsDisposed && activeApp)
            {
                if (sender.ToString() == "D")
                {
                    if (chartDone)
                    {
                        try
                        {
                            yValues_1.Dequeue(); yValues_2.Dequeue(); yValues_3.Dequeue(); yValues_4.Dequeue();
                            yValues_1.Enqueue(com.distances[0]); yValues_2.Enqueue(com.distances[1]); yValues_3.Enqueue(com.distances[2]); yValues_4.Enqueue(com.distances[3]);
                        }
                        catch (Exception exc)
                        {

                        }
                    }
                    return;
                }

                if (sender.ToString() == "B")
                {
                    textBoxWriter = writeInLabel;
                }

                if (sender.ToString() == "CMD")
                {
                    handGesture.executeCommand(com.receivedString);
                    textBoxWriter = writeInTextBox;
                }

                try
                {
                    if (textBoxWriter != null)
                    {
                        Invoke(textBoxWriter, com.receivedString);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void writeInTextBox(string text)
        {
            try
            {
                textBox1.AppendText(text + " Timestamp: " + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Second.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Millisecond.ToString());
                textBox1.AppendText(Environment.NewLine);
                if (textBox1.TextLength >= 32766)
                {
                    textBox1.Clear();
                }
            }
            catch(Exception exc)
            {

            }
        }

        private void writeInLabel(string text)
        {
            try
            {
                liveByte.Text = text;
            }
            catch(Exception exc)
            {

            }
        }

        private void showGraphButton_Click(object sender, EventArgs e)
        {
            if (chart1.Visible || sender.ToString() == "Minimized")
            {
                chartTimer.Enabled = false;
                chart1.Hide();
                Size = new Size(595,375);
            }
            else
            {
                chartTimer.Enabled = true;
                chart1.Show();
                Size = new Size(595,692);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.horizontalGain = handGesture.horizontalGain;
            Properties.Settings.Default.verticalGain = handGesture.verticalGain;
            Properties.Settings.Default.inkognitoApp = handGesture.inkognitoApp - 1;
            Properties.Settings.Default.appModeDef = handGesture.AppMode;
            Properties.Settings.Default.Save();
            releaseResources();
        }

        private void horizontalGain_Scroll(object sender, EventArgs e)
        {
            try
            {
                handGesture.horizontalGain = horizontalGain.Value;
            }
            catch (Exception exc)
            {

            }
        }

        private void verticalGain_Scroll(object sender, EventArgs e)
        {
            try
            {
                handGesture.verticalGain = verticalGain.Value;
            }
            catch (Exception exc)
            {

            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton radioButton = sender as RadioButton;
                if (radioButton == closeRadioButton)
                {
                    handGesture.inkognitoAction = 1;
                }
                else if (radioButton == switchRadioButton)
                {
                    handGesture.inkognitoAction = 2;
                }
                else if (radioButton == notepadRadioButton)
                {
                    handGesture.inkognitoAction = 3;
                }
                else
                {

                }
            }
            catch(Exception exc)
            {

            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox comboBox = sender as ComboBox;
                handGesture.inkognitoApp = comboBox.SelectedIndex + 1;
            }
            catch (Exception exc)
            {

            }
        }
    }
}