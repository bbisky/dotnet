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
<title>Asp.Net̽��</title>
</head>
	
<body>
<br>
<table border="0" width="100%" align="center">
	<tr>
		<td align="center" height="30" style="font-size:14px;font-weight:600;color:#FF3333">Asp.Net ��������Ϣ̽��</td>
	</tr>
</table>
<table width="760" border="1" align="center" cellspacing="0" bordercolor="#666666" bgcolor="#EEEEEE" style="border-collapse:collapse">
	<tr> 
		<td align="center">
			<table border="0" width="95%">
				<tr>
					<td align="center" height="30">��������<a href="http://www.spbdev.com/">SpbDev.com</a>�����������ȫ��ѣ����������⸴�ƣ��ʹ��������뱣��������ӣ�лл������</td>
				</tr>
			</table>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">������������Ϣ</td>
				</tr>
				<tr> 
					<td width="38%" height="26">�������������</td>
					<td><spbdev:SpbLabel ID="ServerName" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">������IP��ַ</td>
					<td><spbdev:SpbLabel ID="ServerIP" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">����������</td>
					<td><spbdev:SpbLabel ID="ServerDomain" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">�������˿�</td>
					<td><spbdev:SpbLabel ID="ServerPort" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">������IIS�汾</td>
					<td><spbdev:SpbLabel ID="ServerIIS" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">ִ���ļ�����·��</td>
					<td><spbdev:SpbLabel ID="ServerFilePath" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">վ������Ŀ¼����·��</td>
					<td><spbdev:SpbLabel ID="ServerPhyAppPath" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">վ������Ŀ¼����</td>
					<td><spbdev:SpbLabel ID="ServerAppPath" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">����������ϵͳ</td>
					<td><spbdev:SpbLabel ID="ServerOS" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">����������ϵͳ��װĿ¼</td>
					<td><spbdev:SpbLabel ID="ServerRoot" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">������Ӧ�ó���װĿ¼</td>
					<td><spbdev:SpbLabel ID="ServerProgramRoot" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">.NET Framework��������</td>
					<td><spbdev:SpbLabel ID="ServerDotNetLang" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">.NET Framework �汾</td>
					<td><spbdev:SpbLabel ID="ServerDotNetVer" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">��������ǰʱ��</td>
					<td><spbdev:SpbLabel ID="ServerNowDate" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr>
					<td height="26">�������ϴ�����������������</td>
					<td><spbdev:SpbLabel ID="ServerLastStartToNow" AllowHtml="false" runat="server"/></td>
				</tr>
			</table>
			<br>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">���������Ӳ����Ϣ</td>
				</tr>
				<tr> 
					<td width="38%" height="26">�����ڴ�����</td>
					<td><spbdev:SpbLabel ID="ServerMemSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">���������ڴ�</td>
					<td><spbdev:SpbLabel ID="ServerMemFreeSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">��ʹ�õ��ڴ�</td>
					<td><spbdev:SpbLabel ID="ServerMemUseSize" AllowHtml="false" runat="server"/> %</td>
				</tr>
				<tr> 
					<td height="26">�����ļ���С</td>
					<td><spbdev:SpbLabel ID="ServerExFileSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">�����ļ����ô�С</td>
					<td><spbdev:SpbLabel ID="ServerExFileFreeSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">�������ڴ�</td>
					<td><spbdev:SpbLabel ID="ServerExMemSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td height="26">ʣ�������ڴ�</td>
					<td><spbdev:SpbLabel ID="ServerExMemFreeSize" AllowHtml="false" runat="server"/> MB</td>
				</tr>
				<tr> 
					<td width="38%" height="26">�߼�������</td>
					<td><spbdev:SpbLabel ID="ServerLogicalDriver" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">CPU ����</td>
					<td><form method="post" action="<%=Request.FilePath%>"><spbdev:SpbLabel ID="ServerCpuCount" AllowHtml="false" runat="server"/> �� &nbsp;<input type="hidden" name="ServerCpuCheck" value="ShowMore"><spbdev:SpbLabel id="ServerCpuCheckIt" allowHtml="true" runat="Server"><input type="submit" value="��ϸ" class="Button"></spbdev:SpbLabel></form></td>
				</tr>
				<asp:Repeater id="ServerCpuInfo" runat="server">
				<HeaderTemplate>
				</table>
				<br>
				<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">������CPU��ϸ��Ϣ</td>
				</tr>
				</HeaderTemplate>
				<ItemTemplate>
				<tr> 
					<td width="38%" height="26">�� <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> �� CPU ��ʶ</td>
					<td><%#DataBinder.Eval(Container.DataItem,"ProcessorID","")%></td>
				</tr>
				<tr> 
					<td height="26">�� <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> �� CPU ����</td>
					<td><%#DataBinder.Eval(Container.DataItem,"Description","")%></td>
				</tr>
				<tr> 
					<td height="26">�� <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> �� CPU ����Ƶ��</td>
					<td><%#DataBinder.Eval(Container.DataItem,"CurrentClockSpeed","")%> MHz</td>
				</tr>
				<tr> 
					<td height="26">�� <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> �� CPU ���Ƶ��</td>
					<td><%#DataBinder.Eval(Container.DataItem,"MaxClockSpeed","")%> MHz</td>
				</tr>
				<tr> 
					<td height="26">�� <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> �� CPU ���������С</td>
					<td><%#DataBinder.Eval(Container.DataItem,"L2CacheSize","")%></td>
				</tr>
				<tr> 
					<td height="26">�� <%#DataBinder.Eval(Container.DataItem,"CpuNum","")%> �� CPU ���������ٶ�</td>
					<td><%#DataBinder.Eval(Container.DataItem,"L2CacheSpeed","")%></td>
				</tr>
				</ItemTemplate>
				</asp:Repeater>
				
			</table>
			<br>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td colspan="2" class="TrHead">������COM�����װ���</td>
				</tr>
				<tr> 
					<td width="38%" height="26">���ݿ�������(Adodb.Recordset)</td>
					<td><spbdev:SpbLabel ID="ServerComAdodb" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">JRO���ݿ�ѹ�����(JRO.JetEngine)</td>
					<td><spbdev:SpbLabel ID="ServerComJro" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">FSO�ļ��������(Scripting.FileSystemObject)</td>
					<td><spbdev:SpbLabel ID="ServerComFso" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">CDONTS�ʼ��������(CDONTS.NewMail)</td>
					<td><spbdev:SpbLabel ID="ServerComCdonts" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">JMail�ʼ����(Jmail.Message)</td>
					<td><spbdev:SpbLabel ID="ServerComJMail" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">Persits�ļ��ϴ����(Persits.Upload.1)</td>
					<td><spbdev:SpbLabel ID="ServerComPersitsUp" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">SoftArtisans�ļ��ϴ����(SoftArtisans.FileUp)</td>
					<td><spbdev:SpbLabel ID="ServerComSAUp" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">Dundas�ļ��ϴ����(Dundas.Upload)</td>
					<td><spbdev:SpbLabel ID="ServerComDundasUp" AllowHtml="false" runat="server"/></td>
				</tr>
				<tr> 
					<td height="26">����COM������</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="text" name="ComProgID" value="<%=ProgID%>" class="InputTxt">&nbsp;&nbsp;<input type="submit" value="���" class="Button">&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerComCheckRslt" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
			</table>
			<br>
			<table width="95%" align="center" border="1" bordercolor="#FFFFFF" cellspacing="0" style="border-collapse:collapse">
				<tr> 
					<td width="100%" colspan="2" class="TrHead">���������ܼ������ٶȼ��</td>
				</tr>
				<tr> 
					<td width="38%" height="26">2000���������������</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="hidden" name="IntCalCheck" value="2000"><input type="submit" value="���" class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerIntCalCheck" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
				<tr> 
					<td height="26">2000��θ�����������</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="hidden" name="DblCalCheck" value="2000"><input type="submit" value="���" class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerDblCalCheck" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
				<tr> 
					<td height="26">�����ٶȼ�⣨��дһ����ȷ��ַ���÷�����ȥ��ȡ�������������ٶȣ�<font color="#FF3333"><B>������ĵȴ�</B></font>��</td>
					<td><form method="post" action="<%=Request.FilePath%>"><input type="text" name="ServerNetWorkCheck" value="<%=InputEnc(CheckUrl)%>" class="InputTxt">&nbsp;<input type="submit" value="���" class="Button">&nbsp;&nbsp;<font color="#FF3333"><spbdev:SpbLabel ID="ServerNetWorkCheck" AllowHtml="false" Visible="false" runat="server"/></font></form></td>
				</tr>
			
			</table>
			<table border="0" width="95%">
				<tr>
					<td align="center" height="30">��Ȩ���У�<a href="http://www.spbdev.com/" target="_blank">www.SpbDev.com</a>&nbsp;&nbsp;&nbsp;ִ��ʱ�䣺<%=ProcessTime%> ����</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</body>
</html>
