using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "book", "learn", "teach", "study", "table" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "espionage", "military", "warfare", "surveillance", "intelligence" };


    //game state
    int level;
    enum Screen {MainMenu, Password, Win, Next };
    Screen currentScreen;
    string password;

    //intialisation
    void Start()
    {
        ShowMainMenu();

    }
    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine("----------------------------");
        Terminal.WriteLine("|   Genesis Hacker™ v1.0   |");
        Terminal.WriteLine("----------------------------");
        Terminal.WriteLine("Press 1 to access School        ");
        Terminal.WriteLine("Press 2 to access Police Station");
        Terminal.WriteLine("Press 3 to access CIA           ");
        Terminal.WriteLine("\nEnter your choice:");

    }

    private void Update() //to check if random is working properly;
    {
       int index = Random.Range(0, level1Passwords.Length);
        print(index);
    }


    void OnUserInput(string input)
    {
        if (input == "menu")
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
        if(isValidLevelNumber)
        {
            level = int.Parse(input); //wont have to specify level at each if {} if we do this
            AskForPassword(); //the code at the bottom will be replaced by this, start game is ask for password
        }
       

        /*if (input == "1")
        {
           password = level1Passwords[2]; //todo randomise later
            StartGame();
        }
        else if (input == "2")
        { 
            password = level2Passwords[3];
            StartGame();
        }
        else if (input == "3")
        {   
            password = level3Passwords[4];
            StartGame();
        }
        */

        else if (input == "7")
        {
            Terminal.WriteLine("You can't hack CR7 he's not from earth");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid option");
        }
    }

    void AskForPassword()
    {

        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter password for level " + level + " hint: " + password.Anagram());
        Terminal.WriteLine("Type menu to return to main menu");

    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;

            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;

            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;

            default:
                Debug.LogError("invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen(input);
        }
        else
        {
           
            AskForPassword();
        }
    }

    void DisplayWinScreen(string input)
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward(input);
        Terminal.WriteLine("Type menu to return to main menu");
    }
   
    void NextLevel(string input)
    {   
        level = level + 1;
        AskForPassword();
    }

    void ShowLevelReward(string input)
    {
        
        switch (level)
        {
            case 1:
                
                Terminal.WriteLine(@"   
     ____________________
    |                   |
    |                   |
    |  Take a laptop    |
    |                   |
    |___________________|
   /                   /
  /    ____           /
 /    /___/          /
/___________________/ ");
                Terminal.WriteLine("Press 2 to try next level");
                currentScreen = Screen.MainMenu;
                if (input == "2")
                {
                    
                    NextLevel(input);
                    currentScreen = Screen.Password;
                }
                break;


            case 2:
                Terminal.WriteLine(@" 
  @@@@@@@                    @@@@@@@ 
 @@@   @@@  Take a handcuff @@@   @@@                    
@@@     @@@%%%%%%%%%%%%%%%%@@@     @@@
@@@     @@@%%%%%%%%%%%%%%%%@@@     @@@
 @@@   @@@%%%%%%%%%%%%%%%%%%@@@   @@@
  @@@@@@@                    @@@@@@@");
                Terminal.WriteLine("Press 3 to try next level");
                currentScreen = Screen.MainMenu;
                if (input == "3")
                {

                    NextLevel(input);
                    currentScreen = Screen.Password;
                }
                break;

            case 3:
                Terminal.WriteLine(@"Take a gun
               ________
_______________|______|_______
|_______ _______ __   _____  |
       | |     | | \  |    \_|
       |_|     | |  \_|
               |_|");

                Terminal.WriteLine("Welcome to the CIA database.");
                
                break;

            default:
                Debug.LogError("Invalid Level");
                break;

        }


        
    }
}


