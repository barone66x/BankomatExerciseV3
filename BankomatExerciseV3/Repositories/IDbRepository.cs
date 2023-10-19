using BankomatExerciseV3.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExerciseV3.Repositories
{
    public interface IDbRepository
    {
        List<Utenti> GetUtentis();
        List<Banche> GetBanks();
        SortedList<int, Banche> GetSortedBanks();

        bool CheckUsername(string username);
        Utenti CheckAccountCredentials(string username, string password,int idBanca);

        int GetBankIdByUserInputChoice(SortedList<int, Banche> sortedListBanks,int choice);



    }
}
