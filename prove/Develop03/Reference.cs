public class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;
    private int _verses;

    public Reference(string book, int chapter, int firstVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _verses = 1;
    }

    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }

    public string Display()
    {
        return _verses == 1 
            ? $"{_book} {_chapter}:{_firstVerse}" 
            : $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
    }
}