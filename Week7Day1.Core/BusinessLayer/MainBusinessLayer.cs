using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;
using Week7Day1.Core.InterfaceRepositories;

namespace Week7Day1.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        //Dichiaro quali sono i repository che ho a disposizione.
        private readonly ICorsoRepository corsiRepo;
        private readonly IDocenteRepository docentiRepo;
        private readonly IStudenteRepository studentiRepo;
        private readonly ILezioneRepository lezioniRepo;

        public MainBusinessLayer(ICorsoRepository corsi, IDocenteRepository docenti, ILezioneRepository lezioni, IStudenteRepository studenti)
        {
            corsiRepo = corsi;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            studentiRepo = studenti;
        }

        public string EliminaCorso(string corso)
        {
            Corso corsoDaEliminare = corsiRepo.GetByCodice(corso);
            //TODO:non deve essere possibile cancellare un corso che ha almeno una lezione associata
            //nè un corso che ha almeno uno studente iscritto.
            if (corsoDaEliminare != null && corsoDaEliminare.Studenti.Count < 2 && corsoDaEliminare.Lezioni.Count < 1)
            {
                corsiRepo.Delete(corsoDaEliminare);
                return "Corso eliminato con successo";
            }
            else throw new ArgumentNullException("Non è possibile eliminare il corso in quanto può essere nullo o il corso ha un numero di iscritti maggiore di 2 con lezioni");
        }




        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.Fetch();
        }



        public string InserisciNuovoCorso(Corso newCorso)
        {
            //controllo input
            //non deve esistere un altro corso con lo stesso codice
            var corsoEsistente = corsiRepo.GetByCodice(newCorso.CodiceCorso);
            if (corsoEsistente != null)
            {
                return "Errore: Codice corso già presente";
            }
            corsiRepo.Add(newCorso);
            return "Corso aggiunto correttamente";
        }

        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione)
        {
            //controllo di dati
            Corso corsoEsistente = corsiRepo.GetByCodice(codiceCorsoDaModificare);
            if (corsoEsistente == null)
            {
                return "Errore: codice errato";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizone = nuovaDescrizione;
            corsiRepo.Update(corsoEsistente);
            return "Il corso è stato modificato con successo";
        }



       
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.Fetch();
        }

        public string InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCodice(nuovoStudente.CodiceCorso);
            if (corsoEsistente == null)
            {
                return "Codice corso errato";
            }
            studentiRepo.Add(nuovoStudente);
            return "studente inserito correttamente";
        }

        public string EliminaStudente(int id)
        {
            Studente studenteDaEliminare = studentiRepo.GetById(id);
            if (studenteDaEliminare != null)
            {
                studentiRepo.Delete(studenteDaEliminare);
                return "studente eliminato con successo";
            }
            else throw new ArgumentNullException();
        }

        public string ModificaStudente(int id, string nuovoemail)
        {
            Studente studenteEsistente = studentiRepo.GetById(id);
            if (studenteEsistente == null)
            {
                return "Errore: codice errato";
            }
            studenteEsistente.Email = nuovoemail;
            studentiRepo.Update(studenteEsistente);
            return "lo studente è stato modificato con successo";
        }

        public List<Studente> GetAllStudentiCorso(string codice)
        {
            return studentiRepo.GetByCorso(codice);
        }

        public List<Docente> GetAllDocenti()
        {
            return docentiRepo.Fetch();
        }

        public string InserisciNuovoDocente(Docente nuovoDocente)
        {
            //controllo input
            Docente docenteEsistente = docentiRepo.VerificaDocente(nuovoDocente);
            if (docenteEsistente == null)
            {
                docentiRepo.Add(nuovoDocente);
                return "Docente inserito correttamente";
            }
            else return "Il docente che si vuole inserire è già nel sistema. ";

        }

        public string EliminaDocente(int id)
        {
            Docente docenteDaEliminare = docentiRepo.GetById(id);
            if (docenteDaEliminare != null)
            {
                docentiRepo.Delete(docenteDaEliminare);
                return "docente eliminato con successo";
            }
            else throw new ArgumentNullException("docente non trovato");
        }

        public string ModificaDocente(int id, string nuovoemail, string nuovotelefono)
        {

           Docente docenteEsistente = docentiRepo.GetById(id);
            if (docenteEsistente == null)
            {
                return "Errore: codice errato";
            }
            docenteEsistente.Email = nuovoemail;
            docenteEsistente.Telefono = nuovotelefono;
            docentiRepo.Update(docenteEsistente);
            return "il docente è stato modificato con successo";
        }

        public List<Lezione> GetAllLezioni()
        {
            return lezioniRepo.Fetch();
        }

        public string InserisciNuovaLezione(Lezione nuovaLezione)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCodice(nuovaLezione.CodiceCorso);
            if (corsoEsistente == null)
            {
                return "Codice corso errato";
            }
            Docente docenteEsistente = docentiRepo.GetById(nuovaLezione.DocenteID);
            if(docenteEsistente == null)
            {
                return "Docente id non trovato";
            }
            lezioniRepo.Add(nuovaLezione);
            return "lezione inserito correttamente";
        }

        public string ModificaLezione(int id, string nuovoaula)
        {

            Lezione lezioneEsistente = lezioniRepo.GetByLezioneId(id);
            if (lezioneEsistente == null)
            {
                return "Errore: id errato";
            }
            lezioneEsistente.Aula = nuovoaula;
            lezioniRepo.Update(lezioneEsistente);
            return "la lezione è stata modificata con successo";
        }

        public string EliminaLezione(int id)
        {
            Lezione lezioneDaEliminare = lezioniRepo.GetByLezioneId(id);
            if (lezioneDaEliminare != null)
            {
                lezioniRepo.Delete(lezioneDaEliminare);
                return "lezione eliminato con successo";
            }
            else throw new ArgumentNullException("lezione selezionata non esistente.");
        }

        public List<Lezione> GetAllLezioniCorso(string codice)
        {
            return lezioniRepo.GetLezioniByCodice(codice);
        }

        public List<Lezione> GetAllLezioniCorsoByNome(string nomecorso)
        {
            return lezioniRepo.GetLezioniByNome(nomecorso);
        }
    }
}