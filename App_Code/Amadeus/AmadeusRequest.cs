using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AmadeusRequest<T>
{
    public string method { get; set; }
    public Parameters<T> @params { get; set; }
    public int id { get; set; }
    public string jsonRpc { get; set; }

    public class Parameters<T>
    {
        public string identifier { get; set; }
        public string checkSum { get; set; }
        public string token { get; set; }
        public T data { get; set; }
    }
}

// public class QueueList
// {
	// public string queueNumber { get; set; }
// }

// public class RetrievePNR
// {
	// public string pnrId { get; set; }
// }