using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaDictionary
{
    internal class CLibro
    {
        private string titolo;
        private string autore;
        private int anno;
        
        public CLibro(string titolo, string autore, int anno)
        {
            this.titolo = titolo;
            this.autore = autore;
            this.anno = anno;
        }

        public CLibro()
        {
            titolo = "";
            autore = "";
            anno = 0;
        }

        public string Titolo
        {
            get { return titolo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Titolo non valido.");
                }
                titolo = value;
            }
        }
        public string Autore
        {
            get { return autore; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Autore non valido.");
                }
                autore = value;
            }
        }
        public int Anno
        {
            get { return anno; }
            set
            {
                if (value > DateTime.Now.Year || value < 0)
                {
                    throw new Exception("Anno non valido.");
                }
                anno = value;
            }
        }

        public string Dettagli()
        {
            return $"Titolo: {titolo}, Autore: {autore}, Anno: {anno}";
        }

    }
}
