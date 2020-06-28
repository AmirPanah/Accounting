<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLecturers.aspx.cs" Inherits="personweb.AddLecturers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
           
                <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,AddLecture%>"></asp:Label>
                     </td>
                </tr>
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,FirstName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
                       <br />
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DashboardText,LastName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox>
                       <br />
                       </td>
                    <td style="height: 40px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,Gender%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                           <asp:ListItem Value="0">زن</asp:ListItem>
                           <asp:ListItem Value="1">مرد</asp:ListItem>
                       </asp:RadioButtonList>
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label7" runat="server" Text="<%$ Resources:DashboardText,NationalCode%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:TextBox ID="txtnationalcode" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,FacultyTitle%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:DropDownList ID="ddlfacultuy" runat="server" Height="16px" Width="106px">
                       </asp:DropDownList>
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                
                <tr>
                   <td style="width: 144px; height: 40px;">
                       <asp:Label ID="Label10" runat="server" Text="<%$ Resources:DashboardText,FieldTitle%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:DropDownList ID="ddlfield" runat="server" Height="19px" Width="108px">
                       </asp:DropDownList>
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 42px;">
                       <asp:Label ID="Label11" runat="server" Text="<%$ Resources:DashboardText,TendencyTitle%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 42px;" class="tdheight">
                       <asp:DropDownList ID="ddltendency" runat="server" Height="16px" Width="111px">
                       </asp:DropDownList>
                    </td>
                    <td style="height: 42px"></td>
               </tr>
               
                   <td style="width: 144px; height: 45px;">
                       <asp:Label ID="Label13" runat="server" Text="<%$ Resources:DashboardText,Username%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 45px;" class="tdheight">
                       <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 45px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 54px;">
                       <asp:Label ID="Label14" runat="server" Text="<%$ Resources:DashboardText,Password%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 54px;" class="tdheight">
                       <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td style="height: 54px"></td>
               </tr>
          <tr>
                   <td style="width: 144px; height: 54px;">
                       <asp:Label ID="Label16" runat="server" Text="<%$ Resources:DashboardText,PassRepeat%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 54px;" class="tdheight">
                       <asp:TextBox ID="tbxConfirmPassword" runat="server" CssClass="textbox" MaxLength="20" TextMode="Password" Width="108px" Height="21px"></asp:TextBox>
                         <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="tbxConfirmPassword" ControlToValidate="txtpass" ErrorMessage="تایید رمز عبور نامعتبر می باشد !" ForeColor="Red">*</asp:CompareValidator>
                    </td>
                    <td style="height: 54px">&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 15px;">
                       <asp:Label ID="Label15" runat="server" Text= "فایل تصویر" CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 15px;" class="tdheight">
                       <asp:FileUpload ID="FileUpload1" runat="server" Height="25px" />
                    </td>
                    <td style="height: 15px">&nbsp;</td>
               </tr>
                <tr>
                   <td colspan="2"><asp:CheckBox ID="chkActiveAccount" Checked="true" TextAlign="Right" runat="server" /><asp:Label ID="Label1" runat="server" Text="<%$ Resources:DashboardText,ActiveAccount %>" ForeColor="Gray" CssClass="font_custom16"></asp:Label></td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       &nbsp;</td>
                   <td style="width: 224px" class="tdheight">
                       &nbsp;</td>
                    <td><asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click" CssClass="pagebutton"/><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/Left-arrow.png" OnClick="ImageButton1_Click1" style="height: 25px" /></td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       &nbsp;</td>
                   <td style="width: 224px" class="tdheight">
                       &nbsp;</td>
                    <td>&nbsp;</td>
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
