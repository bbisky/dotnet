<% @ Page Language="C#" %>
<% @ Import Namespace="System.Data" %>
<Script Language="C#" Runat="Server">
public void Page_Load(Object src,EventArgs e)
{
	//ȡ��ServerVariables��������
	NameValueCollection ServerVariables = Request.ServerVariables;
	
	//����һ�����ݸ��������÷������Ǻ���������
	DataTable dt = new DataTable();
	DataRow dr;

	dt.Columns.Add(new DataColumn("��������",typeof(string)));
	dt.Columns.Add(new DataColumn("����ֵ",typeof(string)));


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
