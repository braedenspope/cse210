namespace FinalProject {

    class Character {

        protected string name;
        protected string race;
        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;
        protected int wisdom;
        protected int charisma;
        protected int baseDamage;
        protected int armorClass;
        protected int health;
        public Character() {}

        public Character(string name) {
            this.name = name;
            initialize();
        }

        public void initialize() {
            updateStats();
            chooseRace();
        }

        public string getName() {
            return name;
        }

        public int getHealth() {
            return health;
        }

        public int getArmorClass() {
            return armorClass;
        }

        public int getBaseDamage() {
            return baseDamage;
        }

        public string getFileString() {
            string type = this.GetType().ToString();
            type = type.Split(".")[1];
            return type + "," + name + "," + race + "," + strength + "," + dexterity + "," + constitution + "," + intelligence + "," + wisdom + "," + charisma + "," + health;
        }

        public virtual void display() {
            Console.WriteLine("Name: " + name);
            string className = this.GetType().ToString();
            className = className.Split(".")[1];
            Console.Write(race + " " + className + "\n\n");
            displayAbilityScores();
            Console.WriteLine();
        }

        public void updateStats() {
            List<string> abilities = populateAbilityList();
            Console.WriteLine("Here are your randomized stats:");
            List<int> stats = new List<int>();
            for (int i = 0; i < 6; i++) {
                int stat = rollStat();
                stats.Add(stat);
                Console.WriteLine("\t"+stat);
            }
            for (int j = 0; j < stats.Count; j++) {
                int choice = 0;
                displayAbilityList(abilities);
                Console.WriteLine("Enter the ability score would you like to put the following stat in: " + stats[j]);
                choice = Int32.Parse(Console.ReadLine());
                setAbility(abilities[choice-1], stats[j]);
                abilities.RemoveAt(choice-1);
            }
            displayAbilityScores(); 
        }

        public void displayAbilityList(List<string> abilities) {
            
            for (int i = 1; i <= abilities.Count; i++) {
                Console.WriteLine(i + ": " + abilities[i-1]);
            }
        }

        public List<string> populateAbilityList() {
            List<string> abilities = new List<string>();
            abilities.Add("Strength");
            abilities.Add("Dexterity");
            abilities.Add("Consitution");
            abilities.Add("Intelligence");
            abilities.Add("Wisdom");
            abilities.Add("Charisma");
            return abilities;
        }

        public int rollStat() {
            int stat = 0;
            List<int> rolls = new List<int>();
            int lowest = 25;
            Random random = new Random();
            for (int i = 0; i < 4; i++) {
                int roll = random.Next(1,7);
                rolls.Add(roll);
            }
            foreach (int roll in rolls) {
                if (roll < lowest) {
                    lowest = roll;
                }
            }
            rolls.Remove(lowest);
            foreach (int roll in rolls) {
                stat += roll;
            }
            return stat;
        }

        public virtual int performHeavyAttack(int rollToHit, int baseDamage, int enemyArmor) {
            int damage = baseDamage + 2;
            if (rollToHit >= enemyArmor) {
                Console.WriteLine("The attack hits!");
                return damage;
            } else {
                Console.WriteLine("The attack misses.");
                return 0;
            }
        }

        public virtual int performLightAttack(int rollToHit, int baseDamage, int enemyArmor) {
            int damage = baseDamage + 2;
            if (rollToHit >= enemyArmor) {
                Console.WriteLine("The attack hits!");
            } else {
                Console.WriteLine("The attack misses.");
            }
            return damage;
        }

        public void chooseRace() {
            int choice = 0;
            while (choice == 0) {
                Console.WriteLine("\t1. Human");
                Console.WriteLine("\t2. Elf");
                Console.WriteLine("\t3. Dwarf");
                Console.WriteLine("\t4. Half-Orc");
                Console.WriteLine("\t5. Gnome");
                Console.Write("What race is " + name + "? ");
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1) {
                    setRace("Human");
                    strength++;
                    dexterity++;
                    constitution++;
                    intelligence++;
                    wisdom++;
                    charisma++;
                } else if (choice == 2) {
                    setRace("Elf");
                    dexterity += 2;
                    wisdom++;
                } else if (choice == 3) {
                    setRace("Dwarf");
                    constitution += 2;
                    strength++;
                } else if (choice == 4) {
                    setRace("Half-Orc");
                    constitution++;
                    strength += 2;
                } else if (choice == 5) {
                    setRace("Gnome");
                    intelligence += 2;
                    dexterity++;
                }
                this.health = 10 + constitution;
            }
        }
        
        public void displayAbilityScores() {
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Constitution: " + constitution);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Wisdom: " + wisdom);
            Console.WriteLine("Charisma: " + charisma);
        }

        public void setAbility(string ability, int score) {
            if (ability == "Strength") {
                this.strength = score;
            } else if (ability == "Dexterity") {
                this.dexterity = score;
            } else if (ability == "Constitution") {
                this.constitution = score;
            } else if (ability == "Intelligence") {
                this.intelligence = score;
            } else if (ability == "Wisdom") {
                this.wisdom = score;
            } else if (ability == "Charisma") {
                this.charisma = score;
            }
        } 

        public void setRace(string race) {
            this.race = race;
        }

        public void setHealth(int damage) {
            this.health -= damage;
        }

    }
}