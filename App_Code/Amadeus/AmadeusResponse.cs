using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class AmadeusResponse<T>
{
    public T result { get; set; }
    public int id { get; set; }
    public string jsonRpc { get; set; }
}
