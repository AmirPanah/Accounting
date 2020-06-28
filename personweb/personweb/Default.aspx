<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="personweb.SystemLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
    <title>ASP.net Captcha</title>
    <style type="text/css">
        .txtInput {
            width: 90px;
            height: 15px;
            padding: 3px;
        }

        div {
            margin: 5px;
            width: 1017px;
        }

        .validator {
            color: Red;
        }
        .auto-style3 {
            width: 415px;
            height: 46px;
        }
        .auto-style4 {
            width: 213px;
            height: 46px;
        }
        .auto-style5 {
            height: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        
            <div id="armDiv" style="width: 1050px; background-color: #3399FF; height: 88px; text-align: right; margin-left:auto; margin-right:auto">
                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,company %>" CssClass="font_custom"></asp:Label>
                <br />
                <br />
            </div>
            
       
        <div style="border: 1px groove #000000; width:350px;margin-left:auto;margin-right:auto" >
        
            <%--<fieldset>--%>
                

              
                    <table style="margin-left:auto;margin-right:auto">
                        <tr>
                            <td style="background-color: #3399FF">

                                <br />
                                <br />

                                <br />

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <table>
                        <tr>
                            <td class="auto-style3" dir="rtl">

                                <asp:TextBox ID="tbxusername" runat="server"></asp:TextBox>

                            </td>
                            <td class="auto-style4" dir="rtl">
                                <asp:Label ID="Label1" runat="server" Text="نام کاربری" ></asp:Label>
                            </td>
                        </tr>

                         <tr>
                            <td class="auto-style3" dir="rtl">

                                <asp:TextBox ID="tbxpass" runat="server" TextMode="Password"></asp:TextBox>

                            </td>
                            <td class="auto-style4" dir="rtl">
                                <asp:Label ID="Label2" runat="server" Text="پسورد"></asp:Label>
                             </td>
                        </tr>
                    </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="text-align: center; border-top-style: dashed; border-top-width: 1px; border-top-color: #000000;">
                                 <asp:TextBox ID="txtCaptchaText" runat="server" 
                        Width="90px"></asp:TextBox>
                    <asp:Image ID="imgCaptcha" runat="server"
                        ImageUrl="~/GenerateCaptcha.ashx" />
                    <asp:ImageButton ID="imgbReGenerate" runat="server"
                        CausesValidation="false"
                        ImageUrl="~/Images/refresh.png" OnClick="imgbReGenerate_Click" />
                                 <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" style="text-align: center">
                                <asp:Button ID="btnSubmitCaptcha" runat="server"
                        Text="ورود" OnClick="btnSubmitCaptcha_Click" BackColor="#00CCFF" BorderColor="Black" Font-Bold="True" Font-Size="Large" Height="31px" Width="101px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:Label ID="lblStatus" runat="server" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
             
                
              
            <%--</fieldset>--%>
       
        </div>
    </form>
</body>
</html>
