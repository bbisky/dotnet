<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="zgw" Namespace="ZedGraph.Web" Assembly="ZedGraph.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <%--  <ZGW:ZEDGRAPHWEB id="ZedGraphWeb1" runat="server" RenderMode="ImageTag"
            Width="1000" Height="400"  CacheDuration="300" onrendergraph="OnRenderGraph1"></ZGW:ZEDGRAPHWEB>--%>
            
            
    <ZGW:ZEDGRAPHWEB id="ZedGraphWeb2" runat="server" RenderMode="ImageTag"
            Width="600" Height="400" onrendergraph="OnRenderGraph2"></ZGW:ZEDGRAPHWEB>
    </div>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    </form>
    cache:
   <%-- <img src="chart.aspx" />--%>
</body>
</html>
