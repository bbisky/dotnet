using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BerryBox.Utility;

namespace BerryBox
{
    public partial class TestRichTextBox : Form
    {
        private OutputLogger m_Logger;
        public TestRichTextBox()
        {
            InitializeComponent();
            this.m_Logger = new OutputLogger(richTextBox1);

            this.m_Logger.AppendError("这是一条错误信息");
            this.m_Logger.AppendWarning("这是一条警告信息");
            this.m_Logger.AppendSuccess("这是一条成功信息");
            this.m_Logger.AppendText("这是一条自定义样式的信息", Color.OrangeRed, new Font("微软雅黑", 3*9f, FontStyle.Bold));
            this.m_Logger.AppendText("这是一条自定义样式的信息", Color.DarkOrange, new Font("微软雅黑", 5 * 9f, FontStyle.Strikeout));
        }
    }
}
