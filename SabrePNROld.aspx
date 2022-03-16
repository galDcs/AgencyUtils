<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SabrePNROld.aspx.cs" Inherits="SabrePNROld" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <span>Docket Id</span>
                <span>B. client</span>
                <span>Docket Describe</span>
            </div>
            <div class="col-md-6">
                <asp:CheckBoxList ID="chkListPNRS" runat="server" class="pnr_list"></asp:CheckBoxList>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12" runat="server" id="divException">

            </div>
        </div>
    </div>
</asp:Content>

