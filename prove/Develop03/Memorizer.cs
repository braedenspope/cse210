namespace Develop03 {

    class Memorizer {

        private int length = 0;
        private int hidden = 0;
        private List<string> words = new List<string>();
        private Scripture scripture = new Scripture();

        public Memorizer(Scripture scripture) {
            this.scripture.setReference(scripture.getReference());
            this.scripture.setScripture(scripture.getScripture());
            string[] words = this.scripture.getScripture().Split();
            for (int i = 0; i < words.Length; i++) {
                this.words.Add(words[i]);
            }
            this.length = words.Length;
        }

        public void runMemorizer() {
            displayScripture();
            Console.WriteLine();
            string enter = null;
            while(enter != "quit" && !allHidden()) {
                Console.WriteLine("Press enter to continue or type 'quit' to finish:");
                enter = Console.ReadLine();
                if (enter != "quit") {
                    Console.Clear();
                    hideWords();
                    Console.WriteLine("");
                    displayScripture();
                    Console.WriteLine();
                } else {

                }
            }
        }

        public void hideWords() {
            Random rand = new Random();
            int wordsToHide = 0;
            if (hidden >= length/2) {
                wordsToHide = 1;
            } else {
                wordsToHide = rand.Next(3);
            }
            for (int i = 0; i < wordsToHide; i++) {
                int wordToHide = rand.Next(length);
                words[wordToHide] = hideWord(words[wordToHide]);
                
            }
            
        }

        public bool allHidden() {
            for (int i = 0; i < words.Count; i++) {
                if (!words[i].Contains("_")) {
                    return false;
                }
            }
            return true;
        }

        public string hideWord(string word) {
            string hiddenWord = "";
            for (int i = 0; i < word.Length; i++) {
                hiddenWord += "_";
            }
            return hiddenWord;
        }

        public void displayScripture() {
            Console.Write(scripture.getReference() + " ");
            for (int i = 0; i < words.Count; i++) {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }

    }
}