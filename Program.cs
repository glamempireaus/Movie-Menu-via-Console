using System;


internal class Program
{
    public static bool keepRunning = true;
    public static bool keepRendering = true;

    public static bool loggedInAsStaff = true;
    public static bool loggedInAsMember = true;

    public static MemberCollection members = new MemberCollection(20);
    public static MovieCollection movies = new MovieCollection();

    public static Member member1 = new Member("Charlie", "Bumfluff", "0413802381", "41986");

    static void Main(string[] args)
    {
        // intialise program instances
        Program.Init();

        // initialise gui system
        Interface.Init();

        // initialise gui rendering
        Render.Init(); 

        while (keepRunning)
        {
            Interface.Loop();

            if (keepRendering)
            {
                Render.Loop();
            }
        }

        return;
    }
    public static void Init()
    {
        // init members

        Member member2 = new Member("Alex", "Nasty", "0403328381", "32333");
        Member member3 = new Member("Alex", "November", "0403910289", "3192");
        Member member4 = new Member("Jimmy", "Fallon", "0411028382", "15982");
        Member member5 = new Member("Craig", "Buttworth", "0403320919", "3192");

        // init a member collection

        members.Add(member1);
        members.Add(member2);
        members.Add(member3);
        members.Add(member4);
        members.Add(member5);

        // init some starter movies    

        Movie movie1 = new Movie("Murder21", MovieGenre.Drama, MovieClassification.M15Plus, 5, 30);
        Movie movie2 = new Movie("Oprah Winfrey", MovieGenre.Comedy, MovieClassification.PG, 5, 15);
        Movie movie3 = new Movie("Survivor", MovieGenre.Drama, MovieClassification.M, 5, 24);
        Movie movie4 = new Movie("Californication", MovieGenre.Comedy, MovieClassification.M15Plus, 5, 21);

        movies.Insert(movie1);
        movies.Insert(movie2);
        movies.Insert(movie3);
        movies.Insert(movie4);

        // add some borrowers

        movie1.AddBorrower(member1);
        movie1.AddBorrower(member2);
        movie1.AddBorrower(member3);
        movie1.AddBorrower(member4);
        movie1.AddBorrower(member5);

        movie2.AddBorrower(member1);
        movie2.AddBorrower(member2);
        movie2.AddBorrower(member3);

        movie3.AddBorrower(member1);
        movie3.AddBorrower(member3);

        movie4.AddBorrower(member5);
    }
}