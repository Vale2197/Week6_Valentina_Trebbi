using CodeWeek6.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWeek6
{
    internal interface IMAgenti
    {
        List<Agente> GetAll();

        void GetByArea(string area);

        void GetByYears(int year);

        bool Add(Agente agente);
    }
}
