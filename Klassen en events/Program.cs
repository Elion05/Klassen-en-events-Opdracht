using System;
using System.Collections.Generic;

namespace Klassen_en_events
{
    class Program
    {
        static void Main()
        {
            Boek boek1 = new Boek("12345678910", "C# voor noobs", "Jon Doe", 29);
            Boek boek2 = new Boek("09876543211", "Java voor noobs", "Jane Doe", 35);
            Boek boek3 = new Boek("5", "Fortnite", "Joe Biden", 50);
            Boek boek4 = new Boek("7", "Proclubs", "Elion Rexhepi", 10);

            Tijdschrift tijdschrift3 = new Tijdschrift("10", "Daily Bugle", "Tech support",50, Verschijningsperiode.Dagelijks);
            Tijdschrift tijdschrift4 = new Tijdschrift("545454", "Destiny is a way", "Hisuite", 24, Verschijningsperiode.Wekelijks);
            Tijdschrift tijdschrift1 = new Tijdschrift("112", "Tech Today", "Tech Publishers", 5, Verschijningsperiode.Maandelijks);
            Tijdschrift tijdschrift2 = new Tijdschrift("113", "Daily News", "News Corp", 2, Verschijningsperiode.Dagelijks);

            List<Boek> items = new List<Boek> { boek1, boek2, boek3, boek4, tijdschrift1, tijdschrift2 , tijdschrift3, tijdschrift4};
            //List<Tijdschrift> tijdschriftitem = new List<Tijdschrift>(tijdschrift1, tijdschrift2, tijdschrift3, tijdschrift4); Ik heb mezelfmakkelijk gemaakt en dit niet geschreven omdat het makkelijker was om te schrijven
            

            Console.WriteLine("Beschikbare items zijn: ");
            //dit gaat tonen hoeveel items er in de lijst staan en toont ze met hun index + 1
            for (int i = 0; i< items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
            //we gaan nu voor de bestelling te plaatsen de gebruiker vragen welk item hij wil bestellen
            Console.WriteLine("Welk item wil je bestellen? (nummer ingeven)");
            int keuze = int.Parse(Console.ReadLine());

            Console.Write("Aantal: ");
            int aantal = int.Parse(Console.ReadLine());

            var gekozenItem = items[keuze - 1];

            //bestelinng maken
            if(gekozenItem is Tijdschrift tijdschrift)
            {
                var bestelling = new Bestelling<Tijdschrift>(tijdschrift, aantal);
                var result = bestelling.Bestel(); //tuple
                
                Console.WriteLine(bestelling.ToString());
            }
            else // Boek
            {
                var bestelling = new Bestelling<Boek>((Boek)gekozenItem, aantal);
                var result = bestelling.Bestel(); //tuple
        
                Console.WriteLine(bestelling.ToString());
            }

            Console.WriteLine("Klaar. Druk op een toets om af te sluiten.");
            Console.ReadKey();
        }
    }
    }
