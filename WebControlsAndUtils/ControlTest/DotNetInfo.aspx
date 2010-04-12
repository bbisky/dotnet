<%@Page ContentType="text/html" Language="C#" Inherits="SpbDev.DotNetInfo.Index"%>
<%@ Register TagPrefix="spbdev" Namespace="SpbDev.DotNetInfo" Assembly="SpbDev.DotNetInfo"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<style type="text/css">
<!--
body,table,td{font-size:12px;color:#000000;word-break:break-all;}
form{margin:0;padding:0}
td td{padding-left:12px;}
a{color:#000090;}
a:hover{color:#FF3333}
.InputTxt{font-size:12px;width:140px;height:18px;border:solid 1px #333333;}
.Button{font-size:12px;width:32px;height:16px;border:solid 1px #333333;background:#CCCCCC}
.TrHead{font-size:12px;color:#CC3380;font-weight:600;text-align:center;height:28px;background:#CCCCCC}
//-->
</style>
<title>Asp.Net探针</title>
</head>
	
<body>
<br>
<table border="0" width="100%" align="center">
	<tr>
		<td align="center" height="30" style="font-size:14px;font-weight:600;color:#FF3333">Asp.Net 服务器信息探针</td>
	</tr>
</table>
<table width="760" border="1" align="center" cellspacing="0" bordercolor="#666666" bgcolor="#EEEEEE" style="border-collapse:collapse">
	<tr> 
		<td align="center">
			<table border="0" width="95%">
				<tr>
					<td align="center" height="30">本程序由<a href="http://www.spbdev.com/">SpbDev.com</a>设计制作，完全免费，您可以任意复制，和传播。但请保留相关链接，谢谢合作。</td>
				</tr>
			</table>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">服务器基本信息</td>
				</tr>
				<tr> 
					<td width="38%" height="26">服务器计算机名</td>
					<td><spbdev:SpbLabel ID="ServerName" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">服务器IP地址</td>
					<td><spbdev:SpbLabel ID="ServerIP" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">服务器域名</td>
					<td><spbdev:SpbLabel ID="ServerDomain" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">服务器端口</td>
					<td><spbdev:SpbLabel ID="ServerPort" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">服务器IIS版本</td>
					<td><spbdev:SpbLabel ID="ServerIIS" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">执行文件绝对路径</td>
					<td><spbdev:SpbLabel ID="ServerFilePath" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">站点虚拟目录绝对路径</td>
					<td><spbdev:SpbLabel ID="ServerPhyAppPath" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">站点虚拟目录名称</td>
					<td><spbdev:SpbLabel ID="ServerAppPath" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">服务器操作系统</td>
					<td><spbdev:SpbLabel ID="ServerOS" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">服务器操作系统安装目录</td>
					<td><spbdev:SpbLabel ID="ServerRoot" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">服务器应用程序安装目录</td>
					<td><spbdev:SpbLabel ID="ServerProgramRoot" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">.NET Framework语言种类</td>
					<td><spbdev:SpbLabel ID="ServerDotNetLang" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">.NET Framework 版本</td>
					<td><spbdev:SpbLabel ID="ServerDotNetVer" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">服务器当前时间</td>
					<td><spbdev:SpbLabel ID="ServerNowDate" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">服务器上次启动到现在已运行</td>
					<td><spbdev:SpbLabel ID="ServerLastStartToNow" AllowHtml="false" runat="server"/></td>
				</tr>
			</table>
			<br>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">服务器相关硬件信息</td>
				</tr>
				<tr> 
					<td width="38%" height="26">物理内存总数</td>
					<td><spbdev:SpbLabel ID="ServerMemSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">可用物理内存</td>
					<td><spbdev:SpbLabel ID="ServerMemFreeSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">正使用的内存</td>
					<td><spbdev:SpbLabel ID="ServerMemUseSize" AllowHtml="false" runat="server"/> %</td>
				</tr>
				<tr> 
					<td height="26">交换文件大小</td>
					<td><spbdev:SpbLabel ID="ServerExFileSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">交换文件可用大小</td>
					<td><spbdev:SpbLabel ID="ServerExFileFreeSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">总虚拟内存</td>
					<td><spbdev:SpbLabel ID="ServerExMemSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">剩余虚拟内存</td>
					<td><spbdev:SpbLabel ID="ServerExMemFreeSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td width="38%" height="26">逻辑驱动器</td>
					<td><spbdev:SpbLabel ID="ServerLogicalDriver" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">CPU 总数</td>
					<td><form method="post" action="<%=Request.FilePath%>"><spbdev:SpbLabel ID="ServerCpuCount" AllowHtml="false" runat="server"/> 个 &nbsp;<input type="hidden" name="ServerCpuCheck" value="ShowMore"><spbdev:SpbLabel id="ServerCpuCheckIt" allowHtml="true" runat="Server"><input type="submit" value="详细" class="Button"></spbdev:SpbLabel></form></td>
				</tr>
				<asp:Repeater id="ServerCpuInfo" runat="server">
				<HeaderTemplate>
				</table>
				<br>
				<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">服务器CPU详细信息</td>
				</tr>
				</HeaderTemplate>
				<ItemTemplate>
				<tr> 
					<td width="38%" height="26">第 <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> 个 CPU 标识</td>
					<td><%#DataBinder.Eval(Container.DataItem,"ProcessorID","")%></td>
				</tr>
				<tr> 
					<td height="26">第 <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> 个 CPU 描述</td>
					<td><%#DataBinder.Eval(Container.DataItem,"Description","")%></td>
				</tr>
				<tr> 
					<td height="26">第 <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> 个 CPU 工作频率</td>
					<td><%#DataBinder.Eval(Container.DataItem,"CurrentClockSpeed","")%> MHz</td>
				</tr>
				<tr> 
					<td height="26">第 <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> 个 CPU 最高频率</td>
					<td><%#DataBinder.Eval(Container.DataItem,"MaxClockSpeed","")%> MHz</td>
				</tr>
				<tr> 
					<td height="26">第 <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> 个 CPU 二级缓存大小</td>
					<td><%#DataBinder.Eval(Container.DataItem,"L2CacheSize","")%></td>
				</tr>
				<tr> 
					<td height="26">第 <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> 个 CPU 二级缓存速度</td>
					<td><%#DataBinder.Eval(Container.DataItem,"L2CacheSpeed","")%></td>
				</tr>
				</ItemTemplate>
				</asp:Repeater>
				
			</table>
			<br>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">服务器COM组件安装检测</td>
				</tr>
				<tr> 
					<td width="38%" height="26">数据库访问组件(Adodb.Recordset)</td>
					<td><spbdev:SpbLabel ID="ServerComAdodb" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">JRO数据库压缩组件(JRO.JetEngine)</td>
					<td><spbdev:SpbLabel ID="ServerComJro" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">FSO文件操作组件(Scripting.FileSystemObject)</td>
					<td><spbdev:SpbLabel ID="ServerComFso" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">CDONTS邮件发送组件(CDONTS.NewMail)</td>
					<td><spbdev:SpbLabel ID="ServerComCdonts" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">JMail邮件组件(Jmail.Message)</td>
					<td><spbdev:SpbLabel ID="ServerComJMail" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">Persits文件上传组件(Persits.Upload.1)</td>
					<td><spbdev:SpbLabel ID="ServerComPersitsUp" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">SoftArtisans文件上传组件(SoftArtisans.FileUp)</td>
					<td><spbdev:SpbLabel ID="ServerComSAUp" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">Dundas文件上传组件(Dundas.Upload)</td>
					<td><spbdev:SpbLabel ID="ServerComDundasUp" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">其它COM组件检测</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="text" name="ComProgID" value="<%=ProgID%>" class="InputTxt">&nbsp;&nbsp;<input type="submit" value="检测" class="Button">&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerComCheckRslt" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
			</table>
			<br>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td width="100%" colspan="2" class="TrHead">服务器性能及网络速度检测</td>
				</tr>
				<tr> 
					<td width="38%" height="26">2000万次整数运算性能</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="hidden" name="IntCalCheck" value="2000"><input type="submit" value="检测" class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerIntCalCheck" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
				<tr> 
					<td height="26">2000万次浮点运算性能</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="hidden" name="DblCalCheck" value="2000"><input type="submit" value="检测" class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerDblCalCheck" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
				<tr> 
					<td height="26">网络速度检测（填写一个正确网址，让服务器去获取数据来测网络速度，<font color="#FF3333"><B>务必耐心等待</B></font>）</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="text" name="ServerNetWorkCheck" value="<%=InputEnc(CheckUrl)%>" class="InputTxt">&nbsp;<input type="submit" value="检测" class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerNetWorkCheck" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
			
			</table>
			<table border="0" width="95%">
				<tr>
					<td align="center" height="30">版权所有：<a href="http://www.spbdev.com/" target="_blank">www.SpbDev.com</a>&nbsp;&nbsp;&nbsp;执行时间：<%=ProcessTime%> 毫秒</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</body>
</html>
