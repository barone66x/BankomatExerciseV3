using BankomatExerciseV3.Controllers;
using BankomatExerciseV3.Db;
using BankomatExerciseV3.Menu;

using BankomatExerciseV3.Repositories;
using BankomatExerciseV3.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BankomatExerciseV3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();
            ConfigureServices(services);
            services               
                .AddSingleton<Inizializza>()
                .BuildServiceProvider()        
                .GetService<Inizializza>()
            .Execute();

            Console.ReadLine();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<IDbRepository, DbRepository>();
            services
                .AddScoped<EsercitazioneBancaEntities1>();
            services.
                AddScoped<BankController>();
           
            services
                .AddSingleton<UserInterface>();
            services
               .AddSingleton<Checker>();
        }
    }
}

