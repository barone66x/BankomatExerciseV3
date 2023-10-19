using BankomatExerciseV3.Controllers;
using BankomatExerciseV3.Db;
using BankomatExerciseV3.Menu;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExerciseV3
{
    public class Inizializza
    {
        List<Utenti> _utenti;
        private readonly BankController _bankController;
        private readonly UserInterface _menu;

        public Inizializza(BankController bankController, UserInterface menu)
        {
            _bankController = bankController;
            _menu = menu;
        }

        public  void Execute()
        {

            //_utenti = await _bankController.GetUsers();

            //Console.WriteLine(_utenti[1].NomeUtente);
            //_menu.Esegui(await _bankController.GetUsers());
           // var utenti = await _bankController.GetUsers();
           //var banca = await _bankController.GetBanks();
            _menu.WelcomeScreen();


            //Console.ReadLine();
        }
    }
}
