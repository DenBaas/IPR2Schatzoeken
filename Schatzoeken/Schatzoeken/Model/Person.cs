using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schatzoeken.Model
{
    public class Person
    {
        private int score = 0;
        private int hitByMonsters = 0;
        private int treasuresFound = 0;
        private int hintsFound = 0;

        public Person(string newName)
        {
            
        }

        public int getScore()
        {
            return score;
        }

        public void addScore(int points)
        {
            if (points == Hint.POINTS)
                hintsFound++;
            else if (points < 0)
                hitByMonsters++;
            else
                treasuresFound++;
            score += points;
        }

        public int getHitsOfMonsters()
        {
            return hitByMonsters;
        }

        public int TreasuresFound()
        {
            return treasuresFound;
        }

        public int HintsFound()
        {
            return hintsFound;
        }
    }
}
