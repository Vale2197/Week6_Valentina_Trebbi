// See https://aka.ms/new-console-template for more information
//Implementare una Console App che tramite menù permetta di:
//-Mostrare tutti gli agenti di polizia
//- Scelta un’area geografica, mostrare gli agenti assegnati a quell’area
//- Scelti gli anni di servizio, mostrare gli agenti con anni di servizio maggiori o uguali rispetto all’input
//- Inserire un nuovo agente solo se non è già presente nel database
using CodeWeek6;
using CodeWeek6.Entities;

Console.WriteLine("----Polizia----");

bool program = true;

int choice = 0;

IMAgenti agenti = new MAgente();

do
{
    Menu();
    choice = LeggiNum();

    switch (choice)
    {
        case 1:
            MostraAgenti();
            break;

        case 2:
            MostraAgenteAreaSpecifica();
            break;

        case 3:
            MostraInBaseAgliAnniServizio();
            break;

        case 4:
            RegistraAgente();
            break;
        case 5:
            program = false;
            break;

        default:
            Console.WriteLine("scelta non valida");
            break;
    }

} while (program);

static int LeggiNum()
{
    int num = 0;

    while (!int.TryParse(Console.ReadLine(), out num) || num <= 0 || num > DateTime.Now.Year)
    {
        Console.WriteLine("numero non valido o troppo grande");
    }
    return num;
}

static void Menu()
{
    Console.WriteLine("1- Mostra tutti gli agenti");
    Console.WriteLine("2- Mostra tutti gli agenti in base all'area geografica");
    Console.WriteLine("3- Mostra agenti in base agli anni di servizio maggiori di un determinato anno");
    Console.WriteLine("4- Registra agente");
    Console.WriteLine("5- Esci");
}

void MostraAgenti()
{
    if (agenti.GetAll().Count() != 0)
    {
        foreach (var item in agenti.GetAll())
        {
            Console.WriteLine(item.ToString());
        }

    }
    else
    {
        Console.WriteLine("mi dispiace ma ancora non sono presenti agenti registrati..");
    }

}

void MostraAgenteAreaSpecifica()
{
    Console.WriteLine("inserisci un' area geografica");

    string area = Console.ReadLine();
    agenti.GetByArea(area);
}

void MostraInBaseAgliAnniServizio()
{
    Console.WriteLine("inserisci l'anno minimo di servizio");

    int anno = LeggiNum();

    agenti.GetByYears(anno);
}

void RegistraAgente()
{
    Agente agente = new Agente();
    Console.WriteLine("inserisci Nome");
    agente.Nome = Console.ReadLine();

    Console.WriteLine("inserisci Cognome");
    agente.Cognome = Console.ReadLine();

    Console.WriteLine("inserisci codice fiscale");
    agente.CodiceFiscale = Console.ReadLine();

    Console.WriteLine("inserisci area geografica");
    agente.AreaGeografica = Console.ReadLine();

    Console.WriteLine("inserisci anno di inizio");
    agente.AnnoInizio = LeggiNum();

    Console.WriteLine("verifica...");

    if(agenti.Add(agente))
    {
        Console.WriteLine("l'operazione è andata a buon fine");
    }
    else
    {
        Console.WriteLine("qualcosa è andato storto... verifica di non aver inserito un codice fiscale esistente");
    }
    
}