using System;
using System.Collections.Generic;
using System.Text;

namespace Sky.WebControls.Components
{
    /// <summary>
    /// Weather entity
    /// </summary>
    [Serializable]
    public class WeatherInfo
    {
        private string m_date;
        private string m_Img1;
        private string m_Img2;
        private string m_Temp;
        private string m_Wind;

        /// <summary>
        /// ��������
        /// </summary>
        public string Date
        {
            get { return this.m_date; }
            set { this.m_date = value; }
        }

        /// <summary>
        /// ����ͼƬ1
        /// </summary>
        public string Img1
        {
            get { return this.m_Img1; }
            set { this.m_Img1 = value; }
        }

        /// <summary>
        /// ����ͼƬ2
        /// </summary>
        public string Img2
        {
            get { return this.m_Img2; }
            set { this.m_Img2 = value; }
        }

        /// <summary>
        /// �¶�
        /// </summary>
        public string Temperature
        {
            get { return this.m_Temp; }
            set { this.m_Temp = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Wind
        {
            get { return this.m_Wind; }
            set { this.m_Wind = value; }
        }

    }
}
