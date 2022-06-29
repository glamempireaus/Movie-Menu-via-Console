using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Interface
{
    // session
    public static ParentMenu currentParentMenu = ParentMenu.MAIN_MENU;
    public static ChildMenu currentChildMenu = ChildMenu.NONE;

    // data which Render.cs reads, and can potentially modify -> marked with _

    public static string _addMovieMessage = "";
    public static bool _hasAddedMovie = false;

    public static string _deleteMovieMessage = "";
    public static bool _hasDeletedMovie = false;

    public static string _registerMemberMessage = "";
    public static bool _hasRegisteredMember = false;

    public static string _deleteMemberMessage = "";
    public static bool _hasDeletedMember = false;

    public static string _phoneNumberMessage = "";
    public static string _phoneNumberErrorMessage = "";
    public static bool _isDisplayingPhoneNumber = false;

    public static string _movieParticipantsMessage = "";
    public static string _movieParticipantsErrorMessage = "";
    public static bool _isDisplayingMovieParticipants = false;


    public static IMovie[] _topThreeMovies = new IMovie[3];

    public static IMovie[] _borrowableMovies = null;
    public static string _borrowMessage = "";
    public static bool _hasBorrowedMovie = false;

    public static IMovie[] _borrowedMovies = null;
    public static string _returnMessage = "";
    public static bool _hasReturnedMovie = false;


    public static string _movieInfoMessage = "";
    public static string _movieInfoErrorMessage = "";
    public static bool _isDisplayingMovieInfo = false;

    public static bool _forceRender = false; 

    public enum ParentMenu
    {
        NULL = -1,
        MAIN_MENU = 1,
        MEMBER_MENU = 2,
        STAFF_MENU = 3,
    }

    public enum ChildMenu
    {
        NULL = -1,
        NONE = 0,
        STAFF_LOGIN = 1,
        MEMBER_LOGIN = 2,
        MEMBER_BROWSE_MOVIES = 3,
        MEMBER_DISPLAY_MOVIE_INFO = 4,
        MEMBER_BORROWED_MOVIES = 5,
        MEMBER_RETURN_MOVIE = 6,
        MEMBER_LIST_BORROWED_MOVIES = 7,
        MEMBER_TOP_3_MOVIES = 8,
        STAFF_ADD_DVD = 9,
        STAFF_DELETE_DVD = 10,
        STAFF_REGISTER_MEMBER = 11,
        STAFF_DELETE_MEMBER = 12,
        STAFF_DISPLAY_PHONE_NUMBER = 13,
        STAFF_DISPLAY_MOVIE_PARTICIPANTS = 14,
    }

    public static void Init()
    {

    }

    public static void Loop()
    {
        // MAIN MENUS
        if (currentChildMenu == ChildMenu.NONE)
        {
            switch (currentParentMenu)
            {
                case ParentMenu.MAIN_MENU:

                    MainMenu();

                    break;

                case ParentMenu.MEMBER_MENU:

                    MemberMenu();

                    break;

                case ParentMenu.STAFF_MENU:

                    StaffMenu();

                    break;
            }
        }

        // CHILD MENUS
        else
        {
            switch (currentChildMenu)
            {
                case ChildMenu.STAFF_LOGIN:

                    StaffLogin();

                    break;

                case ChildMenu.MEMBER_LOGIN:

                    MemberLogin();

                    break;

                case ChildMenu.STAFF_ADD_DVD:

                    StaffAddMovie();

                    break;

                case ChildMenu.STAFF_DELETE_DVD:

                    StaffDeleteMovie();

                    break;

                case ChildMenu.STAFF_REGISTER_MEMBER:

                    StaffRegisterMember();

                    break;


                case ChildMenu.STAFF_DELETE_MEMBER:

                    StaffDeleteMember();

                    break;

                case ChildMenu.STAFF_DISPLAY_PHONE_NUMBER:

                    StaffDisplayPhoneNumber();

                    break;

                case ChildMenu.STAFF_DISPLAY_MOVIE_PARTICIPANTS:

                    StaffDisplayMovieParticipants();

                    break;

                case ChildMenu.MEMBER_BROWSE_MOVIES:

                    MemberBrowseAllMovies();

                    break;

                case ChildMenu.MEMBER_DISPLAY_MOVIE_INFO:

                    MemberDisplayMovieInfo();

                    break;

                case ChildMenu.MEMBER_BORROWED_MOVIES:

                    MemberBorrowMovie();

                    break;

                case ChildMenu.MEMBER_RETURN_MOVIE:

                    MemberReturnMovie();

                    break;

                case ChildMenu.MEMBER_LIST_BORROWED_MOVIES:

                    MemberDisplayBorrowedMovies();

                    break;

                case ChildMenu.MEMBER_TOP_3_MOVIES:

                    MemberGetTop3Movies();

                    break;
            }
        }
    }

    public static void MainMenu()
    {
        int input = Input.GetNumberFromKeyboardInput();

        switch (input)
        {
            case 1:

                if (Program.loggedInAsStaff)
                {
                    currentParentMenu = ParentMenu.STAFF_MENU;
                }
                else
                {
                    currentChildMenu = ChildMenu.STAFF_LOGIN;
                }
                
                break;

            case 2:

                if (Program.loggedInAsMember)
                {
                    currentParentMenu = ParentMenu.MEMBER_MENU;
                }
                else
                {
                    currentChildMenu = ChildMenu.MEMBER_LOGIN;
                }


                break;

            case 0:

                Program.keepRunning = false;
                break;
        }

    }

    public static void MemberMenu()
    {
        int input = Input.GetNumberFromKeyboardInput();

        switch (input)
        {
            case 1:

                currentChildMenu = ChildMenu.MEMBER_BROWSE_MOVIES;
                break;

            case 2:

                currentChildMenu = ChildMenu.MEMBER_DISPLAY_MOVIE_INFO;
                break;

            case 3:

                currentChildMenu = ChildMenu.MEMBER_BORROWED_MOVIES;
                break;

            case 4:

                currentChildMenu = ChildMenu.MEMBER_RETURN_MOVIE;
                break;

            case 5:

                currentChildMenu = ChildMenu.MEMBER_LIST_BORROWED_MOVIES;
                break;

            case 6:

                currentChildMenu = ChildMenu.MEMBER_TOP_3_MOVIES;
                break;

            case 0:
                currentChildMenu = ChildMenu.NONE;
                currentParentMenu = ParentMenu.MAIN_MENU;
                break;
        }
    }

    public static void StaffMenu()
    {
        Render.Loop();
        int input = Input.GetNumberFromKeyboardInput();

        switch (input)
        {
            case 1:

                currentChildMenu = ChildMenu.STAFF_ADD_DVD;
                break;

            case 2:

                currentChildMenu = ChildMenu.STAFF_DELETE_DVD;
                break;

            case 3:

                currentChildMenu = ChildMenu.STAFF_REGISTER_MEMBER;
                break;

            case 4:

                currentChildMenu = ChildMenu.STAFF_DELETE_MEMBER;
                break;

            case 5:

                currentChildMenu = ChildMenu.STAFF_DISPLAY_PHONE_NUMBER;
                break;

            case 6:

                currentChildMenu = ChildMenu.STAFF_DISPLAY_MOVIE_PARTICIPANTS;
                break;

            case 0:
                currentChildMenu = ChildMenu.NONE;
                currentParentMenu = ParentMenu.MAIN_MENU;
                break;
        }
    }

    public static void MemberLogin()
    {
        Render.Loop();

        string firstName = Input.GetFullKeyboardInput(true, 8, 12, true);

        if (firstName == "0")
        {
            currentChildMenu = ChildMenu.NONE;
            return;
        }

        string lastName = Input.GetFullKeyboardInput(true, 9, 11, false);
        string pin = Input.GetMultipleNumbersFromKeyboardInput(false, 10, 10);

        int checkMemberCredentials = Login.CheckMemberCredentials(firstName, lastName, pin);

        if (checkMemberCredentials == 1)
        {
            Program.loggedInAsMember = true;
            currentChildMenu = ChildMenu.NONE;
            currentParentMenu = ParentMenu.MEMBER_MENU;
        }
        else
        {
            _forceRender = true;
        }
    }

    public static void StaffLogin()
    {
        Render.Loop();

        string username = Input.GetFullKeyboardInput(true, 8, 10, true);

        if (username == "0")
        {
            currentChildMenu = ChildMenu.NONE;
            return;
        }

        string password = Input.GetFullKeyboardInput(false, 9, 10, false);

        int checkStaffCredentials = Login.CheckStaffCredentials(username, password);

        if (checkStaffCredentials == 1)
        {
            Program.loggedInAsStaff = true;
            currentChildMenu = ChildMenu.NONE;
            currentParentMenu = ParentMenu.STAFF_MENU;
        }
        else
        {
            _forceRender = true;
        }
    }

    public static void StaffAddMovie()
    {
        // get keyboard input

        string input = Input.GetFullKeyboardInput(true, 8, 7, true);

        if (input == "0")
        {
            if (_hasAddedMovie)
            {
                _hasAddedMovie = false;
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
                _addMovieMessage = "";

                return;
            }
        }

        string movieTitle = input;

        input = Input.GetFullKeyboardInput(true, 9, 7, false);

        MovieGenre movieGenre;

        if (!Enum.TryParse<MovieGenre>(input, out movieGenre))
        {
            _addMovieMessage = "Error: Invalid genre";
            _forceRender = true;
            return;
        }

        input = Input.GetFullKeyboardInput(true, 10, 16, false);

        MovieClassification movieClassification;

        if (!Enum.TryParse<MovieClassification>(input, out movieClassification))
        {
            _addMovieMessage = "Error: Invalid genre";
            _forceRender = true;
            return;
        }

        input = Input.GetMultipleNumbersFromKeyboardInput(true, 11, 10);
        int movieDuration = Int32.Parse(input);

        input = Input.GetMultipleNumbersFromKeyboardInput(true, 12, 18);
        int movieAvailableCopies = Int32.Parse(input);

        if (Program.movies.Search(movieTitle) != null)
        {
            _addMovieMessage = "Error: Movie name already exists. Please try another name.";
            _forceRender = true;
            return;
        }

        // set movie

        Movie movie = new Movie(movieTitle, movieGenre, movieClassification, movieDuration, movieAvailableCopies);

        Program.movies.Insert(movie);

        _addMovieMessage = "You've successfully added the movie: " + movieTitle;
        _forceRender = true;
    }

    public static void StaffDeleteMovie()
    {
        // fetch all movies

        IMovie[] moviesArray = Program.movies.ToArray();

        // render list and get keyboard input

        _forceRender = true;
        Render.Loop(); // negate the hang

        int input = Input.GetNumberFromKeyboardInput();

        if (input == 0)
        {
            _deleteMovieMessage = "";
            if (_hasDeletedMovie)
            {
                _hasDeletedMovie = false;
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
            }

            return;
        }

        // check for invalid input
        if (input > moviesArray.Length || moviesArray[input - 1] == null)
        {
            return;
        }

        // find and delete movie

        Movie movie = (Movie)Program.movies.Search(moviesArray[input - 1].Title);

        Program.movies.Delete(movie);

        // set delete message

        _deleteMovieMessage = "You've deleted: " + movie.Title;
        _hasDeletedMovie = true;
    }

    public static void StaffRegisterMember()
    {
        // get keyboard input

        string input = Input.GetFullKeyboardInput(true, 8, 12, true);

        if (input == "0")
        {
            currentChildMenu = ChildMenu.NONE;
            _registerMemberMessage = "";
            return;
        }

        string firstName = input;

        input = Input.GetFullKeyboardInput(true, 9, 11, false);
        string lastName = input;

        input = Input.GetMultipleNumbersFromKeyboardInput(false, 10, 25);
        string pin = input;

        if (!IMember.IsValidPin(pin))
        {
            _registerMemberMessage = "Error: Invalid pin number. (Must be 4 - 6 digits long)";
            _forceRender = true;
            return;
        }

        input = Input.GetFullKeyboardInput(true, 11, 15, false);
        string phoneNumber = input;

        if (!IMember.IsValidContactNumber(phoneNumber))
        {
            _registerMemberMessage = "Error: Invalid phone number. (Must start with 0, and be 10 digits long.)";
            _forceRender = true;
            return;
        }

        // check for duplicate
        if (Program.members.Search(firstName, lastName) != null)
        {
            _registerMemberMessage = "Error: User already exists. Please try again.";
            _forceRender = true;
            return;
        }

        Member member = new Member(firstName, lastName, phoneNumber, pin);

        Program.members.Add(member);

        _registerMemberMessage = "You've successfully registered member: " + firstName + " " + lastName;
        _forceRender = true;

    }

    public static void StaffDeleteMember()
    {
        // render list and get keyboard input

        _forceRender = true;
        Render.Loop(); // negate the hang

        int input = Input.GetNumberFromKeyboardInput();

        if (input == 0)
        {
            _deleteMovieMessage = "";
            if (_hasDeletedMember)
            {
                _hasDeletedMember = false;
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
            }

            return;
        }

        // check for invalid input
        if (input > Program.members.Number - 1)
        {
            return;
        }

        // find and delete movie

        Member member = Program.members.members[input - 1];

        Program.members.Delete(member);

        // set delete message

        _deleteMovieMessage = "You've deleted member: " + member.FirstName + " " + member.LastName;
        _hasDeletedMember = true;
    }

    public static void StaffDisplayPhoneNumber()
    {
        // get keyboard input and check if user pressed 0

        string input;
        if (_isDisplayingPhoneNumber)
        {
            input = Input.GetNumberFromKeyboardInput().ToString();
        }
        else
        {
            input = Input.GetFullKeyboardInput(true, 8, 12, true);
        }

        if (Int32.TryParse(input, out _) && Int32.Parse(input) == 0)
        {
            if (_isDisplayingPhoneNumber)
            {
                _phoneNumberMessage = "";
                _isDisplayingPhoneNumber = false;
                _forceRender = true;
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
                _phoneNumberErrorMessage = "";
            }
            return;
        }

        string firstName = input;
        string lastName = Input.GetFullKeyboardInput(true, 9, 11, true);

        IMember searchedMember = Program.members.Search(firstName, lastName);

        if (searchedMember != null)
        {
            _phoneNumberMessage = searchedMember.FirstName + "'s contact number is:" +
                "\n\n" + searchedMember.ContactNumber.ToString();

            _isDisplayingPhoneNumber = true;
            _phoneNumberErrorMessage = "";
        }
        else
        {
            _phoneNumberErrorMessage = "Error: Invalid contact number";
        }
        _forceRender = true;
        Render.Loop();
    }

    public static void StaffDisplayMovieParticipants()
    {
        string input = Input.GetFullKeyboardInput(true, 8, 7, true);

        if (input == "0")
        {
            if (_isDisplayingMovieParticipants)
            {
                _isDisplayingMovieParticipants = false;
                _movieParticipantsErrorMessage = "";
                _forceRender = true;
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
            }
            return;
        }

        // try input

        Movie movie = (Movie)Program.movies.Search(input);

        if (movie == null)
        {
            _movieParticipantsErrorMessage = "Error: Couldn't find movie title.";
        }
        else
        {
            _movieParticipantsMessage = movie.Borrowers.ToString();
            _movieParticipantsErrorMessage = "";
            _isDisplayingMovieParticipants = true;
        }

        _forceRender = true;
    }

    public static void MemberBrowseAllMovies()
    {
        int input = Input.GetNumberFromKeyboardInput();

        if (input == 0)
        {
            currentChildMenu = ChildMenu.NONE;
        }
    }

    public static void MemberDisplayMovieInfo()
    {
        // get keyboard input and check if user pressed 0

        string input;
        if (_isDisplayingMovieInfo)
        {
            input = Input.GetNumberFromKeyboardInput().ToString();
        }
        else
        {
            input = Input.GetFullKeyboardInput(true, 8, 7, true);
        }

        if (Int32.TryParse(input, out _) && Int32.Parse(input) == 0)
        {
            if (_isDisplayingMovieInfo)
            {
                _movieInfoMessage = "";
                _isDisplayingMovieInfo = false;
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
            }
        }

        string titleInput = input;

        IMovie searchedMovie = Program.movies.Search(titleInput);

        if (searchedMovie != null)
        {
            _movieInfoMessage = "Title: " + searchedMovie.Title +
                "\nDuration: " + searchedMovie.Duration + " minutes" +
                "\nClassification: " + searchedMovie.Classification +
                "\nGenre: " + searchedMovie.Genre +
                "\nBorrowers: " + searchedMovie.NoBorrowings +
                "\nTotal Copies: " + searchedMovie.TotalCopies;

            _isDisplayingMovieInfo = true;
        }
        _forceRender = true;
        Render.Loop();
    }



    public static void MemberBorrowMovie()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        // fetch borrowable movies

        _borrowableMovies = new IMovie[moviesArray.Length];

        int index = 0;
        for (int i = 0; i < moviesArray.Length; i++)
        {
            if (!moviesArray[i].Borrowers.Search(Login.loggedInMember))
            {
                _borrowableMovies[index] = moviesArray[i];
                index++;
            }
        }

        // render list and get keyboard input

        _forceRender = true;
        Render.Loop(); // negate the hang

        int input = Input.GetNumberFromKeyboardInput();

        if (input == 0)
        {
            if (_hasBorrowedMovie)
            {
                _hasBorrowedMovie = false;
                _borrowMessage = "";
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
            }

            return;
        }

        if (input > _borrowableMovies.Length || _borrowableMovies[input - 1] == null)
        {
            return;
        }

        // add borrowed movie

        _borrowableMovies[input-1].Borrowers.Add(Login.loggedInMember);

        // set borrow message

        _borrowMessage = "You're now borrowing: " + _borrowableMovies[input - 1].Title;
        _hasBorrowedMovie = true;
    }

    public static void MemberReturnMovie()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        // fetch borrowed movies

        _borrowedMovies = new IMovie[moviesArray.Length];

        int index = 0;
        for (int i = 0; i < moviesArray.Length; i++)
        {
            if (moviesArray[i].Borrowers.Search(Login.loggedInMember))
            {
                _borrowedMovies[index] = moviesArray[i];
                index++;
            }
        }

        // render list and get keyboard input

        _forceRender = true;
        Render.Loop(); // negate the hang

        int input = Input.GetNumberFromKeyboardInput();

        if (input == 0)
        {
            if (_hasReturnedMovie)
            {
                _hasReturnedMovie = false;
                _returnMessage = "";
            }
            else
            {
                currentChildMenu = ChildMenu.NONE;
            }

            return;
        }
        
        if (input > _borrowedMovies.Length || _borrowedMovies[input - 1] == null)
        {
            return;
        }

        // delete borrowed movie

        _borrowedMovies[input - 1].Borrowers.Delete(Login.loggedInMember);

        // set return message

        _returnMessage = "You've returned: " + _borrowedMovies[input - 1].Title;
        _hasReturnedMovie = true;

    }

    public static void MemberDisplayBorrowedMovies()
    {
        IMovie[] moviesArray = Program.movies.ToArray();

        _borrowedMovies = new IMovie[moviesArray.Length];

        int index = 0;
        for (int i = 0;i < moviesArray.Length;i++)
        {
            if (moviesArray[i].Borrowers.Search(Login.loggedInMember))
            {
                _borrowedMovies[index] = moviesArray[i];
                index++;
            }
        }

        _forceRender = true;
        Render.Loop();

        int input = Input.GetNumberFromKeyboardInput();
        if (input == 0)
        {
            currentChildMenu = ChildMenu.NONE;
        }
    }

    public static void MemberGetTop3Movies()
    {
        // counting sort: O(n)

        IMovie[] moviesArray = Program.movies.ToArray();

        // fetch max

        IMovie max = moviesArray[0];
        for (int i = 1; i < moviesArray.Length; i++)
        {
            if (moviesArray[i].NoBorrowings > max.NoBorrowings)
            {
                max = moviesArray[i];
            }
        }

        // init int array of max + 1

        int[] moviesArraySorting = new int[max.NoBorrowings + 1];

        // total the occurences of each borrower amount in an array of length: max + 1

        for (int i = 0; i < moviesArray.Length; i++)
        {
            moviesArraySorting[moviesArray[i].NoBorrowings]++;
        }

        // modify array by adding previous values

        for (int i = 1; i < moviesArraySorting.Length; i++)
        {
            moviesArraySorting[i] += moviesArraySorting[i - 1];
        }

        // now we can sort array based on added values in moviesArraySorting

        IMovie[] moviesArraySorted = new IMovie[moviesArray.Length];

        for (int i = 0; i < moviesArray.Length; i++)
        {
            moviesArraySorted[moviesArraySorting[moviesArray[i].NoBorrowings] - 1] = moviesArray[i];
            moviesArraySorting[moviesArray[i].NoBorrowings]--;
        }

        Interface._topThreeMovies[0] = moviesArraySorted[moviesArraySorted.Length - 1];
        Interface._topThreeMovies[1] = moviesArraySorted[moviesArraySorted.Length - 2];
        Interface._topThreeMovies[2] = moviesArraySorted[moviesArraySorted.Length - 3];

        _forceRender = true;
        Render.Loop();

        int input = Input.GetNumberFromKeyboardInput();

        if (input == 0)
        {
            currentChildMenu = ChildMenu.NONE;
        }
    }
}
