using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Collections.Generic;
using CarlosAg.ExcelXmlWriter;
namespace Sky.Excel
{
    /// <summary>
    /// ExcelBook 导出功能主类 的摘要说明
    /// </summary>
    public class ExcelBook
    {
        private Workbook _book = new Workbook();
        private DataTable _dataTable = null;
        private string _title = "";
        private Page _page = null;
        private List<ExcelColumnCollection> _columnNamesCollection = new List<ExcelColumnCollection>();
        private SortedList<string, int> _maxLengthOfField = new SortedList<string, int>();
        private bool _isAutoFitWidth = true;
        private string _Author = "";
        private string _LastAuthor = "";
        private string _Company = "";
        private string _Version = "11.6408";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dt">DataTable形式的数据源</param>
        /// <param name="title">Excel显示标题</param>
        public ExcelBook(DataTable dt, string title)
        {
            Page page = (Page)HttpContext.Current.Handler;
            if (dt == null)
            {
                throw new Exception("数据源为空");
            }
            _dataTable = dt;
            _title = title;
            _page = page;
        }
        /// <summary>
        /// 以GridView的Head为标题
        /// </summary>
        /// <param name="row">GridView表头行对象</param>
        public void SetColumnNameFromGridViewHeadRow(GridViewRow row)
        {
            ExcelColumnCollection excelcols = new ExcelColumnCollection();
            _columnNamesCollection.Add(excelcols);
            foreach (TableCell cell in row.Cells)
            {
                excelcols.Add(new ExcelColumn(cell.Text));
            }
        }
        /// <summary>
        /// 初始化Excel Workbook
        /// </summary>
        /// <param name="book">book</param>
        private void InitializeBook(Workbook book)
        {
            book.Properties.Author = Author;
            book.Properties.LastAuthor = LastAuthor;
            book.Properties.Created = DateTime.Now;
            book.Properties.Company = Company;
            book.Properties.Version = Version;
            book.ExcelWorkbook.WindowHeight = 13500;
            book.ExcelWorkbook.WindowWidth = 17100;
            book.ExcelWorkbook.WindowTopX = 360;
            book.ExcelWorkbook.WindowTopY = 75;
            book.ExcelWorkbook.ProtectWindows = false;
            book.ExcelWorkbook.ProtectStructure = false;
        }
        /// <summary>
        /// 设置样式
        /// </summary>
        /// <param name="styles">样式集合</param>
        private void SetStyles(WorksheetStyleCollection styles)
        {
            // -----------------------------------------------
            //  Default
            // -----------------------------------------------
            WorksheetStyle Default = styles.Add("Default");
            Default.Name = "Normal";
            Default.Font.FontName = "宋体";
            Default.Font.Size = 12;
            Default.Alignment.Vertical = StyleVerticalAlignment.Center;
            // -----------------------------------------------
            //  TitleStyle
            // -----------------------------------------------
            WorksheetStyle TitleStyle = styles.Add("TitleStyle");
            TitleStyle.Font.Bold = true;
            TitleStyle.Font.FontName = "黑体";
            TitleStyle.Font.Size = 14;
            TitleStyle.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            TitleStyle.Alignment.Vertical = StyleVerticalAlignment.Center;
            // -----------------------------------------------
            //  FieldStyle
            // -----------------------------------------------
            WorksheetStyle FieldStyle = styles.Add("FieldStyle");
            FieldStyle.Font.Bold = true;
            FieldStyle.Font.FontName = "宋体";
            FieldStyle.Font.Size = 12;
            FieldStyle.Alignment.Horizontal = StyleHorizontalAlignment.Center;
            FieldStyle.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            FieldStyle.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            FieldStyle.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            FieldStyle.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  LastFieldStyle
            // -----------------------------------------------
            WorksheetStyle LastFieldStyle = styles.Add("LastFieldStyle");
            LastFieldStyle.Font.Bold = true;
            LastFieldStyle.Font.FontName = "宋体";
            LastFieldStyle.Font.Size = 12;
            LastFieldStyle.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            LastFieldStyle.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
            LastFieldStyle.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            LastFieldStyle.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            // -----------------------------------------------
            //  DataStyle
            // -----------------------------------------------
            WorksheetStyle DataStyle = styles.Add("DataStyle");
            DataStyle.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous, 1);
            DataStyle.Borders.Add(StylePosition.Right, LineStyleOption.Continuous, 1);
            DataStyle.Borders.Add(StylePosition.Top, LineStyleOption.Continuous, 1);
            DataStyle.Borders.Add(StylePosition.Left, LineStyleOption.Continuous, 1);
        }
        /// <summary>
        /// 设置Excel Sheet
        /// </summary>
        /// <param name="sheets">sheets集合</param>
        private void SetSheels(WorksheetCollection sheets)
        {
            Worksheet sheet = sheets.Add(_title);
            sheet.Table.DefaultRowHeight = 14.25F;
            sheet.Table.DefaultColumnWidth = 54F;
            sheet.Table.FullColumns = 1;
            sheet.Table.FullRows = 1;

            // -----------------------------------------------

            WorksheetRow row = null;
            WorksheetCell cell = null;

            #region 大标题
            row = sheet.Table.Rows.Add();
            row.AutoFitHeight = true;
            row.Height = 30;
            cell = row.Cells.Add();
            cell.StyleID = "TitleStyle";
            cell.Data.Type = DataType.String;
            cell.Data.Text = _title;
            cell.MergeAcross = _dataTable.Columns.Count - 1;
            #endregion

            foreach (DataColumn dc in _dataTable.Columns)//初始化列宽度集合
            {
                _maxLengthOfField[dc.ColumnName] = 0;
            }

            //-----------------------------------------------字段
            #region 字段标题行

            if (_columnNamesCollection.Count != 0)
            {
                for (int i = 0; i < _columnNamesCollection.Count; i++)
                {
                    row = sheet.Table.Rows.Add();
                    row.AutoFitHeight = true;
                    int j = 0;
                    foreach (ExcelColumn ec in _columnNamesCollection[i])
                    {
                        cell = row.Cells.Add();
                        cell.Data.Text = ec.Name;
                        cell.Data.Type = DataType.String;
                        if (i != _columnNamesCollection.Count - 1)
                        {
                            cell.MergeAcross = ec.MergeAcross;
                            cell.StyleID = "FieldStyle";
                        }
                        else//最下层标题行
                        {
                            cell.StyleID = "LastFieldStyle";
                            _maxLengthOfField[_dataTable.Columns[j++].ColumnName] =
                                GetMaxLength(_maxLengthOfField[_dataTable.Columns[j++].ColumnName], ec.Name);
                        }
                    }
                }
            }
            else
            {
                row = sheet.Table.Rows.Add();
                row.AutoFitHeight = true;
                foreach (DataColumn dc in _dataTable.Columns)
                {
                    cell = row.Cells.Add();
                    cell.Data.Text = dc.ColumnName;
                    cell.Data.Type = DataType.String;
                    cell.StyleID = "FieldStyle";
                    _maxLengthOfField[dc.ColumnName] = GetMaxLength(_maxLengthOfField[dc.ColumnName], dc.ColumnName);
                }
            }
            #endregion
            // -----------------------------------------------

            #region 数据行
            object dcValueO = null;
            string dcValueS = null;
            foreach (DataRow dr in _dataTable.Rows)
            {
                row = sheet.Table.Rows.Add();
                row.AutoFitHeight = true;
                foreach (DataColumn dc in _dataTable.Columns)
                {
                    dcValueO = dr[dc];
                    if (dcValueO == DBNull.Value)
                        dcValueS = string.Empty;
                    else
                        dcValueS = dcValueO.ToString();
                    cell = row.Cells.Add();
                    cell.Data.Text = dcValueS;
                    cell.Data.Type = TypeConvert(dc.DataType);
                    cell.StyleID = "DataStyle";
                    if (_isAutoFitWidth || _columnNamesCollection.Count == 0)
                    {
                        _maxLengthOfField[dc.ColumnName] = GetMaxLength(_maxLengthOfField[dc.ColumnName], dcValueS);
                    }
                }
            }
            #endregion
            // -----------------------------------------------

            #region 设置列
            WorksheetColumn column = null;
            if (!_isAutoFitWidth && _columnNamesCollection.Count != 0)
            {
                foreach (ExcelColumn ec in _columnNamesCollection[_columnNamesCollection.Count - 1])
                {
                    column = new WorksheetColumn();
                    column.AutoFitWidth = false;
                    column.Width = ec.Width;
                    sheet.Table.Columns.Add(column);
                }
            }
            else
            {
                foreach (DataColumn dc in _dataTable.Columns)
                {
                    column = new WorksheetColumn();
                    column.AutoFitWidth = false;
                    column.Width = _maxLengthOfField[dc.ColumnName] * 7;
                    sheet.Table.Columns.Add(column);
                }
            }
            #endregion
            //  Options
            // -----------------------------------------------
            sheet.Options.Selected = true;
            sheet.Options.ProtectObjects = false;
            sheet.Options.ProtectScenarios = false;
            sheet.Options.Print.PaperSizeIndex = 9;
            sheet.Options.Print.HorizontalResolution = 300;
            sheet.Options.Print.VerticalResolution = 300;
            sheet.Options.Print.ValidPrinterInfo = true;
        }
        /// <summary>
        /// 向客户端发送Excel下载文档数据
        /// </summary>
        /// <param name="downloadFileName">下载时显示的文件名称</param>
        public void WriteExcelToClient(string downloadFileName)
        {
            string fileName = string.IsNullOrEmpty(downloadFileName) ?
                (string.IsNullOrEmpty(_title) ? "未命名文件" : _title) : downloadFileName;

            InitializeBook(_book);
            SetStyles(_book.Styles);
            SetSheels(_book.Worksheets);

            _book.Save(_page.Response.OutputStream);
            _page.Response.AppendHeader("Content-Disposition", "Attachment; FileName=" +
                HttpUtility.UrlEncode(fileName, Encoding.UTF8) + ".xls;");
            _page.Response.ContentEncoding = System.Text.Encoding.UTF8;
            _page.Response.Charset = "UTF-8";
            _page.Response.Flush();
            _page.Response.End();
        }
        /// <summary>
        /// 向客户端发送Excel下载文档数据
        /// </summary>
        public void WriteExcelToClient()
        {
            WriteExcelToClient(null);
        }
        /// <summary>
        /// 数据类型转换
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private DataType TypeConvert(Type type)
        {
            switch (type.Name)
            {
                case "Decimal":
                case "Double":
                case "Single":
                    return DataType.Number;
                case "Int16":
                case "Int32":
                case "Int64":
                case "SByte":
                case "UInt16":
                case "UInt32":
                case "UInt64":
                    return DataType.Number;
                case "String":
                    return DataType.String;
                case "DateTime":
                    return DataType.String;
                default:
                    return DataType.String;
            }
        }
        /// <summary>
        /// 添加标题行 集合
        /// </summary>
        /// <param name="exColumnCollection"></param>
        public void AddColumnNamesCollection(ExcelColumnCollection exColumnCollection)
        {
            _columnNamesCollection.Add(exColumnCollection);
        }
        /// <summary>
        /// 清楚标题行集合
        /// </summary>
        public void ClearColumnNamesCollection()
        {
            _columnNamesCollection.Clear();
        }
        /// <summary>
        /// 列宽是否自适应
        /// </summary>
        public bool IsAutoFitWidth
        {
            get { return _isAutoFitWidth; }
            set { _isAutoFitWidth = value; }
        }
        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }
        public string LastAuthor
        {
            get { return _LastAuthor; }
            set { _LastAuthor = value; }
        }
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        /// <summary>
        /// 获取字段最大宽度函数
        /// </summary>
        /// <param name="oldLength">原来长度</param>
        /// <param name="str">当前字符串</param>
        /// <returns>最大值</returns>
        private int GetMaxLength(int oldLength, string str)
        {
            if (str == null) str = "";
            byte[] bs = System.Text.Encoding.Default.GetBytes(str.Trim());
            int newLength = bs.Length;
            if (oldLength > newLength)
                return oldLength;
            else
                return newLength;
        }
    }
}