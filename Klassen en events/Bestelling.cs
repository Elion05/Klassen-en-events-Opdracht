using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_en_events
{
    internal class Bestelling<T>
    {
        private static int teller = 0; //basis bestelling 0, elke nieuwe bestelling krijgt een nummer hoger

        public int Id { get; }
       
        public T Item { get; set; }

        public DateTime Datum { get; private set; } 

        public int Aantal { get; set; } 

        public event Action<string> BestellingGeplaatst;


        public Bestelling(T itemn, int aantal)
        {
            Id = teller++; 
            Item = itemn;
            Aantal = aantal;
            Datum = DateTime.Now;        
        }

        
        public (string isbn, int aantal, decimal totaalPrijs) Bestel()
        {
            if (Item is Boek boek)
            {
                
                decimal totaal = boek.Prijs * Aantal;
                BestellingGeplaatst?.Invoke($"Bestelling{Id} is geplaatst op {Datum}.");
                return (boek.Isbn, Aantal, totaal); //DIT IS DE TUPLE
            }
            else
            {
                return ("Onbekend", Aantal, 0);
            }
        }
        public override string ToString()
        {
            if (Item is Tijdschrift tijdschrift)
            {
                decimal totaal = tijdschrift.Prijs * Aantal;
                return $"Tijdschrift besteld : {tijdschrift.Naam} (Isbn: {tijdschrift.Isbn}), Aantal: {Aantal}, Totaal: {totaal:C} Periode: {tijdschrift.Periode}, Datum: {Datum}";
            }
            else if (Item is Boek boek)
            {
                decimal totaal = boek.Prijs * Aantal;
                return $"Boek besteld : {boek.Naam} (Isbn: {boek.Isbn}), Aantal: {Aantal}, Totaal: {totaal:C}, Datum: {Datum}";
            }
            else
            {
                return $"Bestelling {Id}: Onbekend item, Aantal: {Aantal}, Datum: {Datum}";
            }
        }
    }
}