<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVPNs.aspx.cs" Inherits="personweb.AddVPNss" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="Style/Dashboard.css" rel="stylesheet" />
      <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
                <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label7" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,AddVPN%>"></asp:Label>
                     </td>
                </tr>
                <tr>
                   <td style="width: 144px">
                       <asp:Label ID="Label4" runat="server" Text="<%$ Resources:DashboardText,UserTypeID%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px" class="tdheight">
                       <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="114px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                           <asp:ListItem Value="0">.</asp:ListItem>
<asp:ListItem Value="1">دانشجو</asp:ListItem>
                           <asp:ListItem Value="2">استاد</asp:ListItem>
                           <asp:ListItem Value="3">کارمند</asp:ListItem>
                           <asp:ListItem></asp:ListItem>
                       </asp:DropDownList>
                       <br />
                    </td>
                    <td>&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,UserID%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px" class="tdheight">
                       <asp:DropDownList ID="ddluserid" runat="server" Height="21px" Width="113px">
                       </asp:DropDownList>
                       <br />
                    </td>
                    <td>&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       <asp:Label ID="Label9" runat="server" Text="<%$ Resources:DashboardText,DepartmentName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px" class="tdheight">
                       <asp:DropDownList ID="ddldepartment" runat="server" Height="21px" Width="113px">
                       </asp:DropDownList>
                       </td>
                    <td>&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 15px;">
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,Username%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 15px;" class="tdheight">
                       <asp:TextBox ID="txtusername" runat="server" Width="106px"></asp:TextBox>
                       <br />
                       </td>
                    <td style="height: 15px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 15px;">
                       <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,Password%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 15px;" class="tdheight">
                       <asp:TextBox ID="txtpass" runat="server" Width="106px" TextMode="Password"></asp:TextBox>
                       </td>
                    <td style="height: 15px">&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 15px;">
                       <asp:Label ID="Label10" runat="server" Text="<%$ Resources:DashboardText,Description%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 15px;" class="tdheight">
                       <asp:TextBox ID="txtdes" runat="server" Width="106px" TextMode="MultiLine"></asp:TextBox>
                       </td>
                    <td style="height: 15px">&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       &nbsp;</td>
                   <td style="width: 224px" class="tdheight">
                       &nbsp;</td>
                    <td><asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" CssClass="pagebutton" OnClick="Button1_Click"/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/Left-arrow.png" OnClick="ImageButton1_Click1" style="height: 25px" /></td>
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
