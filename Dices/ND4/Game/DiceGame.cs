using les9_game.GuiMenu;
using System;
using System.Collections.Generic;

namespace ND4.Game
{
    class DiceGame : Player, IRenderable
    {
        protected int diceID;
        private TextBlock TextBlockDraw;
        private TextBlock TextBlockWin;
        private Random rollDice = new Random();
        private GuiController guiController = new GuiController();
        private List<int> sumList = new List<int>();
        public DiceGame(int playerID, int diceID) : base(playerID)
        {
            base.playerID = playerID;
            this.diceID = diceID;
            TextBlockDraw = new TextBlock(10, 2, 100, new List<string> { "Didziausias rezultatas tarp kai kuriu zaideju yra lygus,",
                "todel bus sugeneruotas papildomas raundas" });
        }

        // Kauliuku ridenimas ir isridentu akiu suma
        public List<int> SumList()
        {
            Console.Clear();
            // Praeinami visi zaidejai
            for (int i = 0; i < 2 + playerID; i++)
            {
                int sum = 0;
                Console.Write(players[i] + " - isridentu akiu skaicius: ");
                // Praeinami kauliukai
                for (int j = 0; j < diceID; j++)
                {
                    int diceResult = rollDice.Next(1, 7);
                    Console.Write(diceResult + " | ");
                    sum += diceResult;
                }
                sumList.Add(sum);
                Console.WriteLine("Rezultatas: " + sum);
                System.Threading.Thread.Sleep(1500);
            }
            Console.WriteLine("\nIsridenti visi kauliukai. Prasome palaukti.");
            return sumList;
        }

        // Tekstas, jei geriausias rezultatas tarp keliu zaideju vienodas
        public void DrawText()
        {
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            TextBlockDraw.Render();
        }

        // Laimetojo atrinkimas ir paskelbimas
        public void Render()
        {            
            Console.Clear();
            bool gameNotFinished = false;            
            do
            {
                // List'o prvalymas
                sumList.Clear();
                // List'as su galutiniais rezultatais
                SumList();
                bool needExtraRound = false;
                for (int i = 0; i < 2 + playerID; i++)
                {                    
                    int count = 0;
                    int draw = 0;
                    for (int j = 0; j < 2 + playerID; j++)
                    {    
                        // Vieno zaidejo galutinis rezultatas didesnis uz kito zaidejo
                        if (sumList[i] > sumList[j])
                        {
                            count += 1;
                        }
                        // Vieno zaidejo galutinis rezultatas lygus su kito zaidejo
                        else if (sumList[i] == sumList[j])
                        {
                            count += 1;
                            draw += 1;
                        }
                        // Vieno zaidejo galutinis rezultatas mazesnis uz kito zaidejo
                        else if (sumList[i] < sumList[j])
                        {
                            continue;
                        }
                    }
                    // Tikrinama ar daugiausiai akiu yra isridenes daugiau negu vienas zaidejas
                    if ((playerID + 2) == count && draw > 1)
                    {
                        needExtraRound = true;
                        break;
                    }
                    // Skelbiamas laimetojas
                    else if ((playerID + 2) == count)
                    {
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        TextBlockWin = new TextBlock(10, 2, 100, new List<string> { $"Laimetojas {players[i]}", "Tuoj busite nukreiptas " +
                            "i meniu langa" });
                        TextBlockWin.Render();
                        gameNotFinished = true;
                        break;
                    }               
                }
                // Tikrinama ar reikalingas papildomas raundas
                if (needExtraRound)
                {
                    DrawText();
                }
                System.Threading.Thread.Sleep(5000);
            } while (gameNotFinished == false);
            // Zaidimo pabaigos menu
            guiController.GameEndMenu();
        }
    }
}