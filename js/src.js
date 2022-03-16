

var gDocketId = "<%=xDocket_ID%>";;
if (gDocketId == ""){
gDocketId = document.getElementById("DocketID").value;
}
	function ShowDocketTree(){			
    parent.document.location.href = '/AGN_SRC/Dockets/Main/main_screen.asp?DocketID=' + gDocketId + '&PageFunc=common';
    return true;
}
var newNotesWindowName = 0;
function showDocketNotes() {
    newNotesWindowName = newNotesWindowName + 1;
    window.open('/AGN_SRC/dockets/main/docket_remark.asp?DocketID=<%=xDocket_ID%>&ShowInfoBar=no', newNotesWindowName, 'width=695, height=600, top=160, left=85, resizable, scrollbars, toolbar=no, menubar=no, location=no, directories=no', false);
    return true;
}
function OpenDocket() {
    var Res;
    var State = new Array('gotoDocket');
    var Arguments = new Array("Go to docket No.");
    Res = window.showModalDialog('/Library/docket_action.asp?PageFunc=gotoDocket&DocketID=<%=xDocket_ID%>', Arguments, 'dialogHeight: 200px; ' + 'dialogWidth: 400px; ' + 'edge: Raised; ' + 'center: No; ' + 'help: No; ' + 'resizable: No; ' + 'status: No;');
    if (Res.length > 0) { window.parent.document.location.href = '/AGN_SRC/Dockets/Main/main_screen.asp?DocketID=' + Res + '&PageFunc=common'; }
}
function ExitDocket() {
    window.parent.document.location.href = '/AGN_SRC/Library/IFrameNavigator/source.asp?iFramePage=0104';
}
function GotoPrices() {
    window.parent.document.location.href = '/AGN_SRC/Library/IFrameNavigator/source.asp?iFramePage=0105';
}
function ViewReport() {
    var Res;
    var State = new Array('report');
    var Arguments = new Array('report', 10);
    Res = window.showModalDialog('/Library/docket_action.asp?PageFunc=report&DocketID=<%=xDocket_ID%>', Arguments, 'dialogHeight: 200px; ' + 'dialogWidth: 1000px; ' + 'edge: Raised; ' + 'center: Yes; ' + 'help: No; ' + 'resizable: No; ' + 'status: No;'); try { if (Res != '' && Res > 0) return true; } catch (e) { alert(e.description); } return false;
}
function BackToList() {
    window.parent.document.location.href = '/AGN_SRC/Library/IFrameNavigator/source.asp?iFramePage=0103&PageFunc=load_from_cash&wasDocketID=<%=xDocket_ID%>';
}

function ExRateCalculator() {
    var newExRateCalcWindowName = 0; window.open('/AGN_SRC/Library/exrate_calculator.asp', newExRateCalcWindowName, 'width=350, height=220, top=160, left=185, resizable, scrollbars=no, toolbar=no, menubar=no, location=no, directories=no', false);
}


