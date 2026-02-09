using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

public class ScriptureGenerator
{
    private List<(Reference Reference, string Text)> _scriptures;
    private Random _random = new Random();

    public Scripture GetRandomScripture()
    {
        _scriptures = new List <(Reference Reference, string Text)>
        {
            (new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son"),
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thy heart and lean not unto thine own understanding"),
            (new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me"),
            (new Reference("Genesis", 1, 1), "In the beginning God created the heaven and the earth")
        };

        int index = _random.Next(_scriptures.Count);
        var selected = _scriptures[index];
        return new Scripture(selected.Text, selected.Reference);
    }
}