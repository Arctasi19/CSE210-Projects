public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;

    public void Display()
    {
        Console.WriteLine($"Date: {this._date}");
        Console.WriteLine($"Prompt: {this._promptText}");
        Console.WriteLine($"Entry: \n{this._entryText}");
    }
}