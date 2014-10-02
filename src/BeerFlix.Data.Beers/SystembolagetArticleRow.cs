using System;

namespace BeerFlix.Data.Beers
{
    public class SystembolagetArticleRow
    {
        public int nr { get; set; }
        public int Artikelid { get; set; }
        public int Varnummer { get; set; }
        public string Namn { get; set; }
        public string Namn2 { get; set; }
        public double Prisinklmoms { get; set; }
        public double? Pant { get; set; }
        public int Volymiml { get; set; }
        public double PrisPerLiter { get; set; }
        public DateTime Saljstart { get; set; }
        public DateTime? Slutlev { get; set; }
        public string Varugrupp { get; set; }
        public string Forpackning { get; set; }
        public string Forslutning { get; set; }
        public string Ursprung { get; set; }
        public string Ursprunglandnamn { get; set; }
        public string Producent { get; set; }
        public string Leverantor { get; set; }
        public int? Argang { get; set; }
        public int? Provadargang { get; set; }
        public double Alkoholhalt { get; set; }
        public string Sortiment { get; set; }
        public bool Ekologisk { get; set; }
        public bool Koscher { get; set; }
        public string RavarorBeskrivning { get; set; }
    }
}