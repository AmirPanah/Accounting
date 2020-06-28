<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEmail.aspx.cs" Inherits="personweb.AddEmail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link href="Style/Dashboard.css" rel="stylesheet" />
      <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label9" runat="server" CssClass="lblheader" ></asp:Label>
                     </td>
                </tr>
                <tr>
                   <td style="width: 144px">
                       <asp:Label ID="Label4" runat="server" Text="<%$ Resources:DashboardText,UserTypeID%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px" class="tdheight">
                       <asp:Label ID="lblusertypeid" runat="server" Text="Label"></asp:Label>
                       <br />
                    </td>
                    <td>&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 21px;">
                       <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,UserID%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 21px;" class="tdheight">
                       <asp:Label ID="lbluserid" runat="server" Text="Label"></asp:Label>
                       <br />
                    </td>
                    <td style="height: 21px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 15px;">
                       <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DashboardText,EmailTypeID%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 15px;" class="tdheight">
                       <asp:DropDownList ID="ddlemailtype" runat="server" Height="20px" Width="110px">
                       </asp:DropDownList>
                       <br />
                       </td>
                    <td style="height: 15px"></td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,EmailAddrress%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px" class="tdheight">
                       <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" Width="141px"></asp:TextBox>
                    </td>
                    <td><asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click" CssClass="pagebutton"/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/Left-arrow.png" OnClick="ImageButton1_Click1" style="height: 25px" /></td>
               </tr>
               <tr>
                   <td class="tdheight" style="width: 144px; height: 18px;"></td>
                   <td style="width: 224px; height: 18px;">
                       
                       &nbsp;</td>
                   <td style="height: 18px">&nbsp;</td>
               </tr>
               <tr>
                   <td colspan="2" class="tdheight">
                       <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
                   </td>
               </tr>
               
           </table>
</asp:Content>
