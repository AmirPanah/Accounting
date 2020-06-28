<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentsUpdate.aspx.cs" Inherits="personweb.DepatrmentsUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table style="border: 1px groove #000099; width: 90%" class="tableborder" dir="rtl">
               
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label6" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,EditDepartment%>"></asp:Label>
                     </td>
                </tr>
       <tr>
           <td style="height:40px">
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:DashboardText,DepartmentID %>" CssClass="font_custom16"></asp:Label>
                         <asp:Label ID="lblDepartmentid" runat="server"></asp:Label></td>
           <td></td>
       </tr>
                <tr>
                    <td style="height: 40px">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:DashboardText,DepartmentName %>" CssClass="font_custom16"></asp:Label>
                    <asp:Label ID="lbltitle" runat="server"></asp:Label>
                        </td>
                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px">
                        
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,DepartmentName %>" CssClass="font_custom16"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td align="right" style="height: 40px">

                        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click1" CssClass="pagebutton"/>

                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Icons/Left-arrow.png" />

                    </td>

                </tr>
                <tr>
                    <td style="height: 40px">
                      
                          
                    </td>
                   
                    <td style="height: 40px">
                        &nbsp;</td>
                </tr>
                               
               
                <tr>
                    <td style="height: 40px">
                        <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label> </td>
                    <td style="height: 40px">
                          
                      </td>
                </tr>
                               
               
            </table>
</asp:Content>
