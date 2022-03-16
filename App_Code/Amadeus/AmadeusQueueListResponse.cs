using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AmadeusQueueListResponse
/// </summary>
public class AmadeusQueueListResponse
{
	public QueueInfo queueInfo { get; set; }
	public List<PnrItem> PNRitemArr { get; set; }
	public string errorDescription { get; set; }		
	public string errorCode { get; set; }		
	
	public class QueueInfo
	{
		public int queueNumber { get; set; }
		public int numberInQueue { get; set; }
		public string officeID { get; set; }		
	}
	
	public class PnrItem
	{
		public string controlNumber { get; set; }
		public string surname { get; set; }
		public string inHouseIdentification1 { get; set; }
		public string departureDate { get; set; }
		public string marketingCompany { get; set; }
	}
}
