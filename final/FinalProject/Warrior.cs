namespace FinalProject {

    class Warrior : Character {

        public Warrior(string name) {
            this.name = name;
            base.initialize();
            this.armorClass = 10 + this.dexterity / 3;
            this.baseDamage = 2;
        }

        public Warrior(string name, string race, string strength, string dexterity, string constitution, string intelligence, string wisdom, string charisma, string health) {
            this.name = name;
            this.race = race;
            this.strength = Int32.Parse(strength);
            this.dexterity = Int32.Parse(dexterity);
            this.constitution = Int32.Parse(constitution);
            this.intelligence = Int32.Parse(intelligence);
            this.wisdom = Int32.Parse(wisdom);
            this.charisma = Int32.Parse(charisma);
            this.health = Int32.Parse(health);
            this.armorClass = 10 + this.dexterity / 3;
        }

        public override int performHeavyAttack(int rollToHit, int baseDamage, int enemyArmor)
        {   
            Console.WriteLine(name + " swings their longsword!");
            Thread.Sleep(1000);
            return base.performHeavyAttack(rollToHit, baseDamage, enemyArmor);
            
        }

        public override int performLightAttack(int rollToHit, int baseDamage, int enemyArmor)
        {
            Console.WriteLine(name + " swings their club!");
            Thread.Sleep(1000);
            return base.performLightAttack(rollToHit, baseDamage, enemyArmor);
        }

        public override void display()
        {
            base.display();
            Console.WriteLine("Abilities:");
            Console.WriteLine("Heavy Attack: Longsword");
            Console.WriteLine("Light Attack: Club");
        }
    }
}