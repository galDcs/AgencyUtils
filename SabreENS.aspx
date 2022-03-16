<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="SabreENS.aspx.cs" Inherits="SabreENS" Async="true" %>

<html>
    <style>
        td, th {
            padding: 4px;
            border: 1px solid #ccc;
            text-align: left;
        }
        h1 {
            font-size: 28px;
            font-weight: bold;
        }

        h2 {
            font-size: 22px;
            font-weight: bold;
        }
		.row {
			margin-top: 10px;
		}
		table {
		    width: 100%;
		}
		.loadingP {
			width: 100%;
			height: 10000px;
			position: absolute;
			background: #cccccc7a;
			z-index: 999;
		}
		
		.loadingP img {
			margin: 17% 48%;
		}
    </style>
	<link href="https://cdn.datatables.net/1.10.13/css/jquery.dataTables.min.css" rel="stylesheet"/>
	<link href="https://cdn.datatables.net/buttons/1.2.4/css/buttons.dataTables.min.css" rel="stylesheet"/>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js"></script>
	<!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.18/pdfmake.min.js"></script> -->
	<script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.js"></script>
	<!-- <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.37/vfs_fonts.js"></script> -->
	<script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
	<script src="https://cdn.datatables.net/1.10.13/js/jquery.dataTables.min.js"></script>
	<script src="https://cdn.datatables.net/buttons/1.5.2/js/dataTables.buttons.min.js"></script>
	<script src="https://cdn.datatables.net/buttons/1.5.3/js/buttons.bootstrap.js"></script>
	<script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.html5.min.js"></script>
	<!-- <script src="https://www.credit2000.co.il/creditreports/Scripts/buttons.print.js"></script> -->
	<script src="https://cdn.datatables.net/buttons/1.5.2/js/buttons.print.min.js"></script>
	<script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js"></script>
	<script src="//cdn.datatables.net/plug-ins/1.10.19/sorting/datetime-moment.js"></script>
	<script>
	   
	</script>	
	
	<form>
	<body>
		<div class="container">
			<div class="row">	
				<h1>Sabre Ens</h1>
			</div>
		</div>
	</form>
</html>

