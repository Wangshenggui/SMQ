using System;
using System.IO.Ports;
using System.Text;

namespace SMQ
{
    internal class SerialPortHelper : IDisposable
    {
        private SerialPort serialPort;
        private bool isClosing = false;
        public event Action<string> DataReceivedEvent;
        public event Action<string> UpdateSerialComboBoxEvent;

        public string SerialPortName;

        public SerialPortHelper(SerialPort port)
        {
            serialPort = port;
        }

        public void ScanCOM()
        {
            // 获取所有可用的串口名称
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                Console.WriteLine("未发现任何串口。");
            }
            else
            {
                Console.WriteLine("发现以下串口：");
                foreach (string port in portNames)
                {
                    Console.WriteLine(port);  // 输出 COM1, COM3 等
                    UpdateSerialComboBoxEvent?.Invoke(port);
                }
            }
        }
        public void OpenCOM()
        {
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();

                serialPort.PortName = SerialPortName;
                serialPort.BaudRate = 115200;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;
                serialPort.Encoding = Encoding.GetEncoding("GB2312");
                serialPort.ReceivedBytesThreshold = 1;

                serialPort.DataReceived += CommDataReceived;
                serialPort.Open();

                System.Windows.Forms.MessageBox.Show($"串口 {serialPort.PortName} 打开成功！");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("串口打开失败：" + ex.Message);
            }
        }

        int a = 0;
        private void CommDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isClosing) return;

            try
            {
                int len = serialPort.BytesToRead;
                if (len == 0) return;

                byte[] buffer = new byte[len];
                serialPort.Read(buffer, 0, len);
                string received = Encoding.Default.GetString(buffer);

                a++;

                DataReceivedEvent?.Invoke(a.ToString()); // UI 安全回调
                

                // 不使用 DiscardInBuffer，避免线程冲突
            }
            catch
            {
                // 忽略错误
            }
        }

        public void Dispose()
        {
            isClosing = true;

            try
            {
                if (serialPort != null)
                {
                    serialPort.DataReceived -= CommDataReceived;

                    if (serialPort.IsOpen)
                    {
                        serialPort.Close(); // 不会阻塞线程
                    }

                    serialPort.Dispose();
                }
            }
            catch
            {
                // 忽略异常
            }
        }
    }
}
