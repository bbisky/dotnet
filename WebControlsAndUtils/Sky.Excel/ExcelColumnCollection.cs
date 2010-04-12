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
    /// ExcelColumnCollection 的摘要说明
    /// </summary>
    public class ExcelColumnCollection : System.Collections.CollectionBase
    {
        public ExcelColumnCollection()
        {
        }

        /// <summary>
        /// 将对象添加到 ExcelColumnCollection 的结尾处。
        /// </summary>
        /// <param name="value">要添加到 ExcelColumnCollection 的末尾处的 <see cref="ExcelColumn"/>。</param>
        /// <returns>ExcelColumnCollection 索引，已在此处添加了 value。</returns>
        public int Add(ExcelColumn value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// 搜索指定的 <see cref="ExcelColumn"/>，并返回整个 ExcelColumnCollection 中第一个匹配项的从零开始的索引。
        /// </summary>
        /// <param name="value">要在 ExcelColumnCollection 中查找的 <see cref="ExcelColumn"/>。</param>
        /// <returns>如果在整个 ExcelColumnCollection 中找到 value 的第一个匹配项，则为该项的从零开始的索引；否则为 -1。</returns>
        public int IndexOf(ExcelColumn value)
        {
            return (List.IndexOf(value));
        }

        /// <summary>
        /// 从 RoleCollection 中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="value">要从 <see cref="ExcelColumnCollection"/> 移除的 <see cref="ExcelColumn"/>。</param>
        /// 
        /// <exception cref="System.ArgumentException">未在 ExcelColumnCollection 对象中找到 value 参数。</exception>
        /// <exception cref="System.NotSupportedException">ExcelColumnCollection 为只读，或 ExcelColumnCollection 具有固定大小。
        /// </exception>
        public void Remove(ExcelColumn value)
        {
            List.Remove(value);
        }

        /// <summary>
        /// 获取或设置指定索引处的元素。
        /// </summary>
        /// <param name="index">要获得或设置的元素从零开始的索引。</param>
        /// <returns>指定索引处的元素。</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">index 小于零。
        /// - 或 -
        /// index 等于或大于 Count。
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
        /// 获取或设置指定 关键字 的元素。
        /// </summary>
        /// <param name="nodeText">要获得或设置的元素的关键字。</param>
        /// <returns>如果在整个 ItemNodeCollection 中找到 关键字 的第一个匹配项，则为该项的元素；否则为 null。</returns>
        /// <exception cref="System.ArgumentException">设置未成功，集合中未找到指定关键字的元素。</exception>
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

                throw new ArgumentException("设置未成功，集合中未找到指定关键字的元素。");
            }
        }
    }
}