namespace SMQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.COM_TextBox = new System.Windows.Forms.TextBox();
            this.SerialComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // COM_TextBox
            // 
            this.COM_TextBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.COM_TextBox.Location = new System.Drawing.Point(426, 25);
            this.COM_TextBox.Name = "COM_TextBox";
            this.COM_TextBox.Size = new System.Drawing.Size(100, 31);
            this.COM_TextBox.TabIndex = 0;
            this.COM_TextBox.Text = "COM0";
            this.COM_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.COM_TextBox.TextChanged += new System.EventHandler(this.COM_TextBox_TextChanged);
            // 
            // SerialComboBox
            // 
            this.SerialComboBox.FormattingEnabled = true;
            this.SerialComboBox.Location = new System.Drawing.Point(803, 25);
            this.SerialComboBox.Name = "SerialComboBox";
            this.SerialComboBox.Size = new System.Drawing.Size(121, 20);
            this.SerialComboBox.TabIndex = 1;
            this.SerialComboBox.SelectedIndexChanged += new System.EventHandler(this.SerialComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 583);
            this.Controls.Add(this.SerialComboBox);
            this.Controls.Add(this.COM_TextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.TextBox COM_TextBox;
        private System.Windows.Forms.ComboBox SerialComboBox;
    }
}

