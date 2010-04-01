<% @ Page Language="C#" %>
<% @ Import Namespace="System.Data" %>
<Script Language="C#" Runat="Server">
public void Page_Load(Object src,EventArgs e)
{
	//取得ServerVariables变量集合
	NameValueCollection ServerVariables = Request.ServerVariables;
	
	//产生一个数据个，它的用法，我们后面再讨论
	DataTable dt = new DataTable();
	DataRow dr;

	dt.Columns.Add(new DataColumn("环境变量",typeof(string)));
	dt.Columns.Add(new DataColumn("变量值",typeof(string)));


	foreach(string SingleVariable in ServerVariables)
	{
		dr = dt.NewRow();
		dr[0] = SingleVariable;
		dr[1] = ServerVariables[SingleVariable].ToString();
		dt.Rows.Add(dr);
	}

	DataGrid1.DataSource = new DataView(dt);
	DataGrid1.DataBind();
}
</script>
<html>
<head>
<title></title>
</head>
<body>
<ASP:DataGrid id="DataGrid1" runat="server"
BorderColor="black"
BorderWidth="1"
GridLines="Both"
CellPadding="3"
CellSpacing="0"
Font-Name="Verdana"
Font-Size="8pt"
HeaderStyle-BackColor="#aaaadd"
AlternatingItemStyle-BackColor="#eeeeee"
/>
</body>
</html>
