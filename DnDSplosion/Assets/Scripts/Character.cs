using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DnDSplosion
{

   public enum eStats
        {
            STR = 0,
            DEX,
            CON,
            INT,
            WIS,
            CHA
        }

    public class Character
    {
        

        // Character information
        string name;
        int level;
        int experience;

        int HP;
        int HP_temp;
        int initiative;
        int AC;

        int inspiration;
        int profBonus;
        int passWisdom;

        // Stats
        int statStr;
        int statDex;
        int statCon;
        int statInt;
        int statWis;
        int statCha;



        // Skill Profs
        // Save Profs
        // Armor Profs
        // Weapon Profs
        // Languages <str[]>
        // Tools and others <str[]>
        // Passive Wisdom
        // Feats

        // Equipment
        // Inventory
        // Attacks
        // Magic Items

        // Spell Book

        // Background
        // Personality Traits
        // Ideals
        // Bonds
        // flaws

        // Features

        // CalcChar()

        Char_Class Class;
        Char_Race Race;

        // Constructors
        public Character()
        {
            Class = new Char_Class();
            Race = new Char_Race();

            name = " ";
            level = 0;
            experience = 0;

            HP = 0;
            HP_temp = 0;
            initiative = 0;
            AC = 0;

            inspiration = 0;
            profBonus = 0;
            passWisdom = 0;

            statStr = 0;
            statDex = 0;
            statCon = 0;
            statWis = 0;
            statInt = 0;
            statCha = 0;
        }       
        
        // Getters and Setters
        public string getName()
        {
            return this.name;
        }

        public int setName(string name)
        {
            this.name = name;

            return 1;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int setLevel(int level)
        {
            this.level = level;

            return 1;
        }

        public int getExperience()
        {
            return this.experience;
        }

        public int setExperience(int experience)
        {
            this.experience = experience;

            return 1;
        }

        public int getHP()
        {
            return this.HP;
        }

        public int setHP(int HP)
        {
            this.HP = HP;

            return 1;
        }

        public int getHP_temp()
        {
            return this.HP_temp;
        }

        public int setHP_temp(int HP_temp)
        {
            this.HP_temp = HP_temp;

            return 1;
        }

        public int getInitiative()
        {
            return this.initiative;
        }

        public int setInitiative(int initiative)
        {
            this.initiative = initiative;

            return 1;
        }

        public int getAC()
        {
            return this.AC;
        }

        public int setAC(int AC)
        {
            this.AC = AC;

            return 1;
        }

        public int getInspiration()
        {
            return this.inspiration;
        }

        public int setInspiration(int inspiration)
        {
            this.inspiration = inspiration;

            return 1;
        }

        public int getProfBonus()
        {
            return this.profBonus;
        }

        public int setProfBonus(int profBonus)
        {
            this.profBonus = profBonus;

            return 1;
        }

        public int getPassWisdom()
        {
            return this.passWisdom;
        }

        public int setPassWisdom(int passWisdom)
        {
            this.passWisdom = passWisdom;

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
            switch(stat)
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

        // Utility
        public int calcStats(int[] stats)
        {
            stats[(int)eStats.STR] = this.statStr;
            stats[(int)eStats.DEX] = this.statDex;
            stats[(int)eStats.CON] = this.statCon;
            stats[(int)eStats.INT] = this.statInt;
            stats[(int)eStats.WIS] = this.statWis;
            stats[(int)eStats.CHA] = this.statCha;

            stats[(int)eStats.STR] += this.Class.getStat(eStats.STR);
            stats[(int)eStats.DEX] += this.Class.getStat(eStats.DEX);
            stats[(int)eStats.CON] += this.Class.getStat(eStats.CON);
            stats[(int)eStats.INT] += this.Class.getStat(eStats.INT);
            stats[(int)eStats.WIS] += this.Class.getStat(eStats.WIS);
            stats[(int)eStats.CHA] += this.Class.getStat(eStats.CHA);

            stats[(int)eStats.STR] += this.Race.getStat(eStats.STR);
            stats[(int)eStats.DEX] += this.Race.getStat(eStats.DEX);
            stats[(int)eStats.CON] += this.Race.getStat(eStats.CON);
            stats[(int)eStats.INT] += this.Race.getStat(eStats.INT);
            stats[(int)eStats.WIS] += this.Race.getStat(eStats.WIS);
            stats[(int)eStats.CHA] += this.Race.getStat(eStats.CHA);

            return 1;
        }

    } // end Character
} // end DnDSplosion
