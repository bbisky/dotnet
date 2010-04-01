<%@ Page Language="c#" Inherits="ZG1.graph" CodeFile="mypage.aspx.cs" %>
<%@ Register TagPrefix="zgw" Namespace="ZedGraph.Web" Assembly="ZedGraph.Web" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>A Sample Page Using ZedGraph.RenderMode.ImageTag</title>
</head>
   <body>
      <p>
         The default render mode is ImageTag, so it does not need to be
         explicitly designated.  The RenderMode property is included here
         for clarity.<br /><br />
         In this mode an IMG tag is generated in-place, and the image is
         generated and saved in the specified folder (RenderedImagePath
         property, default to ~/ZedGraphImages/).  Two charts are included
         below to demonstrate how the CodeFile can include multiple charts:
         <br /><br />
         
         <ZGW:ZEDGRAPHWEB id="ZedGraphWeb1" runat="server" RenderMode="ImageTag"
            Width="300" Height="200"></ZGW:ZEDGRAPHWEB>
         <ZGW:ZEDGRAPHWEB id="ZedGraphWeb2" runat="server" RenderMode="ImageTag"
            Width="600" Height="400"></ZGW:ZEDGRAPHWEB>
                  
      </p>
   </body>
</html>
