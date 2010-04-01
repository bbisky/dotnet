<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chart.aspx.cs" Inherits="chart" %>
<%@ Register TagPrefix="zgw" Namespace="ZedGraph.Web" Assembly="ZedGraph.Web" %>
<ZGW:ZEDGRAPHWEB id="ZedGraphWeb1" CacheDuration="300" CacheSuffix='<%=new Guid() %>' runat="server" width="500" Height="375" 
    RenderMode="RawImage" onrendergraph="OnRenderGraph2" />
