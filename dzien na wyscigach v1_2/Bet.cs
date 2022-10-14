using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dzien_na_wyscigach_v1_2
{
    public class Bet
    {
        public int Amount;
        public int DogNumber;
        public Guy Bettor;

        /// <summary>
        /// Zwraca string, który określa, kto obstawił wyścig, jak dużo pieniędzy
        /// postawił i na którego psa (" Janek postawił 8 zł na psa numr 4").
        /// Jeżeli ilość jest równa zero, zakład nie został zawarty
        /// ("Janek nie zawarł zakładu")
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            if (Amount == 0)
            {
               return Bettor.Name + " nie zawarł zakładu ";
            }
            else
            {
                return Bettor.Name + " stawia " + Amount + " na charta numer " + DogNumber;
            }
        }

        /// <summary>
        /// Parametrem jest zwycięzca wyścigu. Jeżeli pies wygrał,
        /// zwróć wartość podstawową. W przeciwnym razie zwróć wartość
        /// postawioną ze znakiem minus
        /// </summary>
        /// <param name="Winner"></param>
        /// <returns></returns>
        public int PayOut(int Winner)
        {
            if(DogNumber == Winner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}