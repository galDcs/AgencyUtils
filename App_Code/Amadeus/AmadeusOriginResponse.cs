using System;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot(ElementName="PNR_Reply")]
public class AmadeusOriginResponse {
	[XmlElement(ElementName="pnrHeader")]
	public PnrHeader PnrHeaderX { get; set; }
	[XmlElement(ElementName="securityInformation")]
	public SecurityInformation SecurityInformationX { get; set; }
	[XmlElement(ElementName="freetextData")]
	public FreetextData FreetextDataX { get; set; }
	[XmlElement(ElementName="pnrHeaderTag")]
	public PnrHeaderTag PnrHeaderTagX { get; set; }
	[XmlElement(ElementName="sbrPOSDetails")]
	public SbrPOSDetails SbrPOSDetailsX { get; set; }
	[XmlElement(ElementName="sbrCreationPosDetails")]
	public SbrCreationPosDetails SbrCreationPosDetailsX { get; set; }
	[XmlElement(ElementName="sbrUpdatorPosDetails")]
	public SbrUpdatorPosDetails SbrUpdatorPosDetailsX { get; set; }
	[XmlElement(ElementName="technicalData")]
	public TechnicalData TechnicalDataX { get; set; }
	[XmlElement(ElementName="travellerInfo")]
	public List<TravellerInfo> TravellersInfo { get; set; }
	[XmlElement(ElementName="originDestinationDetails")]
	public OriginDestinationDetails OriginDestinationDetailsX { get; set; }
	[XmlElement(ElementName="dataElementsMaster")]
	public DataElementsMaster DataElementsMasterX { get; set; }
	[XmlElement(ElementName="tstData")]
	public List<TstData> TstDataX { get; set; }
	[XmlAttribute(AttributeName="xmlns")]
	public string Xmlns { get; set; }
	
	public class From {
		[XmlElement(ElementName="Address")]
		public string Address { get; set; }
	}

	[XmlRoot(ElementName="RelatesTo")]
	public class RelatesTo {
		[XmlAttribute(AttributeName="RelationshipType")]
		public string RelationshipType { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="Session")]
	public class Session {
		[XmlElement(ElementName="SessionId")]
		public string SessionId { get; set; }
		[XmlElement(ElementName="SequenceNumber")]
		public string SequenceNumber { get; set; }
		[XmlElement(ElementName="SecurityToken")]
		public string SecurityToken { get; set; }
		[XmlAttribute(AttributeName="TransactionStatusCode")]
		public string TransactionStatusCode { get; set; }
	}

	[XmlRoot(ElementName="Header")]
	public class Header {
		[XmlElement(ElementName="To")]
		public string To { get; set; }
		[XmlElement(ElementName="From")]
		public From From { get; set; }
		[XmlElement(ElementName="Action")]
		public string Action { get; set; }
		[XmlElement(ElementName="MessageID")]
		public string MessageID { get; set; }
		[XmlElement(ElementName="RelatesTo")]
		public RelatesTo RelatesTo { get; set; }
		[XmlElement(ElementName="Session")]
		public Session Session { get; set; }
	}

	[XmlRoot(ElementName="reservation")]
	public class Reservation {
		[XmlElement(ElementName="companyId")]
		public string CompanyId { get; set; }
		[XmlElement(ElementName="controlNumber")]
		public string ControlNumber { get; set; }
		[XmlElement(ElementName="date")]
		public string Date { get; set; }
		[XmlElement(ElementName="time")]
		public string Time { get; set; }
	}

	[XmlRoot(ElementName="reservationInfo")]
	public class ReservationInfo {
		[XmlElement(ElementName="reservation")]
		public Reservation Reservation { get; set; }
	}

	[XmlRoot(ElementName="pnrHeader")]
	public class PnrHeader {
		[XmlElement(ElementName="reservationInfo")]
		public ReservationInfo ReservationInfo { get; set; }
	}

	[XmlRoot(ElementName="responsibilityInformation")]
	public class ResponsibilityInformation {
		[XmlElement(ElementName="typeOfPnrElement")]
		public string TypeOfPnrElement { get; set; }
		[XmlElement(ElementName="agentId")]
		public string AgentId { get; set; }
		[XmlElement(ElementName="officeId")]
		public string OfficeId { get; set; }
		[XmlElement(ElementName="iataCode")]
		public string IataCode { get; set; }
	}

	[XmlRoot(ElementName="queueingInformation")]
	public class QueueingInformation {
		[XmlElement(ElementName="queueingOfficeId")]
		public string QueueingOfficeId { get; set; }
	}

	[XmlRoot(ElementName="secondRpInformation")]
	public class SecondRpInformation {
		[XmlElement(ElementName="creationOfficeId")]
		public string CreationOfficeId { get; set; }
		[XmlElement(ElementName="agentSignature")]
		public string AgentSignature { get; set; }
		[XmlElement(ElementName="creationDate")]
		public string CreationDate { get; set; }
		[XmlElement(ElementName="creatorIataCode")]
		public string CreatorIataCode { get; set; }
		[XmlElement(ElementName="creationTime")]
		public string CreationTime { get; set; }
	}

	[XmlRoot(ElementName="securityInformation")]
	public class SecurityInformation {
		[XmlElement(ElementName="responsibilityInformation")]
		public ResponsibilityInformation ResponsibilityInformation { get; set; }
		[XmlElement(ElementName="queueingInformation")]
		public QueueingInformation QueueingInformation { get; set; }
		[XmlElement(ElementName="cityCode")]
		public string CityCode { get; set; }
		[XmlElement(ElementName="secondRpInformation")]
		public SecondRpInformation SecondRpInformation { get; set; }
	}

	[XmlRoot(ElementName="freetextDetail")]
	public class FreetextDetail {
		[XmlElement(ElementName="subjectQualifier")]
		public string SubjectQualifier { get; set; }
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
		[XmlElement(ElementName="companyId")]
		public string CompanyId { get; set; }
	}

	[XmlRoot(ElementName="freetextData")]
	public class FreetextData {
		[XmlElement(ElementName="freetextDetail")]
		public FreetextDetail FreetextDetail { get; set; }
		[XmlElement(ElementName="longFreetext")]
		public string LongFreetext { get; set; }
	}

	[XmlRoot(ElementName="statusInformation")]
	public class StatusInformation {
		[XmlElement(ElementName="indicator")]
		public string Indicator { get; set; }
	}

	[XmlRoot(ElementName="pnrHeaderTag")]
	public class PnrHeaderTag {
		[XmlElement(ElementName="statusInformation")]
		public StatusInformation StatusInformation { get; set; }
	}

	[XmlRoot(ElementName="originIdentification")]
	public class OriginIdentification {
		[XmlElement(ElementName="originatorId")]
		public string OriginatorId { get; set; }
		[XmlElement(ElementName="inHouseIdentification1")]
		public string InHouseIdentification1 { get; set; }
	}

	[XmlRoot(ElementName="sbrUserIdentificationOwn")]
	public class SbrUserIdentificationOwn {
		[XmlElement(ElementName="originIdentification")]
		public OriginIdentification OriginIdentification { get; set; }
		[XmlElement(ElementName="originatorTypeCode")]
		public string OriginatorTypeCode { get; set; }
	}

	[XmlRoot(ElementName="deliveringSystem")]
	public class DeliveringSystem {
		[XmlElement(ElementName="companyId")]
		public string CompanyId { get; set; }
		[XmlElement(ElementName="locationId")]
		public string LocationId { get; set; }
	}

	[XmlRoot(ElementName="sbrSystemDetails")]
	public class SbrSystemDetails {
		[XmlElement(ElementName="deliveringSystem")]
		public DeliveringSystem DeliveringSystem { get; set; }
	}

	[XmlRoot(ElementName="userPreferences")]
	public class UserPreferences {
		[XmlElement(ElementName="codedCountry")]
		public string CodedCountry { get; set; }
	}

	[XmlRoot(ElementName="sbrPreferences")]
	public class SbrPreferences {
		[XmlElement(ElementName="userPreferences")]
		public UserPreferences UserPreferences { get; set; }
	}

	[XmlRoot(ElementName="sbrPOSDetails")]
	public class SbrPOSDetails {
		[XmlElement(ElementName="sbrUserIdentificationOwn")]
		public SbrUserIdentificationOwn SbrUserIdentificationOwn { get; set; }
		[XmlElement(ElementName="sbrSystemDetails")]
		public SbrSystemDetails SbrSystemDetails { get; set; }
		[XmlElement(ElementName="sbrPreferences")]
		public SbrPreferences SbrPreferences { get; set; }
	}

	[XmlRoot(ElementName="sbrCreationPosDetails")]
	public class SbrCreationPosDetails {
		[XmlElement(ElementName="sbrUserIdentificationOwn")]
		public SbrUserIdentificationOwn SbrUserIdentificationOwn { get; set; }
		[XmlElement(ElementName="sbrSystemDetails")]
		public SbrSystemDetails SbrSystemDetails { get; set; }
		[XmlElement(ElementName="sbrPreferences")]
		public SbrPreferences SbrPreferences { get; set; }
	}

	[XmlRoot(ElementName="sbrUpdatorPosDetails")]
	public class SbrUpdatorPosDetails {
		[XmlElement(ElementName="sbrUserIdentificationOwn")]
		public SbrUserIdentificationOwn SbrUserIdentificationOwn { get; set; }
		[XmlElement(ElementName="sbrSystemDetails")]
		public SbrSystemDetails SbrSystemDetails { get; set; }
		[XmlElement(ElementName="sbrPreferences")]
		public SbrPreferences SbrPreferences { get; set; }
	}

	[XmlRoot(ElementName="sequenceDetails")]
	public class SequenceDetails {
		[XmlElement(ElementName="number")]
		public string Number { get; set; }
	}

	[XmlRoot(ElementName="enveloppeNumberData")]
	public class EnveloppeNumberData {
		[XmlElement(ElementName="sequenceDetails")]
		public SequenceDetails SequenceDetails { get; set; }
	}

	[XmlRoot(ElementName="lastTransmittedEnvelopeNumber")]
	public class LastTransmittedEnvelopeNumber {
		[XmlElement(ElementName="currentRecord")]
		public string CurrentRecord { get; set; }
	}

	[XmlRoot(ElementName="dateTime")]
	public class DateTime {
		[XmlElement(ElementName="year")]
		public string Year { get; set; }
		[XmlElement(ElementName="month")]
		public string Month { get; set; }
		[XmlElement(ElementName="day")]
		public string Day { get; set; }
	}

	[XmlRoot(ElementName="purgeDateData")]
	public class PurgeDateData {
		[XmlElement(ElementName="dateTime")]
		public DateTime DateTime { get; set; }
	}

	[XmlRoot(ElementName="technicalData")]
	public class TechnicalData {
		[XmlElement(ElementName="enveloppeNumberData")]
		public EnveloppeNumberData EnveloppeNumberData { get; set; }
		[XmlElement(ElementName="lastTransmittedEnvelopeNumber")]
		public LastTransmittedEnvelopeNumber LastTransmittedEnvelopeNumber { get; set; }
		[XmlElement(ElementName="purgeDateData")]
		public PurgeDateData PurgeDateData { get; set; }
	}

	[XmlRoot(ElementName="reference")]
	public class Reference {
		[XmlElement(ElementName="qualifier")]
		public string Qualifier { get; set; }
		[XmlElement(ElementName="number")]
		public string Number { get; set; }
	}

	[XmlRoot(ElementName="elementManagementPassenger")]
	public class ElementManagementPassenger {
		[XmlElement(ElementName="reference")]
		public Reference Reference { get; set; }
		[XmlElement(ElementName="segmentName")]
		public string SegmentName { get; set; }
		[XmlElement(ElementName="lineNumber")]
		public string LineNumber { get; set; }
	}

	[XmlRoot(ElementName="traveller")]
	public class Traveller {
		[XmlElement(ElementName="surname")]
		public string Surname { get; set; }
		[XmlElement(ElementName="quantity")]
		public string Quantity { get; set; }
	}

	[XmlRoot(ElementName="passenger")]
	public class Passenger {
		[XmlElement(ElementName="firstName")]
		public string FirstName { get; set; }
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="travellerInformation")]
	public class TravellerInformation {
		[XmlElement(ElementName="traveller")]
		public Traveller Traveller { get; set; }
		[XmlElement(ElementName="passenger")]
		public Passenger Passenger { get; set; }
	}

	[XmlRoot(ElementName="dateAndTimeDetails")]
	public class DateAndTimeDetails {
		[XmlElement(ElementName="qualifier")]
		public string Qualifier { get; set; }
		[XmlElement(ElementName="date")]
		public string Date { get; set; }
	}

	[XmlRoot(ElementName="dateOfBirth")]
	public class DateOfBirth {
		[XmlElement(ElementName="dateAndTimeDetails")]
		public DateAndTimeDetails DateAndTimeDetails { get; set; }
	}

	[XmlRoot(ElementName="passengerData")]
	public class PassengerData {
		[XmlElement(ElementName="travellerInformation")]
		public TravellerInformation TravellerInformation { get; set; }
		[XmlElement(ElementName="dateOfBirth")]
		public DateOfBirth DateOfBirth { get; set; }
	}

	[XmlRoot(ElementName="travellerNameInfo")]
	public class TravellerNameInfo {
		[XmlElement(ElementName="quantity")]
		public string Quantity { get; set; }
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="otherPaxNamesDetails")]
	public class OtherPaxNamesDetails {
		[XmlElement(ElementName="nameType")]
		public string NameType { get; set; }
		[XmlElement(ElementName="referenceName")]
		public string ReferenceName { get; set; }
		[XmlElement(ElementName="displayedName")]
		public string DisplayedName { get; set; }
		[XmlElement(ElementName="surname")]
		public string Surname { get; set; }
		[XmlElement(ElementName="givenName")]
		public string GivenName { get; set; }
	}

	[XmlRoot(ElementName="enhancedTravellerInformation")]
	public class EnhancedTravellerInformation {
		[XmlElement(ElementName="travellerNameInfo")]
		public TravellerNameInfo TravellerNameInfo { get; set; }
		[XmlElement(ElementName="otherPaxNamesDetails")]
		public OtherPaxNamesDetails OtherPaxNamesDetails { get; set; }
	}

	[XmlRoot(ElementName="dateOfBirthInEnhancedPaxData")]
	public class DateOfBirthInEnhancedPaxData {
		[XmlElement(ElementName="dateAndTimeDetails")]
		public DateAndTimeDetails DateAndTimeDetails { get; set; }
	}

	[XmlRoot(ElementName="enhancedPassengerData")]
	public class EnhancedPassengerData {
		[XmlElement(ElementName="enhancedTravellerInformation")]
		public EnhancedTravellerInformation EnhancedTravellerInformation { get; set; }
		[XmlElement(ElementName="dateOfBirthInEnhancedPaxData")]
		public DateOfBirthInEnhancedPaxData DateOfBirthInEnhancedPaxData { get; set; }
	}

	[XmlRoot(ElementName="travellerInfo")]
	public class TravellerInfo {
		[XmlElement(ElementName="elementManagementPassenger")]
		public ElementManagementPassenger ElementManagementPassenger { get; set; }
		[XmlElement(ElementName="passengerData")]
		public PassengerData PassengerData { get; set; }
		[XmlElement(ElementName="enhancedPassengerData")]
		public EnhancedPassengerData EnhancedPassengerData { get; set; }
	}

	[XmlRoot(ElementName="elementManagementItinerary")]
	public class ElementManagementItinerary {
		[XmlElement(ElementName="reference")]
		public Reference Reference { get; set; }
		[XmlElement(ElementName="segmentName")]
		public string SegmentName { get; set; }
		[XmlElement(ElementName="lineNumber")]
		public string LineNumber { get; set; }
	}

	[XmlRoot(ElementName="product")]
	public class Product {
		[XmlElement(ElementName="depDate")]
		public string DepDate { get; set; }
		[XmlElement(ElementName="depTime")]
		public string DepTime { get; set; }
		[XmlElement(ElementName="arrDate")]
		public string ArrDate { get; set; }
		[XmlElement(ElementName="arrTime")]
		public string ArrTime { get; set; }
	}

	[XmlRoot(ElementName="boardpointDetail")]
	public class BoardpointDetail {
		[XmlElement(ElementName="cityCode")]
		public string CityCode { get; set; }
	}

	[XmlRoot(ElementName="offpointDetail")]
	public class OffpointDetail {
		[XmlElement(ElementName="cityCode")]
		public string CityCode { get; set; }
	}

	[XmlRoot(ElementName="companyDetail")]
	public class CompanyDetail {
		[XmlElement(ElementName="identification")]
		public string Identification { get; set; }
	}

	[XmlRoot(ElementName="productDetails")]
	public class ProductDetails {
		[XmlElement(ElementName="identification")]
		public string Identification { get; set; }
		[XmlElement(ElementName="classOfService")]
		public string ClassOfService { get; set; }
		[XmlElement(ElementName="equipment")]
		public string Equipment { get; set; }
		[XmlElement(ElementName="numOfStops")]
		public string NumOfStops { get; set; }
		[XmlElement(ElementName="weekDay")]
		public string WeekDay { get; set; }
	}

	[XmlRoot(ElementName="typeDetail")]
	public class TypeDetail {
		[XmlElement(ElementName="detail")]
		public string Detail { get; set; }
	}

	[XmlRoot(ElementName="travelProduct")]
	public class TravelProduct {
		[XmlElement(ElementName="product")]
		public Product Product { get; set; }
		[XmlElement(ElementName="boardpointDetail")]
		public BoardpointDetail BoardpointDetail { get; set; }
		[XmlElement(ElementName="offpointDetail")]
		public OffpointDetail OffpointDetail { get; set; }
		[XmlElement(ElementName="companyDetail")]
		public CompanyDetail CompanyDetail { get; set; }
		[XmlElement(ElementName="productDetails")]
		public ProductDetails ProductDetails { get; set; }
		[XmlElement(ElementName="typeDetail")]
		public TypeDetail TypeDetail { get; set; }
	}

	[XmlRoot(ElementName="business")]
	public class Business {
		[XmlElement(ElementName="function")]
		public string Function { get; set; }
	}

	[XmlRoot(ElementName="itineraryMessageAction")]
	public class ItineraryMessageAction {
		[XmlElement(ElementName="business")]
		public Business Business { get; set; }
	}

	[XmlRoot(ElementName="relatedProduct")]
	public class RelatedProduct {
		[XmlElement(ElementName="quantity")]
		public string Quantity { get; set; }
		[XmlElement(ElementName="status")]
		public List<string> Status { get; set; }
	}

	[XmlRoot(ElementName="arrivalStationInfo")]
	public class ArrivalStationInfo {
		[XmlElement(ElementName="terminal")]
		public string Terminal { get; set; }
	}

	[XmlRoot(ElementName="facilities")]
	public class Facilities {
		[XmlElement(ElementName="entertainement")]
		public string Entertainement { get; set; }
		[XmlElement(ElementName="entertainementDescription")]
		public string EntertainementDescription { get; set; }
	}

	[XmlRoot(ElementName="flightDetail")]
	public class FlightDetail {
		[XmlElement(ElementName="productDetails")]
		public ProductDetails ProductDetails { get; set; }
		[XmlElement(ElementName="arrivalStationInfo")]
		public ArrivalStationInfo ArrivalStationInfo { get; set; }
		[XmlElement(ElementName="facilities")]
		public Facilities Facilities { get; set; }
	}

	[XmlRoot(ElementName="selection")]
	public class Selection {
		[XmlElement(ElementName="option")]
		public string Option { get; set; }
	}

	[XmlRoot(ElementName="selectionDetails")]
	public class SelectionDetails {
		[XmlElement(ElementName="selection")]
		public Selection Selection { get; set; }
	}

	[XmlRoot(ElementName="itineraryInfo")]
	public class ItineraryInfo {
		[XmlElement(ElementName="elementManagementItinerary")]
		public ElementManagementItinerary ElementManagementItinerary { get; set; }
		[XmlElement(ElementName="travelProduct")]
		public TravelProduct TravelProduct { get; set; }
		[XmlElement(ElementName="itineraryMessageAction")]
		public ItineraryMessageAction ItineraryMessageAction { get; set; }
		[XmlElement(ElementName="relatedProduct")]
		public RelatedProduct RelatedProduct { get; set; }
		[XmlElement(ElementName="flightDetail")]
		public FlightDetail FlightDetail { get; set; }
		[XmlElement(ElementName="selectionDetails")]
		public SelectionDetails SelectionDetails { get; set; }
		[XmlElement(ElementName="markerRailTour")]
		public string MarkerRailTour { get; set; }
		[XmlElement(ElementName="itineraryFreetext")]
		public ItineraryFreetext ItineraryFreetext { get; set; }
	}

	[XmlRoot(ElementName="itineraryFreetext")]
	public class ItineraryFreetext {
		[XmlElement(ElementName="freetextDetail")]
		public FreetextDetail FreetextDetail { get; set; }
		[XmlElement(ElementName="longFreetext")]
		public string LongFreetext { get; set; }
	}

	[XmlRoot(ElementName="originDestinationDetails")]
	public class OriginDestinationDetails {
		[XmlElement(ElementName="originDestination")]
		public string OriginDestination { get; set; }
		[XmlElement(ElementName="itineraryInfo")]
		public List<ItineraryInfo> ItineraryInfo { get; set; }
	}

	[XmlRoot(ElementName="elementManagementData")]
	public class ElementManagementData {
		[XmlElement(ElementName="reference")]
		public Reference Reference { get; set; }
		[XmlElement(ElementName="segmentName")]
		public string SegmentName { get; set; }
		[XmlElement(ElementName="lineNumber")]
		public string LineNumber { get; set; }
	}

	[XmlRoot(ElementName="otherDataFreetext")]
	public class OtherDataFreetext {
		[XmlElement(ElementName="freetextDetail")]
		public FreetextDetail FreetextDetail { get; set; }
		[XmlElement(ElementName="longFreetext")]
		public string LongFreetext { get; set; }
	}

	[XmlRoot(ElementName="dataElementsIndiv")]
	public class DataElementsIndiv {
		[XmlElement(ElementName="elementManagementData")]
		public ElementManagementData ElementManagementData { get; set; }
		[XmlElement(ElementName="otherDataFreetext")]
		public OtherDataFreetext OtherDataFreetext { get; set; }
		[XmlElement(ElementName="ticketElement")]
		public TicketElement TicketElement { get; set; }
		[XmlElement(ElementName="referenceForDataElement")]
		public ReferenceForDataElement ReferenceForDataElement { get; set; }
		[XmlElement(ElementName="serviceRequest")]
		public ServiceRequest ServiceRequest { get; set; }
		[XmlElement(ElementName="pnrSecurity")]
		public PnrSecurity PnrSecurity { get; set; }
	}

	[XmlRoot(ElementName="ticket")]
	public class Ticket {
		[XmlElement(ElementName="indicator")]
		public string Indicator { get; set; }
		[XmlElement(ElementName="date")]
		public string Date { get; set; }
		[XmlElement(ElementName="officeId")]
		public string OfficeId { get; set; }
		[XmlElement(ElementName="electronicTicketFlag")]
		public string ElectronicTicketFlag { get; set; }
		[XmlElement(ElementName="airlineCode")]
		public string AirlineCode { get; set; }
	}

	[XmlRoot(ElementName="ticketElement")]
	public class TicketElement {
		[XmlElement(ElementName="passengerType")]
		public string PassengerType { get; set; }
		[XmlElement(ElementName="ticket")]
		public Ticket Ticket { get; set; }
	}

	[XmlRoot(ElementName="referenceForDataElement")]
	public class ReferenceForDataElement {
		[XmlElement(ElementName="reference")]
		public List<Reference> Reference { get; set; }
	}

	[XmlRoot(ElementName="ssr")]
	public class Ssr {
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
		[XmlElement(ElementName="status")]
		public string Status { get; set; }
		[XmlElement(ElementName="quantity")]
		public string Quantity { get; set; }
		[XmlElement(ElementName="companyId")]
		public string CompanyId { get; set; }
		[XmlElement(ElementName="freeText")]
		public string FreeText { get; set; }
	}

	[XmlRoot(ElementName="serviceRequest")]
	public class ServiceRequest {
		[XmlElement(ElementName="ssr")]
		public Ssr Ssr { get; set; }
	}

	[XmlRoot(ElementName="security")]
	public class Security {
		[XmlElement(ElementName="identification")]
		public string Identification { get; set; }
		[XmlElement(ElementName="accessMode")]
		public string AccessMode { get; set; }
	}

	[XmlRoot(ElementName="securityInfo")]
	public class SecurityInfo {
		[XmlElement(ElementName="creationDate")]
		public string CreationDate { get; set; }
		[XmlElement(ElementName="agentCode")]
		public string AgentCode { get; set; }
		[XmlElement(ElementName="officeId")]
		public string OfficeId { get; set; }
	}

	[XmlRoot(ElementName="pnrSecurity")]
	public class PnrSecurity {
		[XmlElement(ElementName="security")]
		public List<Security> Security { get; set; }
		[XmlElement(ElementName="securityInfo")]
		public SecurityInfo SecurityInfo { get; set; }
		[XmlElement(ElementName="indicator")]
		public string Indicator { get; set; }
	}

	[XmlRoot(ElementName="dataElementsMaster")]
	public class DataElementsMaster {
		[XmlElement(ElementName="marker2")]
		public string Marker2 { get; set; }
		[XmlElement(ElementName="dataElementsIndiv")]
		public List<DataElementsIndiv> DataElementsIndiv { get; set; }
	}

	[XmlRoot(ElementName="generalInformation")]
	public class GeneralInformation {
		[XmlElement(ElementName="tstReferenceNumber")]
		public string TstReferenceNumber { get; set; }
		[XmlElement(ElementName="tstCreationDate")]
		public string TstCreationDate { get; set; }
	}

	[XmlRoot(ElementName="tstGeneralInformation")]
	public class TstGeneralInformation {
		[XmlElement(ElementName="generalInformation")]
		public GeneralInformation GeneralInformation { get; set; }
	}

	[XmlRoot(ElementName="tstFreetext")]
	public class TstFreetext {
		[XmlElement(ElementName="freetextDetail")]
		public FreetextDetail FreetextDetail { get; set; }
		[XmlElement(ElementName="longFreetext")]
		public string LongFreetext { get; set; }
	}

	[XmlRoot(ElementName="fareElement")]
	public class FareElement {
		[XmlElement(ElementName="primaryCode")]
		public string PrimaryCode { get; set; }
		[XmlElement(ElementName="notValidBefore")]
		public string NotValidBefore { get; set; }
		[XmlElement(ElementName="notValidAfter")]
		public string NotValidAfter { get; set; }
		[XmlElement(ElementName="baggageAllowance")]
		public string BaggageAllowance { get; set; }
		[XmlElement(ElementName="fareBasis")]
		public string FareBasis { get; set; }
	}

	[XmlRoot(ElementName="fareBasisInfo")]
	public class FareBasisInfo {
		[XmlElement(ElementName="fareElement")]
		public FareElement FareElement { get; set; }
	}

	[XmlRoot(ElementName="monetaryInfo")]
	public class MonetaryInfo {
		[XmlElement(ElementName="qualifier")]
		public string Qualifier { get; set; }
		[XmlElement(ElementName="amount")]
		public string Amount { get; set; }
		[XmlElement(ElementName="currencyCode")]
		public string CurrencyCode { get; set; }
	}

	[XmlRoot(ElementName="taxFields")]
	public class TaxFields {
		[XmlElement(ElementName="taxIndicator")]
		public string TaxIndicator { get; set; }
		[XmlElement(ElementName="taxCurrency")]
		public string TaxCurrency { get; set; }
		[XmlElement(ElementName="taxAmount")]
		public string TaxAmount { get; set; }
		[XmlElement(ElementName="taxCountryCode")]
		public string TaxCountryCode { get; set; }
		[XmlElement(ElementName="taxNatureCode")]
		public string TaxNatureCode { get; set; }
	}

	[XmlRoot(ElementName="fareData")]
	public class FareData {
		[XmlElement(ElementName="issueIdentifier")]
		public string IssueIdentifier { get; set; }
		[XmlElement(ElementName="monetaryInfo")]
		public List<MonetaryInfo> MonetaryInfo { get; set; }
		[XmlElement(ElementName="taxFields")]
		public List<TaxFields> TaxFields { get; set; }
	}

	[XmlRoot(ElementName="segmentAssociation")]
	public class SegmentAssociation {
		[XmlElement(ElementName="selection")]
		public List<Selection> Selection { get; set; }
	}

	[XmlRoot(ElementName="referenceForTstData")]
	public class ReferenceForTstData {
		[XmlElement(ElementName="reference")]
		public List<Reference> References { get; set; }
	}

	[XmlRoot(ElementName="tstData")]
	public class TstData {
		[XmlElement(ElementName="tstGeneralInformation")]
		public TstGeneralInformation TstGeneralInformation { get; set; }
		[XmlElement(ElementName="tstFreetext")]
		public List<TstFreetext> TstFreetext { get; set; }
		[XmlElement(ElementName="fareBasisInfo")]
		public FareBasisInfo FareBasisInfo { get; set; }
		[XmlElement(ElementName="fareData")]
		public FareData FareData { get; set; }
		[XmlElement(ElementName="segmentAssociation")]
		public SegmentAssociation SegmentAssociation { get; set; }
		[XmlElement(ElementName="referenceForTstData")]
		public ReferenceForTstData ReferenceForTstData { get; set; }
	}
}
