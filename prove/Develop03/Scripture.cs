namespace Develop03 {

    class Scripture {
        private string reference;
        private string scripture;

        public Scripture() {}

        public Scripture(string reference, string scripture) {
            this.reference = reference;
            this.scripture = scripture;
        }

        public string getReference() {
            return this.reference;
        }

        public void setReference(string reference) {
          this.reference = reference;  
        }

        public string getScripture() {
            return this.scripture;
        }

        public void setScripture(string scripture) {
            this.scripture = scripture;
        }

    }
}