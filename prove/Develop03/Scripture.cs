public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private Random _random = new Random();

    public Scripture(string verse, Reference reference)
    {
        _reference = reference;
        _words = verse.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.Display()}");
        Console.WriteLine(string.Join(" ", _words.Select(w => w.Display())));
        Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
    }

    public bool AllHidden() => _words.All(w => w.IsHidden());
}