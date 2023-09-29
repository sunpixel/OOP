using System;
using System.Runtime.CompilerServices;
using static System.Console;
using System.Collections.Generic;


string[] Options = { "Search", "Exit" };
string prompt = "";

Menu StartMenu = new Menu(Options);

int SelectedIndex = StartMenu.Run();

if (SelectedIndex == 0)
{
    Librarian lib = new Librarian();
}
else if (SelectedIndex == 1)
{
    System.Environment.Exit(0);
}


class SoundLibrary
{
    // All search request have to go here
    private int index;
    private List<string> songs = new();
    private static string[] info;


    public SoundLibrary(in int currentIndex)
    {
        index = currentIndex;
    }

    private void AllSongs() // 0
    {
        string[] list = { "Комарово", "Звездное лето", "Hot & Cold", "Wrecking Ball", "Прекрасное Далёко"};
        append_members(list);
    }

    private void Author()   // 1
    {
        string[] list = { "Игорь Скляр", "Алла Пугачёва", "Katty Perry", "Miley Sirus", "Татьяна Дасковская" };
        append_members(list);
    }

    private void Year() // 3
    {
        string[] list = {"2020", "2021", "2022", "2023" };
        append_members(list);
    }

    private void Other()    // 2,4,5....
    {
        WriteLine("There will be something here in the future!!");
    }


    private void append_members(string[] list)
    {
        songs.Clear();
        info = list;
        for (int i = 0; i > list.Length; i++)
        {
            songs.Add(list[i]);
        }
    }

    // Func to change names inside of a list (Dyanmic array)

    private void control_function()
    {
        Menu side = new(info);
    }

}

struct Librarian
{
    // Basicaly a search engine that allows search in the library


    private static string[] Options = {"All songs", "Author", "Album", "Year", "Rating", "Options" };
    private int index;
    private int i;
    private string prompt = "";

    public Librarian() 
    {
        Run();
    }
       
    private void Run()
    {
        Menu LibraryCatalgue = new Menu(Options);

        // Replacing names and making a choice

        do
        {
            index = LibraryCatalgue.Run();
            if (index == Options.Length - 1)
            {
                string[] EditableOptions = new string[5];
                for (int i = 0; i < Options.Length - 1; i++)
                {
                    EditableOptions[i] = Options[i];
                }
                LibraryCatalgue.Options = EditableOptions;
                i = LibraryCatalgue.Run();

                WriteLine($"Enter new name for {Options[i]}");
                Options[i] = ReadLine();

                LibraryCatalgue.Options = Options;
            }
            else 
            {
                SoundLibrary SL = new(index);
                break;
            }

        } while (true);

    }
}


class Menu
{
    private int SelectedInex;
    public string[] Options;


    public Menu(string[] options)
    {
        SelectedInex = 0;
        Options = options;
    }

    private void Name()
    {
        Console.WriteLine(
            "\t░█▄█░█▀▀░█▀▀░█▀█░▀█▀░█▀█░█▀█░█▀▀\n" +
            "\t░█░█░█▀▀░█░█░█▀█░░█░░█░█░█░█░█▀▀\n" +
            "\t░▀░▀░▀▀▀░▀▀▀░▀░▀░░▀░░▀▀▀░▀░▀░▀▀▀\n" +
            "\n\n");
    }

    private void DisplayOptions()
    {
        WriteLine("-------------------------------------------------------");
        for (int i = 0; i < Options.Length; i++) 
        {
            string currentOption = Options[i];
            string prefix;

            if (i == SelectedInex)
            {
                prefix = ">";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.White;
            }
            else 
            {
                prefix = " ";
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            WriteLine($"{prefix} {currentOption} ");
        }
        ResetColor();
    }

    public int Run()
    {
        ConsoleKey keypressed;
        do
        {
            Clear();
            Name();
            DisplayOptions();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keypressed = keyInfo.Key;

            // Update seletedIndex based on user input

            if (keypressed == ConsoleKey.DownArrow)
            {
                SelectedInex++;
                if (SelectedInex == Options.Length)
                { SelectedInex = 0; }
            }
            else if (keypressed == ConsoleKey.UpArrow)
            {
                SelectedInex--;
                if (SelectedInex == -1)
                { SelectedInex = Options.Length - 1; }
            }

        } while (keypressed != ConsoleKey.Enter);
        return SelectedInex;
    }
}

