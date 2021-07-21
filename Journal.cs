using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JournalApp
{
    class Journal
    {
        private string JournalFile = "MyJournal.txt";

        public void Run()
        {
            Console.Title = "Journal App";
            DisplayIntro();
            Menu();
            DisplayOutro();
        }

        private void Menu()
        {
            bool running = true;

            Console.Clear();
            while(running)
            {
                Console.WriteLine("\nChoose one of the options below : " +
                                  "\n - 1. Create the journal" +
                                  "\n - 2. Read the journal." +
                                  "\n - 3. Clear the journal." +
                                  "\n - 4. Add to the journal." +
                                  "\n - 5. Quit");
                Console.Write("\n >>> ");
                int choice = Convert.ToInt32(Console.ReadLine().Trim());

                switch (choice)
                {
                    case 1:
                        CreateJournalFile();
                        break;
                    case 2:
                        DisplayJournalContents();
                        break;
                    case 3:
                        ClearFile();
                        break;
                    case 4:
                        AddEntry();
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease choose a number between 1-5!");
                        WaitForKey();
                        Menu();
                        break;
                }
            } 
        }

        private void CreateJournalFile()
        {
            if (!File.Exists(JournalFile))
            {
                File.CreateText(JournalFile);
                Console.WriteLine($"\n{JournalFile} file has been created!");
            }
            Console.WriteLine($"\n{JournalFile} file already exists!");
            WaitForKey();
        }

        private void DisplayIntro()
        {
            Console.WriteLine(@"(\ 
\'\ 
 \'\     __________  
 / '|   ()_________)
 \ '/    \ ~~~~~~~~ \
   \       \ ~~~~~~~~ \
   ==).      \__________\
  (__)       ()__________)");
            Console.WriteLine("\nWelcome to the Journal App!");
            WaitForKey();
        }

        private void DisplayOutro()
        {
            Console.WriteLine("\nThank you, for using this app!");
            WaitForKey();
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }

        private void DisplayJournalContents()
        {
            string journalTxt = File.ReadAllText(JournalFile);
            Console.WriteLine($"\n +---+ Journal Contents : +---+\n{journalTxt}\n" +
                               "+------------------------------+");
            WaitForKey();
        }

        private void ClearFile()
        {
            File.WriteAllText(JournalFile, "");
            Console.WriteLine($"\n{JournalFile} file has been cleared!");
            WaitForKey();
        }

        private void AddEntry()
        {
            // Basic Version
            //Console.WriteLine("\nEdit your journal here : ");
            //Console.Write(" >>> ");
            //string txt = Console.ReadLine();
            //Console.WriteLine("\nJournal has been modified!");
            //WaitForKey();

            //File.AppendAllText(JournalFile, $"\nEntry : \n => {txt}\n");

            // Advanced Version
            Console.WriteLine("\nEdit your journal here : (Type 'EXIT' and press enter to stop.)");

            Console.Write(" >>> ");
            string newEntry = "";
            bool shouldContinue = true;

            while (shouldContinue)
            {
                string line = Console.ReadLine();
                if (line.ToLower().Trim() == "exit")
                {
                    if (line.Contains("=>"))
                    {
                        line.Replace("=>", newEntry);
                    }
                    shouldContinue = false;
                }
                else
                {
                    Console.Write(" >>> ");
                    newEntry += "\n => " + line;
                }
            }

            File.AppendAllText(JournalFile, $"\nEntry : {newEntry}\n");
            Console.WriteLine("\nJournal has been modified!");
            WaitForKey();

            
        }
    }
}
