<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmailContactsUpdate.aspx.cs" Inherits="personweb.EmailContactsUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
               
                
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,EditEmailContact%>"></asp:Label>
                     </td>
                </tr>
       <tr>
           <td style="height:40px; width: 245px;">
                <asp:Label ID="lbl" runat="server" Text="<%$ Resources:DashboardText,EmailID %>" CssClass="font_custom16"></asp:Label>
                       
                          
                        <asp:Label ID="lblid" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                      
                          
                    </td>
           <td style="height:40px; width: 163px;">
                &nbsp;</td>
           <td></td>
       </tr>
                <tr>
                    <td style="height: 40px; width: 245px;">
                        
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,UserTypeID%>" CssClass="font_custom16"></asp:Label>
                       <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="114px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                           <asp:ListItem Value="0">.</asp:ListItem>
<asp:ListItem Value="1">دانشجو</asp:ListItem>
                           <asp:ListItem Value="2">استاد</asp:ListItem>
                           <asp:ListItem Value="3">کارمند</asp:ListItem>
                           <asp:ListItem></asp:ListItem>
                       </asp:DropDownList>
                        </td>
                    <td style="height: 40px; width: 163px;">
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 245px;">
                        
                       <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DashboardText,UserID%>"  CssClass="font_custom16"></asp:Label>
                    &nbsp;&nbsp;
                                              
                          <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                       
                       
                          
                        
                      
                          
                    </td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                        <asp:DropDownList ID="ddluserid" runat="server" Height="16px" Width="107px" AutoPostBack="True" OnSelectedIndexChanged="ddluserid_SelectedIndexChanged">
                       </asp:DropDownList>
                    </td>
                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 245px;">
                        
                       <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,EmailTypeID%>"  CssClass="font_custom16"></asp:Label>
                     
                        <asp:Label ID="lblEmailtype" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                        
                      
                          
                    </td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                          <asp:DropDownList ID="ddlemailtype" runat="server" Height="20px" Width="110px" AutoPostBack="True" OnSelectedIndexChanged="ddlemailtype_SelectedIndexChanged">
                       </asp:DropDownList>
                        
                      
                          
                    </td>
                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 245px;">
                        
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,EmailAddrress%>"  CssClass="font_custom16"></asp:Label>
                     
                        <asp:Label ID="lblEmailaddrress" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                        
                      
                          
                    </td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                       <asp:TextBox ID="TextBox2" runat="server" TextMode="Email" Width="141px"></asp:TextBox>
                       
                          
                    </td>
                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 245px;">
                        
                        &nbsp;</td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                        &nbsp;</td>
                    <td align="right" style="height: 40px">

                        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click1" CssClass="pagebutton"/>

                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Icons/Left-arrow.png" />

                    </td>

                </tr>
                <tr>
                    <td style="height: 40px; width: 245px;">
                      
                          
                        &nbsp;</td>
                   
                    <td style="height: 40px; width: 163px;">
                      
                          
                        &nbsp;</td>
                   
                    <td style="height: 40px">
                        &nbsp;</td>
                </tr>
                               
               
                <tr>
                    <td style="height: 40px; width: 245px;">
                        <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label> </td>
                    <td style="height: 40px; width: 163px;">
                        &nbsp;

                        </td>
                    <td style="height: 40px">
                          
                      </td>
                </tr>
                               
               
            </table>
</asp:Content>
