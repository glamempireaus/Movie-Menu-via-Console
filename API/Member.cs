using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Member : IMember
{
    // Fields
    private string firstName;
    private string lastName;
    private string contactNumber;
    private string pin;

    // Properties
    public string FirstName { get { return firstName; } set { firstName = value; } }  // Get and set the first name of this member
    public string LastName { get { return lastName; } set { lastName = value; } }  // Get and set the last name of this member
    public string ContactNumber { get { return contactNumber; } set { contactNumber = value; } }  // Get and set the contact number of this member
    public string Pin { get { return pin; } set { pin = value; } } // Get and set a pin number

    // Constructor with member's first name and lastname
    public Member(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    // Constructor with member's full details
    public Member(string firstName, string lastName, string contactNumber, string pin)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.contactNumber = contactNumber;
        this.pin = pin;
    }

    // Define how to comapre two member objects
    // This member's full name is compared to another member's full name 
    public int CompareTo(IMember member)
    {
        Member another = (Member)member;
        if (this.LastName.CompareTo(another.LastName) < 0)
        {
            return -1;
        }
        else if (this.LastName.CompareTo(another.LastName) == 0)
        {
            return this.FirstName.CompareTo(another.FirstName);
        }
        else
        {
            return 1;
        }
    }

    // Return a string containing the first name, last name and contact number of this memeber
    public string ToString()
    {
        return lastName + ", " + firstName;
    }
}
