using System.IO;
using System.Runtime.InteropServices.Marshalling;
public class GoalManager
{
    private int _score;
    private List<Goal> _goalsList;
    public GoalManager()
    {
        
    }
    public void DisplayUserInfo()
    {
        Console.WriteLine($"User Score: {_score}");
    }
    public void CreateGoal()
    {
        int userInput = 5;
        while (userInput != 4)
        {
            Console.Write(""); //TODO
            userInput = int.Parse(Console.ReadLine());

            if (userInput == 1) //SimpleGoal
            {
                string goalName = GetString("What is a name for this goal?");
                string goalDesc = GetString($"What is a short description for '{goalName}'");
                int goalValue = GetInt($"What is the point value for'{goalName}'");

                SimpleGoal newGoal = new SimpleGoal (goalName, goalDesc, goalValue);
                _goalsList.Add(newGoal);

                Console.WriteLine("Simple Goal Created!");
                break;
            }
            else if (userInput == 2) //EternalGoal
            {
                string goalName = GetString("What is a name for this goal?");
                string goalDesc = GetString($"What is a short description for '{goalName}'");
                int goalValue = GetInt($"What is the point value for'{goalName}'");

                EternalGoal newGoal = new EternalGoal (goalName, goalDesc, goalValue);
                _goalsList.Add(newGoal);
                
                Console.WriteLine("Eternal Goal Created!");
                break;
            }
            else if (userInput == 3) //ChecklistGoal
            {
                string goalName = GetString("What is a name for this goal?");
                string goalDesc = GetString($"What is a short description for '{goalName}'");
                int goalValue = GetInt($"What is the point value for'{goalName}'");
                int target = GetInt($"How many times should you do this goal before it is completed?");
                int bonus = GetInt($"How many bonus points should be won upon completion?");

                CheckListGoal newGoal = new CheckListGoal(goalName, goalDesc, goalValue, target, bonus);
                _goalsList.Add(newGoal);
                
                Console.WriteLine("Checklist Goal Created!");
                break;
            }
            else
            {
                Console.WriteLine("Please Enter A Valid Option.");
            }
        }
    }
    public string GetString(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        string userInput = Console.ReadLine();
        return userInput;
    }
    public int GetInt(string prompt)
    {
        Console.WriteLine(prompt);
        Console.Write("> ");
        int userInput = int.Parse(Console.ReadLine());
        return userInput;
    }
    public void DisplayGoals()
    {
        //TODO
    }
    public void DisplayGoalsInfo()
    {
        //TODO
    }
    public void RecordEvent()
    {
        //TODO
    }
    public void SaveGoals(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goalsList)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadGoals(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(":");
            string goalType = parts[0];
            string goalData = parts[1];

            string[] data = goalData.Split("|");

            if (goalType == "SimpleGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);

                SimpleGoal newGoal = new SimpleGoal(name, description, points, isComplete);
                if (isComplete == true)
                {
                    newGoal.IsComplete();
                }
                _goalsList.Add(newGoal);
            } 
            else if (goalType == "EternalGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                EternalGoal newGoal = new EternalGoal(name, description, points);
                _goalsList.Add(newGoal);
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);
                int bonusPoints = int.Parse(data[4]);
                int timesCompleted = int.Parse(data[5]);
                int targetAmount = int.Parse(data[6]);

                CheckListGoal newGoal = new CheckListGoal(name, description, points, targetAmount, bonusPoints, timesCompleted, isComplete);
                _goalsList.Add(newGoal);
            }
        }
    }
}