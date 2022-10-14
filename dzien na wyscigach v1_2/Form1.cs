namespace dzien_na_wyscigach_v1_2
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Greyhound[] greyhoundsArray = new Greyhound[4];
        Guy[] guysArray = new Guy[3];

        public Form1()
        {
            InitializeComponent();
            greyhoundsArray[0] = new Greyhound()
            {
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox1.Width,
                MyPictureBox = greyhoundPictureBox1,
                MyRandom = random
            };
            greyhoundsArray[1] = new Greyhound()
            {
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox2.Width,
                MyPictureBox = greyhoundPictureBox2,
                MyRandom = random
            };
            greyhoundsArray[2] = new Greyhound()
            {
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox3.Width,
                MyPictureBox = greyhoundPictureBox3,
                MyRandom = random
            };
            greyhoundsArray[3] = new Greyhound()
            {
                StartingPosition = racetrackPictureBox.Left,
                RacetrackLength = racetrackPictureBox.Width - greyhoundPictureBox4.Width,
                MyPictureBox = greyhoundPictureBox4,
                MyRandom = random 
            };
            guysArray[0] = new Guy()
            {
                Name = "Jurek",
                Cash = 50,
                MyRadioButton = janRadioButton,
                MyLabel = janBetLabel
            };
            guysArray[1] = new Guy()
            {
                Name = "Bartek",
                Cash = 50,
                MyRadioButton = bartekRadioButton,
                MyLabel = bartekBetLabel
            };
            guysArray[2] = new Guy()
            {
                Name = "Łucja",
                Cash = 50,
                MyRadioButton = arekRadioButton,
                MyLabel = arekBetLabel
            };
            minimumBetLabel.Text = "Minimalny zakłąd to " + betAmountNumericUpDown.Minimum;
            setDescription();
        }

        public void setDescription()
        {
            foreach (Guy item in guysArray)
            {
                    item.ClearBet();
            }
        }

        private void confirmBetButton_Click(object sender, EventArgs e)
        {
            foreach(Guy item in guysArray)
            {
                if (item.MyRadioButton.Checked)
                {
                    item.PlaceBet((int)betAmountNumericUpDown.Value, (int)selectGreyhoundNumberNumericUpDown.Value);
                }
            }
        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            startRace();
        }

        private void startRace()
        {
            timer1.Start();
            groupBox1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int winningDog;
            for (int i = 0; i < greyhoundsArray.Length; i++)
            {
                if (greyhoundsArray[i].Run() == true)
                {
                    timer1.Stop();
                    winningDog = i + 1;
                    for (int j = 0; j < guysArray.Length; j++)
                    {
                        guysArray[j].Collect(winningDog);
                        guysArray[j].ClearBet();
                    }
                    MessageBox.Show("wygrał chart nr " + winningDog);
                    groupBox1.Enabled = true;
                    for (int k = 0; k < greyhoundsArray.Length; k++)
                    {
                        greyhoundsArray[k].TakeStartingPosition();
                    }
                }
            }
        }

        private void janRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bartekRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void arekRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}