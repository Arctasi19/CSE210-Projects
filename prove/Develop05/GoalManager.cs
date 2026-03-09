using System.IO;
public class GoalManager
{
    private int _score;
    private List<Goal> _goalsList;
    public GoalManager()
    {
        _goalsList = new List<Goal>();
        _score = 0;
    }
    public void DisplayUserInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void CreateGoal()
    {
        int userInput = 5;
        while (userInput != 4)
        {
            Console.WriteLine("The Types of goals are:"); 
            Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");

            userInput = GetInt("Which type of goal would you like to create?");

            if (userInput == 1) //SimpleGoal
            {
                string goalName = GetString("What is the name of your goal?");
                string goalDesc = GetString("What is a short description of it?");
                int goalValue = GetInt("What is the amount of points associated with this goal?");

                SimpleGoal newGoal = new SimpleGoal (goalName, goalDesc, goalValue);
                _goalsList.Add(newGoal);

                Console.WriteLine("Simple Goal Created!");
                break;
            }
            else if (userInput == 2) //EternalGoal
            {
                string goalName = GetString("What is the name of your goal?");
                string goalDesc = GetString("What is a short description of it?");
                int goalValue = GetInt("What is the amount of points associated with this goal?");

                EternalGoal newGoal = new EternalGoal (goalName, goalDesc, goalValue);
                _goalsList.Add(newGoal);
                
                Console.WriteLine("Eternal Goal Created!");
                break;
            }
            else if (userInput == 3) //ChecklistGoal
            {
                string goalName = GetString("What is the name of your goal?");
                string goalDesc = GetString("What is a short description of it?");
                int goalValue = GetInt("What is the amount of points associated with this goal?");
                int target = GetInt("How many times does this goal need to be accomplished for a bonus?");
                int bonus = GetInt("What is the bonus for accomplishing it that many times?");

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
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goalsList.Count; i++)
        {
            Goal goal = _goalsList[i];
            Console.WriteLine($"{i+1}. {goal.GetName()}");
        }
    }
    public void DisplayGoalsInfo()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goalsList.Count; i++)
        {
            Goal goal = _goalsList[i];
            string checkBox = " ";
            if (goal.CheckComplete())
                checkBox = "X";
            Console.WriteLine($"{i+1}. [{checkBox}] {goal.Display()}");
        }
    }
    public void RecordEvent()
    {
        while (true)
        {
            Console.WriteLine();

            DisplayGoals();
            
            int userChoice = GetInt("Which goal did you accomplish? (enter 0 to cancel)");
            if (userChoice > 0 && userChoice <= _goalsList.Count)
            {
                Goal goal = _goalsList[userChoice-1];
                int pointsReceived = goal.RecordEvent();

                _score += pointsReceived;
                Console.WriteLine($"Congratulations! you have earned {pointsReceived} Points!");
                Console.WriteLine($"You now have {_score} points.");
                break;
            }
            else if (userChoice == 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid goal number.");
            }
        }
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
        if (!File.Exists(fileName)) 
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = System.IO.File.ReadAllLines(fileName);
        _score = int.Parse(lines[0]);
        _goalsList.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (!lines.Contains(":")) continue;

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
    public void DeleteGoal()
    {
        if (_goalsList.Count == 0)
        {
            Console.WriteLine("You have no goals to delete.");
            return;
        }

        while (true)
        {
            DisplayGoals();
            int index = GetInt("Which goal would you like to delete? (enter 0 to cancel)") - 1;
            if (index >= 0 && index < _goalsList.Count)
            {
                _goalsList.RemoveAt(index);
                Console.WriteLine("Goal successfully deleted.");
                break;
            }
            else if (index == -1)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid Goal Number");
            } 
        }
    }
}