﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EduLevelsManager.aspx.cs" Inherits="personweb.EduLevelsManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style/Dashboard.css" rel="stylesheet" />
     <table style="border: 1px groove #000099; width: 90%" class="tableborder" dir="rtl">
                
                 <tr class="tableheaderback">
                    <td   style=" height: 40px;" class="tableheaderback" >
                        <asp:Label ID="Label4" runat="server" CssClass="lblheader" Text="<%$ Resources:DashboardText,ManageEduLevel%>"></asp:Label>
                     </td>
                </tr>
               
               
                <tr>
                    
                        <td class="align" style="background-color: #EBEBEB">
                        
                        
                        
                        <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" PageSize="5" Width="90%" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="LevelID" HeaderText="کد مقطع " >
                                <ItemStyle HorizontalAlign="Center" Width="75px" />
                               </asp:BoundField>
                                <asp:BoundField DataField="LevelTitle" HeaderText="نام مقطع "  >
                                <ItemStyle HorizontalAlign="Center" Width="75px" />
                               </asp:BoundField>
                               
                                
                                <asp:TemplateField HeaderText="ویرایش">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="~/Icons/EditIcon.png" Target="_blank" NavigateUrl='<%#"EditEduLevel/" + Eval("LevelID").ToString() %>'>HyperLink</asp:HyperLink>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="حذف">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <EmptyDataTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </EmptyDataTemplate>

           <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Height="30px" CssClass="gridHeader" HorizontalAlign="Center" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="center" Height="30px"/>
            <RowStyle BackColor="#F7F6F3" Height="25px" ForeColor="#333333" />

             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C"  />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
                 <tr>
                    <td>

                        &nbsp;</td>

                </tr>
                 <tr>
                    <td>

                       <asp:Button ID="Button1" runat="server" Text="<%$ Resources:DashboardText,InsertDepartment %>" OnClick="Button1_Click" CssClass="pagebutton"/>&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="<%$ Resources:DashboardText,Delete %>" OnClick="Button2_Click"  OnClientClick="return confirm(document.getElementById('askDelete').getAttribute('value'));" CssClass="pagebutton"/>
                        <input type="hidden" id="askDelete" name="askDelete" value="<%=Resources.DashboardText.AskToDelete %>" /></td>

                </tr>
                 <tr>
                    <td>

                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="79px">
                            <asp:ListItem Value="0">کد مقطع</asp:ListItem>
                            <asp:ListItem Value="1">نام&nbsp; مقطع</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtsearch" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Icons/search.png" OnClick="ImageButton2_Click" />

                    </td>

                </tr>
               <tr>
               
                   <td>

                        <asp:Label ID="lblrecordcount" runat="server" Text=""></asp:Label>
                        
                       
                    </td>
               </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSelectedDataCount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
               
                <tr>
                       <td class="align" style="background-color: #EBEBEB">
                       <asp:Label ID="lblmessage" runat="server"></asp:Label>
                    </td>
                </tr>
               
            </table>
</asp:Content>
