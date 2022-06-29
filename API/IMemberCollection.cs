using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMemberCollection
{
    public int Capacity // get the capacity of this member collection 
    {
        get;
    }
    public int Number // get the number of members in this collection
    {
        get;
    }

    // Check if this member collection is full
    public bool IsFull();

    // check if this member collection is empty
    public bool IsEmpty();

    // Add a new member to this member collection
    public void Add(IMember member);

    // Remove a given member out of this member collection
    public void Delete(IMember aMember);

    // Search a given member in this member collection 
    public bool Search(IMember member);

    // Remove all the members in this member collection
    public void Clear();

    // Return a string containing the information about all the members in this member collection.
    public string ToString();
}
