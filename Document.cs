using System.Text.RegularExpressions;

class Document
{
    public string writeText = string.Empty;
    public string fileName = "sdr.txt"; 

    public void WriteToFile (string ?writeText, string fileName)
    {
        File.WriteAllText(fileName, writeText);  // Create a file and write the content of writeText to it

        string readText = File.ReadAllText(fileName);  // Read the contents of the file
        Console.WriteLine(readText);  // Output the content 
    }
    
    public void DisplayText(string a)
    {
        Console.WriteLine(a);
    }

    public string GetValidatedInput(string prompt)
    {
        string? input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()?.Trim().ToUpper();
            
            if (string.IsNullOrEmpty(input) || IsNumeric(input))
            {
                Console.WriteLine("Input invalid. Please try again.");
            } 

        } while (string.IsNullOrEmpty(input) || IsNumeric(input));

        return input;
    }

    public string GetValidatedName(string prompt)
    {
        string? input;
        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input) || input.Length < 2 || !IsValidName(input))
            {
                Console.WriteLine("Invalid input. Name must be at least 2 letters and contain only alphabetic characters.");
            }

        } while (string.IsNullOrEmpty(input) || input.Length < 2 || !IsValidName(input));

        return input.ToUpper(); // Normalize to uppercase
    }

    public long GetValidatedMRN(string prompt)
    {
        long number;
        string? input;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()?.Trim();

            if (!long.TryParse(input, out number) || input.Length != 7)
            {
                Console.WriteLine("Invalid MRN. Please enter exactly 7 numeric digits.");
            }

        } while (!long.TryParse(input, out number) || input.Length != 7);

        return number;
    }

    public int GetValidatedNumber(string prompt)
    {
        int number;
        string? input;

        do
        {
            Console.WriteLine(prompt);
            input = Console.ReadLine()?.Trim();

            if (!int.TryParse(input, out number) || number < 1 || number > 50)
            {
                Console.WriteLine("Invalid number. Please enter a number between 1 and 50.");
            }

        } while (!int.TryParse(input, out number) || number < 1 || number > 50);

        return number;
    }

    public char GetValidatedChoice(string prompt, char[] validChoices)
    {
        string? input;
        do
        {
            Console.WriteLine($"{prompt} ({string.Join("/", validChoices)}):");
            input = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(input) || input.Length != 1 || !validChoices.Contains(input[0]))
            {
                Console.WriteLine($"Invalid input. Please enter one of the following: {string.Join(", ", validChoices)}.");
            }

        } while (string.IsNullOrEmpty(input) || input.Length != 1 || !validChoices.Contains(input[0]));

        return input[0]; // Return the valid character
    }
    static bool IsValidName(string input)
    {
        return Regex.IsMatch(input, @"^[A-Za-z]+$"); // Ensures only letters (no numbers/symbols)
    }
    static bool IsNumeric(string input)
    {
        return long.TryParse(input, out _);
    }

     
}



