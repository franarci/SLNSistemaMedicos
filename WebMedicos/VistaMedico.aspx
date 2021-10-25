<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaMedico.aspx.cs" Inherits="WebMedicos.VistaMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server" Width="117px"></asp:TextBox>
            <br />
            <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtApellido" runat="server" Width="117px"></asp:TextBox>
            <br />
            NroMatricula&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;<asp:TextBox ID="txtFechaNac" runat="server" Height="16px" Width="119px"></asp:TextBox>
            <br />
        Especialidad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList ID="dropEspecialidad" runat="server" Height="17px" Width="127px">
            </asp:DropDownList>
            <br />
        Id&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnGuardar" runat="server" style="margin-top: 0px" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnModificar" runat="server" style="margin-top: 0px" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" style="margin-top: 0px" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:GridView ID="gridCliente" runat="server">
            </asp:GridView>
        <div>
        </div>
    </form>
</body>
</html>
