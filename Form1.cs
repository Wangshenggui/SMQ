using System;
using System.Windows.Forms;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;

namespace SMQ
{
    public partial class Form1 : Form
    {
        private SerialPortHelper serialPortHelper;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPortHelper = new SerialPortHelper(serialPort1);
            serialPortHelper.DataReceivedEvent += UpdateTextBox;
            serialPortHelper.UpdateSerialComboBoxEvent += UpdateSerialComboBox;
            serialPortHelper.ScanCOM();
        }

        private void UpdateTextBox(string receivedData)
        {
            if (IsDisposed) return; // 防止窗体已关闭还访问控件

            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateTextBox), receivedData);
            }
            else
            {
                //COM_TextBox.AppendText(receivedData + Environment.NewLine);
                COM_TextBox.Text = receivedData;
            }
        }
        // 更新串口扫描
        private void UpdateSerialComboBox(string COM_Data)
        {
            if (IsDisposed) return; // 防止窗体已关闭还访问控件

            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(UpdateSerialComboBox), COM_Data);
            }
            else
            {
                SerialComboBox.Items.Add(COM_Data);
                SerialComboBox.SelectedIndex = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPortHelper?.Dispose();
        }

        private void SerialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPortHelper.SerialPortName = SerialComboBox.SelectedItem.ToString();
            serialPortHelper.OpenCOM();
        }

        private void COM_TextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
