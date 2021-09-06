using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7Day1.Core.Entities;
using Week7Day1.Core.InterfaceRepositories;

namespace Week7Day1.Core.BusinessLayer
{
    public class MainBusinessLayer :IBusinessLayer
    {
        //Dichiaro quali sono i repository che ho a disposizione.
        private readonly ICorsoRepository corsiRepo;
        private readonly IDocenteRepository docentiRepo;
        private readonly IStudenteRepository studentiRepo;
        private readonly ILezioneRepository lezioniRepo;

        public MainBusinessLayer(ICorsoRepository corsi, IDocenteRepository docenti, ILezioneRepository  lezioni, IStudenteRepository studenti)
        {
            corsiRepo = corsi;
            docentiRepo = docenti;
            lezioniRepo = lezioni;
            studentiRepo = studenti;
        }

        public string EliminaCorso(string corso)
        {
            Corso corsoDaEliminare = corsiRepo.GetByCodice(corso);
            if (corsoDaEliminare != null)
            {
                corsiRepo.Delete(corsoDaEliminare);
                return "Corso eliminato con successo";
            }
            else throw new ArgumentNullException();
        }




        #region Funzionalità Corsi
        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.Fetch();
        }

        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.Fetch();
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
            if(corsoEsistente == null)
            {
                return "Errore: codice errato";
            }
            corsoEsistente.Nome = nuovoNome;
            corsoEsistente.Descrizone = nuovaDescrizione;
            corsiRepo.Update(corsoEsistente);
            return "Il corso è stato modificato con successo";
        }

        #endregion
    }
}
