using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;
using System.Threading;
using Timer = System.Timers.Timer;

namespace VRS_Projekt
{
    class SerialCom
    {
        public SerialPort port = new SerialPort();
        public event EventHandler CommandEvent;

        public bool openedPort = false;
        public bool activeCommunication = true;

        public string receivedString = "";
        public string msg = "";
        public int[] distances = new int[4];

        public SerialCom()
        {
            scanPorts();
        }

        #region METHODS

        public void scanPorts()
        {
            string[] portNames = SerialPort.GetPortNames();

            openedPort = false;
            if (portNames.Length > 0)
            {
                openedPort = openPort(portNames[0]);
            }

            Console.WriteLine("Port opened - {0}",openedPort);
        }

        private bool openPort(string portName)
        {
            try
            {
                port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
                port.Open();
                port.ReadTimeout = 100;
                port.DiscardInBuffer();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            return port.IsOpen;
        }

        private bool parseString(string splitedMsg)
        {
            string[] splitedString = new string[4];
            bool valid = true;

            try
            {
                splitedString = splitedMsg.Split('_');
            }
            catch (Exception exc)
            {

            }

            if (splitedString[0] == "D")
            {
                msg = "D";
                try
                {
                    int.TryParse(splitedString[1], out distances[0]);
                    int.TryParse(splitedString[2], out distances[1]);
                    int.TryParse(splitedString[3], out distances[2]);
                    int.TryParse(splitedString[4], out distances[3]);
                }
                catch(Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
                
            }
            else if (splitedString[0] == "B")
            {
                msg = "B";
                int.TryParse(splitedString[1], out int num);
                receivedString = Convert.ToString(num, 2).PadLeft(8, '0');
            }
            else if (splitedString[0] == "CMD")
            {
                msg = "CMD";
                receivedString = splitedMsg;
            }
            else
            {
                Console.WriteLine("Unrecognized msg {0}", splitedMsg);
                valid = false;
            }

            return valid;
        }

        private void parseMessage(string rcvData)
        {
            char[] spearator = { '-', ' ' };
            string[] splitedMsg = rcvData.Split(spearator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in splitedMsg)
            {
                if (parseString(s))
                {
                    CommandEvent?.Invoke(msg, new EventArgs());
                }
            }
        }

        public void continuousReceiving()
        {
            int state = 1;
            string receivedString = "";

            while (activeCommunication)
            {
                switch (state)
                {
                    //Otvorenie portu
                    case 1:
                        if (!port.IsOpen)
                        {
                            scanPorts();
                            if (!port.IsOpen)
                            {
                                Thread.Sleep(5000);
                            }
                        }
                        else
                        {
                            state = 2;
                        }
                        break;
                    //Prijimanie dat
                    case 2:
                        try
                        {
                            receivedString = port.ReadTo("%");
                        }
                        catch (Exception exc)
                        {
                            state = 1;
                        }
                        parseMessage(receivedString);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
