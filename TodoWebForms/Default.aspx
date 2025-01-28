<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoWebForms.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Todo List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Todo List</h1>
            <div>
                <asp:TextBox ID="txtNewTask" runat="server" placeholder="Nueva tarea"></asp:TextBox>
                <asp:Button ID="btnAddTask" runat="server" Text="Agregar" OnClick="btnAddTask_Click" />
            </div>
            <div>
                <asp:GridView ID="gvTasks" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="TaskDescription" HeaderText="Tarea" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Eliminar" 
                                    CommandName="DeleteTask" 
                                    CommandArgument='<%# Container.DataItemIndex %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>