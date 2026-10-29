namespace Libreria
{
    public abstract class Libro
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public int AnnoPubblicazione { get; set; }
        public Genere Genere { get; set; }

        public abstract string Dettagli();
    }
}
