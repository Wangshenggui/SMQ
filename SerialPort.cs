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
            // ��ȡ���п��õĴ�������
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                Console.WriteLine("δ�����κδ��ڡ�");
            }
            else
            {
                Console.WriteLine("�������´��ڣ�");
                foreach (string port in portNames)
                {
                    Console.WriteLine(port);  // ��� COM1, COM3 ��
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

                System.Windows.Forms.MessageBox.Show($"���� {serialPort.PortName} �򿪳ɹ���");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("���ڴ�ʧ�ܣ�" + ex.Message);
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

                DataReceivedEvent?.Invoke(a.ToString()); // UI ��ȫ�ص�
                

                // ��ʹ�� DiscardInBuffer�������̳߳�ͻ
            }
            catch
            {
                // ���Դ���
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
                        serialPort.Close(); // ���������߳�
                    }

                    serialPort.Dispose();
                }
            }
            catch
            {
                // �����쳣
            }
        }
    }
}
