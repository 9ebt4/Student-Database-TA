string[] name = { "ethan", "justin", "billy", "jeff" };
string[] hometown = { "rolla", "ohio", "billyland", "jefferson" };
string[] food = { "wings", "tacos", "goats", "twenty dollar bills" };
bool runProgram = true;

while (runProgram)
{
    while (true)
    {
        Console.WriteLine("View students? y/n");
        string response = Console.ReadLine().Trim().ToLower();
        if(response == "y")
        {
            Console.WriteLine("Available students to choose from.");
            for (int i = 1; i < name.Length + 1; i++)
            {
                Console.WriteLine($"{i}. {name[i - 1]}");
            }
            break;
        }
        else if(response == "n")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid response. Please only use y/n.");
        }
    }
    
    int input = -1;
    
    Console.WriteLine("Would you like to use the index or the students name? number/name");
    while(true)
    {
        string response = Console.ReadLine().Trim().ToLower();
        if(response == "number")
        {
            while (input < 0 || input > name.Length)
            {
                Console.WriteLine($"Please enter a number between 1 and {name.Length}");
                input = GetUserInput() - 1;

            }
            Console.WriteLine($"You chose {name[input]}");
            break;
        }
        else if (response == "name")
        {
            while (true)
            {
                Console.WriteLine("Please enter a name.");
                response = Console.ReadLine().ToLower().Trim();
                if(name.Any(n => n.Equals(response)))
                {
                    input = Array.IndexOf(name, response);
                    break;
                }
                else
                {
                    Console.WriteLine("Name is invalid. Please try again.");
                }
            }
            break;
        }
        else
        {
            Console.WriteLine("Invalid entry please try again.");
        }
    }
    

    string answer = null;
    while(true)
    {
        Console.WriteLine("Choose hometown, favorite food or both. (hometown/favorite food/ both");
        answer = Console.ReadLine().ToLower().Trim();
        if (answer.Contains("home") || answer.Contains("town"))
        {
            Console.WriteLine($"{name[input]} was born in {hometown[input]}.");
            break;
        }
        else if(answer.Contains("fav") || answer.Contains("food"))
        {
            Console.WriteLine($"{name[input]} was likes {food[input]}.");
            break;
        }
        else if (answer.Contains("both"))
        {
            Console.WriteLine($"{name[input]} was born in {hometown[input]} and likes {food[input]}.");
            break;
        }
        else
        {
            Console.WriteLine("Invalid response: please enter hometown/");
            answer = null;
        }
    }
    runProgram = Continue();                                                            
}

static int GetUserInput()
{
    while (true)
    {
        try
        {
            return int.Parse(Console.ReadLine().Trim());
        }
        catch (FormatException)
        {
            Console.WriteLine("Only use whole numbers with no spaces, letters or symbols.");
        }
    }    
}

static bool Continue()
{
    while (true)
    {
        Console.WriteLine("View another student? y/n");
        string input = Console.ReadLine().ToLower().Trim();
        if(input == "y")
        {
            return true;
        }
        if(input == "n")
        {
            Console.WriteLine("Have a good day");
            return false;
        }
        else
        {
            Console.WriteLine("Please only use lower case y or n with no numbers or symbols.");
        }
    }
}