using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Traveller
/// </summary>
public class Traveller
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string AgeGroupId { get; set; }
    public string GenderId { get; set; }
    public string Mail { get; set; }
    public string Id { get; set; }
    public string Phone { get; set; }
    public string CellPhone { get; set; }
    public string Remarks { get; set; }
    public string Address { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }

    //
    public decimal Brutto { get; set; }
    public decimal Netto { get; set; }

    public List<Escort> Escorts = new List<Escort>();
    public List<Escort> mEscorts
    {
        get
        {
            return Escorts;
        }
        set
        {
            Escorts = value;
        }
    }

    public Traveller()
    {

    }

    public class Escort : Traveller
    {
        public bool IsMain { get; set; }

        public Escort(string iLastName, string iFirstName, string iDateOfBirth, string iGender)
        {
            LastName = iLastName;
            FirstName = iFirstName;
            DateTime dateOfBirth;
            DateTime.TryParse(iDateOfBirth, out dateOfBirth);
            DateOfBirth = dateOfBirth;
            GenderId = iGender;
        }
    }

    public void SaveToSession()
    {
        HttpContext.Current.Session["Traveller"] = this;
    }

    public static Traveller LoadFromSession()
    {
        if (HttpContext.Current.Session["Traveller"] == null)
        {
            throw new Exception("פג זמן השימוש במערכת, נדרשת התחברות מחדש");
        }
        else if (HttpContext.Current.Session["Traveller"] is Traveller)
        {
            return (Traveller)HttpContext.Current.Session["Traveller"];
        }
        else
        {
            throw new Exception("שגיאה, יש להכנס למערכת מחדש.");
        }
    }

}