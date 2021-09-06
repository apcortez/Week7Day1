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
        public List<Studente> GetAllStudenti();
        #endregion
    }
}
