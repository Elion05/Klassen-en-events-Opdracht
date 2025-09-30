using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_en_events
{

    public enum Verschijningsperiode
    {
        Dagelijks,
        Wekelijks,
        Maandelijks,
    }
    internal class Tijdschrift : Boek //deze klasse erft van de klasse Boek met de eigenschappen Isbn, Naam, Uitgever en Prijs
    {
        
        public Verschijningsperiode Periode { get; set; } //extra eigenschap voor tijdschrift die niet in boek zit



        //deze constructor roept de constructor van de basis klasse Boek aan met de eigenschappen die in Boek zitten
        public Tijdschrift(string isbn, string naam, string uitgever, decimal prijs, Verschijningsperiode periode)
            : base(isbn, naam, uitgever, prijs)
        {
            Periode = periode;
        }
        
        public Tijdschrift() { }

        public override void Lees()
        {
            base.Lees();

            Console.WriteLine("Geef verschijningsperiode in (Dagelijks, Wekelijks, Maandelijks):");
            if(Enum.TryParse(Console.ReadLine(), out Verschijningsperiode periode))
                Periode = periode;
        }
        public override string ToString()
        {
            //dit gaat van de klasse Boek de ToString methode aanroepen en daarbovenop voegen we de Periode toe
            return base.ToString() + $", Periode: {Periode}";
          
        }
    }
}
