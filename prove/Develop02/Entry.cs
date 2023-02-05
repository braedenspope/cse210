using System;

namespace Develop02
{
    public class Entry 
    {
        public string date;
        public string prompt;
        public string response;
        public Entry(string prompt, string response) {
            this.prompt = prompt;
            this.response = response;
            DateTime current = DateTime.Now;
            this.date = current.ToShortDateString();
        }

        public Entry(string date, string prompt, string response){
            this.prompt = prompt;
            this.response = response;
            this.date = date;
        }
    }
}