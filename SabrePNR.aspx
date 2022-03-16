<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SabrePNR.aspx.cs" Inherits="SabrePNR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link rel="preconnect" href="https://fonts.gstatic.com" />
<link href="https://fonts.googleapis.com/css2?family=Dosis&display=swap" rel="stylesheet" />
<link href="https://fonts.googleapis.com/css2?family=Quicksand&display=swap" rel="stylesheet" />
<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
<link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" />
<script src="https://code.jquery.com/jquery-3.5.1.js"></script>
<script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>

<style>
	.loadingGif {
            background: rgba(255,255,255,0.6);
            z-index: 99;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;
	}

	.loadingP {
		position: relative;
		margin-right: 48%;
		margin-top: 20%;
	}
    #divPNRTable tr {
	border: 1px solid #ddd;
}
    #divPNRTable tr:hover {
        background: #c3d7f7;
        cursor: pointer;
    }
	
	h2 {
		text-align: center;
		margin-bottom: 60px !important;
	}

    #divPNRTable {
        width: 100%;
        margin-left: 20px;
        /*overflow-y: scroll;
        border: 1px solid gray;*/
        padding:15px;
    }

    #chkTablePNRS {
	overflow-y: auto;
    max-height: 300px;
    display: block;
}
#chkTablePNRS th { 
	position: sticky; 
	top: 0;
	border-bottom: 2px solid;
        background: #fff;

}
#chkTablePNRS tfoot th {
    position: sticky;
    bottom: 0;
	border: 0;
    border-top: 2px solid;
    padding: 7px;
	direction: ltr;
}

    #divDocketNo span {
        display: block;
        font-size: 21px;
        font-weight: 600;
        padding-top: 8px;
        padding-bottom: 5px;
    }

    #divDocketNo {
        margin-top:20px;
        display: block;
        padding: 8px;
        border: 1px solid;
        box-shadow: 3px 5px;
    }

     #divPNRTable th {
    width: 1%;
    }


/* Works on Chrome, Edge, and Safari */
*::-webkit-scrollbar {
  width: 12px;
}

*::-webkit-scrollbar-track {
  background: rgb(242, 242, 242);
}

*::-webkit-scrollbar-thumb {
  background-color: #1030a5;
  border-radius: 20px;
  border: 4px solid #1030a5;
}

    .clearAllSpan:hover {
        font-weight: 800;
        color:#1030a5;
    }

    .clearAllSpan:hover {
        cursor: pointer;
    }

    .divBlock {
        margin-top: 10px;
        margin-bottom: 10px;
    }

    .btnCreateDocket {
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

    .btnCreateDocket:hover {
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

    * {
        font-family: 'Quicksand', sans-serif;
        font-size: 16px;
    }

    .tool-tip {
        color: #fff;
        background-color: rgba(0, 0, 0, .7);
        text-shadow: none;
        font-size: .8em;
        visibility: hidden;
        -webkit-border-radius: 7px;
        -moz-border-radius: 7px;
        -o-border-radius: 7px;
        border-radius: 7px;
        text-align: center;
        opacity: 0;
        z-index: 999;
        padding: 3px 8px;
        position: absolute;
        cursor: default;
        -webkit-transition: all 240ms ease-in-out;
        -moz-transition: all 240ms ease-in-out;
        -ms-transition: all 240ms ease-in-out;
        -o-transition: all 240ms ease-in-out;
        transition: all 240ms ease-in-out;
    }

    .tool-tip,
    .tool-tip.top {
        top: auto;
        bottom: 114%;
        left: 50%;
    }

    .tool-tip.top:after,
    .tool-tip:after {
        position: absolute;
        bottom: -12px;
        left: 50%;
        margin-left: -7px;
        content: ' ';
        height: 0px;
        width: 0px;
        border: 6px solid transparent;
        border-top-color: rgba( 0, 0, 0, .7);
    }
/* default heights, width and margin w/o Javscript */

    .tool-tip,
    .tool-tip.top {
        width: 200px;
        height: 45px;
        margin-left: -43px;
    }
/* tool tip position left */

    .tool-tip.left {
        top: 50%;
        left: auto;
        right: 105%;
        margin-top: -15px;
        margin-left: auto;
    }

    .tool-tip.left:after {
        left: auto;
        right: -12px;
        top: 50%;
        margin-top: -6px;
        bottom: auto;
        border-top-color: transparent;
        border-left-color: rgba( 0, 0, 0, .7);
    }

/* on hover of element containing tooltip default*/

    *:not(.on-focus):hover > .tool-tip,
    .on-focus input:focus + .tool-tip {
        visibility: visible;
        opacity: 1;
        -webkit-transition: all 240ms ease-in-out;
        -moz-transition: all 240ms ease-in-out;
        -ms-transition: all 240ms ease-in-out;
        -o-transition: all 240ms ease-in-out;
        transition: all 240ms ease-in-out;
    }
/* left slideIn */

    *:not(.on-focus) > .tool-tip.slideIn.left,
    .on-focus > .tool-tip.slideIn.left {
        right: 50%;
    }

    *:not(.on-focus):hover > .tool-tip.slideIn.left,
    .on-focus > input:focus + .tool-tip.slideIn.left {
        right: 105%;
    }


    #divDocketDetails {
        border: 1px solid;
        padding-left: 35px;
        padding-right: 35px;
        box-shadow: 3px 5px;
    }

    #divPnrData {
    border: 1px solid #cecece;
    background: #f2f2f2;
    padding-bottom: 9px;
    padding-top: 5px;
}

    .headerPnrData span {
        font-weight: 500;
    }

    .bodyPnrData {
        background: #fff;
        border: 1px solid #dedede;
    }

    .bodyPnrData span {
        display: block;
    }
    .headerPnrData span {
    font-weight: 700;
}

</style>

<script>	
    var selected = 0;
    $(document).ready(function () {
        debugger;
        hideLoader();
        $('#' + '<%= txtPnrList.ClientID %>').val("");
        $('#chkTablePNRS').DataTable({
            dom: 'Bflrtip',
            "order": [0, 'desc'],
            "paging": false,          
            buttons: [],
            "oLanguage": {
                "sSearch": '<i class="fas fa-search" style="padding-right:10px"></i>',
                "sInfo": ' _END_ ',
                "sInfoFiltered": " / _MAX_ "
            }
        });
        $("#chkTablePNRS_filter").before($("#divSelected"));
        $("#chkTablePNRS_filter").before($("#divClearSelected"));
        $("#chkTablePNRS_filter").before($(".dataTables_length"));
        $("#chkTablePNRS_filter").before($("#chkTablePNRS_filter label"));
        $("#chkTablePNRS_wrapper label").attr("class", "col-md-4");
        $("#chkTablePNRS_wrapper label").attr("style", "margin-left:50px");
		$('#chkTablePNRS_wrapper').children().find('i').css('padding-left','15px');

        var pnrData = document.getElementById("divPnrData");
        var faildPnrs =  document.getElementById('<%= divFailedPnrs.ClientID %>');
        var insertedPnrs = document.getElementById('<%= divInsertedPnrs.ClientID %>');
        if (faildPnrs.innerHTML.length > 0 || insertedPnrs.innerHTML.length > 0) pnrData.classList.remove("hide");
		var heightstBlock = 0;
        $('.bodyPnrData').each(function () {
            var currentHeight = $(this).css('height').replace("px", "");
            heightstBlock = Math.max(heightstBlock, currentHeight);
        });
        $('.bodyPnrData').css('height', heightstBlock + "px");
    });
    
	function showOrHideBussinessClientDdl(elem) {
		if (elem.value == "2") {
			$('.bussiness-client').show();
		}
		else {
			$('.bussiness-client').hide();
		}
	}
    function changeCount(itemNo) {
        debugger;
        !document.getElementById('chk' + itemNo).checked ? selected > 0 ? selected-- : 0 : selected++;
        document.getElementById('spanSelectedCount').innerHTML = "<b>Selected:</b> " + selected;
    }
    function markInput(itemNo, isChkbox) {
        debugger;
        var checkedBox = document.getElementById('chk' + itemNo);
        if (!isChkbox) {
            checkedBox.checked = !checkedBox.checked;
        }
        var pnrListVal = $('#' + '<%= txtPnrList.ClientID %>').val();
        var index = pnrListVal.indexOf(checkedBox.value);
        // if (index == -1) {
        //     pnrListVal += "|" + checkedBox.value;
        // }
        // else {
        //     pnrListVal = pnrListVal.replace(checkedBox.value, "");
        // }
        
        // $('#' + '<%= txtPnrList.ClientID %>').val(pnrListVal);
        // !document.getElementById('chk' + itemNo).checked ? selected > 0 ? selected-- : 0 : selected++;
        // document.getElementById('spanSelectedCount').innerHTML = "<b>Selected:</b> " + selected;
        if (index == -1) pnrListVal += "|" + checkedBox.value;
        else pnrListVal = pnrListVal.replace(checkedBox.value, "");
        $('#' + '<%= txtPnrList.ClientID %>').val(pnrListVal);
        changeCount(itemNo);
    }

    function clearAll() {
        debugger;
        var checkBoxListLength = $('input[type="checkbox"]').length;
        for (var i = 0; i < checkBoxListLength; i++) {
            if(document.getElementById('chk' + i) != null)
                document.getElementById('chk' + i).checked = false;
        }
        selected = 0;
		document.getElementById('spanSelectedCount').innerHTML = "<b>Selected:</b> " + selected;
    }


</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
		<div class="row">
			<div class="col-lg-12">
				<h2>PNR without Docket</h2>
			</div>
		</div>
        <div class="row">
            <div class="col-md-3">
            <div id="divDocketDetails">
                <div class="divBlock" runat="server" id="divDocketId">
                    <label>Docket Id </label>
                    <div class="on-focus clearfix" style="position: relative;">
                        <asp:TextBox ID="txtOpenInDocketId" runat="server" placeholder="Docket Id"  class="form-control" autocomplete="off" onchange=""></asp:TextBox> 
                        <div class="tool-tip slideIn left">Creates all selected PNRs in the Entered Docket Number</div>
                    </div>
                </div>
                <div class="divBlock">
                    <label>Docket Type</label>
						<asp:DropDownList ID="ddlDocketType" runat="server" onchange="showOrHideBussinessClientDdl(this);" class="form-control">
							<asp:ListItem Value="1" Text="Regular"></asp:ListItem>
							<asp:ListItem Value="2" Text="Bussiness"></asp:ListItem>
							<asp:ListItem Value="3" Text="Group"></asp:ListItem>
						</asp:DropDownList> 
                </div>
                <div class="divBlocks">
                    <label>Docket Describe</label>
						<asp:DropDownList runat="server" id="ddlDocketDescribes" class="form-control">
							<asp:ListItem Value="0" Text="הכל"></asp:ListItem>
						</asp:DropDownList>		
                </div>
                <div class="divBlock">
                    <label>Bussiness Clients</label>
						<asp:DropDownList runat="server" id="ddlBussinessClients" class="form-control"></asp:DropDownList>
                </div>
                <div class="divBlock">
                    <asp:Button CssClass="btnCreateDocket" runat="server" OnClientClick="showLoader();" OnClick="btnCreateOrUpdateDocket_Click" Text="Create Docket"/>
                </div>
            </div>
            <!-- <div id="divDocketNo" class="hide">
                <span style="font-size: 18px;">Docket Updated Successfully.</span>
                <asp:Label ID="lblDocketNo" runat="server"></asp:Label>
            </div> -->
            </div>
            <div id="divSelected" class="col-md-3">
                 <span id="spanSelectedCount"><b>Selected:</b> 0</span>
            </div>
            <div id="divClearSelected" class="col-md-4">
                <span class="clearAllSpan" onclick="clearAll();">Clear Selected</span>
            </div>
            <div class="col-md-8">                
                <div id="divPNRTable">
                    <table id="chkTablePNRS" class="table table-striped table-bordered" >
                        <thead>
                            <tr>                       
                                <th id="thChkbx"></th>
                                <th style="width: 94px;">PNR</th>
                                <th style="width: 92px;">Queue</th>
                                <th style="width: 89px;">City Code</th>
                                <th style="width: 104px;">Created On</th>
                                <th style="width: 144px;">Client Name</th>
                            </tr>
                        </thead>
                        <tbody id="tableBody" runat="server">
                        </tbody>
                    </table>
                </div>
                <asp:TextBox ID="txtPnrList" runat="server" CssClass="hide"></asp:TextBox>
            </div>
            <div class="col-md-11">
                <div id="divPnrData" class="col-md-12 hide">
                    <div class="col-md-4">
                        <div class="col-md-12 headerPnrData"><span>Inserted Pnrs</span></div>
                        <div id="divInsertedPnrs" class="col-md-12 bodyPnrData" runat="server"></div>
                    </div>
                    <div class="col-md-4">
                        <div class="col-md-12 headerPnrData"><span>Failed Pnrs</span></div>
                        <div id="divFailedPnrs" class="col-lg-12 bodyPnrData" runat="server"></div>
                    </div>
                    <div class="col-md-4">
                        <div class="col-md-12 headerPnrData"><span>Replaced Tickets</span></div>
                        <div id="divReplacedTickets" class="col-lg-12 bodyPnrData" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
		<asp:TextBox ID="textBoxDebugPnr" CssClass="hide" runat="server"></asp:TextBox>
        <div class="row">
            <div class="col-lg-12" runat="server" id="divException">
            </div>
        </div>
    </div>
</asp:Content>

