using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWeek6.Entities
{
    internal abstract class Persona
    {
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string CodiceFiscale { get; set; }

        public Persona()
        {

        }
        public Persona(string nome, string cognome, string codice)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codice;
        }

        public override string ToString()
        {
            return $"CF: {CodiceFiscale} - Nome: {Nome} - Cognome: {Cognome}";
        }
    }
}
