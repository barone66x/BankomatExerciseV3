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
        private int _loginFailedCount = 0;
        private string _username;
        private int _databaseBankId;
        public UserInterface(BankController controller,Checker check)
        {
            _controller = controller;
            _check = check;
        }

        public  void WelcomeScreen()
        {
            int choiceBank = 0;
            bool checkLogin = false;
            
            var sortedListBanks =  _controller.GetSortedBanks();

            Console.WriteLine("Welcome to Bankomat V3");
        
            do
            {
                choiceBank =  BankList(sortedListBanks);

               
            }
            while (choiceBank == -1);

            while (checkLogin == false & _loginFailedCount <3)           
            {
                checkLogin =  Login(sortedListBanks, choiceBank);
                //if (checkLogin == false)
                //{
                //    loginFailedCount++;
                //}
            }
            if (_loginFailedCount >=3)
            {
                if (!_controller.CheckUserBlocked(_username, _databaseBankId))
                {
                    _controller.ChangeUserState(_username);

                }
                
                Console.WriteLine("blocked user");
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
             //BankList(sortedListBanks);

            Console.WriteLine("enter username");
             _username = Console.ReadLine();
            Console.WriteLine("enter password");
            var password = Console.ReadLine();

             _databaseBankId = _controller.GetBankIdByUserInputChoice(sortedListBanks, choiceBank);
            if (_controller.CheckUsername(_username, _databaseBankId))
            {
                _currentUser = _controller.CheckAccountCredentials(_username, password, _databaseBankId);
                if (_currentUser == null)
                {
                    Console.WriteLine("login failed");
                    _loginFailedCount++;
                    return false;
                }
                return true;

            }
            return false;
            
        }
    }
}
