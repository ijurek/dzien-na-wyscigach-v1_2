using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dzien_na_wyscigach_v1_2
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        // Ostatnie dwa pola są kontrolkami GUI na formularzu
        public RadioButton MyRadioButton;
        public Label MyLabel;

        /// <summary>
        /// Ustaw moje pole tekstowe na opis zakładu, a napis obok
        /// pola wyboru tak, aby pokazywał ilość pieniędzy ("Janek ma 43 zł")
        /// </summary>
        public void UpdateLabels()
        {
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " ma " + Cash + " zł";
        }

        /// <summary>
        /// Wyczyść mój zakład, aby był równy zero
        /// </summary>
        public void ClearBet()
        {
            PlaceBet(0, 1);
            UpdateLabels();
        }

        /// <summary>
        /// Ustal nowy zakład i przechowaj go w polu MyBet
        /// Zwróć true, jeżeli facet ma wystarczającą ilość pieniędzy, aby obstawić
        /// </summary>
        /// <param name="BetAmount"></param>
        /// <param name="DogToWin"></param>
        /// <returns></returns>
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if(Cash >= BetAmount)
            {
                MyBet = new Bet() { Amount = BetAmount, DogNumber = DogToWin, Bettor = this};
                UpdateLabels();
                return true;
            }
            MessageBox.Show("Nie masz wystarczającej ilości pieniędzy");
            return false;
        }

        /// <summary>
        /// Poproś o wypłatę zakładu i zaktualizuj etykiety
        /// kluczem jest użycie obiektu Bet
        /// </summary>
        /// <param name="Winner"></param>
        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLabels();
        }
    }
}