<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SabreLds.aspx.cs" Inherits="SabreLds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Dosis&display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Quicksand&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="css/Style.css" />

    <style>
        .loadingGif{
            background: rgba(255,255,255,0.6);
            z-index: 99;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;
        }

        .loadingP{
            position: relative;
            margin-left: 48%;
            margin-top: 20%;
        }

        .row {
            margin: 0 !important;
        }

        [id$='_Main'] {
            padding-left:7%;
        }

        *:not(i) {
            font-family: 'Quicksand', sans-serif !important;
            font-size: 16px;
        }
        .divPnrInfo_Row,
        .divDocketDetails_Row {
            margin-top: 5%;
            margin-bottom: 5%;
        }

        .btn_Main {
            display: block;
            border-radius: 16px;
            padding: 6px;
            width: 70%;
            border: 3px solid #1030a5;
            color: #1030a5;
            font-weight: 700;
            background: #ffffff;
            position: relative;
            margin: 0 auto;
            margin-top: 15px;
        }

        .btn_Main:hover {
            display: block;
            border-radius: 16px;
            padding: 6px;
            width: 70%;
            border: 3px solid #1030a5;
            color: #ffffff;
            font-weight: 700;
            background: #1030a5;
            position: relative;
            margin: 0 auto;
            margin-top: 15px;
            cursor: pointer;
        }
    </style>
    
    <script>
        const txtPnrId = '<%= txtPnr.ClientID %>';
        const lblDocketId = '<%= lblDocketId.ClientID %>';

        $(document).ready(function () {
            hideLoader();
            // Show the loader each time a post back happens
            $('form').attr('onsubmit', 'showLoader();');

            // Display the block showing the created docket id if the label isn't empty.
            $('#' + lblDocketId).closest('.divPnrInfo_Row').css('display', $('#' + lblDocketId).text().length > 0 ? 'block' : 'none');
        });

        function checkPnrValue() {
            return $('#' + txtPnrId) != null && /[0-9]+/.exec($('#' + txtPnrId).val());
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div id="divForm_Main" class="col-lg-8">
            <div id="divDocketDetails_Main" class="col-lg-6">        
            <div class="divDocketDetails_Row">
                <label><%= Utils.GetTextFromFile("lbl_DocketId") %> </label>
                <div class="on-focus clearfix" style="position: relative;">
                    <asp:TextBox ID="txtOpenInDocketId" runat="server" placeholder="Docket Id"  class="form-control" autocomplete="off"></asp:TextBox> 
                    <div class="tool-tip slideIn left"><%= Utils.GetTextFromFile("mess_CrtDocket") %> </div>
                </div>
            </div>
            <div class="divDocketDetails_Row">
                <label><%= Utils.GetTextFromFile("lbl_DocketType") %> </label>
				    <asp:DropDownList ID="ddlDocketTypes" class="form-control" runat="server" onchange="showOrHideBussinessClientDdl(this);">
				    </asp:DropDownList> 
            </div>
            <div class="divDocketDetails_Row">
                <label><%= Utils.GetTextFromFile("lbl_DocketDescription") %></label>
				    <asp:DropDownList id="ddlDocketDescribes" class="form-control" runat="server">
				    </asp:DropDownList>		
            </div>
            <div class="divDocketDetails_Row">
                <label><%= Utils.GetTextFromFile("lbl_BussinessClients") %></label>
				    <asp:DropDownList runat="server" id="ddlBussinessClients" class="form-control"></asp:DropDownList>
            </div>
        </div>
            <div id="divPnrInfo_Main" class="col-lg-6">
                <div class="divPnrInfo_Row">
                    <label><%= Utils.GetTextFromFile("lbl_PnrNumber") %></label>
                    <asp:TextBox ID="txtPnr" class="form-control" placeholder="Pnr" runat="server"></asp:TextBox>
                </div>
                <div class="divPnrInfo_Row">
                    <asp:Button CssClass="btn_Main" OnClientClick="checkPnrValue();" OnClick="btnInsertPnr_Click" runat="server" />
                    <script>$('.btn_Main').val('<%= Utils.GetTextFromFile("btnMain_RtrPnr")%>');</script>
                </div>
                <div class="divPnrInfo_Row">
                    <label><%= Utils.GetTextFromFile("lbl_DocketId") %></label>
                    <label id="lblDocketId" runat="server"></label>
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>
