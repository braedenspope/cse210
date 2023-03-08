using System;

namespace Develop03 {
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("D&C 76:22", "And now, after the many testimonies which have been given of him, this is the testimony, last of all, which we give of him: That he lives!");
            Memorizer memorizer = new Memorizer(scripture);
            memorizer.runMemorizer();
        }
    }
}
