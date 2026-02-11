public class Word
{
    private string _word;
    private bool _hidden_status = true;

    public Word(string word)
    {
        _word = word;
    }

    public void Hide()
    {
        _hidden_status = false;
    }
    public bool IsHidden()
    {
        return !_hidden_status;
    }

    public string Display()
    {
        return _hidden_status ? _word : new string('_', _word.Length);
    }
}