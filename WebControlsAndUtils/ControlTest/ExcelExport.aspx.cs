using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Sky.Excel;
public partial class ExcelExport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExcelBook eb = new ExcelBook(CreateDataSource(), "测试Excel");
        eb.IsAutoFitWidth = true;//自定适用列宽
        eb.Author = "Sky.Excel";//作者
        eb.LastAuthor = "Sky";//最后作者
        eb.Company = "CUC";//公司
        eb.Version = "1.0";//版本
        eb.WriteExcelToClient("测试Excel");//下载Excel文件
        //eb.WriteExcelToClient();//以标题为下载文件名
    }

    System.Data.DataTable CreateDataSource()
    {
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Data.DataRow dr;
        dt.Columns.Add(new System.Data.DataColumn(" id ", typeof(System.Int32)));
        dt.Columns.Add(new System.Data.DataColumn(" 学生姓名 ", typeof(System.String)));
        dt.Columns.Add(new System.Data.DataColumn(" 语文 ", typeof(System.Decimal)));
        dt.Columns.Add(new System.Data.DataColumn(" 数学 ", typeof(System.Decimal)));
        dt.Columns.Add(new System.Data.DataColumn(" 英语 ", typeof(System.Decimal)));
        dt.Columns.Add(new System.Data.DataColumn(" 计算机 ", typeof(System.Decimal)));

        for (int i = 1; i < 30; i++)
        {
            System.Random rd = new System.Random(Environment.TickCount * i); ;
            dr = dt.NewRow();
            dr[0] = i;
            dr[1] = " 【孟子E章】 " + i.ToString();
            dr[2] = System.Math.Round(rd.NextDouble() * 100, 2);
            dr[3] = System.Math.Round(rd.NextDouble() * 100, 2);
            dr[4] = System.Math.Round(rd.NextDouble() * 100, 2);
            dr[5] = System.Math.Round(rd.NextDouble() * 100, 2);
            dt.Rows.Add(dr);
        }
       
        return dt;
    }

}
