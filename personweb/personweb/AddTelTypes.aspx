﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTelTypes.aspx.cs" Inherits="personweb.AddTelTypes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
                
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,AddTelType%>"></asp:Label>
                     </td>
                </tr>
                <tr>
                   <td style="width: 144px">
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,TelTypeName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 149px" class="tdheight">
                       <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                    <td><asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click" CssClass="pagebutton"/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/Left-arrow.png" OnClick="ImageButton1_Click1" style="height: 25px" /></td>
               </tr>
               <tr>
                   <td class="tdheight" style="width: 144px; height: 18px;"></td>
                   <td style="width: 149px; height: 18px;">
                       
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
