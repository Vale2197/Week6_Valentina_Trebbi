using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWeek6.Entities
{
    internal class MAgente : IMAgenti
    {

        private string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Add(Agente agente)
        {
            bool fatto = true;

            SqlConnection conn = new SqlConnection(connection_string);
            List<Agente> agentiEsistenti = GetAll();

            foreach (Agente a in agentiEsistenti)
            {
                if (a.CodiceFiscale.ToLower() == agente.CodiceFiscale.ToLower())
                {
                    fatto = false;
                }
            }

            if (fatto)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Agente values( @nome , @cognome , @codiceFisc , @area , @annoInizio )", conn);
                cmd.Parameters.AddWithValue("@nome", agente.Nome);
                cmd.Parameters.AddWithValue("@cognome", agente.Cognome);
                cmd.Parameters.AddWithValue("@codiceFisc", agente.CodiceFiscale);
                cmd.Parameters.AddWithValue("@area", agente.AreaGeografica);
                cmd.Parameters.AddWithValue("@annoInizio", agente.AnnoInizio);

                int result = cmd.ExecuteNonQuery();

                conn.Close();

                Console.WriteLine($"{result} agenti aggiunti");
            }

            return fatto;

        }

        public List<Agente> GetAll()
        {
            List<Agente> list = new List<Agente>();

            SqlConnection connection = new SqlConnection(connection_string);
            connection.Open();

            SqlCommand cmd = new SqlCommand("select * from Agente", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string nome = (string)reader["nome"];
                string cognome = (string)reader["cognome"];
                string codiceF = (string)reader["codiceFiscale"];
                string area = (string)reader["areaGeografica"];
                int annoInizio = (int)reader["annoDiInizio"];

                Agente agente = new Agente(nome, cognome, codiceF, area, annoInizio);
                list.Add(agente);
            }

            connection.Close();
            return list;
        }

        public void GetByArea(string area)
        {
            List<Agente> list = new List<Agente>();

            SqlConnection conn = new SqlConnection(connection_string);
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Agente where areaGeografica = @area", conn);

            command.Parameters.AddWithValue("@area", area);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string nome = (string)reader["nome"];
                string cognome = (string)reader["cognome"];
                string codiceF = (string)reader["codiceFiscale"];
                string areaG = (string)reader["areaGeografica"];
                int annoInizio = (int)reader["annoDiInizio"];

                Agente agente = new Agente(nome, cognome, codiceF, areaG, annoInizio);
                list.Add(agente);
            }

            conn.Close();

            if (list.Count() > 0)
            {
                foreach (Agente a in list)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            else
            {
                Console.WriteLine("non sono presenti agenti in quest' area");
            }
        }

        public void GetByYears(int year)
        {
            List<Agente> list = GetAll();

            bool esistono = false;

            foreach (Agente a in list)
            {
                if (a.AnniDiServizio() >= year)
                {
                    Console.WriteLine(a.ToString());
                    esistono = true;
                }
            }

            if (!esistono)
            {
                Console.WriteLine("non ci sono agenti con anni di servizio uguali o maggiori di quelli inseriti :(");
            }

        }

    }
}
