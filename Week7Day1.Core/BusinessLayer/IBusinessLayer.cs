using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;

namespace Week7Day1.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Aggiungere "l'elenco" delle funzionalità richieste dalla traccia

        #region Funzionalità Corsi
        //Visualizza corsi
        public List<Corso> GetAllCorsi();

        //Inserire un nuovo corso
        public string InserisciNuovoCorso(Corso newCorso);

        //Modifica Coros
        public string ModificaCorso(string codiceCorsoDaModificare, string nuovoNome, string nuovaDescrizione);

        public string EliminaCorso(string codice);

        #endregion
        #region Funzionalità Studenti
        //Visualizza tutti gli studenti
        public List<Studente> GetAllStudenti();

        public string InserisciNuovoStudente(Studente nuovoStudente);
        public string EliminaStudente(int id);
        public string ModificaStudente(int id, string nuovoemail);
        public List<Studente> GetAllStudentiCorso(string codice);
        #endregion

        public List<Docente> GetAllDocenti();
        public string InserisciNuovoDocente(Docente nuovoDocente);
        public string EliminaDocente(int id);
        public string ModificaDocente(int id, string nuovoemail, string nuovotelefono);
        public List<Lezione> GetAllLezioni();
        public string InserisciNuovaLezione(Lezione nuovaLezione);
        public string ModificaLezione(int id, string nuovoaula);
        public string EliminaLezione(int id);
        public List<Lezione> GetAllLezioniCorso(string codice);
        public List<Lezione> GetAllLezioniCorsoByNome(string nomecorso);
    }
}
