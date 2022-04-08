using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWeek6.Entities
{
    internal class Agente : Persona
    {
        public string AreaGeografica { get; set; }

        public int AnnoInizio { get; set; }

        public Agente()
        {

        }
        public Agente(string nome, string cognome, string codice, string area, int annoInizio) : base(nome, cognome, codice)
        {
            AreaGeografica = area;
            AnnoInizio = annoInizio;
        }

        public int AnniDiServizio()
        {
            int oggiAnno = DateTime.Now.Year;

            return oggiAnno - AnnoInizio;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Anni Di Servizio: {AnniDiServizio()}";
        }
    }
}
