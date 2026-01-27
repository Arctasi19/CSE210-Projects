using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic;

public class PromptGenerator
{
    public List<string> _prompts = [
        "What is something that made you smile today? ",
        "What made you feel sad today? ",
        "What is something you learned today? ",
        "How did you see the hand of the Lord in your life today?",
        "What was the strongest emotion I felt today?"
        ];

    public string Prompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string randomString = _prompts[index];
        return randomString;
    }
}