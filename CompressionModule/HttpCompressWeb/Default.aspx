<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link id="Link2" rel="icon" type="image/png" href="~/favicon.png" runat="server" />
    <script type="text/javascript" src="js/ajaxroutine.js?nostrip=1" ></script>
    <script type="text/javascript" src="js/xslt.js" ></script>
    <script type="text/javascript" src="js/soapclient.js" ></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="txtTest" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="txtTest" ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:Label ID="lblTime" runat="server"></asp:Label>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>

</html>