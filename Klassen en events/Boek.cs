using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_en_events
{
    internal class Boek
    {
        //default eigenschappen van een boek, isbn, naam, uitgever en prijs
        public string Isbn { get; set; }
        public string Naam { get; set; }
        public string Uitgever { get; set; }



        private decimal prijs2;
        public decimal Prijs
        {
            get { return prijs2; }
            set
            {
                if (value < 5) prijs2 = 5;
                else if(value > 50) prijs2 = 50;
                else prijs2 = value;
            }
        }


        //constructor om een boek zijn eigenschappen mee te geven bij het aanmaken van een nieuwe object (Boek boek1 = new Boek(...))
        public Boek(string isbn, string naam, string uitgever, decimal prijs)
        {
            Isbn = isbn;
            Naam = naam;
            Uitgever = uitgever;
            Prijs = prijs;
        }

        //lege constructor
        public Boek(){}


        //basis leesmethode voor een boek met virtual zodat tijdschrift kan overrgeride worden
        public virtual void Lees()
        {
            Console.WriteLine("Geef isbn in:");
            Isbn = Console.ReadLine();

            Console.WriteLine("Geef naam in:");
            Naam = Console.ReadLine();

            Console.WriteLine("Geef uitgever in:");
            Uitgever = Console.ReadLine();

            Console.WriteLine("Geef prijs in:");
            if (decimal.TryParse(Console.ReadLine(), out decimal prijs))
                Prijs = prijs;
        }
        public override string ToString()
        {
            return $"Beschikbare items: {Naam}, ISBN: {Isbn}, Uitgever: {Uitgever}, Prijs: {Prijs:C}";
        }
    }
}
