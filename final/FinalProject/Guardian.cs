namespace FinalProject {

    class Guardian : Character {
        
        public Guardian(string name) {
            this.name = name;
            base.initialize();
            this.armorClass = 12 + this.dexterity / 3;
            this.baseDamage = 1;
        }

        public Guardian(string name, string race, string strength, string dexterity, string constitution, string intelligence, string wisdom, string charisma, string health) {
            this.name = name;
            this.race = race;
            this.strength = Int32.Parse(strength);
            this.dexterity = Int32.Parse(dexterity);
            this.constitution = Int32.Parse(constitution);
            this.intelligence = Int32.Parse(intelligence);
            this.wisdom = Int32.Parse(wisdom);
            this.charisma = Int32.Parse(charisma);
            this.health = Int32.Parse(health);
            this.armorClass = 12 + this.dexterity / 3;
        }

        public override int performHeavyAttack(int rollToHit, int baseDamage, int enemyArmor)
        {   
            Console.WriteLine(name + " swings their warhammer!");
            Thread.Sleep(1000);
            return base.performHeavyAttack(rollToHit, baseDamage, enemyArmor);
            
        }

        public override int performLightAttack(int rollToHit, int baseDamage, int enemyArmor)
        {
            Console.WriteLine(name + " swings their fist!");
            Thread.Sleep(1000);
            return base.performLightAttack(rollToHit, baseDamage, enemyArmor);
        }

        public override void display()
        {
            base.display();
            Console.WriteLine("Abilities:");
            Console.WriteLine("Heavy Attack: Warhammer");
            Console.WriteLine("Light Attack: Punch");
        }
    }
}