<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EduTendenciesUpdate.aspx.cs" Inherits="personweb.EduTendenciesUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
              
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label9" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,EditEduTendency%>"></asp:Label>
                     </td>
                </tr>
       <tr>
           <td style="height:40px">
                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:DashboardText,TendencyID %>" CssClass="font_custom16"></asp:Label>
                         <asp:Label ID="lblTendencytid" runat="server"></asp:Label></td>
           <td></td>
       </tr>
                <tr>
                    <td style="height: 40px">
                        
                        <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,TendencyName %>" CssClass="font_custom16"></asp:Label>
                         <asp:Label ID="lbltitle" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                      
                          
                       
                       
                          
                        </td>
                </tr>
                <tr>
                    <td style="height: 40px">
                        
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,TendencyName %>" CssClass="font_custom16"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px">
                        
                       <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DashboardText,FieldName%>"  CssClass="font_custom16"></asp:Label>
                    &nbsp;&nbsp;
                       
                        <asp:DropDownList ID="ddlfield" runat="server" Height="16px" Width="100px">
                       </asp:DropDownList>
                         <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                      
                          
                       
                       
                          
                    </td>
                    <td align="right" style="height: 40px">

                        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click1" CssClass="pagebutton"/>

                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Icons/Left-arrow.png" />

                    </td>

                </tr>
                <tr>
                    <td style="height: 40px">
                      
                          
                        &nbsp;</td>
                   
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
