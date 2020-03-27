using les9_game.GuiMenu;
using ND4.Game;
using System;
using System.Collections.Generic;

namespace ND4.GuiMenu
{
    class PlayerSelectionMenu : Window
    {
        private const int buttonY = 10;
        private const int buttonYLine2 = 20;
        private const int buttonWidth = 10;
        private const int buttonHeight = 5;
        private Button P2;
        private Button P3;
        private Button P4;
        private Button P5;
        private Button P6;
        private Button P7;
        private TextBlock titleTextBlock;
        private List<Button> menuButtons = new List<Button>();
        public int buttonIndex { get; set; } = 0;
        
        public PlayerSelectionMenu() : base(0, 0, 120, 30, '%')
        {
            // Mygtuku parametrai
            P2 = new Button(20, buttonY, buttonWidth, buttonHeight, "P2");
            P3 = new Button(50, buttonY, buttonWidth, buttonHeight, "P3");
            P4 = new Button(80, buttonY, buttonWidth, buttonHeight, "P4");
            P5 = new Button(20, buttonYLine2, buttonWidth, buttonHeight, "P5");
            P6 = new Button(50, buttonYLine2, buttonWidth, buttonHeight, "P6");
            P7 = new Button(80, buttonYLine2, buttonWidth, buttonHeight, "P7");
            // Title parametrai
            titleTextBlock = new TextBlock(10, 5, 100, new List<string> { "Pasirink norima zaideju skaiciu", "Pasirinkes norima zaideju skaiciu spausk klavisa - Enter" });
            // Mygtuku sudejimas i sarasa
            menuButtons.Add(P2);
            menuButtons.Add(P3);
            menuButtons.Add(P4);
            menuButtons.Add(P5);
            menuButtons.Add(P6);
            menuButtons.Add(P7);
        }

        // Mygtuko index'o didinimas
        public int IncreaseIndex()
        {
            return buttonIndex == 5 ? buttonIndex = 0 : buttonIndex += 1;
        }

        // Mygtuko index'o mazinimas
        public int DecreaseIndex()
        {
            return buttonIndex == 0 ? buttonIndex = 5 : buttonIndex -= 1;
        }

        // Mygtuko index'o didinimas persokimui i kita eilute
        public int IncreaseIndexBy3()
        {
            if (buttonIndex == 0 || buttonIndex == 1 || buttonIndex == 2)
            {
                return buttonIndex += 3;
            }
            else
            {
                return buttonIndex -= 3;
            }
        }

        // Mygtuko index'o mazinimas persokimui i kita eilute
        public int DecreaseIndexBy3()
        {
            if (buttonIndex == 3 || buttonIndex == 4 || buttonIndex == 5)
            {
                return buttonIndex -= 3;
            }
            else
            {
                return buttonIndex += 3;
            }
        }

        // Aktyvaus mygtuko nustatymas
        public void SetActiveButton()
        {
            // Pasirenkamas Start mygtukas
            switch (buttonIndex)
            {
                case 0:
                    foreach (Button button in menuButtons)
                    {
                        P2.SetActive();
                        P3.DisActive();
                        P4.DisActive();
                        P5.DisActive();
                        P6.DisActive();
                        P7.DisActive();
                        button.Render();
                    }
                    break;
                case 1:
                    foreach (Button button in menuButtons)
                    {
                        P2.DisActive();
                        P3.SetActive();
                        P4.DisActive();
                        P5.DisActive();
                        P6.DisActive();
                        P7.DisActive();
                        button.Render();
                    }
                    break;
                case 2:
                    foreach (Button button in menuButtons)
                    {
                        P2.DisActive();
                        P3.DisActive();
                        P4.SetActive();
                        P5.DisActive();
                        P6.DisActive();
                        P7.DisActive();
                        button.Render();
                    }
                    break;
                case 3:
                    foreach (Button button in menuButtons)
                    {
                        P2.DisActive();
                        P3.DisActive();
                        P4.DisActive();
                        P5.SetActive();
                        P6.DisActive();
                        P7.DisActive();
                        button.Render();
                    }
                    break;
                case 4:
                    foreach (Button button in menuButtons)
                    {
                        P2.DisActive();
                        P3.DisActive();
                        P4.DisActive();
                        P5.DisActive();
                        P6.SetActive();
                        P7.DisActive();
                        button.Render();
                    }
                    break;
                case 5:
                    foreach (Button button in menuButtons)
                    {
                        P2.DisActive();
                        P3.DisActive();
                        P4.DisActive();
                        P5.DisActive();
                        P6.DisActive();
                        P7.SetActive();
                        button.Render();
                    }
                    break;
            }
        }

        // Meniu atvaizdavimas
        public override void Render()
        {
            base.Render();
            titleTextBlock.Render();
            SetActiveButton();
            Console.SetCursorPosition(0, 0);
        }
    }
}
