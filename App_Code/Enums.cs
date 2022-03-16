
//Declare here all your enums.

public enum eReports
{
    ERROR = 0,

    AllocationReport = 1,
    OweToSupplierReport,
    canceledVouchersReport
}


public enum MessageType
{
    Error,
    Warning,
    Info
}

public enum eLanguage
{
    Hebrew = 1255,
    English = 1252,
    Russian = 1251
}


public enum eFormError
{
    none,
    fromDate,
    toDate,
    fromDocket,
    toDocket,
    fromCancelDate,
    toCancelDate
}

public enum eDealType
{
    FLIGHT = 1,
    CHARTER,
	NOFSHON
}

public enum eIdType
{
    Passport = 1
}

public enum eProductType
{
    F = 1, //FLIGHT
    A = 2
}