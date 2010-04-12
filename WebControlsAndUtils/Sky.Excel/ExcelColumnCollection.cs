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
    /// ExcelColumnCollection ��ժҪ˵��
    /// </summary>
    public class ExcelColumnCollection : System.Collections.CollectionBase
    {
        public ExcelColumnCollection()
        {
        }

        /// <summary>
        /// ��������ӵ� ExcelColumnCollection �Ľ�β����
        /// </summary>
        /// <param name="value">Ҫ��ӵ� ExcelColumnCollection ��ĩβ���� <see cref="ExcelColumn"/>��</param>
        /// <returns>ExcelColumnCollection ���������ڴ˴������ value��</returns>
        public int Add(ExcelColumn value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// ����ָ���� <see cref="ExcelColumn"/>������������ ExcelColumnCollection �е�һ��ƥ����Ĵ��㿪ʼ��������
        /// </summary>
        /// <param name="value">Ҫ�� ExcelColumnCollection �в��ҵ� <see cref="ExcelColumn"/>��</param>
        /// <returns>��������� ExcelColumnCollection ���ҵ� value �ĵ�һ��ƥ�����Ϊ����Ĵ��㿪ʼ������������Ϊ -1��</returns>
        public int IndexOf(ExcelColumn value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// �� RoleCollection ���Ƴ��ض�����ĵ�һ��ƥ���
        /// </summary>
        /// <param name="value">Ҫ�� <see cref="ExcelColumnCollection"/> �Ƴ��� <see cref="ExcelColumn"/>��</param>
        /// 
        /// <exception cref="System.ArgumentException">δ�� ExcelColumnCollection �������ҵ� value ������</exception>
        /// <exception cref="System.NotSupportedException">ExcelColumnCollection Ϊֻ������ ExcelColumnCollection ���й̶���С��
        /// </exception>
        public void Remove(ExcelColumn value)
        {
            List.Remove(value);
        }

        /// <summary>
        /// ��ȡ������ָ����������Ԫ�ء�
        /// </summary>
        /// <param name="index">Ҫ��û����õ�Ԫ�ش��㿪ʼ��������</param>
        /// <returns>ָ����������Ԫ�ء�</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index С���㡣
        /// - �� -
        /// index ���ڻ���� Count��
        /// </exception>
        public ExcelColumn this[int index]
        {
            get
            {
                return (ExcelColumn)List[index];
            }

            set
            {
                List[index] = value;
            }
        }

        /// <summary>
        /// ��ȡ������ָ�� �ؼ��� ��Ԫ�ء�
        /// </summary>
        /// <param name="nodeText">Ҫ��û����õ�Ԫ�صĹؼ��֡�</param>
        /// <returns>��������� ItemNodeCollection ���ҵ� �ؼ��� �ĵ�һ��ƥ�����Ϊ�����Ԫ�أ�����Ϊ null��</returns>
        /// <exception cref="System.ArgumentException">����δ�ɹ���������δ�ҵ�ָ���ؼ��ֵ�Ԫ�ء�</exception>
        public ExcelColumn this[string name]
        {
            get
            {
                ExcelColumn excelColumn;
                for (int i = 0; i < List.Count; i++)
                {
                    excelColumn = (ExcelColumn)List[i];

                    if (excelColumn.Name == name)
                    {
                        return excelColumn;
                    }
                }

                return null;
            }

            set
            {
                ExcelColumn excelColumn;
                for (int i = 0; i < List.Count; i++)
                {
                    excelColumn = (ExcelColumn)List[i];

                    if (excelColumn.Name == name)
                    {
                        excelColumn = value;
                        return;
                    }
                }

                throw new ArgumentException("����δ�ɹ���������δ�ҵ�ָ���ؼ��ֵ�Ԫ�ء�");
            }
        }
    }
}