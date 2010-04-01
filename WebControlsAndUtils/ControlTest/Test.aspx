
<%@ Page language="c#" Inherits="ControlTest.Test" CodeFile="Test.aspx.cs" %>

<%@ Register Assembly="Sky.WebControls" Namespace="Sky.WebControls" TagPrefix="sky" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head runat="server">
		<title>Test</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">
		    .weather{
		        width:200px;
		        text-align:center;
		    }
		</style>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:Literal ID="Literal1" runat="server"></asp:Literal><br /><%--
            <sky:Weather ID="Weather1" runat="server" CssClass="weather">
            </sky:Weather>--%>
           
            <sky:Pager ID="Pager2" runat="server" PagerType="Numberic" PageSize="20" SummaryText="" PageIndex="1" UrlFormat="?pageid={0}">
            </sky:Pager>
            <sky:DropdownList ID="DropDownList1" DataTextField="Ó¢Óï" DataValueField="ID" runat="server"></sky:DropdownList>
            <asp:Button ID="Button2" runat="server" Text=" Submit" OnClick="Button2_Click" />
            <asp:DropDownList ID="DropDownList2" runat="server"> 
            </asp:DropDownList>
		</form>
	</body>
</html>
