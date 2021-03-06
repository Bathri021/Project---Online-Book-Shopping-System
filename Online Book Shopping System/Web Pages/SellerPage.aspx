﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Web Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="SellerPage.aspx.cs" Inherits="Online_Book_Shopping_System.Web_Pages.SellerPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" type="text/css" href="../Styles/SellerPageStyle.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="sellerPageContent">
        <h2 class="formTitle">Books Of The Seller</h2>
         <div id="Panel">
            <asp:GridView ID="GridViewBook" runat="server" AutoGenerateColumns="false" DataKeyNames="BookID" AutoGenerateDeleteButton="true"
                AutoGenerateEditButton="true" ShowFooter="true" OnRowCancelingEdit="GridViewBook_RowCancelingEdit"
                OnRowDeleting="GridViewBook_RowDeleting" OnRowEditing="GridViewBook_RowEditing"
                OnRowUpdating="GridViewBook_RowUpdating" CellSpacing="2">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="lblBookID" runat="server" Text='<%#Bind("BookID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Title">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTitle" runat="server" Text='<%#Bind("Title") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTitle" runat="server" Text='<%#Bind("Title") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox runat="server" ID="txtTitle" CssClass="txtField"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAuthor" runat="server" Text='<%#Bind("Author") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAuthor" runat="server" Text='<%#Bind("Author") %>'></asp:Label>
                        </ItemTemplate>
                         <FooterTemplate>
                            <asp:TextBox runat="server" ID="txtAuthor" CssClass="txtField"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Genere">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGenere" runat="server" Text='<%#Bind("Genere") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblGenere" runat="server" Text='<%#Bind("Genere") %>'></asp:Label>
                        </ItemTemplate>
                         <FooterTemplate>
                            <asp:TextBox runat="server" ID="txtGenere" CssClass="txtField"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Price">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%#Bind("Price") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%#Bind("Price") %>'></asp:Label>
                        </ItemTemplate>
                         <FooterTemplate>
                            <asp:TextBox runat="server" ID="txtPrice" CssClass="txtField"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="No Of Pages">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNoOfPages" runat="server" Text='<%#Bind("NoOfPages") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNoOfPages" runat="server" Text='<%#Bind("NoOfPages") %>'></asp:Label>
                        </ItemTemplate>
                         <FooterTemplate>
                            <asp:TextBox runat="server" ID="txtNoOfPages" CssClass="txtField"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Quantity">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                         <FooterTemplate>
                            <asp:TextBox runat="server" ID="txtQuantity" CssClass="txtField"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate></ItemTemplate>
                        <FooterTemplate>
                            <asp:Button runat="server" ID="btnSave" Text="Insert Book" OnClick="btnSave_Click" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
              
            </asp:GridView>
        </div>
    </div>
</asp:Content>
