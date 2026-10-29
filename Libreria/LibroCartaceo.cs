namespace Libreria
{
    internal class LibroCartaceo : Libro, IPrestabile
    {
        public int NumeroPagine { get; set; }
        public bool Prestato { get; set; }

        public override string Dettagli()
        {
            return $"{Titolo} - {Autore} - " + $"{AnnoPubblicazione} - " + $"{Genere} - {NumeroPagine} pagine - " + $"{(Prestato ? "Prestato" : "Disponibile")}";
        }
        public void Presta()
        {
            if (Prestato == false)
            {
                Prestato = true;
            }
            else
            {
                Console.WriteLine("Il libro è già prestato!");
            }
        }

        public void Restituisci()
        {
            if (Prestato == true)
            {
                Prestato = false;
            }
            else
            {
                Console.WriteLine("Il libro è già disponibile!");
            }
        }
    }
}
