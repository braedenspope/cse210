namespace FinalProject {

    class Assassin : Character {
        
        public Assassin(string name) {
            this.name = name;
            base.initialize();
            this.armorClass = 8 + this.dexterity / 3;
            this.baseDamage = 3;
        }

        public Assassin(string name, string race, string strength, string dexterity, string constitution, string intelligence, string wisdom, string charisma, string health) {
            this.name = name;
            this.race = race;
            this.strength = Int32.Parse(strength);
            this.dexterity = Int32.Parse(dexterity);
            this.constitution = Int32.Parse(constitution);
            this.intelligence = Int32.Parse(intelligence);
            this.wisdom = Int32.Parse(wisdom);
            this.charisma = Int32.Parse(charisma);
            this.health = Int32.Parse(health);
            this.armorClass = 8 + this.dexterity / 3;
        }

        public override int performHeavyAttack(int rollToHit, int baseDamage, int enemyArmor)
        {   
            Console.WriteLine(name + " swings their rapier!");
            Thread.Sleep(1000);
            return base.performHeavyAttack(rollToHit, baseDamage, enemyArmor);
            
        }

        public override int performLightAttack(int rollToHit, int baseDamage, int enemyArmor)
        {
            Console.WriteLine(name + " swings their dagger!");
            Thread.Sleep(1000);
            return base.performLightAttack(rollToHit, baseDamage, enemyArmor);
        }

        public override void display()
        {
            base.display();
            Console.WriteLine("Abilities:");
            Console.WriteLine("Heavy Attack: Rapier");
            Console.WriteLine("Light Attack: Dagger");
        }
    }
}