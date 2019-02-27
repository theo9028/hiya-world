
using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "station", "astronaut", "astroid", "uranus", "exploration" };

    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("-------------------------------");
        Terminal.WriteLine("        HACKERTRON 30001       ");
        Terminal.WriteLine("-------------------------------");
        Terminal.WriteLine("Press 1 to hack the local library");
        Terminal.WriteLine("Press 2 to hack the police station");
        Terminal.WriteLine("Press 3 to hack the planet");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "sombra") // easter egg
        {
            Terminal.WriteLine("boop!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandPassword();
        Terminal.WriteLine("Enter your password: " + password.Anagram());
        Terminal.WriteLine("Type menu to go back");
    }

    private void SetRandPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...WELL DONE!");
                Terminal.WriteLine("Type menu to go back");
                break;
            case 2:
                Terminal.WriteLine("Got The Key...WELL DONE!");
                Terminal.WriteLine("Type menu to go back");
                break;
            case 3:
                Terminal.WriteLine("THE MOON IS OURS!");
                Terminal.WriteLine("Type menu to go back");
                Terminal.WriteLine(@"
___
\_ |__   ____   ____ ______  
 | __ \ /  _ \ /  _ \\____ \ 
 | \_\ (  <_> |  <_> )  |_> >
 |___  /\____/ \____/|   __/ 
     \/              |__|    
"
                );
                break;
        }
        
    }
}
