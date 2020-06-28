<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonsAdminsUpdate.aspx.cs" Inherits="personweb.PersonsAdminUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
                
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,EditPersonAdmin%>"></asp:Label>
                     </td>
                </tr>
            
              
               
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label16" runat="server" Text=  "کد " CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 96px; height: 40px;" class="tdheight">
                       <asp:Label ID="lbllecid" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="height: 40px">&nbsp;</td>
               </tr>
              
               
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,FirstName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 96px; height: 40px;" class="tdheight">
                       <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                       <br />
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                
               
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label17" runat="server" Text="<%$ Resources:DashboardText,LastName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 96px; height: 40px;" class="tdheight">
                       <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 40px">&nbsp;</td>
               </tr>
                
                <tr>
                   <td style="width: 144px; height: 45px;">
                       <asp:Label ID="Label13" runat="server" Text="<%$ Resources:DashboardText,Username%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 96px; height: 45px;" class="tdheight">
                       <asp:Label ID="lblusername" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                    </td>
                    <td style="height: 45px">
                       <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                    </td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 54px;">
                       <asp:Label ID="Label14" runat="server" Text="<%$ Resources:DashboardText,Password%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 96px; height: 54px;" class="tdheight">
                       <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td style="height: 54px"></td>
               </tr>
           <tr>
                   <td style="width: 144px; height: 54px;">
                       <asp:Label ID="Label2" runat="server" Text="<%$ Resources:DashboardText,PassRepeat%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 54px;" class="tdheight">
                       <asp:TextBox ID="tbxConfirmPassword" runat="server" CssClass="textbox" MaxLength="20" TextMode="Password" Width="108px" Height="16px"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxConfirmPassword" ControlToValidate="txtpass" ErrorMessage="تایید رمز عبور نامعتبر می باشد !" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                    <td style="height: 54px">&nbsp;</td>
               </tr>
               
                <tr>
                    <td style="height: 40px">
                       <asp:CheckBox ID="chkActiveAccount" runat="server" Checked="true" TextAlign="Right" />
                    </td>
                    <td>

                        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:DashboardText,ActiveAccount %>" ForeColor="Gray" CssClass="font_custom16"></asp:Label>

                    </td>
                    <td></td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       &nbsp;</td>
                   <td style="width: 96px" class="tdheight">
                       &nbsp;</td>
                    
                    <td><asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click" CssClass="pagebutton"/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/Left-arrow.png" OnClick="ImageButton1_Click1" style="height: 25px" /></td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       &nbsp;</td>
                   <td style="width: 96px" class="tdheight">
                       &nbsp;</td>
                    <td>&nbsp;</td>
               </tr>
               <tr>
                   <td class="tdheight" style="width: 144px; height: 18px;"></td>
                   <td style="width: 96px; height: 18px;">
                       
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
