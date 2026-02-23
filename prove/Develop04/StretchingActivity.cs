class StretchingActivity : Activity
{
    private List<string> _stretches = [
        "Stretch both arms outwards, reaching to the sides as far as you can.",
        "Stretch both arms upwards, reaching as high as you can.",
        "Bend down and try to touch your toes.",
        "Keeping your feet in place, twist to the right and to the left.",
        "Standing tall, put your chin to your chest. Roll your head slowly from side to side.",
        "Stretch both arms forwards, hands locked together, palms pointing away from you."
    ];
    public StretchingActivity() : base(
        "Stretching Activity",
        "This activity will help you relax by taking you through a few stretching exercises that can be done standing or sitting."
    ) //Constructor
    {
        
    }
    public void Run() //Core Program
    {
        //Starts Program
        StartMessage();
        Console.WriteLine("If you can, stand up! If not, that's okay.");
        Console.WriteLine("Get Ready To Stretch...\n");
        PauseSpinner(5);
        
        //Runs a loop of randomized stretching prompts until time has run out.
        int duration = GetDuration();
        int timer = duration * 1000;
        while (timer > 0)
        {
            string stretch = GetRandomString(_stretches);
            Console.WriteLine($"~~ {stretch} ~~");
            Console.Write("And keep going! Hold...");
            PauseTimer(10);
            Console.WriteLine("\n");
            timer -= 10000;
        }

        //Ends program with common end message
        EndMessage();
    }
}