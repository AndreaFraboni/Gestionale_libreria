namespace Libreria {

    public abstract class Libro
    {

        public string Titolo;
        public string Autore;
        public int AnnoPubblicazione;
        public Genere Genere;

        public abstract void Dettagli();
    }
}