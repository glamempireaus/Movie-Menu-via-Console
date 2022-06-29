using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMember
{
    // Get and set the first name of this member
    public string FirstName
    {
        get;
        set;
    }

    // Get and set the last name of this member
    public string LastName
    {
        get;
        set;
    }

    // Get and set the contact number of this member
    public string ContactNumber
    {
        get;
        set; //contact number must be valid 
    }

    // Get and set a pin for this member
    public string Pin
    {
        get;
        set; //pin must be valid 
    }

    // Define how to comapre two member objects
    public int CompareTo(IMember member);

    // Check if a contact phone number is valid. A contact phone number is valid if it has 10 digits and the first digit is 0.
    public static bool IsValidContactNumber(string phonenumber)
    {
        if (phonenumber == null)
        {
            return false;
        }

        if (!int.TryParse(phonenumber, out _))
        {
            return false;
        }

        if (phonenumber.Length != 10)
        {
            return false;
        }

        if (phonenumber.Substring(0, 1) != "0")
        {
            return false;
        }

        return true;
    }

    // Check if a pin is valid. A pin is valid if it is a number which has a minimal of 4 and a maximal of 6 digits.
    public static bool IsValidPin(string pin)
    {
        if (pin == null)
        {
            return false;
        }

        if (!int.TryParse(pin, out _))
        {
            return false;
        }

        if (pin.Length < 4 || pin.Length > 6)
        {
            return false;
        }

        return true;
    }

    // Return a string containing the first name, last name and contact number of this memeber
    public string ToString();
}