using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankomatExerciseV3.Db;

namespace BankomatExerciseV3.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly EsercitazioneBancaEntities1 _ctx;

        public DbRepository(EsercitazioneBancaEntities1 ctx)
        {
            _ctx = ctx;
        }

        public List<Utenti> GetUtentis()
        {
            var utenti =  _ctx.Utenti.ToList();
            return utenti;
        }

        public  List<Banche> GetBanks()
        {
            var banche = _ctx.Banche.ToList();
            return banche;
        }

        public  SortedList<int,Banche> GetSortedBanks()
        {
            var banche =  _ctx.Banche.ToList();
            SortedList<int, Banche> sortedBanche = new SortedList<int, Banche>();
            int i = 1;
            foreach (var banca in banche)
            {
                sortedBanche.Add(i,banca);
                i++;
            }

            return sortedBanche;
        }

        public  bool CheckUsername(string username)
        {
            var utente =  _ctx.Utenti.Where(u => u.NomeUtente.Equals(username)).FirstOrDefault();
            if (utente == null)
            { 
                return false;
            }
            return true;
        }

        public Utenti CheckAccountCredentials(string username,string password,int idBanca)
        {
            var utente =  _ctx.Utenti.Where(u => u.NomeUtente.Equals(username)).FirstOrDefault();

            if (utente == null)
            {
                return null;
            }

            if (utente.IdBanca == idBanca & utente.Password.Equals(password))
            {
                return utente;
            }
            else return null;
        }

        public int GetBankIdByUserInputChoice(SortedList<int, Banche> sortedListBanks,int choice)
        {
            var userBank = sortedListBanks[choice];
            return (int)_ctx.Banche.Where(i => i.Id == userBank.Id).FirstOrDefault().Id;
             
        }
    }
}
