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
        public string Name = String.Empty;

        public Person(string bas)
        {
            Name = bas;
        }

        public Person()
        {

        }

        public Person(string newName, int score)
        {
            Name = newName;
            this.score = score;
        }

        public int GetScore()
        {
            return score;
        }

        public void AddScore(int points)
        {
            if (points == Hint.POINTS)
                hintsFound++;
            else if (points < 0)
                hitByMonsters++;
            else
                treasuresFound++;
            score += points;
            if (score < 0)
                points = 0;
        }

        public int GetHitsOfMonsters()
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

        public override string ToString()
        {
            return Name + "\t score: " + score.ToString();
        }
    }
}
