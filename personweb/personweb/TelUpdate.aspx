﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TelUpdate.aspx.cs" Inherits="personweb.TelUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table style="border: 1px groove #000099; width:90%" class="tableborder" dir="rtl">
              
                 <tr class="tableheaderback">
                    <td colspan="3"   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label9" runat="server" Font-Size="Larger" ForeColor="White" Text="Label"></asp:Label>
                     </td>
                </tr>
       <tr>
           <td style="height:40px; width: 218px;">
                <asp:Label ID="lbl" runat="server" Text="<%$ Resources:DashboardText,TelID %>" CssClass="font_custom16"></asp:Label>
                       
                          
                        <asp:Label ID="lblid" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                      
                          
                    </td>
           <td style="height:40px; width: 163px;">
                &nbsp;</td>
           <td></td>
       </tr>
                <tr>
                    <td style="height: 40px; width: 218px;">
                        
                        <asp:Label ID="Label5" runat="server" Text="<%$ Resources:DashboardText,UserTypeID%>" CssClass="font_custom16"></asp:Label>
                        <asp:Label ID="lblusertypeid" runat="server" Text="Label"></asp:Label>
                        </td>
                    <td style="height: 40px; width: 163px;">
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 218px;">
                        
                       <asp:Label ID="Label6" runat="server" Text="<%$ Resources:DashboardText,UserID%>"  CssClass="font_custom16"></asp:Label>
                    &nbsp;&nbsp;
                                              
                          <asp:Label ID="lbluserid" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                       
                       
                          
                        
                      
                          
                    </td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                        &nbsp;</td>
                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 218px;">
                        
                       <asp:Label ID="Label8" runat="server" Text="<%$ Resources:DashboardText,TelTypeID%>"  CssClass="font_custom16"></asp:Label>
                     
                        <asp:Label ID="lblTeltype" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                        
                      
                          
                    </td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                          <asp:DropDownList ID="ddlteltype" runat="server" Height="20px" Width="110px" AutoPostBack="True" OnSelectedIndexChanged="ddlteltype_SelectedIndexChanged1">
                       </asp:DropDownList>
                        
                      
                          
                    </td>
                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 218px;">
                        
                       <asp:Label ID="Label3" runat="server" Text="<%$ Resources:DashboardText,TelNumber%>"  CssClass="font_custom16"></asp:Label>
                     
                        <asp:Label ID="lbltelnumber" runat="server" ForeColor="#FF3300" Text="Label"></asp:Label>
                        
                      
                          
                    </td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                       <asp:TextBox ID="TextBox2" runat="server" TextMode="Number" Width="141px"></asp:TextBox>
                       
                          
                    </td>
                    <td align="right" style="height: 40px">

                        &nbsp;</td>

                </tr>
                <tr>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 218px;">
                        
                        &nbsp;</td>
                    
                    
                    <td dir="rtl" align="right" style="height: 40px; width: 163px;">
                        
                        &nbsp;</td>
                    <td align="right" style="height: 40px">

                        <asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,Insert %>" OnClick="Button1_Click1" CssClass="pagebutton"/>

                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/Icons/Left-arrow.png" />

                    </td>

                </tr>
                <tr>
                    <td style="height: 40px; width: 218px;">
                      
                          
                        &nbsp;</td>
                   
                    <td style="height: 40px; width: 163px;">
                      
                          
                        &nbsp;</td>
                   
                    <td style="height: 40px">
                        &nbsp;</td>
                </tr>
                               
               
                <tr>
                    <td style="height: 40px; width: 218px;">
                        <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label> </td>
                    <td style="height: 40px; width: 163px;">
                        &nbsp;

                        </td>
                    <td style="height: 40px">
                          
                      </td>
                </tr>
                               
               
            </table>
</asp:Content>
