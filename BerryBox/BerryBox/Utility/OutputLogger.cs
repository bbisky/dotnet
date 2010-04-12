using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BerryBox.Utility
{
    /// <summary>
    /// 日志输出辅助类
    /// </summary>
    public class OutputLogger
    {
        private RichTextBox logger;
        private Font m_DefaultFont = new Font("Arial", 9f, FontStyle.Regular);
        public OutputLogger(RichTextBox rtb)
        {
            this.logger = rtb;           
        }
        delegate void AppendDelegate(string msg,Color color,Font font);
        void Append(string msg, Color color, Font font)
        {           
            if (this.logger.InvokeRequired)
            {
                AppendDelegate log = new AppendDelegate(Append);
                this.logger.BeginInvoke(log, msg, color, font);
                
            }
            else
            {
                if (font != null)
                    this.logger.SelectionFont = font;
                else
                    this.logger.SelectionFont = this.m_DefaultFont;

                this.logger.SelectionColor = color;
                this.logger.AppendText(msg);
                this.logger.AppendText(Environment.NewLine);
                //变为默认
                this.logger.SelectionColor = Color.Black;
                this.logger.SelectionFont = this.m_DefaultFont;
                //滚动到底部
                this.logger.SelectionStart = this.logger.Text.Length;
                this.logger.SelectionLength = 0;
                this.logger.ScrollToCaret();
            }
        }
        delegate void ClearDelegate();
        /// <summary>
        /// 清除日志框
        /// </summary>
        public void Clear()
        {
            if (this.logger.InvokeRequired)
            {
                ClearDelegate d = new ClearDelegate(Clear);
                this.logger.BeginInvoke(d);
            }
            else
            {
                this.logger.Text = "";
            }
        }
        /// <summary>
        /// 错误信息,红色显示
        /// </summary>
        /// <param name="msg"></param>
        public void AppendError(string msg)
        {
            this.Append(msg, Color.Red, null);
        }

        /// <summary>
        /// 错误信息,红色显示
        /// </summary>
        /// <param name="msg"></param>
        public void AppendWarning(string msg)
        {
            this.Append(msg, Color.Orange, null);
        }

        /// <summary>
        /// 错误信息,红色显示
        /// </summary>
        /// <param name="msg"></param>
        public void AppendSuccess(string msg)
        {
            this.Append(msg, Color.Green, null);
        }

        /// <summary>
        /// 默认样式的信息
        /// </summary>
        /// <param name="msg"></param>
        public void AppendText(string msg)
        {
            this.Append(msg, Color.Black, null);
        }
        /// <summary>
        /// 自定义样式的日志
        /// </summary>
        /// <param name="msg"></param>
        public void AppendText(string msg, Color color, Font font)
        {
            this.Append(msg, color, font);
        }

    }
}
