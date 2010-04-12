using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace Sky.Excel
{
    /// <summary>
    /// Excel����ExcelColumn ��ժҪ˵��
    /// </summary>
    public class ExcelColumn
    {
        private int _width = 150;//Ĭ�Ͽ��
        private string _name = string.Empty;//����
        private int _mergeAcross = 0;//��Խ�ֶ�
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="width">�п�</param>
        /// <param name="name">����</param>
        public ExcelColumn(int width, string name)
        {
            this._width = width;
            this._name = name;
            this._mergeAcross = 0;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="colspan">�ϲ�����</param>
        public ExcelColumn(string name, int colspan)
        {
            this._name = name;
            this._mergeAcross = colspan - 1;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="name">����</param>
        public ExcelColumn(string name)
        {
            this._name = name;
        }
        public int Width
        {
            get { return _width; }
        }
        public string Name
        {
            get { return _name; }
        }
        public int MergeAcross
        {
            get { return _mergeAcross; }
        }

    }
}