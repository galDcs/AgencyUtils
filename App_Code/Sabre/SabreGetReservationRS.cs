using System.Xml.Serialization;
using System.Collections.Generic;

public class SabreGetReservationResponse
{
    [XmlElement(ElementName = "GetReservationRS_stl19")]
    public GetReservationRS_stl19 GetReservation { get; set; }

    [XmlRoot(ElementName = "GetReservationRS_stl19")]
    public class GetReservationRS_stl19
    {
        [XmlElement(ElementName = "Reservation_stl19")]
        public Reservation_stl19 Reservation_stl19 { get; set; }
        [XmlElement(ElementName = "PriceQuote_or114")]
        public PriceQuote_or114 PriceQuote_or114 { get; set; }
        [XmlAttribute(AttributeName = "Version")]
        public string Version { get; set; }
    }

    [XmlRoot(ElementName = "FlightsRange_stl19")]
    public class FlightsRange_stl19
    {
        [XmlAttribute(AttributeName = "Start")]
        public string Start { get; set; }
        [XmlAttribute(AttributeName = "End")]
        public string End { get; set; }
    }

    [XmlRoot(ElementName = "DividedRecord_stl19")]
    public class DividedRecord_stl19
    {
        [XmlElement(ElementName = "DivideTimestamp_stl19")]
        public string DivideTimestamp_stl19 { get; set; }
        [XmlElement(ElementName = "RecordLocator_stl19")]
        public string RecordLocator_stl19 { get; set; }
        [XmlElement(ElementName = "AgentSine_stl19")]
        public string AgentSine_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "SplitToRecord_stl19")]
    public class SplitToRecord_stl19
    {
        [XmlElement(ElementName = "DivideTimestamp_stl19")]
        public string DivideTimestamp_stl19 { get; set; }
        [XmlElement(ElementName = "RecordLocator_stl19")]
        public string RecordLocator_stl19 { get; set; }
        [XmlElement(ElementName = "OriginalNumberOfPax_stl19")]
        public string OriginalNumberOfPax_stl19 { get; set; }
        [XmlElement(ElementName = "CurrentNumberOfPax_stl19")]
        public string CurrentNumberOfPax_stl19 { get; set; }
        [XmlElement(ElementName = "CurrentPassengerNames_stl19")]
        public string CurrentPassengerNames_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "DivideSplitDetails_stl19")]
    public class DivideSplitDetails_stl19
    {
        [XmlElement(ElementName = "DividedRecord_stl19")]
        public DividedRecord_stl19 DividedRecord_stl19 { get; set; }
        [XmlElement(ElementName = "SplitToRecord_stl19")]
        public SplitToRecord_stl19 SplitToRecord_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "BookingDetails_stl19")]
    public class BookingDetails_stl19
    {
        [XmlElement(ElementName = "RecordLocator_stl19")]
        public string RecordLocator_stl19 { get; set; }
        [XmlElement(ElementName = "CreationTimestamp_stl19")]
        public string CreationTimestamp_stl19 { get; set; }
        [XmlElement(ElementName = "SystemCreationTimestamp_stl19")]
        public string SystemCreationTimestamp_stl19 { get; set; }
        [XmlElement(ElementName = "CreationAgentID_stl19")]
        public string CreationAgentID_stl19 { get; set; }
        [XmlElement(ElementName = "UpdateTimestamp_stl19")]
        public string UpdateTimestamp_stl19 { get; set; }
        [XmlElement(ElementName = "PNRSequence_stl19")]
        public string PNRSequence_stl19 { get; set; }
        [XmlElement(ElementName = "FlightsRange_stl19")]
        public FlightsRange_stl19 FlightsRange_stl19 { get; set; }
        [XmlElement(ElementName = "DivideSplitDetails_stl19")]
        public DivideSplitDetails_stl19 DivideSplitDetails_stl19 { get; set; }
        [XmlElement(ElementName = "EstimatedPurgeTimestamp_stl19")]
        public string EstimatedPurgeTimestamp_stl19 { get; set; }
        [XmlElement(ElementName = "UpdateToken_stl19")]
        public string UpdateToken_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Source_stl19")]
    public class Source_stl19
    {
        [XmlAttribute(AttributeName = "BookingSource")]
        public string BookingSource { get; set; }
        [XmlAttribute(AttributeName = "AgentSine")]
        public string AgentSine { get; set; }
        [XmlAttribute(AttributeName = "PseudoCityCode")]
        public string PseudoCityCode { get; set; }
        [XmlAttribute(AttributeName = "ISOCountry")]
        public string ISOCountry { get; set; }
        [XmlAttribute(AttributeName = "AgentDutyCode")]
        public string AgentDutyCode { get; set; }
        [XmlAttribute(AttributeName = "AirlineVendorID")]
        public string AirlineVendorID { get; set; }
        [XmlAttribute(AttributeName = "HomePseudoCityCode")]
        public string HomePseudoCityCode { get; set; }
        [XmlAttribute(AttributeName = "PrimeHostID")]
        public string PrimeHostID { get; set; }
    }

    [XmlRoot(ElementName = "POS_stl19")]
    public class POS_stl19
    {
        [XmlElement(ElementName = "Source_stl19")]
        public Source_stl19 Source_stl19 { get; set; }
        [XmlAttribute(AttributeName = "AirExtras")]
        public string AirExtras { get; set; }
        [XmlAttribute(AttributeName = "InhibitCode")]
        public string InhibitCode { get; set; }
    }

    [XmlRoot(ElementName = "FrequentFlyer_stl19")]
    public class FrequentFlyer_stl19
    {
        [XmlElement(ElementName = "SupplierCode_stl19")]
        public string SupplierCode_stl19 { get; set; }
        [XmlElement(ElementName = "Number_stl19")]
        public string Number_stl19 { get; set; }
        [XmlElement(ElementName = "TierLevelNumber_stl19")]
        public string TierLevelNumber_stl19 { get; set; }
        [XmlElement(ElementName = "ShortText_stl19")]
        public string ShortText_stl19 { get; set; }
        [XmlElement(ElementName = "ReceivingCarrierCode_stl19")]
        public string ReceivingCarrierCode_stl19 { get; set; }
        [XmlElement(ElementName = "StatusCode_stl19")]
        public string StatusCode_stl19 { get; set; }
        [XmlAttribute(AttributeName = "RPH")]
        public string RPH { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "DOCSEntry_stl19")]
    public class DOCSEntry_stl19
    {
        [XmlElement(ElementName = "DocumentType_stl19")]
        public string DocumentType_stl19 { get; set; }
        [XmlElement(ElementName = "CountryOfIssue_stl19")]
        public string CountryOfIssue_stl19 { get; set; }
        [XmlElement(ElementName = "DocumentNumber_stl19")]
        public string DocumentNumber_stl19 { get; set; }
        [XmlElement(ElementName = "DocumentNationalityCountry_stl19")]
        public string DocumentNationalityCountry_stl19 { get; set; }
        [XmlElement(ElementName = "DateOfBirth_stl19")]
        public string DateOfBirth_stl19 { get; set; }
        [XmlElement(ElementName = "Gender_stl19")]
        public string Gender_stl19 { get; set; }
        [XmlElement(ElementName = "DocumentExpirationDate_stl19")]
        public string DocumentExpirationDate_stl19 { get; set; }
        [XmlElement(ElementName = "Surname_stl19")]
        public string Surname_stl19 { get; set; }
        [XmlElement(ElementName = "Forename_stl19")]
        public string Forename_stl19 { get; set; }
        [XmlElement(ElementName = "MiddleName_stl19")]
        public string MiddleName_stl19 { get; set; }
        [XmlElement(ElementName = "PrimaryHolder_stl19")]
        public string PrimaryHolder_stl19 { get; set; }
        [XmlElement(ElementName = "FreeText_stl19")]
        public string FreeText_stl19 { get; set; }
        [XmlElement(ElementName = "ActionCode_stl19")]
        public string ActionCode_stl19 { get; set; }
        [XmlElement(ElementName = "NumberInParty_stl19")]
        public string NumberInParty_stl19 { get; set; }
        [XmlElement(ElementName = "VendorCode_stl19")]
        public string VendorCode_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "APISRequest_stl19")]
    public class APISRequest_stl19
    {
        [XmlElement(ElementName = "DOCSEntry_stl19")]
        public DOCSEntry_stl19 DOCSEntry_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "TicketingRequest_stl19")]
    public class TicketingRequest_stl19
    {
        [XmlElement(ElementName = "TicketType_stl19")]
        public string TicketType_stl19 { get; set; }
        [XmlElement(ElementName = "ValidatingCarrier_stl19")]
        public string ValidatingCarrier_stl19 { get; set; }
        [XmlElement(ElementName = "ActionCode_stl19")]
        public string ActionCode_stl19 { get; set; }
        [XmlElement(ElementName = "NumberInParty_stl19")]
        public string NumberInParty_stl19 { get; set; }
        [XmlElement(ElementName = "BoardPoint_stl19")]
        public string BoardPoint_stl19 { get; set; }
        [XmlElement(ElementName = "OffPoint_stl19")]
        public string OffPoint_stl19 { get; set; }
        [XmlElement(ElementName = "ClassOfService_stl19")]
        public string ClassOfService_stl19 { get; set; }
        [XmlElement(ElementName = "DateOfTravel_stl19")]
        public string DateOfTravel_stl19 { get; set; }
        [XmlElement(ElementName = "TicketNumber_stl19")]
        public string TicketNumber_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "SpecialRequests_stl19")]
    public class SpecialRequests_stl19
    {
        [XmlElement(ElementName = "APISRequest_stl19")]
        public List<APISRequest_stl19> APISRequest_stl19 { get; set; }
        [XmlElement(ElementName = "TicketingRequest_stl19")]
        public List<TicketingRequest_stl19> TicketingRequest_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "PreReservedSeat_stl19")]
    public class PreReservedSeat_stl19
    {
        [XmlElement(ElementName = "SeatNumber_stl19")]
        public string SeatNumber_stl19 { get; set; }
        [XmlElement(ElementName = "SmokingPrefOfferedIndicator_stl19")]
        public string SmokingPrefOfferedIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "SeatTypeCode_stl19")]
        public string SeatTypeCode_stl19 { get; set; }
        [XmlElement(ElementName = "SeatStatusCode_stl19")]
        public string SeatStatusCode_stl19 { get; set; }
        [XmlElement(ElementName = "BoardPoint_stl19")]
        public string BoardPoint_stl19 { get; set; }
        [XmlElement(ElementName = "OffPoint_stl19")]
        public string OffPoint_stl19 { get; set; }
        [XmlElement(ElementName = "Changed_stl19")]
        public string Changed_stl19 { get; set; }
        [XmlElement(ElementName = "NameNumber_stl19")]
        public string NameNumber_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "PreReservedSeats_stl19")]
    public class PreReservedSeats_stl19
    {
        [XmlElement(ElementName = "PreReservedSeat_stl19")]
        public List<PreReservedSeat_stl19> PreReservedSeat_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Seats_stl19")]
    public class Seats_stl19
    {
        [XmlElement(ElementName = "PreReservedSeats_stl19")]
        public PreReservedSeats_stl19 PreReservedSeats_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "AccountingLine_stl19")]
    public class AccountingLine_stl19
    {
        [XmlElement(ElementName = "FareApplication_stl19")]
        public string FareApplication_stl19 { get; set; }
        [XmlElement(ElementName = "FormOfPaymentCode_stl19")]
        public string FormOfPaymentCode_stl19 { get; set; }
        [XmlElement(ElementName = "AirlineDesignator_stl19")]
        public string AirlineDesignator_stl19 { get; set; }
        [XmlElement(ElementName = "DocumentNumber_stl19")]
        public string DocumentNumber_stl19 { get; set; }
        [XmlElement(ElementName = "CommissionAmount_stl19")]
        public string CommissionAmount_stl19 { get; set; }
        [XmlElement(ElementName = "BaseFare_stl19")]
        public string BaseFare_stl19 { get; set; }
        [XmlElement(ElementName = "TaxAmount_stl19")]
        public string TaxAmount_stl19 { get; set; }
        [XmlElement(ElementName = "PassengerName_stl19")]
        public string PassengerName_stl19 { get; set; }
        [XmlElement(ElementName = "NumberOfConjunctedDocuments_stl19")]
        public string NumberOfConjunctedDocuments_stl19 { get; set; }
        [XmlElement(ElementName = "TarriffBasis_stl19")]
        public string TarriffBasis_stl19 { get; set; }
        [XmlElement(ElementName = "CurrencyCode_stl19")]
        public string CurrencyCode_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
        [XmlElement(ElementName = "NumberOfCoupons_stl19")]
        public string NumberOfCoupons_stl19 { get; set; }
        [XmlElement(ElementName = "OriginalTicketNumber_stl19")]
        public string OriginalTicketNumber_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "AccountingLines_stl19")]
    public class AccountingLines_stl19
    {
        [XmlElement(ElementName = "AccountingLine_stl19")]
        public List<AccountingLine_stl19> AccountingLine_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "EquivalentPrice_stl19")]
    public class EquivalentPrice_stl19
    {
        [XmlElement(ElementName = "Price_stl19")]
        public string Price_stl19 { get; set; }
        [XmlElement(ElementName = "Currency_stl19")]
        public string Currency_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "TTLPrice_stl19")]
    public class TTLPrice_stl19
    {
        [XmlElement(ElementName = "Price_stl19")]
        public string Price_stl19 { get; set; }
        [XmlElement(ElementName = "Currency_stl19")]
        public string Currency_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "OriginalBasePrice_stl19")]
    public class OriginalBasePrice_stl19
    {
        [XmlElement(ElementName = "Price_stl19")]
        public string Price_stl19 { get; set; }
        [XmlElement(ElementName = "Currency_stl19")]
        public string Currency_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "TotalOriginalBasePrice_stl19")]
    public class TotalOriginalBasePrice_stl19
    {
        [XmlElement(ElementName = "Price_stl19")]
        public string Price_stl19 { get; set; }
        [XmlElement(ElementName = "Currency_stl19")]
        public string Currency_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "TotalEquivalentPrice_stl19")]
    public class TotalEquivalentPrice_stl19
    {
        [XmlElement(ElementName = "Price_stl19")]
        public string Price_stl19 { get; set; }
        [XmlElement(ElementName = "Currency_stl19")]
        public string Currency_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "TotalTTLPrice_stl19")]
    public class TotalTTLPrice_stl19
    {
        [XmlElement(ElementName = "Price_stl19")]
        public string Price_stl19 { get; set; }
        [XmlElement(ElementName = "Currency_stl19")]
        public string Currency_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Segment_stl19")]
    public class Segment_stl19
    {
        [XmlElement(ElementName = "AirlineCode_stl19")]
        public string AirlineCode_stl19 { get; set; }
        [XmlElement(ElementName = "FlightNumber_stl19")]
        public string FlightNumber_stl19 { get; set; }
        [XmlElement(ElementName = "ClassOfService_stl19")]
        public string ClassOfService_stl19 { get; set; }
        [XmlElement(ElementName = "DepartureDate_stl19")]
        public string DepartureDate_stl19 { get; set; }
        [XmlElement(ElementName = "BoardPoint_stl19")]
        public string BoardPoint_stl19 { get; set; }
        [XmlElement(ElementName = "OffPoint_stl19")]
        public string OffPoint_stl19 { get; set; }
        [XmlElement(ElementName = "MarketingCarrier_stl19")]
        public string MarketingCarrier_stl19 { get; set; }
        [XmlElement(ElementName = "OperatingCarrier_stl19")]
        public string OperatingCarrier_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
        [XmlElement(ElementName = "ETicketNumber_stl19")]
        public string ETicketNumber_stl19 { get; set; }
        [XmlElement(ElementName = "ETicketCoupon_stl19")]
        public string ETicketCoupon_stl19 { get; set; }
        [XmlElement(ElementName = "EMDNumber_stl19")]
        public string EMDNumber_stl19 { get; set; }
        [XmlElement(ElementName = "EMDCoupon_stl19")]
        public string EMDCoupon_stl19 { get; set; }
        [XmlElement(ElementName = "Air_stl19")]
        public Air_stl19 Air_stl19 { get; set; }
        [XmlElement(ElementName = "Product_stl19")]
        public Product_stl19 Product_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "AncillaryService_stl19")]
    public class AncillaryService_stl19
    {
        [XmlElement(ElementName = "CommercialName_stl19")]
        public string CommercialName_stl19 { get; set; }
        [XmlElement(ElementName = "RficCode_stl19")]
        public string RficCode_stl19 { get; set; }
        [XmlElement(ElementName = "RficSubcode_stl19")]
        public string RficSubcode_stl19 { get; set; }
        [XmlElement(ElementName = "SSRCode_stl19")]
        public string SSRCode_stl19 { get; set; }
        [XmlElement(ElementName = "OwningCarrierCode_stl19")]
        public string OwningCarrierCode_stl19 { get; set; }
        [XmlElement(ElementName = "BookingIndicator_stl19")]
        public string BookingIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "Vendor_stl19")]
        public string Vendor_stl19 { get; set; }
        [XmlElement(ElementName = "EMDType_stl19")]
        public string EMDType_stl19 { get; set; }
        [XmlElement(ElementName = "EquivalentPrice_stl19")]
        public EquivalentPrice_stl19 EquivalentPrice_stl19 { get; set; }
        [XmlElement(ElementName = "TTLPrice_stl19")]
        public TTLPrice_stl19 TTLPrice_stl19 { get; set; }
        [XmlElement(ElementName = "OriginalBasePrice_stl19")]
        public OriginalBasePrice_stl19 OriginalBasePrice_stl19 { get; set; }
        [XmlElement(ElementName = "RefundIndicator_stl19")]
        public string RefundIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "CommisionIndicator_stl19")]
        public string CommisionIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "InterlineIndicator_stl19")]
        public string InterlineIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "FeeApplicationIndicator_stl19")]
        public string FeeApplicationIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "PassengerTypeCode_stl19")]
        public string PassengerTypeCode_stl19 { get; set; }
        [XmlElement(ElementName = "BoardPoint_stl19")]
        public string BoardPoint_stl19 { get; set; }
        [XmlElement(ElementName = "OffPoint_stl19")]
        public string OffPoint_stl19 { get; set; }
        [XmlElement(ElementName = "TotalOriginalBasePrice_stl19")]
        public TotalOriginalBasePrice_stl19 TotalOriginalBasePrice_stl19 { get; set; }
        [XmlElement(ElementName = "TotalEquivalentPrice_stl19")]
        public TotalEquivalentPrice_stl19 TotalEquivalentPrice_stl19 { get; set; }
        [XmlElement(ElementName = "TotalTTLPrice_stl19")]
        public TotalTTLPrice_stl19 TotalTTLPrice_stl19 { get; set; }
        [XmlElement(ElementName = "FareCalculationModeIndicator_stl19")]
        public string FareCalculationModeIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "FareCalculationPriceIndicator_stl19")]
        public string FareCalculationPriceIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "StatusIndicator_stl19")]
        public string StatusIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "NumberOfItems_stl19")]
        public string NumberOfItems_stl19 { get; set; }
        [XmlElement(ElementName = "ActionCode_stl19")]
        public string ActionCode_stl19 { get; set; }
        [XmlElement(ElementName = "SegmentIndicator_stl19")]
        public string SegmentIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "RefundFormIndicator_stl19")]
        public string RefundFormIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "BookingSource_stl19")]
        public string BookingSource_stl19 { get; set; }
        [XmlElement(ElementName = "TicketingIndicator_stl19")]
        public string TicketingIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "PdcSeat_stl19")]
        public string PdcSeat_stl19 { get; set; }
        [XmlElement(ElementName = "FirstTravelDate_stl19")]
        public string FirstTravelDate_stl19 { get; set; }
        [XmlElement(ElementName = "LastTravelDate_stl19")]
        public string LastTravelDate_stl19 { get; set; }
        [XmlElement(ElementName = "GroupCode_stl19")]
        public string GroupCode_stl19 { get; set; }
        [XmlElement(ElementName = "TicketUsedForEMDPricing_stl19")]
        public string TicketUsedForEMDPricing_stl19 { get; set; }
        [XmlElement(ElementName = "EMDConsummedAtIssuance_stl19")]
        public string EMDConsummedAtIssuance_stl19 { get; set; }
        [XmlElement(ElementName = "PaperDocRequired_stl19")]
        public string PaperDocRequired_stl19 { get; set; }
        [XmlElement(ElementName = "TaxExemption_stl19")]
        public string TaxExemption_stl19 { get; set; }
        [XmlElement(ElementName = "ACSCount_stl19")]
        public string ACSCount_stl19 { get; set; }
        [XmlElement(ElementName = "Segment_stl19")]
        public Segment_stl19 Segment_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "sequenceNumber")]
        public string SequenceNumber { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
        [XmlElement(ElementName = "TTYConfirmationTimestamp_stl19")]
        public string TTYConfirmationTimestamp_stl19 { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
    }

    [XmlRoot(ElementName = "AncillaryServices_stl19")]
    public class AncillaryServices_stl19
    {
        [XmlElement(ElementName = "AncillaryService_stl19")]
        public List<AncillaryService_stl19> AncillaryService_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "ETicketNumber_stl19")]
    public class ETicketNumber_stl19
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TicketDetails_stl19")]
    public class TicketDetails_stl19
    {
        [XmlElement(ElementName = "OriginalTicketDetails_stl19")]
        public string OriginalTicketDetails_stl19 { get; set; }
        [XmlElement(ElementName = "TransactionIndicator_stl19")]
        public string TransactionIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "TicketNumber_stl19")]
        public string TicketNumber_stl19 { get; set; }
        [XmlElement(ElementName = "PassengerName_stl19")]
        public string PassengerName_stl19 { get; set; }
        [XmlElement(ElementName = "AgencyLocation_stl19")]
        public string AgencyLocation_stl19 { get; set; }
        [XmlElement(ElementName = "DutyCode_stl19")]
        public string DutyCode_stl19 { get; set; }
        [XmlElement(ElementName = "AgentSine_stl19")]
        public string AgentSine_stl19 { get; set; }
        [XmlElement(ElementName = "Timestamp_stl19")]
        public string Timestamp_stl19 { get; set; }
        [XmlElement(ElementName = "PaymentType_stl19")]
        public string PaymentType_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
    }

    [XmlRoot(ElementName = "TicketingInfo_stl19")]
    public class TicketingInfo_stl19
    {
        [XmlElement(ElementName = "ETicketNumber_stl19")]
        public List<ETicketNumber_stl19> ETicketNumber_stl19 { get; set; }
        [XmlElement(ElementName = "TicketDetails_stl19")]
        public List<TicketDetails_stl19> TicketDetails_stl19 { get; set; }
        [XmlElement(ElementName = "AlreadyTicketed_stl19")]
        public AlreadyTicketed_stl19 AlreadyTicketed_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Passenger_stl19")]
    public class Passenger_stl19
    {
        [XmlElement(ElementName = "LastName_stl19")]
        public string LastName_stl19 { get; set; }
        [XmlElement(ElementName = "FirstName_stl19")]
        public string FirstName_stl19 { get; set; }
        [XmlElement(ElementName = "EmailAddress_stl19")]
        public EmailAddress_stl19 EmailAddress_stl19 { get; set; }
        [XmlElement(ElementName = "FrequentFlyer_stl19")]
        public FrequentFlyer_stl19 FrequentFlyer_stl19 { get; set; }
        [XmlElement(ElementName = "SpecialRequests_stl19")]
        public SpecialRequests_stl19 SpecialRequests_stl19 { get; set; }
        [XmlElement(ElementName = "Seats_stl19")]
        public Seats_stl19 Seats_stl19 { get; set; }
        [XmlElement(ElementName = "AccountingLines_stl19")]
        public AccountingLines_stl19 AccountingLines_stl19 { get; set; }
        [XmlElement(ElementName = "AncillaryServices_stl19")]
        public AncillaryServices_stl19 AncillaryServices_stl19 { get; set; }
        [XmlElement(ElementName = "Remarks_stl19")]
        public string Remarks_stl19 { get; set; }
        [XmlElement(ElementName = "PhoneNumbers_stl19")]
        public string PhoneNumbers_stl19 { get; set; }
        [XmlElement(ElementName = "TicketingInfo_stl19")]
        public TicketingInfo_stl19 TicketingInfo_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "nameType")]
        public string NameType { get; set; }
        [XmlAttribute(AttributeName = "passengerType")]
        public string PassengerType { get; set; }
        [XmlAttribute(AttributeName = "referenceNumber")]
        public string ReferenceNumber { get; set; }
        [XmlAttribute(AttributeName = "nameId")]
        public string NameId { get; set; }
        [XmlAttribute(AttributeName = "nameAssocId")]
        public string NameAssocId { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
    }

    [XmlRoot(ElementName = "Passengers_stl19")]
    public class Passengers_stl19
    {
        [XmlElement(ElementName = "Passenger_stl19")]
        public List<Passenger_stl19> Passenger_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Poc_stl19")]
    public class Poc_stl19
    {
        [XmlElement(ElementName = "Airport_stl19")]
        public string Airport_stl19 { get; set; }
        [XmlElement(ElementName = "Departure_stl19")]
        public string Departure_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "MarriageGrp_stl19")]
    public class MarriageGrp_stl19
    {
        [XmlElement(ElementName = "Ind_stl19")]
        public string Ind_stl19 { get; set; }
        [XmlElement(ElementName = "Group_stl19")]
        public string Group_stl19 { get; set; }
        [XmlElement(ElementName = "Sequence_stl19")]
        public string Sequence_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "GenericSpecialRequest_stl19")]
    public class GenericSpecialRequest_stl19
    {
        [XmlElement(ElementName = "Code_stl19")]
        public string Code_stl19 { get; set; }
        [XmlElement(ElementName = "FreeText_stl19")]
        public string FreeText_stl19 { get; set; }
        [XmlElement(ElementName = "ActionCode_stl19")]
        public string ActionCode_stl19 { get; set; }
        [XmlElement(ElementName = "NumberInParty_stl19")]
        public string NumberInParty_stl19 { get; set; }
        [XmlElement(ElementName = "AirlineCode_stl19")]
        public string AirlineCode_stl19 { get; set; }
        [XmlElement(ElementName = "TicketNumber_stl19")]
        public string TicketNumber_stl19 { get; set; }
        [XmlElement(ElementName = "FullText_stl19")]
        public string FullText_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "msgType")]
        public string MsgType { get; set; }
    }

    [XmlRoot(ElementName = "SegmentSpecialRequests_stl19")]
    public class SegmentSpecialRequests_stl19
    {
        [XmlElement(ElementName = "GenericSpecialRequest_stl19")]
        public List<GenericSpecialRequest_stl19> GenericSpecialRequest_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Cabin_stl19")]
    public class Cabin_stl19
    {
        [XmlAttribute(AttributeName = "Code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "SabreCode")]
        public string SabreCode { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "ShortName")]
        public string ShortName { get; set; }
        [XmlAttribute(AttributeName = "Lang")]
        public string Lang { get; set; }
    }

    [XmlRoot(ElementName = "Air_stl19")]
    public class Air_stl19
    {
        [XmlElement(ElementName = "DepartureAirport_stl19")]
        public string DepartureAirport_stl19 { get; set; }
        [XmlElement(ElementName = "DepartureAirportCodeContext_stl19")]
        public string DepartureAirportCodeContext_stl19 { get; set; }
        [XmlElement(ElementName = "ArrivalAirport_stl19")]
        public string ArrivalAirport_stl19 { get; set; }
        [XmlElement(ElementName = "ArrivalAirportCodeContext_stl19")]
        public string ArrivalAirportCodeContext_stl19 { get; set; }
        [XmlElement(ElementName = "OperatingAirlineCode_stl19")]
        public string OperatingAirlineCode_stl19 { get; set; }
        [XmlElement(ElementName = "OperatingAirlineShortName_stl19")]
        public string OperatingAirlineShortName_stl19 { get; set; }
        [XmlElement(ElementName = "OperatingFlightNumber_stl19")]
        public string OperatingFlightNumber_stl19 { get; set; }
        [XmlElement(ElementName = "EquipmentType_stl19")]
        public string EquipmentType_stl19 { get; set; }
        [XmlElement(ElementName = "MarketingAirlineCode_stl19")]
        public string MarketingAirlineCode_stl19 { get; set; }
        [XmlElement(ElementName = "MarketingFlightNumber_stl19")]
        public string MarketingFlightNumber_stl19 { get; set; }
        [XmlElement(ElementName = "OperatingClassOfService_stl19")]
        public string OperatingClassOfService_stl19 { get; set; }
        [XmlElement(ElementName = "MarketingClassOfService_stl19")]
        public string MarketingClassOfService_stl19 { get; set; }
        [XmlElement(ElementName = "MarriageGrp_stl19")]
        public MarriageGrp_stl19 MarriageGrp_stl19 { get; set; }
        [XmlElement(ElementName = "Seats_stl19")]
        public Seats_stl19 Seats_stl19 { get; set; }
        [XmlElement(ElementName = "AirlineRefId_stl19")]
        public string AirlineRefId_stl19 { get; set; }
        [XmlElement(ElementName = "Eticket_stl19")]
        public string Eticket_stl19 { get; set; }
        [XmlElement(ElementName = "DepartureDateTime_stl19")]
        public string DepartureDateTime_stl19 { get; set; }
        [XmlElement(ElementName = "ArrivalDateTime_stl19")]
        public string ArrivalDateTime_stl19 { get; set; }
        [XmlElement(ElementName = "FlightNumber_stl19")]
        public string FlightNumber_stl19 { get; set; }
        [XmlElement(ElementName = "ClassOfService_stl19")]
        public string ClassOfService_stl19 { get; set; }
        [XmlElement(ElementName = "ActionCode_stl19")]
        public string ActionCode_stl19 { get; set; }
        [XmlElement(ElementName = "NumberInParty_stl19")]
        public string NumberInParty_stl19 { get; set; }
        [XmlElement(ElementName = "SegmentSpecialRequests_stl19")]
        public SegmentSpecialRequests_stl19 SegmentSpecialRequests_stl19 { get; set; }
        [XmlElement(ElementName = "inboundConnection_stl19")]
        public string InboundConnection_stl19 { get; set; }
        [XmlElement(ElementName = "outboundConnection_stl19")]
        public string OutboundConnection_stl19 { get; set; }
        [XmlElement(ElementName = "AncillaryServices_stl19")]
        public AncillaryServices_stl19 AncillaryServices_stl19 { get; set; }
        [XmlElement(ElementName = "ScheduleChangeIndicator_stl19")]
        public string ScheduleChangeIndicator_stl19 { get; set; }
        [XmlElement(ElementName = "SegmentBookedDate_stl19")]
        public string SegmentBookedDate_stl19 { get; set; }
        [XmlElement(ElementName = "Cabin_stl19")]
        public Cabin_stl19 Cabin_stl19 { get; set; }
        [XmlElement(ElementName = "Banner_stl19")]
        public string Banner_stl19 { get; set; }
        [XmlElement(ElementName = "Informational_stl19")]
        public string Informational_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
        [XmlAttribute(AttributeName = "segmentAssociationId")]
        public string SegmentAssociationId { get; set; }
        [XmlAttribute(AttributeName = "isPast")]
        public string IsPast { get; set; }
        [XmlAttribute(AttributeName = "DayOfWeekInd")]
        public string DayOfWeekInd { get; set; }
        [XmlAttribute(AttributeName = "CodeShare")]
        public string CodeShare { get; set; }
        [XmlAttribute(AttributeName = "SpecialMeal")]
        public string SpecialMeal { get; set; }
        [XmlAttribute(AttributeName = "SmokingAllowed")]
        public string SmokingAllowed { get; set; }
        [XmlAttribute(AttributeName = "ResBookDesigCode")]
        public string ResBookDesigCode { get; set; }
    }

    [XmlRoot(ElementName = "ProductName_or114")]
    public class ProductName_or114
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Cabin_or114")]
    public class Cabin_or114
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "sabreCode")]
        public string SabreCode { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "shortName")]
        public string ShortName { get; set; }
        [XmlAttribute(AttributeName = "lang")]
        public string Lang { get; set; }
    }

    [XmlRoot(ElementName = "Air_or114")]
    public class Air_or114
    {
        [XmlElement(ElementName = "DepartureAirport_or114")]
        public string DepartureAirport_or114 { get; set; }
        [XmlElement(ElementName = "ArrivalAirport_or114")]
        public string ArrivalAirport_or114 { get; set; }
        [XmlElement(ElementName = "EquipmentType_or114")]
        public string EquipmentType_or114 { get; set; }
        [XmlElement(ElementName = "MarketingAirlineCode_or114")]
        public string MarketingAirlineCode_or114 { get; set; }
        [XmlElement(ElementName = "MarketingFlightNumber_or114")]
        public string MarketingFlightNumber_or114 { get; set; }
        [XmlElement(ElementName = "MarketingClassOfService_or114")]
        public string MarketingClassOfService_or114 { get; set; }
        [XmlElement(ElementName = "Cabin_or114")]
        public Cabin_or114 Cabin_or114 { get; set; }
        [XmlElement(ElementName = "AirlineRefId_or114")]
        public string AirlineRefId_or114 { get; set; }
        [XmlElement(ElementName = "Eticket_or114")]
        public string Eticket_or114 { get; set; }
        [XmlElement(ElementName = "DepartureDateTime_or114")]
        public string DepartureDateTime_or114 { get; set; }
        [XmlElement(ElementName = "ArrivalDateTime_or114")]
        public string ArrivalDateTime_or114 { get; set; }
        [XmlElement(ElementName = "FlightNumber_or114")]
        public string FlightNumber_or114 { get; set; }
        [XmlElement(ElementName = "ClassOfService_or114")]
        public string ClassOfService_or114 { get; set; }
        [XmlElement(ElementName = "ActionCode_or114")]
        public string ActionCode_or114 { get; set; }
        [XmlElement(ElementName = "NumberInParty_or114")]
        public string NumberInParty_or114 { get; set; }
        [XmlElement(ElementName = "inboundConnection_or114")]
        public string InboundConnection_or114 { get; set; }
        [XmlElement(ElementName = "outboundConnection_or114")]
        public string OutboundConnection_or114 { get; set; }
        [XmlElement(ElementName = "ScheduleChangeIndicator_or114")]
        public string ScheduleChangeIndicator_or114 { get; set; }
        [XmlElement(ElementName = "SegmentBookedDate_or114")]
        public string SegmentBookedDate_or114 { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
        [XmlAttribute(AttributeName = "segmentAssociationId")]
        public string SegmentAssociationId { get; set; }
    }

    [XmlRoot(ElementName = "ProductDetails_or114")]
    public class ProductDetails_or114
    {
        [XmlElement(ElementName = "ProductName_or114")]
        public ProductName_or114 ProductName_or114 { get; set; }
        [XmlElement(ElementName = "Air_or114")]
        public Air_or114 Air_or114 { get; set; }
        [XmlAttribute(AttributeName = "productCategory")]
        public string ProductCategory { get; set; }
    }

    [XmlRoot(ElementName = "Product_stl19")]
    public class Product_stl19
    {
        [XmlElement(ElementName = "ProductDetails_or114")]
        public ProductDetails_or114 ProductDetails_or114 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Segments_stl19")]
    public class Segments_stl19
    {
        [XmlElement(ElementName = "Poc_stl19")]
        public Poc_stl19 Poc_stl19 { get; set; }
        [XmlElement(ElementName = "Segment_stl19")]
        public List<Segment_stl19> Segment_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "AlreadyTicketed_stl19")]
    public class AlreadyTicketed_stl19
    {
        [XmlElement(ElementName = "Code_stl19")]
        public string Code_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
    }

    [XmlRoot(ElementName = "PassengerReservation_stl19")]
    public class PassengerReservation_stl19
    {
        [XmlElement(ElementName = "Passengers_stl19")]
        public Passengers_stl19 Passengers_stl19 { get; set; }
        [XmlElement(ElementName = "Segments_stl19")]
        public Segments_stl19 Segments_stl19 { get; set; }
        [XmlElement(ElementName = "TicketingInfo_stl19")]
        public TicketingInfo_stl19 TicketingInfo_stl19 { get; set; }
        [XmlElement(ElementName = "ItineraryPricing_stl19")]
        public string ItineraryPricing_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "ReceivedFrom_stl19")]
    public class ReceivedFrom_stl19
    {
        [XmlElement(ElementName = "Name_stl19")]
        public string Name_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "AddressLine_stl19")]
    public class AddressLine_stl19
    {
        [XmlElement(ElementName = "Text_stl19")]
        public string Text_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "AddressLines_stl19")]
    public class AddressLines_stl19
    {
        [XmlElement(ElementName = "AddressLine_stl19")]
        public List<AddressLine_stl19> AddressLine_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Address_stl19")]
    public class Address_stl19
    {
        [XmlElement(ElementName = "AddressLines_stl19")]
        public AddressLines_stl19 AddressLines_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Addresses_stl19")]
    public class Addresses_stl19
    {
        [XmlElement(ElementName = "Address_stl19")]
        public Address_stl19 Address_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "PhoneNumber_stl19")]
    public class PhoneNumber_stl19
    {
        [XmlElement(ElementName = "CityCode_stl19")]
        public string CityCode_stl19 { get; set; }
        [XmlElement(ElementName = "Number_stl19")]
        public string Number_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
    }

    [XmlRoot(ElementName = "PhoneNumbers_stl19")]
    public class PhoneNumbers_stl19
    {
        [XmlElement(ElementName = "PhoneNumber_stl19")]
        public List<PhoneNumber_stl19> PhoneNumber_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "RemarkLine_stl19")]
    public class RemarkLine_stl19
    {
        [XmlElement(ElementName = "Text_stl19")]
        public string Text_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "RemarkLines_stl19")]
    public class RemarkLines_stl19
    {
        [XmlElement(ElementName = "RemarkLine_stl19")]
        public RemarkLine_stl19 RemarkLine_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Remark_stl19")]
    public class Remark_stl19
    {
        [XmlElement(ElementName = "RemarkLines_stl19")]
        public RemarkLines_stl19 RemarkLines_stl19 { get; set; }
        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
    }

    [XmlRoot(ElementName = "Remarks_stl19")]
    public class Remarks_stl19
    {
        [XmlElement(ElementName = "Remark_stl19")]
        public List<Remark_stl19> Remark_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "EmailAddress_stl19")]
    public class EmailAddress_stl19
    {
        [XmlElement(ElementName = "Address_stl19")]
        public string Address_stl19 { get; set; }
        [XmlElement(ElementName = "Comment_stl19")]
        public string Comment_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "EmailAddresses_stl19")]
    public class EmailAddresses_stl19
    {
        [XmlElement(ElementName = "EmailAddress_stl19")]
        public EmailAddress_stl19 EmailAddress_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "GenericSpecialRequests_stl19")]
    public class GenericSpecialRequests_stl19
    {
        [XmlElement(ElementName = "Code_stl19")]
        public string Code_stl19 { get; set; }
        [XmlElement(ElementName = "FreeText_stl19")]
        public string FreeText_stl19 { get; set; }
        [XmlElement(ElementName = "AirlineCode_stl19")]
        public string AirlineCode_stl19 { get; set; }
        [XmlElement(ElementName = "FullText_stl19")]
        public string FullText_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "msgType")]
        public string MsgType { get; set; }
        [XmlElement(ElementName = "ActionCode_stl19")]
        public string ActionCode_stl19 { get; set; }
        [XmlElement(ElementName = "NumberInParty_stl19")]
        public string NumberInParty_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Profile_stl19")]
    public class Profile_stl19
    {
        [XmlElement(ElementName = "ProfileID_stl19")]
        public string ProfileID_stl19 { get; set; }
        [XmlElement(ElementName = "ProfileType_stl19")]
        public string ProfileType_stl19 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Profiles_stl19")]
    public class Profiles_stl19
    {
        [XmlElement(ElementName = "Profile_stl19")]
        public List<Profile_stl19> Profile_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "Parent_stl19")]
    public class Parent_stl19
    {
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
    }

    [XmlRoot(ElementName = "AssociationRule_stl19")]
    public class AssociationRule_stl19
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "Child_stl19")]
    public class Child_stl19
    {
        [XmlElement(ElementName = "AssociationRule_stl19")]
        public AssociationRule_stl19 AssociationRule_stl19 { get; set; }
        [XmlAttribute(AttributeName = "ref")]
        public string Ref { get; set; }
    }

    [XmlRoot(ElementName = "AssociationMatrix_stl19")]
    public class AssociationMatrix_stl19
    {
        [XmlElement(ElementName = "Name_stl19")]
        public string Name_stl19 { get; set; }
        [XmlElement(ElementName = "Parent_stl19")]
        public Parent_stl19 Parent_stl19 { get; set; }
        [XmlElement(ElementName = "Child_stl19")]
        public List<Child_stl19> Child_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "AssociationMatrices_stl19")]
    public class AssociationMatrices_stl19
    {
        [XmlElement(ElementName = "AssociationMatrix_stl19")]
        public AssociationMatrix_stl19 AssociationMatrix_stl19 { get; set; }
    }

    [XmlRoot(ElementName = "NameAssociationTag_or114")]
    public class NameAssociationTag_or114
    {
        [XmlElement(ElementName = "LastName_or114")]
        public string LastName_or114 { get; set; }
        [XmlElement(ElementName = "FirstName_or114")]
        public string FirstName_or114 { get; set; }
        [XmlElement(ElementName = "ReferenceId_or114")]
        public string ReferenceId_or114 { get; set; }
    }

    [XmlRoot(ElementName = "NameAssociationList_or114")]
    public class NameAssociationList_or114
    {
        [XmlElement(ElementName = "NameAssociationTag_or114")]
        public NameAssociationTag_or114 NameAssociationTag_or114 { get; set; }
    }

    [XmlRoot(ElementName = "SegmentAssociationList_or114")]
    public class SegmentAssociationList_or114
    {
        [XmlElement(ElementName = "SegmentAssociationId_or114")]
        public string SegmentAssociationId_or114 { get; set; }
    }

    [XmlRoot(ElementName = "EquivalentPrice_or114")]
    public class EquivalentPrice_or114
    {
        [XmlElement(ElementName = "Price_or114")]
        public string Price_or114 { get; set; }
        [XmlElement(ElementName = "Currency_or114")]
        public string Currency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "TTLPrice_or114")]
    public class TTLPrice_or114
    {
        [XmlElement(ElementName = "Price_or114")]
        public string Price_or114 { get; set; }
        [XmlElement(ElementName = "Currency_or114")]
        public string Currency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "OriginalBasePrice_or114")]
    public class OriginalBasePrice_or114
    {
        [XmlElement(ElementName = "Price_or114")]
        public string Price_or114 { get; set; }
        [XmlElement(ElementName = "Currency_or114")]
        public string Currency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "TotalOriginalBasePrice_or114")]
    public class TotalOriginalBasePrice_or114
    {
        [XmlElement(ElementName = "Price_or114")]
        public string Price_or114 { get; set; }
        [XmlElement(ElementName = "Currency_or114")]
        public string Currency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "TotalEquivalentPrice_or114")]
    public class TotalEquivalentPrice_or114
    {
        [XmlElement(ElementName = "Price_or114")]
        public string Price_or114 { get; set; }
        [XmlElement(ElementName = "Currency_or114")]
        public string Currency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "TotalTTLPrice_or114")]
    public class TotalTTLPrice_or114
    {
        [XmlElement(ElementName = "Price_or114")]
        public string Price_or114 { get; set; }
        [XmlElement(ElementName = "Currency_or114")]
        public string Currency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "Segment_or114")]
    public class Segment_or114
    {
        [XmlElement(ElementName = "AirlineCode_or114")]
        public string AirlineCode_or114 { get; set; }
        [XmlElement(ElementName = "FlightNumber_or114")]
        public string FlightNumber_or114 { get; set; }
        [XmlElement(ElementName = "OperatingFlightNumber_or114")]
        public string OperatingFlightNumber_or114 { get; set; }
        [XmlElement(ElementName = "ClassOfService_or114")]
        public string ClassOfService_or114 { get; set; }
        [XmlElement(ElementName = "DepartureDate_or114")]
        public string DepartureDate_or114 { get; set; }
        [XmlElement(ElementName = "BoardPoint_or114")]
        public string BoardPoint_or114 { get; set; }
        [XmlElement(ElementName = "OffPoint_or114")]
        public string OffPoint_or114 { get; set; }
        [XmlElement(ElementName = "MarketingCarrier_or114")]
        public string MarketingCarrier_or114 { get; set; }
        [XmlElement(ElementName = "OperatingCarrier_or114")]
        public string OperatingCarrier_or114 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "sequence")]
        public string Sequence { get; set; }
        [XmlElement(ElementName = "EMDNumber_or114")]
        public string EMDNumber_or114 { get; set; }
        [XmlElement(ElementName = "EMDCoupon_or114")]
        public string EMDCoupon_or114 { get; set; }
    }

    [XmlRoot(ElementName = "AncillaryServiceData_or114")]
    public class AncillaryServiceData_or114
    {
        [XmlElement(ElementName = "NameAssociationList_or114")]
        public NameAssociationList_or114 NameAssociationList_or114 { get; set; }
        [XmlElement(ElementName = "SegmentAssociationList_or114")]
        public SegmentAssociationList_or114 SegmentAssociationList_or114 { get; set; }
        [XmlElement(ElementName = "CommercialName_or114")]
        public string CommercialName_or114 { get; set; }
        [XmlElement(ElementName = "RficCode_or114")]
        public string RficCode_or114 { get; set; }
        [XmlElement(ElementName = "RficSubcode_or114")]
        public string RficSubcode_or114 { get; set; }
        [XmlElement(ElementName = "SSRCode_or114")]
        public string SSRCode_or114 { get; set; }
        [XmlElement(ElementName = "OwningCarrierCode_or114")]
        public string OwningCarrierCode_or114 { get; set; }
        [XmlElement(ElementName = "Vendor_or114")]
        public string Vendor_or114 { get; set; }
        [XmlElement(ElementName = "EMDType_or114")]
        public string EMDType_or114 { get; set; }
        [XmlElement(ElementName = "SegmentNumber_or114")]
        public string SegmentNumber_or114 { get; set; }
        [XmlElement(ElementName = "EquivalentPrice_or114")]
        public EquivalentPrice_or114 EquivalentPrice_or114 { get; set; }
        [XmlElement(ElementName = "TTLPrice_or114")]
        public TTLPrice_or114 TTLPrice_or114 { get; set; }
        [XmlElement(ElementName = "PortionOfTravelIndicator_or114")]
        public string PortionOfTravelIndicator_or114 { get; set; }
        [XmlElement(ElementName = "OriginalBasePrice_or114")]
        public OriginalBasePrice_or114 OriginalBasePrice_or114 { get; set; }
        [XmlElement(ElementName = "RefundIndicator_or114")]
        public string RefundIndicator_or114 { get; set; }
        [XmlElement(ElementName = "CommisionIndicator_or114")]
        public string CommisionIndicator_or114 { get; set; }
        [XmlElement(ElementName = "InterlineIndicator_or114")]
        public string InterlineIndicator_or114 { get; set; }
        [XmlElement(ElementName = "FeeApplicationIndicator_or114")]
        public string FeeApplicationIndicator_or114 { get; set; }
        [XmlElement(ElementName = "PassengerTypeCode_or114")]
        public string PassengerTypeCode_or114 { get; set; }
        [XmlElement(ElementName = "BoardPoint_or114")]
        public string BoardPoint_or114 { get; set; }
        [XmlElement(ElementName = "OffPoint_or114")]
        public string OffPoint_or114 { get; set; }
        [XmlElement(ElementName = "TotalOriginalBasePrice_or114")]
        public TotalOriginalBasePrice_or114 TotalOriginalBasePrice_or114 { get; set; }
        [XmlElement(ElementName = "TotalEquivalentPrice_or114")]
        public TotalEquivalentPrice_or114 TotalEquivalentPrice_or114 { get; set; }
        [XmlElement(ElementName = "TotalTTLPrice_or114")]
        public TotalTTLPrice_or114 TotalTTLPrice_or114 { get; set; }
        [XmlElement(ElementName = "FareCalculationModeIndicator_or114")]
        public string FareCalculationModeIndicator_or114 { get; set; }
        [XmlElement(ElementName = "FareCalculationPriceIndicator_or114")]
        public string FareCalculationPriceIndicator_or114 { get; set; }
        [XmlElement(ElementName = "NumberOfItems_or114")]
        public string NumberOfItems_or114 { get; set; }
        [XmlElement(ElementName = "ActionCode_or114")]
        public string ActionCode_or114 { get; set; }
        [XmlElement(ElementName = "SegmentIndicator_or114")]
        public string SegmentIndicator_or114 { get; set; }
        [XmlElement(ElementName = "RefundFormIndicator_or114")]
        public string RefundFormIndicator_or114 { get; set; }
        [XmlElement(ElementName = "BookingSource_or114")]
        public string BookingSource_or114 { get; set; }
        [XmlElement(ElementName = "TicketingIndicator_or114")]
        public string TicketingIndicator_or114 { get; set; }
        [XmlElement(ElementName = "PdcSeat_or114")]
        public string PdcSeat_or114 { get; set; }
        [XmlElement(ElementName = "FirstTravelDate_or114")]
        public string FirstTravelDate_or114 { get; set; }
        [XmlElement(ElementName = "LastTravelDate_or114")]
        public string LastTravelDate_or114 { get; set; }
        [XmlElement(ElementName = "GroupCode_or114")]
        public string GroupCode_or114 { get; set; }
        [XmlElement(ElementName = "TicketUsedForEMDPricing_or114")]
        public string TicketUsedForEMDPricing_or114 { get; set; }
        [XmlElement(ElementName = "PaperDocRequired_or114")]
        public string PaperDocRequired_or114 { get; set; }
        [XmlElement(ElementName = "EMDConsummedAtIssuance_or114")]
        public string EMDConsummedAtIssuance_or114 { get; set; }
        [XmlElement(ElementName = "TaxExemption_or114")]
        public string TaxExemption_or114 { get; set; }
        [XmlElement(ElementName = "ACSCount_or114")]
        public string ACSCount_or114 { get; set; }
        [XmlElement(ElementName = "Segment_or114")]
        public Segment_or114 Segment_or114 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlElement(ElementName = "EMDNumber_or114")]
        public string EMDNumber_or114 { get; set; }
        [XmlElement(ElementName = "EMDCoupon_or114")]
        public string EMDCoupon_or114 { get; set; }
        [XmlElement(ElementName = "ETicketNumber_or114")]
        public ETicketNumber_or114 ETicketNumber_or114 { get; set; }
        [XmlElement(ElementName = "TTYConfirmationTimestamp_or114")]
        public string TTYConfirmationTimestamp_or114 { get; set; }
    }

    [XmlRoot(ElementName = "XmlData_or114")]
    public class XmlData_or114
    {
        [XmlElement(ElementName = "AncillaryServiceData_or114")]
        public AncillaryServiceData_or114 AncillaryServiceData_or114 { get; set; }
    }

    [XmlRoot(ElementName = "AncillaryProduct_or114")]
    public class AncillaryProduct_or114
    {
        [XmlElement(ElementName = "XmlData_or114")]
        public XmlData_or114 XmlData_or114 { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "OpenReservationElement_or114")]
    public class OpenReservationElement_or114
    {
        [XmlElement(ElementName = "AncillaryProduct_or114")]
        public AncillaryProduct_or114 AncillaryProduct_or114 { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "elementId")]
        public string ElementId { get; set; }
        [XmlElement(ElementName = "ServiceRequest_or114")]
        public ServiceRequest_or114 ServiceRequest_or114 { get; set; }
        [XmlElement(ElementName = "Profile_or114")]
        public Profile_or114 Profile_or114 { get; set; }
        [XmlElement(ElementName = "Loyalty_or114")]
        public Loyalty_or114 Loyalty_or114 { get; set; }
        [XmlElement(ElementName = "NameAssociation_or114")]
        public NameAssociation_or114 NameAssociation_or114 { get; set; }
        [XmlElement(ElementName = "SegmentAssociation_or114")]
        public SegmentAssociation_or114 SegmentAssociation_or114 { get; set; }
        [XmlElement(ElementName = "Email_or114")]
        public Email_or114 Email_or114 { get; set; }
    }

    [XmlRoot(ElementName = "ETicketNumber_or114")]
    public class ETicketNumber_or114
    {
        [XmlElement(ElementName = "ETicketNumber_or114")]
        public string ETicketNumber_or114X { get; set; }
        [XmlElement(ElementName = "ETicketCoupon_or114")]
        public string ETicketCoupon_or114 { get; set; }
    }

    [XmlRoot(ElementName = "ServiceRequest_or114")]
    public class ServiceRequest_or114
    {
        [XmlElement(ElementName = "FreeText_or114")]
        public string FreeText_or114 { get; set; }
        [XmlElement(ElementName = "FullText_or114")]
        public string FullText_or114 { get; set; }
        [XmlAttribute(AttributeName = "airlineCode")]
        public string AirlineCode { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "serviceType")]
        public string ServiceType { get; set; }
        [XmlAttribute(AttributeName = "ssrType")]
        public string SsrType { get; set; }
        [XmlElement(ElementName = "Comment_or114")]
        public string Comment_or114 { get; set; }
        [XmlAttribute(AttributeName = "actionCode")]
        public string ActionCode { get; set; }
        [XmlAttribute(AttributeName = "serviceCount")]
        public string ServiceCount { get; set; }
        [XmlElement(ElementName = "TravelDocument_or114")]
        public TravelDocument_or114 TravelDocument_or114 { get; set; }
    }

    [XmlRoot(ElementName = "Profile_or114")]
    public class Profile_or114
    {
        [XmlElement(ElementName = "ID_or114")]
        public string ID_or114 { get; set; }
        [XmlElement(ElementName = "Type_or114")]
        public string Type_or114 { get; set; }
        [XmlElement(ElementName = "ShortType_or114")]
        public string ShortType_or114 { get; set; }
        [XmlElement(ElementName = "OwningAgency_or114")]
        public string OwningAgency_or114 { get; set; }
    }

    [XmlRoot(ElementName = "FrequentFlyer_or114")]
    public class FrequentFlyer_or114
    {
        [XmlElement(ElementName = "ActionCode_or114")]
        public string ActionCode_or114 { get; set; }
        [XmlElement(ElementName = "PreviousActionCode_or114")]
        public string PreviousActionCode_or114 { get; set; }
        [XmlElement(ElementName = "Vendor_or114")]
        public string Vendor_or114 { get; set; }
        [XmlElement(ElementName = "ReceivingCarrierCode_or114")]
        public string ReceivingCarrierCode_or114 { get; set; }
        [XmlElement(ElementName = "VitType_or114")]
        public string VitType_or114 { get; set; }
        [XmlElement(ElementName = "FrequentFlyerNumber_or114")]
        public string FrequentFlyerNumber_or114 { get; set; }
        [XmlElement(ElementName = "Text_or114")]
        public string Text_or114 { get; set; }
    }

    [XmlRoot(ElementName = "Loyalty_or114")]
    public class Loyalty_or114
    {
        [XmlElement(ElementName = "FrequentFlyer_or114")]
        public FrequentFlyer_or114 FrequentFlyer_or114 { get; set; }
    }

    [XmlRoot(ElementName = "NameAssociation_or114")]
    public class NameAssociation_or114
    {
        [XmlElement(ElementName = "LastName_or114")]
        public string LastName_or114 { get; set; }
        [XmlElement(ElementName = "FirstName_or114")]
        public string FirstName_or114 { get; set; }
        [XmlElement(ElementName = "ReferenceId_or114")]
        public string ReferenceId_or114 { get; set; }
        [XmlElement(ElementName = "Id_or114")]
        public string Id_or114 { get; set; }
        [XmlElement(ElementName = "NameRefNumber_or114")]
        public string NameRefNumber_or114 { get; set; }
    }

    [XmlRoot(ElementName = "AirSegment_or114")]
    public class AirSegment_or114
    {
        [XmlElement(ElementName = "CarrierCode_or114")]
        public string CarrierCode_or114 { get; set; }
        [XmlElement(ElementName = "FlightNumber_or114")]
        public string FlightNumber_or114 { get; set; }
        [XmlElement(ElementName = "DepartureDate_or114")]
        public string DepartureDate_or114 { get; set; }
        [XmlElement(ElementName = "BoardPoint_or114")]
        public string BoardPoint_or114 { get; set; }
        [XmlElement(ElementName = "OffPoint_or114")]
        public string OffPoint_or114 { get; set; }
        [XmlElement(ElementName = "ClassOfService_or114")]
        public string ClassOfService_or114 { get; set; }
    }

    [XmlRoot(ElementName = "SegmentAssociation_or114")]
    public class SegmentAssociation_or114
    {
        [XmlElement(ElementName = "AirSegment_or114")]
        public AirSegment_or114 AirSegment_or114 { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "SegmentAssociationId")]
        public string SegmentAssociationId { get; set; }
    }

    [XmlRoot(ElementName = "TravelDocument_or114")]
    public class TravelDocument_or114
    {
        [XmlElement(ElementName = "Type_or114")]
        public string Type_or114 { get; set; }
        [XmlElement(ElementName = "DocumentIssueCountry_or114")]
        public string DocumentIssueCountry_or114 { get; set; }
        [XmlElement(ElementName = "DocumentNumber_or114")]
        public string DocumentNumber_or114 { get; set; }
        [XmlElement(ElementName = "DocumentNationalityCountry_or114")]
        public string DocumentNationalityCountry_or114 { get; set; }
        [XmlElement(ElementName = "DocumentExpirationDate_or114")]
        public string DocumentExpirationDate_or114 { get; set; }
        [XmlElement(ElementName = "DateOfBirth_or114")]
        public string DateOfBirth_or114 { get; set; }
        [XmlElement(ElementName = "Gender_or114")]
        public string Gender_or114 { get; set; }
        [XmlElement(ElementName = "LastName_or114")]
        public string LastName_or114 { get; set; }
        [XmlElement(ElementName = "FirstName_or114")]
        public string FirstName_or114 { get; set; }
        [XmlElement(ElementName = "Infant_or114")]
        public string Infant_or114 { get; set; }
        [XmlElement(ElementName = "PrimaryDocHolderInd_or114")]
        public string PrimaryDocHolderInd_or114 { get; set; }
        [XmlElement(ElementName = "HasDocumentData_or114")]
        public string HasDocumentData_or114 { get; set; }
    }

    [XmlRoot(ElementName = "Email_or114")]
    public class Email_or114
    {
        [XmlElement(ElementName = "Address_or114")]
        public string Address_or114 { get; set; }
        [XmlAttribute(AttributeName = "comment")]
        public string Comment { get; set; }
    }

    [XmlRoot(ElementName = "OpenReservationElements_stl19")]
    public class OpenReservationElements_stl19
    {
        [XmlElement(ElementName = "OpenReservationElement_or114")]
        public List<OpenReservationElement_or114> OpenReservationElement_or114 { get; set; }
    }

    [XmlRoot(ElementName = "Reservation_stl19")]
    public class Reservation_stl19
    {
        [XmlElement(ElementName = "BookingDetails_stl19")]
        public BookingDetails_stl19 BookingDetails_stl19 { get; set; }
        [XmlElement(ElementName = "POS_stl19")]
        public POS_stl19 POS_stl19 { get; set; }
        [XmlElement(ElementName = "PassengerReservation_stl19")]
        public PassengerReservation_stl19 PassengerReservation_stl19 { get; set; }
        [XmlElement(ElementName = "ReceivedFrom_stl19")]
        public ReceivedFrom_stl19 ReceivedFrom_stl19 { get; set; }
        [XmlElement(ElementName = "Addresses_stl19")]
        public Addresses_stl19 Addresses_stl19 { get; set; }
        [XmlElement(ElementName = "PhoneNumbers_stl19")]
        public PhoneNumbers_stl19 PhoneNumbers_stl19 { get; set; }
        [XmlElement(ElementName = "Remarks_stl19")]
        public Remarks_stl19 Remarks_stl19 { get; set; }
        [XmlElement(ElementName = "EmailAddresses_stl19")]
        public EmailAddresses_stl19 EmailAddresses_stl19 { get; set; }
        [XmlElement(ElementName = "AccountingLines_stl19")]
        public AccountingLines_stl19 AccountingLines_stl19 { get; set; }
        [XmlElement(ElementName = "GenericSpecialRequests_stl19")]
        public List<GenericSpecialRequests_stl19> GenericSpecialRequests_stl19 { get; set; }
        [XmlElement(ElementName = "Profiles_stl19")]
        public Profiles_stl19 Profiles_stl19 { get; set; }
        [XmlElement(ElementName = "AssociationMatrices_stl19")]
        public AssociationMatrices_stl19 AssociationMatrices_stl19 { get; set; }
        [XmlElement(ElementName = "OpenReservationElements_stl19")]
        public OpenReservationElements_stl19 OpenReservationElements_stl19 { get; set; }
        [XmlAttribute(AttributeName = "numberInParty")]
        public string NumberInParty { get; set; }
        [XmlAttribute(AttributeName = "numberOfInfants")]
        public string NumberOfInfants { get; set; }
        [XmlAttribute(AttributeName = "NumberInSegment")]
        public string NumberInSegment { get; set; }
    }

    [XmlRoot(ElementName = "Reservation")]
    public class Reservation
    {
        [XmlAttribute(AttributeName = "updateToken")]
        public string UpdateToken { get; set; }
    }

    [XmlRoot(ElementName = "Indicators")]
    public class Indicators
    {
        [XmlAttribute(AttributeName = "isExpired")]
        public string IsExpired { get; set; }
        [XmlAttribute(AttributeName = "itineraryChange")]
        public string ItineraryChange { get; set; }
        [XmlAttribute(AttributeName = "segmentSelect")]
        public string SegmentSelect { get; set; }
        [XmlAttribute(AttributeName = "ticketed")]
        public string Ticketed { get; set; }
        [XmlAttribute(AttributeName = "reissue")]
        public string Reissue { get; set; }
    }

    [XmlRoot(ElementName = "Passenger")]
    public class Passenger
    {
        [XmlAttribute(AttributeName = "passengerTypeCount")]
        public string PassengerTypeCount { get; set; }
        [XmlAttribute(AttributeName = "requestedType")]
        public string RequestedType { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "Total")]
    public class Total
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
        [XmlElement(ElementName = "BaseFare")]
        public BaseFare BaseFare { get; set; }
        [XmlElement(ElementName = "EquivalentFare")]
        public EquivalentFare EquivalentFare { get; set; }
        [XmlElement(ElementName = "TotalTax")]
        public TotalTax TotalTax { get; set; }
        [XmlElement(ElementName = "TotalFare")]
        public TotalFare TotalFare { get; set; }
    }

    [XmlRoot(ElementName = "Amounts")]
    public class Amounts
    {
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlElement(ElementName = "ReissueDifference")]
        public ReissueDifference ReissueDifference { get; set; }
    }

    [XmlRoot(ElementName = "PriceQuote")]
    public class PriceQuote
    {
        [XmlElement(ElementName = "Indicators")]
        public Indicators Indicators { get; set; }
        [XmlElement(ElementName = "Passenger")]
        public Passenger Passenger { get; set; }
        [XmlElement(ElementName = "ItineraryType")]
        public string ItineraryType { get; set; }
        [XmlElement(ElementName = "ValidatingCarrier")]
        public string ValidatingCarrier { get; set; }
        [XmlElement(ElementName = "Amounts")]
        public Amounts Amounts { get; set; }
        [XmlElement(ElementName = "LocalCreateDateTime")]
        public string LocalCreateDateTime { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "pricingType")]
        public string PricingType { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "latestPQFlag")]
        public string LatestPQFlag { get; set; }
        [XmlAttribute(AttributeName = "reissueType")]
        public string ReissueType { get; set; }
    }

    [XmlRoot(ElementName = "ReissueDifference")]
    public class ReissueDifference
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "NameAssociation")]
    public class NameAssociation
    {
        [XmlElement(ElementName = "PriceQuote")]
        public List<PriceQuote> PriceQuote { get; set; }
        [XmlAttribute(AttributeName = "firstName")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "lastName")]
        public string LastName { get; set; }
        [XmlAttribute(AttributeName = "nameId")]
        public string NameId { get; set; }
        [XmlAttribute(AttributeName = "nameNumber")]
        public string NameNumber { get; set; }
    }

    [XmlRoot(ElementName = "BaseFare")]
    public class BaseFare
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "EquivalentFare")]
    public class EquivalentFare
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TotalTax")]
    public class TotalTax
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "TotalFare")]
    public class TotalFare
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "FareInfo")]
    public class FareInfo
    {
        [XmlElement(ElementName = "BaseFare")]
        public BaseFare BaseFare { get; set; }
        [XmlElement(ElementName = "EquivalentFare")]
        public EquivalentFare EquivalentFare { get; set; }
        [XmlElement(ElementName = "TotalTax")]
        public TotalTax TotalTax { get; set; }
        [XmlElement(ElementName = "TotalFare")]
        public TotalFare TotalFare { get; set; }
        [XmlAttribute(AttributeName = "passengerType")]
        public string PassengerType { get; set; }
        [XmlAttribute(AttributeName = "passengerTypeCount")]
        public string PassengerTypeCount { get; set; }
        [XmlElement(ElementName = "FareIndicators")]
        public string FareIndicators { get; set; }
        [XmlElement(ElementName = "TaxInfo")]
        public TaxInfo TaxInfo { get; set; }
        [XmlElement(ElementName = "FareCalculation")]
        public FareCalculation FareCalculation { get; set; }
        [XmlElement(ElementName = "FareComponent")]
        public List<FareComponent> FareComponent { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "CurrencyConversion")]
        public CurrencyConversion CurrencyConversion { get; set; }
    }

    [XmlRoot(ElementName = "SummaryByPassengerType")]
    public class SummaryByPassengerType
    {
        [XmlElement(ElementName = "FareInfo")]
        public List<FareInfo> FareInfo { get; set; }
        [XmlElement(ElementName = "Total")]
        public List<Total> Total { get; set; }
    }

    [XmlRoot(ElementName = "Summary")]
    public class Summary
    {
        [XmlElement(ElementName = "NameAssociation")]
        public NameAssociation NameAssociation { get; set; }
        [XmlElement(ElementName = "SummaryByPassengerType")]
        public SummaryByPassengerType SummaryByPassengerType { get; set; }
    }

    [XmlRoot(ElementName = "AgentInfo")]
    public class AgentInfo
    {
        [XmlElement(ElementName = "HomeLocation")]
        public string HomeLocation { get; set; }
        [XmlElement(ElementName = "WorkLocation")]
        public string WorkLocation { get; set; }
        [XmlAttribute(AttributeName = "duty")]
        public string Duty { get; set; }
        [XmlAttribute(AttributeName = "sine")]
        public string Sine { get; set; }
    }

    [XmlRoot(ElementName = "TransactionInfo")]
    public class TransactionInfo
    {
        [XmlElement(ElementName = "CreateDateTime")]
        public string CreateDateTime { get; set; }
        [XmlElement(ElementName = "UpdateDateTime")]
        public string UpdateDateTime { get; set; }
        [XmlElement(ElementName = "LastDateToPurchase")]
        public string LastDateToPurchase { get; set; }
        [XmlElement(ElementName = "LocalCreateDateTime")]
        public string LocalCreateDateTime { get; set; }
        [XmlElement(ElementName = "LocalUpdateDateTime")]
        public string LocalUpdateDateTime { get; set; }
        [XmlElement(ElementName = "InputEntry")]
        public string InputEntry { get; set; }
        [XmlElement(ElementName = "LocalDateTime")]
        public string LocalDateTime { get; set; }
        [XmlElement(ElementName = "ReissueMethod")]
        public string ReissueMethod { get; set; }
        [XmlElement(ElementName = "ReissueResult")]
        public string ReissueResult { get; set; }
    }

    [XmlRoot(ElementName = "NameAssociationInfo")]
    public class NameAssociationInfo
    {
        [XmlAttribute(AttributeName = "firstName")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "lastName")]
        public string LastName { get; set; }
        [XmlAttribute(AttributeName = "nameId")]
        public string NameId { get; set; }
        [XmlAttribute(AttributeName = "nameNumber")]
        public string NameNumber { get; set; }
    }

    [XmlRoot(ElementName = "MarketingFlight")]
    public class MarketingFlight
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CityCode")]
    public class CityCode
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Departure")]
    public class Departure
    {
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }
        [XmlElement(ElementName = "CityCode")]
        public CityCode CityCode { get; set; }
    }

    [XmlRoot(ElementName = "Arrival")]
    public class Arrival
    {
        [XmlElement(ElementName = "DateTime")]
        public string DateTime { get; set; }
        [XmlElement(ElementName = "CityCode")]
        public CityCode CityCode { get; set; }
    }

    [XmlRoot(ElementName = "Flight")]
    public class Flight
    {
        [XmlElement(ElementName = "MarketingFlight")]
        public MarketingFlight MarketingFlight { get; set; }
        [XmlElement(ElementName = "ClassOfService")]
        public string ClassOfService { get; set; }
        [XmlElement(ElementName = "Departure")]
        public Departure Departure { get; set; }
        [XmlElement(ElementName = "Arrival")]
        public Arrival Arrival { get; set; }
        [XmlAttribute(AttributeName = "connectionIndicator")]
        public string ConnectionIndicator { get; set; }
    }

    [XmlRoot(ElementName = "Baggage")]
    public class Baggage
    {
        [XmlAttribute(AttributeName = "allowance")]
        public string Allowance { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "BrandedFare")]
    public class BrandedFare
    {
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "description")]
        public string Description { get; set; }
        [XmlAttribute(AttributeName = "programCode")]
        public string ProgramCode { get; set; }
        [XmlAttribute(AttributeName = "programDescription")]
        public string ProgramDescription { get; set; }
    }

    [XmlRoot(ElementName = "SegmentInfo")]
    public class SegmentInfo
    {
        [XmlElement(ElementName = "Flight")]
        public Flight Flight { get; set; }
        [XmlElement(ElementName = "FareBasis")]
        public string FareBasis { get; set; }
        [XmlElement(ElementName = "NotValidBefore")]
        public string NotValidBefore { get; set; }
        [XmlElement(ElementName = "NotValidAfter")]
        public string NotValidAfter { get; set; }
        [XmlElement(ElementName = "Baggage")]
        public Baggage Baggage { get; set; }
        [XmlElement(ElementName = "BrandedFare")]
        public BrandedFare BrandedFare { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "segID")]
        public string SegID { get; set; }
        [XmlAttribute(AttributeName = "segNumber")]
        public string SegNumber { get; set; }
        [XmlAttribute(AttributeName = "segmentStatus")]
        public string SegmentStatus { get; set; }
        [XmlAttribute(AttributeName = "flown")]
        public string Flown { get; set; }
    }

    [XmlRoot(ElementName = "Amount")]
    public class Amount
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "CombinedTax")]
    public class CombinedTax
    {
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
    }

    [XmlRoot(ElementName = "Tax")]
    public class Tax
    {
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "paid")]
        public string Paid { get; set; }
    }

    [XmlRoot(ElementName = "TaxInfo")]
    public class TaxInfo
    {
        [XmlElement(ElementName = "CombinedTax")]
        public List<CombinedTax> CombinedTax { get; set; }
        [XmlElement(ElementName = "Tax")]
        public List<Tax> Tax { get; set; }
    }

    [XmlRoot(ElementName = "FareCalculation")]
    public class FareCalculation
    {
        [XmlAttribute(AttributeName = "rateOfExchange")]
        public string RateOfExchange { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "FlightSegmentNumbers")]
    public class FlightSegmentNumbers
    {
        [XmlElement(ElementName = "SegmentNumber")]
        public string SegmentNumber { get; set; }
    }

    [XmlRoot(ElementName = "FareDirectionality")]
    public class FareDirectionality
    {
        [XmlAttribute(AttributeName = "roundTrip")]
        public string RoundTrip { get; set; }
        [XmlAttribute(AttributeName = "inbound")]
        public string Inbound { get; set; }
    }

    [XmlRoot(ElementName = "BrandInfo")]
    public class BrandInfo
    {
        [XmlAttribute(AttributeName = "brandCode")]
        public string BrandCode { get; set; }
        [XmlAttribute(AttributeName = "brandDescription")]
        public string BrandDescription { get; set; }
        [XmlAttribute(AttributeName = "programCode")]
        public string ProgramCode { get; set; }
        [XmlAttribute(AttributeName = "programDescription")]
        public string ProgramDescription { get; set; }
    }

    [XmlRoot(ElementName = "Rules")]
    public class Rules
    {
        [XmlAttribute(AttributeName = "carrier")]
        public string Carrier { get; set; }
        [XmlAttribute(AttributeName = "rule")]
        public string Rule { get; set; }
        [XmlAttribute(AttributeName = "tariff")]
        public string Tariff { get; set; }
        [XmlAttribute(AttributeName = "vendor")]
        public string Vendor { get; set; }
    }

    [XmlRoot(ElementName = "FareComponent")]
    public class FareComponent
    {
        [XmlElement(ElementName = "FlightSegmentNumbers")]
        public FlightSegmentNumbers FlightSegmentNumbers { get; set; }
        [XmlElement(ElementName = "FareDirectionality")]
        public FareDirectionality FareDirectionality { get; set; }
        [XmlElement(ElementName = "Departure")]
        public Departure Departure { get; set; }
        [XmlElement(ElementName = "Arrival")]
        public Arrival Arrival { get; set; }
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
        [XmlElement(ElementName = "GoverningCarrier")]
        public string GoverningCarrier { get; set; }
        [XmlElement(ElementName = "BrandInfo")]
        public BrandInfo BrandInfo { get; set; }
        [XmlElement(ElementName = "Rules")]
        public Rules Rules { get; set; }
        [XmlAttribute(AttributeName = "fareBasisCode")]
        public string FareBasisCode { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "typeBitmap")]
        public string TypeBitmap { get; set; }
    }

    [XmlRoot(ElementName = "MiscellaneousInfo")]
    public class MiscellaneousInfo
    {
        [XmlElement(ElementName = "ValidatingCarrier")]
        public string ValidatingCarrier { get; set; }
        [XmlElement(ElementName = "ItineraryType")]
        public string ItineraryType { get; set; }
    }

    [XmlRoot(ElementName = "Message")]
    public class Message
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Remarks")]
    public class Remarks
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "MessageInfo")]
    public class MessageInfo
    {
        [XmlElement(ElementName = "Message")]
        public List<Message> Message { get; set; }
        [XmlElement(ElementName = "Remarks")]
        public Remarks Remarks { get; set; }
        [XmlElement(ElementName = "PricingParameters")]
        public string PricingParameters { get; set; }
    }

    [XmlRoot(ElementName = "HistoryInfo")]
    public class HistoryInfo
    {
        [XmlElement(ElementName = "AgentInfo")]
        public AgentInfo AgentInfo { get; set; }
        [XmlElement(ElementName = "TransactionInfo")]
        public TransactionInfo TransactionInfo { get; set; }
    }

    [XmlRoot(ElementName = "Details")]
    public class Details
    {
        [XmlElement(ElementName = "AgentInfo")]
        public AgentInfo AgentInfo { get; set; }
        [XmlElement(ElementName = "TransactionInfo")]
        public TransactionInfo TransactionInfo { get; set; }
        [XmlElement(ElementName = "NameAssociationInfo")]
        public List<NameAssociationInfo> NameAssociationInfo { get; set; }
        [XmlElement(ElementName = "SegmentInfo")]
        public List<SegmentInfo> SegmentInfo { get; set; }
        [XmlElement(ElementName = "FareInfo")]
        public FareInfo FareInfo { get; set; }
        [XmlElement(ElementName = "FeeInfo")]
        public FeeInfo FeeInfo { get; set; }
        [XmlElement(ElementName = "MiscellaneousInfo")]
        public MiscellaneousInfo MiscellaneousInfo { get; set; }
        [XmlElement(ElementName = "MessageInfo")]
        public MessageInfo MessageInfo { get; set; }
        [XmlElement(ElementName = "HistoryInfo")]
        public HistoryInfo HistoryInfo { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "passengerType")]
        public string PassengerType { get; set; }
        [XmlAttribute(AttributeName = "pricingType")]
        public string PricingType { get; set; }
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlElement(ElementName = "FareComparisonSummary")]
        public FareComparisonSummary FareComparisonSummary { get; set; }
        [XmlElement(ElementName = "ExchangeDocInfo")]
        public ExchangeDocInfo ExchangeDocInfo { get; set; }
        [XmlElement(ElementName = "AddCollectInfo")]
        public AddCollectInfo AddCollectInfo { get; set; }
        [XmlAttribute(AttributeName = "reissueTransactionType")]
        public string ReissueTransactionType { get; set; }
    }

    [XmlRoot(ElementName = "CurrencyConversion")]
    public class CurrencyConversion
    {
        [XmlAttribute(AttributeName = "fromCurrency")]
        public string FromCurrency { get; set; }
        [XmlAttribute(AttributeName = "rateOfExchange")]
        public string RateOfExchange { get; set; }
        [XmlAttribute(AttributeName = "toCurrency")]
        public string ToCurrency { get; set; }
    }

    [XmlRoot(ElementName = "FareDifference")]
    public class FareDifference
    {
        [XmlElement(ElementName = "BaseFare")]
        public BaseFare BaseFare { get; set; }
        [XmlElement(ElementName = "EquivalentFare")]
        public EquivalentFare EquivalentFare { get; set; }
        [XmlElement(ElementName = "TotalTax")]
        public TotalTax TotalTax { get; set; }
        [XmlElement(ElementName = "TotalFare")]
        public TotalFare TotalFare { get; set; }
    }

    [XmlRoot(ElementName = "FareComparisonSummary")]
    public class FareComparisonSummary
    {
        [XmlElement(ElementName = "FareDifference")]
        public FareDifference FareDifference { get; set; }
    }

    [XmlRoot(ElementName = "PassengerName")]
    public class PassengerName
    {
        [XmlAttribute(AttributeName = "firstName")]
        public string FirstName { get; set; }
        [XmlAttribute(AttributeName = "lastName")]
        public string LastName { get; set; }
    }

    [XmlRoot(ElementName = "Base")]
    public class Base
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "Equivalent")]
    public class Equivalent
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ExchangeDocInfo")]
    public class ExchangeDocInfo
    {
        [XmlElement(ElementName = "PassengerName")]
        public PassengerName PassengerName { get; set; }
        [XmlElement(ElementName = "Base")]
        public Base Base { get; set; }
        [XmlElement(ElementName = "Equivalent")]
        public Equivalent Equivalent { get; set; }
        [XmlElement(ElementName = "TotalTax")]
        public TotalTax TotalTax { get; set; }
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlAttribute(AttributeName = "nonFlightDoc")]
        public string NonFlightDoc { get; set; }
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
    }

    [XmlRoot(ElementName = "TotalAmount")]
    public class TotalAmount
    {
        [XmlAttribute(AttributeName = "currencyCode")]
        public string CurrencyCode { get; set; }
        [XmlAttribute(AttributeName = "decimalPlace")]
        public string DecimalPlace { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "AddCollectInfo")]
    public class AddCollectInfo
    {
        [XmlElement(ElementName = "TotalAmount")]
        public TotalAmount TotalAmount { get; set; }
    }

    [XmlRoot(ElementName = "Value")]
    public class Value
    {
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "MiscellaneousData")]
    public class MiscellaneousData
    {
        [XmlElement(ElementName = "Value")]
        public Value Value { get; set; }
    }

    [XmlRoot(ElementName = "PriceQuoteInfo")]
    public class PriceQuoteInfo
    {
        [XmlElement(ElementName = "Reservation")]
        public Reservation Reservation { get; set; }
        [XmlElement(ElementName = "Summary")]
        public Summary Summary { get; set; }
        [XmlElement(ElementName = "Details")]
        public List<Details> Details { get; set; }
        [XmlElement(ElementName = "MiscellaneousData")]
        public MiscellaneousData MiscellaneousData { get; set; }
    }

    [XmlRoot(ElementName = "PriceQuote_or114")]
    public class PriceQuote_or114
    {
        [XmlElement(ElementName = "PriceQuoteInfo")]
        public PriceQuoteInfo PriceQuoteInfo { get; set; }
    }

    [XmlRoot(ElementName = "OBFee")]
    public class OBFee
    {
        [XmlElement(ElementName = "Amount")]
        public Amount Amount { get; set; }
        [XmlElement(ElementName = "Total")]
        public Total Total { get; set; }
        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "BankIdentificationNumber")]
        public string BankIdentificationNumber { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }
        [XmlAttribute(AttributeName = "noChargeIndicator")]
        public string NoChargeIndicator { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }

    [XmlRoot(ElementName = "FeeInfo")]
    public class FeeInfo
    {
        [XmlElement(ElementName = "OBFee")]
        public List<OBFee> OBFee { get; set; }
    }

}

