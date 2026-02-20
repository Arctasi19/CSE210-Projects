public class Scripture
{
    private List<Word> _words;
    private Reference _reference;
    private Random _random = new Random();

    public Scripture(string verse, Reference reference)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string w in verse.Split(' '))
        {
            _words.Add(new Word(w));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                visibleWords.Add(w);
            }
        }
        
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
        List<string> displayWords = new List<string>();
        foreach (Word w in _words)
        {
            displayWords.Add(w.Display());
        }
        string scriptureFull = string.Join(" ", displayWords);
        Console.WriteLine(scriptureFull);
        Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
    }

    public bool AllHidden()
    {
        foreach (Word w in _words)
        {
            if(!w.IsHidden()) return false;
        }
        return true;
    }
}