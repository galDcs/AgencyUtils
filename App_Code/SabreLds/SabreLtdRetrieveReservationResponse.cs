using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName = "Envelope")]
public class SabreLdsRetrieveReservationResponse
{
    [XmlElement(ElementName = "Header")]
    public string Header { get; set; }
    [XmlElement(ElementName = "Body")]
    public BodyClass Body { get; set; }

    [XmlRoot(ElementName = "opStatus")]
    public class OpStatus
    {
        [XmlElement(ElementName = "code")]
        public string Code { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
    }

    [XmlRoot(ElementName = "pax")]
    public class Pax
    {
        [XmlElement(ElementName = "birthDate")]
        public string BirthDate { get; set; }
        [XmlElement(ElementName = "firstName")]
        public string FirstName { get; set; }
        [XmlElement(ElementName = "lastName")]
        public string LastName { get; set; }
        [XmlElement(ElementName = "paxType")]
        public string PaxType { get; set; }
        [XmlElement(ElementName = "paxTitle")]
        public string PaxTitle { get; set; }
        [XmlAttribute(AttributeName = "refId")]
        public string RefId { get; set; }
    }

    [XmlRoot(ElementName = "leg")]
    public class Leg
    {
        [XmlElement(ElementName = "supplierId")]
        public string SupplierId { get; set; }
        [XmlElement(ElementName = "depCity")]
        public string DepCity { get; set; }
        [XmlElement(ElementName = "arrCity")]
        public string ArrCity { get; set; }
        [XmlElement(ElementName = "depDate")]
        public string DepDate { get; set; }
        [XmlElement(ElementName = "arrDate")]
        public string ArrDate { get; set; }
        [XmlElement(ElementName = "airlineId")]
        public string AirlineId { get; set; }
        [XmlElement(ElementName = "flightNumber")]
        public string FlightNumber { get; set; }
        [XmlElement(ElementName = "flightClass")]
        public string FlightClass { get; set; }
        [XmlElement(ElementName = "status")]
        public string Status { get; set; }
        [XmlElement(ElementName = "duration")]
        public string Duration { get; set; }
        [XmlElement(ElementName = "statusRemark")]
        public string StatusRemark { get; set; }
        [XmlElement(ElementName = "aircraftType")]
        public string AircraftType { get; set; }
        [XmlElement(ElementName = "meal")]
        public string Meal { get; set; }
        [XmlElement(ElementName = "maxHandLuggageWeight")]
        public string MaxHandLuggageWeight { get; set; }
        [XmlElement(ElementName = "maxCheckedLuggageWeight")]
        public string MaxCheckedLuggageWeight { get; set; }
        [XmlElement(ElementName = "supplierStatus")]
        public string SupplierStatus { get; set; }
        [XmlAttribute(AttributeName = "seqNum")]
        public string SeqNum { get; set; }
    }

    [XmlRoot(ElementName = "flight")]
    public class Flight
    {
        [XmlElement(ElementName = "leg")]
        public Leg Leg { get; set; }
        [XmlAttribute(AttributeName = "seqNum")]
        public string SeqNum { get; set; }
    }

    [XmlRoot(ElementName = "paxRef")]
    public class PaxRef
    {
        [XmlAttribute(AttributeName = "refId")]
        public string RefId { get; set; }
    }

    [XmlRoot(ElementName = "room")]
    public class Room
    {
        [XmlElement(ElementName = "ldsDealId")]
        public string LdsDealId { get; set; }
        [XmlElement(ElementName = "roomSet")]
        public string RoomSet { get; set; }
        [XmlElement(ElementName = "roomType")]
        public string RoomType { get; set; }
        [XmlElement(ElementName = "paxRef")]
        public List<PaxRef> PaxRef { get; set; }
        [XmlElement(ElementName = "supplierStatus")]
        public string SupplierStatus { get; set; }
        [XmlAttribute(AttributeName = "seqNum")]
        public string SeqNum { get; set; }
    }

    [XmlRoot(ElementName = "hotel")]
    public class Hotel
    {
        [XmlElement(ElementName = "hotelId")]
        public string HotelId { get; set; }
        [XmlElement(ElementName = "hotelName")]
        public string HotelName { get; set; }
        [XmlElement(ElementName = "hotelCity")]
        public string HotelCity { get; set; }
        [XmlElement(ElementName = "board")]
        public string Board { get; set; }
        [XmlElement(ElementName = "category")]
        public string Category { get; set; }
        [XmlElement(ElementName = "checkInDate")]
        public string CheckInDate { get; set; }
        [XmlElement(ElementName = "checkOutDate")]
        public string CheckOutDate { get; set; }
        [XmlElement(ElementName = "nights")]
        public string Nights { get; set; }
        [XmlElement(ElementName = "resourceUrl")]
        public string ResourceUrl { get; set; }
        [XmlElement(ElementName = "location")]
        public string Location { get; set; }
        [XmlElement(ElementName = "room")]
        public List<Room> Room { get; set; }
        [XmlAttribute(AttributeName = "seqNum")]
        public string SeqNum { get; set; }
    }

    [XmlRoot(ElementName = "reservation")]
    public class Reservation
    {
        [XmlElement(ElementName = "dealType")]
        public string DealType { get; set; }
        [XmlElement(ElementName = "sabrePNR")]
        public string SabrePNR { get; set; }
        [XmlElement(ElementName = "supplierPNR")]
        public string SupplierPNR { get; set; }
        [XmlElement(ElementName = "totalFare")]
        public string TotalFare { get; set; }
        [XmlElement(ElementName = "currency")]
        public string Currency { get; set; }
        [XmlElement(ElementName = "remarks")]
        public string Remarks { get; set; }
        [XmlElement(ElementName = "lastSupplierRetrieveTime")]
        public string LastSupplierRetrieveTime { get; set; }
        [XmlElement(ElementName = "pax")]
        public List<Pax> Pax { get; set; }
        [XmlElement(ElementName = "flight")]
        public List<Flight> Flight { get; set; }
        [XmlElement(ElementName = "hotel")]
        public Hotel Hotel { get; set; }
    }

    [XmlRoot(ElementName = "return")]
    public class Return
    {
        [XmlElement(ElementName = "opStatus")]
        public OpStatus OpStatus { get; set; }
        [XmlElement(ElementName = "reservationSupplierStatus")]
        public string ReservationSupplierStatus { get; set; }
        [XmlElement(ElementName = "reservation")]
        public Reservation Reservation { get; set; }
    }

    [XmlRoot(ElementName = "retrieveReservationResponse")]
    public class RetrieveReservationResponse
    {
        [XmlElement(ElementName = "return")]
        public Return Return { get; set; }
    }

    [XmlRoot(ElementName = "Body")]
    public class BodyClass
    {
        [XmlElement(ElementName = "retrieveReservationResponse")]
        public RetrieveReservationResponse RetrieveReservationResponse { get; set; }
    }

}



