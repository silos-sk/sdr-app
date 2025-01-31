using System.IO;
using System.Security.Cryptography.X509Certificates;
class GenereateFile
{
    public string writeText = string.Empty;
    public string fileName = "sdr.txt"; 

    public void WriteToFile (string ?writeText, string fileName)
    {
        File.WriteAllText(fileName, writeText);  // Create a file and write the content of writeText to it

        string readText = File.ReadAllText(fileName);  // Read the contents of the file
        Console.WriteLine(readText);  // Output the content 
    }
     
}



