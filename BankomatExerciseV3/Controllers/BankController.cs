using BankomatExerciseV3.Db;
using BankomatExerciseV3.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExerciseV3.Controllers
{
    public class BankController
    {
        private readonly IDbRepository _dbRepository;

        public BankController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public   List<Utenti>GetUsers()
        {
            return  _dbRepository.GetUtentis();
        }

        public  List<Banche> GetBanks()
        {
            return  _dbRepository.GetBanks();
        }

        public  SortedList<int,Banche> GetSortedBanks()
        {
            return  _dbRepository.GetSortedBanks();
        }

        public bool CheckUsername(string username)
        {
            var result =  _dbRepository.CheckUsername(username);
            return result;
        }

        public Utenti CheckAccountCredentials(string username, string password,int idBanca)
        {
            var utente =  _dbRepository.CheckAccountCredentials(username,password, idBanca);
            return utente;
        }

        public int GetBankIdByUserInputChoice(SortedList<int, Banche> sortedListBanks,int idBank)
        {
            var utente = _dbRepository.GetBankIdByUserInputChoice(sortedListBanks, idBank);
            return utente;
        }
    }
}
