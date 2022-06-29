using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Render
{
    // render triggers
    private static Interface.ParentMenu previousParentMenu = Interface.ParentMenu.NULL;
    private static Interface.ChildMenu previousChildMenu = Interface.ChildMenu.NULL;
    private static Login.LoginErrorCode previousLoginErrorCode = Login.LoginErrorCode.NULL;

    public static void Init()
    {
        Console.Clear();

        Console.CursorVisible = false;

        try
        {
            Console.SetWindowSize(56, 20);

            Console.SetBufferSize(56, 20);
        }
        catch (Exception ex){ }

        Render.Loop();
    }

    public static void Loop()
    {
        // check for permission to render
        if (RenderTriggerGate() == false)
        {
            return;
        }

        Console.Clear();

        Console.SetCursorPosition(0, 0);

        RenderWelcomeMessage();

        // decide what we're rendering
        if (Interface.currentChildMenu == Interface.ChildMenu.NONE)
        {
            RenderCurrentParentMenu();
        }
        else
        {
            RenderCurrentChildMenu();
        }
    }

    public static bool RenderTriggerGate()
    {
        if (Interface._forceRender)
        {
            Interface._forceRender = false;
            return true;
        }

        // check if a menu has changed
        if (Render.previousLoginErrorCode != Login.currentLoginErrorCode)
        {
            Render.previousLoginErrorCode = Login.currentLoginErrorCode;

            return true;
        }

        // check if the menu hasn't changed
        if (Render.previousParentMenu == Interface.currentParentMenu && Render.previousChildMenu == Interface.currentChildMenu)
        {
            return false;
        }
        else
        {
            previousParentMenu = Interface.currentParentMenu;
            previousChildMenu = Interface.currentChildMenu;

            return true;
        }

        return false;
    }

    public static void RenderCurrentParentMenu()
    {
        string text = "";

        switch (Interface.currentParentMenu)
        {

            case Interface.ParentMenu.MAIN_MENU:

                RenderMainMenu();

                break;

            case Interface.ParentMenu.STAFF_MENU:

                RenderStaffMenu();

                break;

            case Interface.ParentMenu.MEMBER_MENU:

                RenderMemberMenu();

                break;



            default: break;

        }

        Console.WriteLine(text);
    }
    public static void RenderCurrentChildMenu()
    {
        switch (Interface.currentChildMenu)
        {
            // STAFF LOGIN
            case Interface.ChildMenu.STAFF_LOGIN:

                RenderStaffLogin();

                break;

            // MEMBER LOGIN
            case Interface.ChildMenu.MEMBER_LOGIN:

                RenderMemberLogin();

                break;


            case Interface.ChildMenu.MEMBER_BORROWED_MOVIES:

                RenderMemberBorrowMovie();

                break;


            case Interface.ChildMenu.MEMBER_BROWSE_MOVIES:

                RenderMemberBrowseAllMovies();

                break;


            case Interface.ChildMenu.MEMBER_DISPLAY_MOVIE_INFO:

                RenderMemberDisplayMovieInfo();

                break;


            case Interface.ChildMenu.MEMBER_RETURN_MOVIE:

                RenderMemberReturnMovie();

                break;


            case Interface.ChildMenu.MEMBER_LIST_BORROWED_MOVIES:

                RenderMemberBorrowedMovies();

                break;


            case Interface.ChildMenu.MEMBER_TOP_3_MOVIES:

                RenderMemberTop3Movies();

                break;


            case Interface.ChildMenu.STAFF_ADD_DVD:

                RenderStaffAddMovie();

                break;


            case Interface.ChildMenu.STAFF_DELETE_DVD:

                RenderStaffDeleteMovie();

                break;

            case Interface.ChildMenu.STAFF_REGISTER_MEMBER:

                RenderStaffRegisterMember();

                break;


            case Interface.ChildMenu.STAFF_DELETE_MEMBER:

                RenderStaffDeleteMember();

                break;


            case Interface.ChildMenu.STAFF_DISPLAY_MOVIE_PARTICIPANTS:

                RenderStaffDisplayMovieParticipants();

                break;


            case Interface.ChildMenu.STAFF_DISPLAY_PHONE_NUMBER:

                RenderStaffDisplayPhoneNumber();

                break;


            default: 
                
                break;
        }
        Console.WriteLine("\n0. Go Back");
    }

    public static void RenderWelcomeMessage()
    {
        string text = String.Join(
        Environment.NewLine,
        "========================================================",
        "Welcome to Community Library Movie DVD Management System",
        "========================================================",
        ""
        );

        Console.WriteLine(text);
    }

    public static void RenderMainMenu()
    {
        string staffText = "Login";
        string memberText = "Login";

        if (Program.loggedInAsStaff == true)
        {
            staffText = "Menu";
        }

        if (Program.loggedInAsMember == true)
        {
            memberText = "Menu";
        }

        string text = String.Join(
        Environment.NewLine,

        "=======================Main Menu========================",
        "",
        "1. Staff " + staffText,
        "2. Member " + memberText,
        "0. Exit",
        "",
        "Enter your choice ==> (1/2/0)"
        );

        Console.WriteLine(text);
    }

    public static void RenderStaffMenu()
    {
        string text = String.Join(
        Environment.NewLine,
        "=======================Staff Menu=======================",
        "",
        "1. Add new DVDs of a new movie to the system",
        "2. Remove DVDs of a movie from the system",
        "3. Register a new member with the system",
        "4. Remove a registered member from the system",
        "5. Display a member's contact phone numer, given the member's name",
        "6. Display all the members who are currently renting a particular movie",
        "0. Return to the main menu",
        "",
        "Enter your choice ==> (1/2/3/4/5/6/0)"
        );

        Console.WriteLine(text);
    }

    public static void RenderMemberMenu()
    {
        string text = String.Join(
        Environment.NewLine,
        "=======================Member Menu======================",
        "",
        "1. Browse all the movies",
        "2. Display all the information about a movie, given the title of the movie",
        "3. Borrow a movie DVD",
        "4. Return a movie DVD",
        "5. List current borrowing movies",
        "6. Display the top 3 movies rented by the members",
        "0. Return to the main menu",
        "",
        "Enter your choice ==> (1/2/3/4/5/6/0)"
        );

        Console.WriteLine(text);
    }

    public static void RenderStaffLogin()
    {
        string errorText = "";

        if (Login.currentLoginErrorCode == Login.LoginErrorCode.INVALID_USERNAME)
        {
            errorText = "You've inputted a wrong name";
        }
        else if (Login.currentLoginErrorCode == Login.LoginErrorCode.INVALID_PASSWORD)
        {
            errorText = "You've inputted a wrong password";
        }

        string text = String.Join(
        Environment.NewLine,
        "=======================Staff Login======================",
        "",
        "Login using a staff account:",
        "",
        "Username: ",
        "Password: ",
        "",
        errorText
        );

        Console.WriteLine(text);
    }

    public static void RenderMemberLogin()
    {
        string errorText = "";

        if (Login.currentLoginErrorCode == Login.LoginErrorCode.INVALID_NAME)
        {
            errorText = "You've inputted a wrong name";
        }
        else if (Login.currentLoginErrorCode == Login.LoginErrorCode.INVALID_PASSWORD)
        {
            errorText = "You've inputted a wrong password";
        }

        string text = String.Join(
        Environment.NewLine,
        "=======================Member Login=====================",
        "",
        "Login using a member account:",
        "",
        "First name: ",
        "Last name: ",
        "Password: ",
        "",
        errorText
        );

        Console.WriteLine(text);
    }

    public static void RenderStaffAddMovie()
    {
        string text = String.Join(
        Environment.NewLine,
        "===================Staff Add Movie======================",
        "",
        "Create movie: ",
        "",
        "Title: ",
        "Genre: ",
        "Classification: ",
        "Duration: ",
        "Available Copies: ",
        "",
        Interface._addMovieMessage
        );

        Console.WriteLine(text);
    }

    public static void RenderStaffDeleteMovie()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        string text = String.Join(
        Environment.NewLine,
        "=================Member Delete Movie===================",
        "",
        "Please select a movie to delete:",
        ""
        );
        Console.WriteLine(text);

        if (Interface._hasDeletedMovie)
        {
            Console.WriteLine(Interface._deleteMovieMessage);
        }
        else
        {

            for (int i = 0; i < moviesArray.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + moviesArray[i].Title);
            }
        }
    }

    public static void RenderStaffRegisterMember()
    {
        string text = String.Join(
        Environment.NewLine,
        "=================Staff Register Member==================",
        "",
        "Register Member: ",
        "",
        "First Name: ",
        "Last Name: ",
        "Pin (can be 4-6 digits): ",
        "Phone Number: ",
        "",
        Interface._registerMemberMessage
        );

        Console.WriteLine(text);
    }

    public static void RenderStaffDeleteMember()
    {
        string text = String.Join(
        Environment.NewLine,
        "==================Member Delete Member==================",
        "",
        "Please select a member to delete:",
        ""
        );
        Console.WriteLine(text);

        if (Interface._hasDeletedMember)
        {
            Console.WriteLine(Interface._deleteMemberMessage);
        }
        else
        {
            Member[] members = Program.members.members;

            int test = members.Count();

            for (int i = 0; i < Program.members.Number; i++)
            {
                Console.WriteLine(i + 1 + ". " + members[i].FirstName + " " + members[i].LastName);
            }
        }
    }

    public static void RenderStaffDisplayPhoneNumber()
    {
        IMember[] membersArray = Program.members.members;

        string text = String.Join(
        Environment.NewLine,
        "==============Staff Display Phone Number==============",
        ""
        );
        Console.WriteLine(text);

        if (Interface._isDisplayingPhoneNumber)
        {
            Console.WriteLine(Interface._phoneNumberMessage);
        }
        else
        {
            Console.WriteLine("Please enter a member's name: " +
                "\n\nFirst name: " +
                "\nLast name: ");
        }

        Console.WriteLine("\n" + Interface._phoneNumberErrorMessage);
    }

    public static void RenderStaffDisplayMovieParticipants()
    {
        MovieCollection movies = Program.movies;

        string text = String.Join(
        Environment.NewLine,
        "===========Staff Display Movie Participants===========",
        ""
        );
        Console.WriteLine(text);

        if (Interface._isDisplayingMovieParticipants)
        {
            Console.WriteLine(Interface._movieParticipantsMessage);
        }
        else
        {
            Console.WriteLine("Please enter a movie title: " +
                "\n\nTitle: ");
        }

        Console.WriteLine("\n" + Interface._movieParticipantsErrorMessage);
    }

    public static void RenderMemberBrowseAllMovies()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        string text = String.Join(
        Environment.NewLine,
        "====================Browse all Movies===================",
        ""
        );
        Console.WriteLine(text);

        for (int i = 0; i < moviesArray.Length; i++)
        {
            Console.WriteLine(i + 1 + ". " + moviesArray[i].Title);
        }
    }

    public static void RenderMemberDisplayMovieInfo()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        string text = String.Join(
        Environment.NewLine,
        "================Display Movie Information===============",
        ""
        );

        Console.WriteLine(text);

        if (Interface._isDisplayingMovieInfo)
        {
            Console.WriteLine(Interface._movieInfoMessage);
        }
        else
        {
            Console.WriteLine("Please enter a valid movie title:\n\nTitle: ");
        }
    }

    public static void RenderMemberReturnMovie()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        string text = String.Join(
        Environment.NewLine,
        "==================Member Return Movie===================",
        "",
        "Please select a movie to return:",
        ""
        );
        Console.WriteLine(text);

        if (Interface._borrowedMovies == null)
        {
            return;
        }

        if (Interface._hasReturnedMovie)
        {
            Console.WriteLine(Interface._returnMessage);
        }
        else
        {
            for (int i = 0; i < Interface._borrowedMovies.Length; i++)
            {
                if (Interface._borrowedMovies[i] == null)
                {
                    break;
                }

                Console.WriteLine(i + 1 + ". " + Interface._borrowedMovies[i].Title);
            }
        }
    }

    public static void RenderMemberBorrowMovie()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        string text = String.Join(
        Environment.NewLine,
        "==================Member Borrow Movie===================",
        "",
        "Please select a movie to borrow:",
        ""
        );
        Console.WriteLine(text);

        if (Interface._borrowableMovies == null)
        {
            return;
        }

        if (Interface._hasBorrowedMovie)
        {
            Console.WriteLine(Interface._borrowMessage);
        }
        else
        {
            for (int i = 0; i < Interface._borrowableMovies.Length; i++)
            {
                if (Interface._borrowableMovies[i] == null)
                {
                    break;
                }

                Console.WriteLine(i + 1 + ". " + Interface._borrowableMovies[i].Title);
            }
        }
    }
    public static void RenderMemberBorrowedMovies()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        string text = String.Join(
        Environment.NewLine,
        "=================Display Borrowed Movies================",
        "",
        "Your current borrowed movies:",
        ""
        );
        Console.WriteLine(text);

        if (Interface._borrowedMovies == null)
        {
            return;
        }

        for (int i = 0; i < Interface._borrowedMovies.Length; i++)
        {
            if (Interface._borrowedMovies[i] == null)
            {
                break;
            }

            Console.WriteLine(i + 1 + ". " + Interface._borrowedMovies[i].Title);
        }
    }

    public static void RenderMemberTop3Movies()
    {
        if (Interface._topThreeMovies[0] == null)
        {
            return;
        }

        int[] topThreeMoviesNum = new int[3];
        for (int i = 0; i < 3; i++)
        {
            topThreeMoviesNum[i] = Interface._topThreeMovies[i].NoBorrowings;
        }

        string text = String.Join(
        Environment.NewLine,
        "=======================Top 3 Movies=====================",
        "",
        "Top 3 movies borrowered by members:",
        Interface._topThreeMovies[0].Title + ": " + topThreeMoviesNum[0],
        Interface._topThreeMovies[1].Title + ": " + topThreeMoviesNum[1],
        Interface._topThreeMovies[2].Title + ": " + topThreeMoviesNum[2]
        );

        Console.WriteLine(text);
    }



}
