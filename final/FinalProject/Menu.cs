public class Menu //INCOMPLETE
{
    private HouseManager HM = new HouseManager();
    public Menu()
    {
        
    }
    public void Run()
    {
        
    }
    public int GetInt(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        int userInput = int.Parse(Console.ReadLine());
        return userInput;
    }
    public string GetStr(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        string userInput = Console.ReadLine();
        return userInput;
    }
}