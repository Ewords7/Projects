//using les9_game.game;
using ND4.Game;
using ND4.GuiMenu;
using System;

namespace les9_game.GuiMenu
{
    class GuiController
    {
        private MainMenu mainMenu;
        private PlayerSelectionMenu playerSelectionMenu;
        private DiceSelectionMenu diceSelectionMenu;
        private GameEndMenu gameEndMenu;
        public GuiController()
        {
            mainMenu = new MainMenu();
            playerSelectionMenu = new PlayerSelectionMenu();
            diceSelectionMenu = new DiceSelectionMenu();
            gameEndMenu = new GameEndMenu();
        }

        // Pagrindinio meniu valdymas
        public void ShowMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {
                mainMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.Q:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.P:
                        PlayerSelectionMenu();
                        break;
                }
            } 
            Console.Clear();
        }

        // Zaidejo pasirinkimo meniu valdymas
        public void PlayerSelectionMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {
                playerSelectionMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.RightArrow:
                        playerSelectionMenu.IncreaseIndex();
                        break;
                    case ConsoleKey.LeftArrow:
                        playerSelectionMenu.DecreaseIndex();
                        break;
                    case ConsoleKey.UpArrow:
                        playerSelectionMenu.IncreaseIndexBy3();
                        break;
                    case ConsoleKey.DownArrow:
                        playerSelectionMenu.DecreaseIndexBy3();
                        break;
                    case ConsoleKey.Enter:
                        DiceSelectionMenu();
                        break;
                }
            }
            Console.Clear();
        }

        // Kauliuko meniu pasirinkimo valdymas
        public void DiceSelectionMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {                
                diceSelectionMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.UpArrow:
                        diceSelectionMenu.MoreDices();
                        break;
                    case ConsoleKey.DownArrow:
                        diceSelectionMenu.LessDices();
                        break;
                    case ConsoleKey.Enter:
                        bool enter = true;
                        while (enter)
                        {
                            DiceGame dice = new DiceGame(playerSelectionMenu.buttonIndex, diceSelectionMenu.diceAmount);
                            dice.Render();
                        }
                        break;                   
                }
            }
            Console.Clear();
        }

        // Zaidimo pabaigos meniu valdymas
        public void GameEndMenu()
        {
            bool needToRender = true;
            while (needToRender)
            {
                gameEndMenu.Render();
                ConsoleKeyInfo pressedChar = Console.ReadKey(true);
                switch (pressedChar.Key)
                {
                    case ConsoleKey.R:
                        needToRender = false;
                        break;
                    case ConsoleKey.M:
                        gameEndMenu.BackToMenu();
                        break;
                    case ConsoleKey.Q:
                        gameEndMenu.QuitGame();
                        break;
                }
            }   
        }
    }
}
