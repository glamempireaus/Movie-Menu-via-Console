using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    public Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }

    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created
    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection
    public void Add(IMember member)
    {
        // check if null
        if (member == null)
        {
            return;
        }

        // check if full
        if (IsFull())
        {
            return;
        }

        // check if there's a duplicate
        for (int i = 0; i < count; i++)
        {
            if (members[i].CompareTo(member) == 0)
            {
                return;
            }
        }

        // find slot for member
        int pos = count - 1;
        while (pos >= 0)
        {
            if (members[pos].CompareTo(member) == 1)
            {
                // less than alphabetically
                members[pos + 1] = members[pos];
                pos--;
            }
            else 
            {
                break;
            }
        }

        // place member
        members[pos + 1] = (Member)member;
        count++;
    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given member was in the member collection
    public void Delete(IMember aMember)
    {
        // parameter tests
        if (aMember == null)
        {
            return;
        }

        Member[] newMembersArray = new Member[capacity];


        // get position of member to be deleted
        int foundIndex = -1;
        for (int i = 0; i < count; i++)
        {
            if (members[i].CompareTo(aMember) == 0)
            {
                foundIndex = i;
                break;
            }
        }

        // check if nothing's found
        if (foundIndex == -1)
        {
            return;
        }

        // construct the new array
        for (int i = 0; i < foundIndex; i++)
        {
            newMembersArray[i] = members[i];
        }

        // replace
        for (int i = foundIndex; i < count - 1; i++)
        {
            newMembersArray[i] = members[i+1];
        }

        members = newMembersArray;

        count--;


        for (int i = 0; i < count; i++)
        {
            if (members[i] != null)
            {
                Console.WriteLine(i + ". " + members[i].FirstName + " " + members[i].LastName);
            }
            else
            {
                Console.WriteLine(i + ". Null");
            }
        }
    }

    public IMember Search(string firstName, string lastName)
    {
        for (int i = 0; i < count; i++)
        {
            if (members[i].FirstName == firstName)
            {
                if (members[i].LastName == lastName)
                {
                    return members[i];
                }
            }
        }

        return null;
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
    // parameter tests
    if (member == null)
    {
        return false;
    }

    // binary search algorithm:

    int left = 0;
    int right = count;
    int searchIndex = (left + right) / 2;
    int comparison;
    while (left < right)
    {
        comparison = members[searchIndex].CompareTo(member);

        if (comparison == -1)
        {
            left = searchIndex + 1;
        }
        else if (comparison == 1)
        {
            right = searchIndex;
        }
        else 
        {
            //Console.WriteLine("Found member: " + member + " at index: " + searchIndex);
            return true;
        }

        searchIndex = (left + right) / 2;
    }

    //Console.WriteLine("Member: " + member + " was not found");

    return false;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        for (int i = 0; i < count; i++)
            s = s + members[i].ToString() + "\n";
        return s;
    }
}
