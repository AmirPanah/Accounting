<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelContactsUpdate.aspx.cs" Inherits="personweb.TelContactsUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
              
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,EditTelContact%>"></asp:Label>
                     </td>
                </tr>
       <tr>
           <td style="height:40px; width: 258px;">
                <asp:Label ID="lbl" runat="server" Text="<%$ Resources:DashboardText,TelID %>" CssClass="font_custom16"></asp:Label>
                       
                          
                        <asp:Label ID="lblid" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                      
                          
                    </td>
           <td style="width: 146px">&nbsp;</td>
           <td></td>
       </tr>
                <tr>
                    <td style="height: 40px; width: 258px;">
                        
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,UserTypeID%>" CssClass="font_custom16"></asp:Label>
                       <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="114px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                           <asp:ListItem Value="0">.</asp:ListItem>
<asp:ListItem Value="1">دانشجو</asp:ListItem>
                           <asp:ListItem Value="2">استاد</asp:ListItem>
                           <asp:ListItem Value="3">کارمند</asp:ListItem>
                           <asp:ListItem></asp:ListItem>
                       </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 258px;">
                        
                       <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DashboardText,UserID%>"  CssClass="font_custom16"></asp:Label>
                    &nbsp;&nbsp;
                                              
                          <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                       
                       
                          
                        
                      
                          
                    </td>
                    <td align="right" style="height: 40px; width: 146px;">

                          
                        <asp:DropDownList ID="ddluserid" runat="server" AutoPostBack="True" Height="17px" OnSelectedIndexChanged="ddluserid_SelectedIndexChanged" Width="138px">
                        </asp:DropDownList>
                    </td>

                    <td align="right" style="height: 40px">

                          
                        &nbsp;</td>

                </tr>
               
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 258px;">
                        
                       <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,TelTypeID%>"  CssClass="font_custom16"></asp:Label>
                    
                        
                                                <asp:Label ID="lblTeltype" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>

                          
                    </td>
                    <td align="right" style="height: 40px; width: 146px;">

                          
                           <asp:DropDownList ID="ddlTeltype" runat="server" Height="21px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="ddlTeltype_SelectedIndexChanged">
                       </asp:DropDownList>
                      
                          
                    </td>

                    <td align="right" style="height: 40px">

                          
                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 258px;">
                        
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,TelNumber%>"  CssClass="font_custom16"></asp:Label>
                    
                        
                                                <asp:Label ID="lbltelnumber" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>

                          
                    </td>
                    <td align="right" style="height: 40px; width: 146px;">

                       <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" Width="141px"></asp:TextBox>
                       
                          
                    </td>

                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 258px;">
                        
                        &nbsp;</td>
                    <td align="right" style="height: 40px; width: 146px;">

                        &nbsp;</td>

                    <td align="right" style="height: 40px">

                        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click1" CssClass="pagebutton"/>

                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Icons/Left-arrow.png" />

                    </td>

                </tr>
                <tr>
                    <td style="height: 40px; width: 258px;">
                      
                          
                        &nbsp;</td>
                   
                    <td style="height: 40px; width: 146px;">
                        &nbsp;</td>
                   
                    <td style="height: 40px">
                        &nbsp;</td>
                </tr>
                               
               
                <tr>
                    <td style="height: 40px; width: 258px;">
                        <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label> </td>
                    <td style="height: 40px; width: 146px;">
                          
                        &nbsp;</td>
                    <td style="height: 40px">
                          
                      </td>
                </tr>
                               
               
            </table>
</asp:Content>
