using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;


namespace ControlTest
{
	/// <summary>
	/// Test ��ժҪ˵����
	/// </summary>
	public partial class Test : System.Web.UI.Page
	{
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
            if (!Page.IsPostBack)
                BindDropDownList();
		}

        void BindDropDownList()
        {
            ArrayList al = new ArrayList();
            for(int i=0;i<20;i++)
                al.Add(new string[] {i.ToString(),new Random().Next().ToString() });
            DropDownList1.DataSource =  CreateData();
            DropDownList1.DataBind();
        }

        DataView CreateData()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ID", typeof(System.Int32)));
            dt.Columns.Add(new System.Data.DataColumn("ѧ������", typeof(System.String)));
            dt.Columns.Add(new System.Data.DataColumn("����", typeof(System.String)));
            dt.Columns.Add(new System.Data.DataColumn("��ѧ", typeof(System.String)));
            dt.Columns.Add(new System.Data.DataColumn("Ӣ��", typeof(System.String)));
            dt.Columns.Add(new System.Data.DataColumn("�����", typeof(System.String)));

            for (int i = 1; i < 30; i++)
            {
                System.Random rd = new System.Random(Environment.TickCount * i); ;
                dr = dt.NewRow();
                dr[0] = i;
                dr[1] = "ѧ������" + i.ToString();
                dr[2] = dt.Columns[2].ColumnName + rd.Next().ToString();
                dr[3] = dt.Columns[3].ColumnName + rd.Next().ToString();
                dr[4] = dt.Columns[4].ColumnName + rd.Next().ToString();
                dr[5] = dt.Columns[5].ColumnName + rd.Next().ToString();
                /*
                dr[1] = string.Format("{0}:{1}", dt.Columns[1].ColumnName, System.Math.Round(rd.NextDouble() * 100, 2));
                dr[2] = string.Format("{0}:{1}",dt.Columns[2].ColumnName ,System.Math.Round(rd.NextDouble() * 100, 2));
                dr[3] = string.Format("{0}:{1}", dt.Columns[3].ColumnName, System.Math.Round(rd.NextDouble() * 100, 2));
                dr[4] = string.Format("{0}:{1}", dt.Columns[4].ColumnName, System.Math.Round(rd.NextDouble() * 100, 2));
                dr[5] = string.Format("{0}:{1}", dt.Columns[5].ColumnName, System.Math.Round(rd.NextDouble() * 100, 2));
                 * */
                dt.Rows.Add(dr);
            }
            System.Data.DataView dv = new System.Data.DataView(dt);
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            return dv;
            
        }

        #region Web ������������ɵĴ���
        override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
        protected void Button1_Click(object sender, EventArgs e)
        {
           // Weather1.City = TextBox1.Text;
           
        }
        void GetHuoDong()
        {
            com.w_360buy.www.newsserver s = new com.w_360buy.www.newsserver();
            Literal1.Text = s.Gethuodong(Pager2.PageIndex - 1, Pager2.PageSize, "").Replace("news.aspx","http://www.360buy.com/news.aspx");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
          
          Response.Write(string.Format("DropDownList Selected: Index:{0},Value:{1},Text{2}",DropDownList1.SelectedIndex,DropDownList1.SelectedValue,DropDownList1.SelectedText));
        }
}
}
