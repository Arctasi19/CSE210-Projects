public class Journal
{
    public List<Entry> _entries = [];

    public void DisplayAll()
    {
        Console.WriteLine("Displaying All Journal Entries:");
        Console.WriteLine("-------------------------------");
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("-------------------------------");
        }
    }
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._mood}");
            }
        }
    }
    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(file);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            string date = parts[0];
            string prompt = parts[1];
            string text = parts[2];
            string mood = parts[3];

            Entry newEntry = new Entry();
            newEntry._date = date;
            newEntry._promptText = prompt;
            newEntry._entryText = text;
            newEntry._mood = mood;

            _entries.Add(newEntry);
        }
    }
}