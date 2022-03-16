using System;
using System.Collections.Generic;

public class FormParameters
{
    // public string Aid { get; set; }
    // public string From { get; set; }
    // public string To { get; set; }
    // public string Destination { get; set; }
    // public string FirstName { get; set; }
    // public string LastName { get; set; }
    // public string Id { get; set; }
    // public DateTime DOB { get; set; }
    // public string PhoneNumber { get; set; }
    // public string Email { get; set; }
    // public string MyUnique { get; set; }

    // public List<Traveller> Travellers { get; set; }

    // public class Traveller
    // {
        // public string Id { get; set; }
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public string Gender { get; set; }
        // public DateTime DOB { get; set; }
    //}
	
	public string Aid { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public string DestinationId { get; set; }
    public string DestinationName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Id { get; set; }
    public DateTime DOB { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string MyUnique { get; set; }

    public string Gender { get; set; }
    public string DocketId { get; set; }

    public List<Traveller> Travellers { get; set; }

    public class Traveller
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}