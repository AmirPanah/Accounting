<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="personweb.employee.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table  style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
          
                <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px; background-color: #0099CC;" class="tableheaderback" >
                        <br />
                        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="20pt" ForeColor="White" Text=" سامانه تجمیع اطلاعات پرسنل  "></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="White" Text="پر کردن تمام فیلدها الزامی است"></asp:Label>
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
                       <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,DepartmentName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 40px;" class="tdheight">
                       <asp:DropDownList ID="ddldep" runat="server" AutoPostBack="True" Height="16px" Width="100px">
                       </asp:DropDownList>
                    </td>
                    <td style="height: 40px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 41px;">
                       <asp:Label ID="Label9" runat="server" Text="<%$ Resources:DashboardText,RoleName%>"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 41px;" class="tdheight">
                       <asp:DropDownList ID="ddlrole" runat="server" AutoPostBack="True">
                       </asp:DropDownList>
                    </td>
                    <td style="height: 41px"></td>
               </tr>
             
               
                
                <tr>
                   <td style="width: 144px; height: 45px;">
                       <asp:Label ID="Label13" runat="server" Text="ایمیل"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 45px;" class="tdheight">
                       <asp:TextBox ID="txtmail" runat="server" Width="108px" TextMode="Email"></asp:TextBox>
                    </td>
                    <td style="height: 45px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 54px;">
                       <asp:Label ID="Label14" runat="server" Text="تلفن ثابت اداری"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 54px;" class="tdheight">
                       <asp:TextBox ID="txttel" runat="server" Width="108px"></asp:TextBox>
                    </td>
                    <td style="height: 54px"></td>
               </tr>
                <tr>
                   <td style="width: 144px; height: 54px;">
                       <asp:Label ID="Label16" runat="server" Text="شماره همراه"  CssClass="font_custom16"></asp:Label>
                    </td>
                   <td style="width: 224px; height: 54px;" class="tdheight">
                       <asp:TextBox ID="txtmobile" runat="server" Width="108px"></asp:TextBox>
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
                   <td colspan="2">&nbsp;</td>
               </tr>
                <tr>
                   <td style="width: 144px">
                       &nbsp;</td>
                   <td style="width: 224px" class="tdheight">
                       &nbsp;</td>
                    <td>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ثبت" BackColor="#009999" Height="27px" Width="70px" />
                
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
    </div>
    </form>
</body>
</html>
