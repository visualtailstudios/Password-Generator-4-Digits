using System;
using System.IO;

class Generator
{
    static void Main()
    {
        Random rand = new Random();
        string root = Path.Combine(AppContext.BaseDirectory, "My Screen Time Password");
        int password = rand.Next(1000, 9999);
        int topfolders = 200;
        int directories = 20;
        int theFile = 13;
        int max = directories;

        Directory.CreateDirectory(root);

        const string chars = "jjnsdhyufjbeijhgiuajnduihuhjnvihsfdnj23897fsda";
        string[] paths = new string[topfolders];
        for (int i = 0; i < topfolders; i++)
        {
            string current = root;
            current = Path.Combine(current, RandomString(chars, rand, RandomInt(rand, 6, 14)));

            for (int d = 0; d < max; d++)
            {
                current = Path.Combine(current, RandomString(chars, rand, RandomInt(rand, 6, 14)));
            }

            Directory.CreateDirectory(current);
            paths[i] = current;
        }
        
        for (int f = 0; f < theFile; f++)
        {
            int pick = rand.Next(paths.Length);
            string targetDir = paths[pick];

            string fileName = "password.txt";
            string filePath = Path.Combine(targetDir, fileName);

            File.WriteAllText(filePath, password.ToString());
            int chance = rand.Next(0, 999999999);
            if(chance==473974749) Console.WriteLine($"> Wrote password {password}<");
            else Console.WriteLine("> Wrote password <");
        }
    }
    
    static string RandomString(string alphabet, Random rand, int length)
    {
        char[] buffer = new char[length];
        for (int i = 0; i < length; i++)
            buffer[i] = alphabet[rand.Next(alphabet.Length)];
        return new string(buffer);
    }
    
    static int RandomInt(Random rand, int minInclusive, int maxInclusive)
        => rand.Next(minInclusive, maxInclusive + 1);
}