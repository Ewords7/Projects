using System;
using System.Collections.Generic;
using System.Text;

namespace ND4.Game
{
    class Player
    {
        protected List<string> players = new List<string>{ "Zaidejas 1", "Zaidejas 2", "Zaidejas 3", "Zaidejas 4", "Zaidejas 5", "Zaidejas 6", "Zaidejas 7" };
        protected int playerID;
        public Player(int playerID)
        {
            this.playerID = playerID;
        }
    }
}
