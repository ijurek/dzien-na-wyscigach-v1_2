using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dzien_na_wyscigach_v1_2
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        /// <summary>
        /// Przesuń się do przodu losowo o 1,2,3,4 punkty
        /// Zaktualizij położenie PictureBox na formularzu
        /// Zwruć true, jeżeli wygram wyścig
        /// </summary>
        /// <returns></returns>
        public bool Run()
        {
            if (Location <= RacetrackLength)
            {
                MyPictureBox.Left = Location += MyRandom.Next(55);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Wyzeruj położenie i ustaw na linii startowej
        /// </summary>
        public void TakeStartingPosition()
        {
            MyPictureBox.Left = StartingPosition;
            Location = 0;
        }
    }
}