using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankomatExerciseV3.Utilities
{
    public class Checker
    {
        public bool IsNumber(string input)
        {
            try
            {
                int number = int.Parse(input);
            }
            catch (Exception ex)
            { 
                Console.WriteLine("input is not a number");
                return false;
            }
            return true;

        }

        public bool IsValidNumber(int input, int minValue, int maxValue) 
        { 
            if (input >= minValue & input <= maxValue) 
            { 
            return true;
            }
            return false;
        
        }
    }
}
