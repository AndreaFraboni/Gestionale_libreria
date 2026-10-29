namespace Libreria
{
    public static class Biblioteca
    {
        static List<Libro> listOfBooks = new List<Libro>();

        public static Libro Cerca(string Titolo)
        {
            foreach (Libro libro in listOfBooks)
            {
                if (libro.Titolo == Titolo) return libro;
            }

            return null;
        }

        public static void Aggiungi(Libro libro)
        {
            listOfBooks.Add(libro);
        }

        public static void Rimuovi(Libro libro)
        {
            if (listOfBooks.Remove(libro))
            {
                Console.WriteLine("Libro rimosso!");
            }
            else
            {
                Console.WriteLine("Libro non trovato!");
            }
        }
        public static void Elenca()
        {
            if (listOfBooks.Count == 0)
            {
                Console.WriteLine("Biblioteca vuota!");
                return;
            }

            foreach (Libro libro in listOfBooks)
            {
                Console.WriteLine(libro.Dettagli());
            }
        }

    }
}
