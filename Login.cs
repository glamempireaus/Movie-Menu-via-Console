using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Login
{
    public const string staffUsername = "staff";
    public const string staffPassword = "today123";

    public static IMember loggedInMember = Program.member1;
    public static LoginErrorCode currentLoginErrorCode = LoginErrorCode.NONE;

    public enum LoginErrorCode
    {
        NULL = -1,
        NONE = 0,
        INVALID_USERNAME = 1,
        INVALID_NAME = 2,
        INVALID_PASSWORD = 3,
    }

    public static int CheckStaffCredentials(string username, string password)
    {
        if (username != staffUsername)
        {
            currentLoginErrorCode = LoginErrorCode.INVALID_USERNAME;

            return 0;
        }

        if (password != staffPassword)
        {
            currentLoginErrorCode = LoginErrorCode.INVALID_PASSWORD;

            return -1;
        }

        currentLoginErrorCode = LoginErrorCode.NONE;

        return 1;
    }

    public static int CheckMemberCredentials(string firstName, string lastName, string pin)
    {
        Member member = (Member)Program.members.Search(firstName, lastName);

        if (member != null)
        {
            if (member.Pin == pin)
            {
                currentLoginErrorCode = LoginErrorCode.NONE;
                loggedInMember = (IMember) member;

                return 1;
            }
            else
            {
                currentLoginErrorCode = LoginErrorCode.INVALID_PASSWORD;
            }
        }

        currentLoginErrorCode = LoginErrorCode.INVALID_NAME;

        return 0;
    }
}
