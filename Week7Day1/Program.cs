
using System;
using Week7Day1.Core.BusinessLayer;
using Week7Day1.Core.Entities;
using Week7Day1.RepositoryMock;

namespace Week7Day1
{
    class Program
    {
       
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryDocentiMock(), new RepositoryLezioniMock(), new RepositoryStudentiMock());
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************Menu****************");
            //Funzionalità su Corsi
            Console.WriteLine("\nFunzionalità CORSI");
            Console.WriteLine("1. Visualizza Corsi");
            Console.WriteLine("2. Inserisci nuovo Corso");
            Console.WriteLine("3. Modifica Corso");
            Console.WriteLine("4. Elimina Corso");
            //Funzionalità su Docenti
            Console.WriteLine("\nFunzionalità Docenti");
            Console.WriteLine("5. Visualizza Docenti");
            Console.WriteLine("6. Inserisci nuovo Docente");
            Console.WriteLine("7. Modifica Docente");
            Console.WriteLine("8. Elimina Docente");
            //Funzionalità su Lezioni
            Console.WriteLine("\nFunzionalità Lezioni");
            Console.WriteLine("9. Visualizza elenco delle lezioni completo");
            Console.WriteLine("10. Inserimento nuova lezione");
            Console.WriteLine("11. Modifica lezione");//per semplicità solo modifica Aula
            Console.WriteLine("12. Elimina lezione");
            Console.WriteLine("13. Visualizza le Lezioni di un Corso ricercando per Codice del Corso");
            Console.WriteLine("14. Visualizza le Lezioni di un Corso ricercando per Nome del Corso");
            //Funzionalità su Studenti
            Console.WriteLine("\nFunzionalità Studenti");
            Console.WriteLine("15. Visualizza l'elenco completo degli studenti");
            Console.WriteLine("16. Inserimento nuovo Studente");
            Console.WriteLine("17. Modifica Studente");//per semplicità solo email
            Console.WriteLine("18. Elimina Studente");
            Console.WriteLine("19. Visualizza l'elenco degli studenti iscritti ad un corso");

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("********************************************");


            int scelta;
            Console.Write("Inserisci scelta: ");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 19)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;

        }
        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break;
                case 4:
                    EliminaCorso();
                    break;
                case 5:
                    VisualizzaDocenti();
                    break;
                case 6:
                    InserisciNuovoDocente();
                    break;
                case 7:
                    ModificaDocente();
                    break;
                case 8:
                    EliminaDocente();
                    break;
                case 9:
                    VisualizzaLezioni();
                    break;
                case 10:
                    InserisciLezione();
                    break;
                case 11:
                    ModificaLezione();
                    break;
                case 12:
                    EliminaLezione();
                    break;
                case 13:
                    VisualizzaLezioneByCodiceCorso();
                    break;
                case 14:
                    VisualizzaLezioniByNomeCorso();
                    break;
                case 15:
                    VisualizzaStudenti();
                    break;
                case 16:
                    InserisciStudente();
                    break;
                case 17:
                    ModificaStudente();
                    break;
                case 18:
                    EliminaStudente();
                    break;
                case 19:
                    VisualizzaStudentiCorso();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void InserisciLezione()
        {
            //Chiedo le info per creare il nuovo studente
            Console.WriteLine("Inserisci data e ora di inizio: ");
            DateTime inizio = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci durata in giorni: ");
            int durata = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci aula: ");
            string aula = Console.ReadLine();
            VisualizzaDocenti();
            Console.WriteLine("Inserisci id docente a cui è assegnato la lazione: ");
            int id = int.Parse(Console.ReadLine());
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui è iscritto");
            string codiceCorso = Console.ReadLine();

            //lo creo
            Lezione nuovaLezione = new Lezione();
            nuovaLezione.DataOraInizio = inizio;
            nuovaLezione.Durata = durata;
            nuovaLezione.Aula = aula;
            nuovaLezione.CodiceCorso = codiceCorso;
            nuovaLezione.DocenteID = id;
            //lo passo al bl
            var esito = bl.InserisciNuovaLezione(nuovaLezione);
            Console.WriteLine(esito);
        }

        private static void ModificaLezione()
        {

            Console.WriteLine("Ecco l'elenco delle lezioni: ");
            VisualizzaLezioni();
            Console.WriteLine("Quale lezione vuoi modificare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova aula: ");
            string nuovoaula = Console.ReadLine();

            string esito = bl.ModificaLezione(id, nuovoaula);
            Console.WriteLine(esito);
        }

        private static void VisualizzaLezioniByNomeCorso()
        {

            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi visualizzare? Inserisci nome: ");
            string nomecorso = Console.ReadLine();
            var lezioniCorso = bl.GetAllLezioniCorsoByNome(nomecorso);
            if (lezioniCorso.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono lezioni del corso!");
            }
            else
            {
                Console.WriteLine("***Lista lezioni***");
                foreach (var item in lezioniCorso)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaLezioneByCodiceCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi visualizzare? Inserisci codice");
            string codice = Console.ReadLine();
            var lezioniCorso = bl.GetAllLezioniCorso(codice);
            if (lezioniCorso.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono lezioni del corso!");
            }
            else
            {
                Console.WriteLine("***Lista lezioni***");
                foreach (var item in lezioniCorso)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaLezione()
        {
            VisualizzaLezioni();
            Console.WriteLine("Quale lezione vuoi eliminare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine());

            string esito = bl.EliminaLezione(id);
            Console.WriteLine(esito);
        }

        private static void VisualizzaLezioni()
        {
            var lezioni = bl.GetAllLezioni();
            if (lezioni.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono lezioni!");
            }
            else
            {
                Console.WriteLine("***Lista lezioni***");
                foreach (var item in lezioni)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti: ");
            VisualizzaDocenti();
            Console.WriteLine("Quale docente vuoi eliminare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine());

            string esito = bl.EliminaDocente(id);
            Console.WriteLine(esito);
        }

        private static void ModificaDocente()
        {
            Console.WriteLine("Ecco l'elenco dei docenti: ");
            VisualizzaDocenti();
            Console.WriteLine("Quale studente vuoi modificare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova email: ");
            string nuovoemail = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo telefono: ");
            string nuovotelefono = Console.ReadLine();

            string esito = bl.ModificaDocente(id, nuovoemail, nuovotelefono);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoDocente()
        {
            //Chiedo le info per creare il nuovo docente
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci telefono");
            string telefono = Console.ReadLine();
            

            //lo creo
            Docente nuovoDocente = new Docente();
            nuovoDocente.Nome = nome;
            nuovoDocente.Cognome = cognome;
            nuovoDocente.Email = email;
            nuovoDocente.Telefono = telefono;


            //lo passo al bl
            var esito = bl.InserisciNuovoDocente(nuovoDocente);
            Console.WriteLine(esito);
        }

        private static void VisualizzaDocenti()
        {
            var docenti = bl.GetAllDocenti();
            if (docenti.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono docenti!");
            }
            else
            {
                Console.WriteLine("***Lista docenti***");
                foreach (var item in docenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void VisualizzaStudentiCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi visualizzare? ");
            string codice = Console.ReadLine();
            var studentiCorso = bl.GetAllStudentiCorso(codice);
            if (studentiCorso.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono studenti!");
            }
            else
            {
                Console.WriteLine("***Lista studenti***");
                foreach (var item in studentiCorso)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaStudente()
        {
            Console.WriteLine("Ecco l'elenco degli studenti: ");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi eliminare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine());

            string esito = bl.EliminaStudente(id);
            Console.WriteLine(esito);
        }

        private static void ModificaStudente()
        {
            Console.WriteLine("Ecco l'elenco degli studenti: ");
            VisualizzaStudenti();
            Console.WriteLine("Quale studente vuoi modificare? Inserisci l'id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la nuova email: ");
            string nuovoemail = Console.ReadLine();

            string esito = bl.ModificaStudente(id, nuovoemail);
            Console.WriteLine(esito);


        }

        private static void InserisciStudente()
        {
            //Chiedo le info per creare il nuovo studente
            Console.WriteLine("Inserisci nome");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string cognome = Console.ReadLine();
            Console.WriteLine("Inserisci email");
            string email = Console.ReadLine();
            Console.WriteLine("Inserisci dat di nascita (formato aaaa-mm-gg)");
            DateTime dataNascita = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci titolo studio");
            string titoloStudio = Console.ReadLine();
            VisualizzaCorsi();
            Console.WriteLine("Inserisci codice corso a cui è iscritto");
            string codiceCorso = Console.ReadLine();

            //lo creo
            Studente nuovoStudente = new Studente();
            nuovoStudente.Nome = nome;
            nuovoStudente.Cognome = cognome;
            nuovoStudente.DataNascita = dataNascita;
            nuovoStudente.Email = email;
            nuovoStudente.TitoloStudio = titoloStudio;
            nuovoStudente.CodiceCorso = codiceCorso;

            //lo passo al bl
            var esito = bl.InserisciNuovoStudente(nuovoStudente);
            Console.WriteLine(esito);


        }

        private static void VisualizzaStudenti()
        {
            var studenti = bl.GetAllStudenti();
            if (studenti.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono studenti!");
            }
            else
            {
                Console.WriteLine("***Lista studenti***");
                foreach (var item in studenti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        private static void EliminaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();

            string esito = bl.EliminaCorso(codice);
            Console.WriteLine(esito);
        }

        private static void ModificaCorso()
        {
            Console.WriteLine("Ecco l'elenco dei corsi disponibili");
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo nome del corso:");
            string nuovonome = Console.ReadLine();
            Console.WriteLine("Inserisci nuova descrizione: ");
            string nuovadescrizione = Console.ReadLine();

            string esito = bl.ModificaCorso(codice, nuovonome, nuovadescrizione);
            Console.WriteLine(esito);
            
        }

        private static void InserisciNuovoCorso()
        {
            //Chiedo all'utente i dati per creare il nuovo corso
            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();

            //lo creo
            Corso nuovoCorso = new Corso();
            nuovoCorso.Nome = nome;
            nuovoCorso.CodiceCorso = codice;
            nuovoCorso.Descrizone = descrizione;

            //lo passo al business layer per controllare i dati ed aggiungerlo poi nel "DB"
            string esito = bl.InserisciNuovoCorso(nuovoCorso);
            //Stampo il messaggio
            Console.WriteLine(esito);
        }

        private static void VisualizzaCorsi()
        {
            var corsi = bl.GetAllCorsi();
            if (corsi.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono corsi!");
            }
            else
            {
                Console.WriteLine("I Corsi disponibili sono:");
                foreach (var item in corsi)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}