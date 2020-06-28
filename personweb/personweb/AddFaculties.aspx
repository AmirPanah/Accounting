<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFaculties.aspx.cs" Inherits="personweb.AddFaculties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
    <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
         
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,AddFaculty%>"></asp:Label>
                     </td>
                </tr>
                <tr>
                   <td style="width: 77px">
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,FacultyName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 150px" class="tdheight">
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td><asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click" CssClass="pagebutton"/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/Left-arrow.png" OnClick="ImageButton1_Click1" /></td>
               </tr>
               <tr>
                   <td class="tdheight" style="width: 77px; height: 18px;"></td>
                   <td style="width: 150px; height: 18px;">
                       
                   </td>
                   <td style="height: 18px">&nbsp;</td>
               </tr>
               <tr>
                   <td colspan="2" class="tdheight">
                       <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               
           </table>
</asp:Content>
