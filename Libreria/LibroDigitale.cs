namespace Libreria
{
    internal class LibroDigitale : Libro
    {
        public decimal DimensioneMB { get; set; }

        public override string Dettagli()
        {
            return $"{Titolo} - {Autore} - " + $"{AnnoPubblicazione} - " + $"{Genere} - {DimensioneMB} MB";
        }
    }
}
