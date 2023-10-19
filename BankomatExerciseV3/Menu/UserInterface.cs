using BankomatExerciseV3.Controllers;
using BankomatExerciseV3.Db;
using BankomatExerciseV3.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExerciseV3.Menu
{
    public class UserInterface
    {
        private Banche _currentBank;
        private Utenti _currentUser;
        private BankController _controller;
        private Checker _check;
        public UserInterface(BankController controller,Checker check)
        {
            _controller = controller;
            _check = check;
        }

        public  void WelcomeScreen()
        {
            int choiceBank = 0;
            bool checkLogin = false;
            int loginFailedCount = 0;
            var sortedListBanks =  _controller.GetSortedBanks();

            Console.WriteLine("Welcome to Bankomat V3");
        
            do
            {
                choiceBank =  BankList(sortedListBanks);

               
            }
            while (choiceBank == -1);

            while (checkLogin == false & loginFailedCount <3)           
            {
                checkLogin =  Login(sortedListBanks, choiceBank);
                if (checkLogin == false)
                {
                    loginFailedCount++;
                }
            }
            if (loginFailedCount >=3)
            {
                Console.WriteLine("implement block user");
            }
            else
            {
                Console.WriteLine($"login successfully, {_currentUser.NomeUtente}");
            }
            
          


        }

        private  int BankList(SortedList<int, Banche> sortedListBanks)
        {
            string stringInput = string.Empty;
            int input = 0;
            Console.WriteLine("Select a bank");
            foreach (var sortedBank in sortedListBanks)
            {
                Console.WriteLine($"{sortedBank.Key}   {sortedBank.Value.Nome}");
            }

             stringInput = Console.ReadLine();
   
            if (_check.IsNumber(stringInput))
            {
                input = int.Parse(stringInput);
                if (_check.IsValidNumber(input, 1,sortedListBanks.Count))
                {
                   return input;
                }
            }
            return -1;
            

            
        }


        private  bool Login(SortedList<int,Banche> sortedListBanks, int choiceBank)
        {
             BankList(sortedListBanks);

            Console.WriteLine("enter username");
            var username = Console.ReadLine();
            Console.WriteLine("enter password");
            var password = Console.ReadLine();

            var databaseBankId = _controller.GetBankIdByUserInputChoice(sortedListBanks, choiceBank);

            _currentUser =  _controller.CheckAccountCredentials(username, password, databaseBankId);
            if (_currentUser == null)
            {
                Console.WriteLine("login failed");
                return false;
            }
            return true;
        }
    }
}
