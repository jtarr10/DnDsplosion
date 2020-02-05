using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSplosion
{
    class Char_Race
    {
        string name;

        // Stats
        int statStr { public get; public set; }
        int statDex;
        int statCon;
        int statInt;
        int statWis;
        int statCha;

        int speed;

        // Skill Profs
        // Save Profs
        // Armor Profs
        // Weapon Profs

        // Tools and others <str[]>

       

        public string getName()
        {
            return this.name;
        }

        public int setName(string name)
        {
            this.name = name;

            return 1;
        }

        public int getStats(int[] stats)
        {
            stats[(int)eStats.STR] = this.statStr;
            stats[(int)eStats.DEX] = this.statDex;
            stats[(int)eStats.CON] = this.statCon;
            stats[(int)eStats.INT] = this.statInt;
            stats[(int)eStats.WIS] = this.statWis;
            stats[(int)eStats.CHA] = this.statCha;

            return 1;
        }

        public int setStats(int statStr, int statDex, int statCon, int statInt, int statWis, int statCha)
        {
            this.statStr = statStr == 0 ? this.statStr : statStr;
            this.statDex = statDex == 0 ? this.statDex : statDex;
            this.statCon = statCon == 0 ? this.statCon : statCon;
            this.statInt = statInt == 0 ? this.statInt : statInt;
            this.statWis = statWis == 0 ? this.statWis : statWis;
            this.statCha = statCha == 0 ? this.statCha : statCha;

            return 1;
        }

        public int getStat(eStats stat)
        {
            switch (stat)
            {
                case (eStats.STR):
                    return this.statStr;

                case (eStats.DEX):
                    return this.statDex;

                case (eStats.CON):
                    return this.statCon;

                case (eStats.INT):
                    return this.statInt;

                case (eStats.WIS):
                    return this.statWis;

                case (eStats.CHA):
                    return this.statCha;

                default:
                    return 0;
            }

        }

        public int setStat(eStats stat, int val)
        {
            switch (stat)
            {
                case (eStats.STR):
                    this.statStr = val;
                    break;

                case (eStats.DEX):
                    this.statDex = val;
                    break;

                case (eStats.CON):
                    this.statCon = val;
                    break;

                case (eStats.INT):
                    this.statInt = val;
                    break;

                case (eStats.WIS):
                    this.statWis = val;
                    break;

                case (eStats.CHA):
                    this.statCha = val;
                    break;

                default:
                    return 0;
            }

            return 1;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public int setSpeed(int speed)
        {
            this.speed = speed;

            return 1;
        }

    }
}
