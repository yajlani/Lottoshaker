using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices.Sensors;

namespace Lottoshaker
{
    public partial class NumberSelection : PhoneApplicationPage
    {

        int highestNum;     // highest number allows in this lottery
        int numsToPick;     // number of digits in this lottery (6 max)
        Random rndNum;  // random number generator
        List<int> lottoNums;
        int lottoNum;
        shaker myShaker;


        public NumberSelection()
        {
            InitializeComponent();
            rndNum = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            lottoNums = new List<int>();
            myShaker = new shaker();
        }

       

        private void ShookDevice(object sender, EventArgs e)
        {
            // Update UI
            if (e.GetType() == typeof(SensorReadingEventArgs<AccelerometerReading>))
            {
                // Update UI
                SensorReadingEventArgs<AccelerometerReading> acc = (SensorReadingEventArgs<AccelerometerReading>)e;
                Dispatcher.BeginInvoke(() => UpdateUI());
            }
        }

        private void UpdateUI()
        {
            PickNumbers();
            ShowNumbers();
            SetUpLottery();
            lottoNums.Clear();

        }

        private void SetUpLottery()
        {
            switch (MainPage.chosenLottery)
            {
                case Lottoshaker.MainPage.Lottery.Lotto649:
                    highestNum = 49;
                    numsToPick = 6;
                    break;
                case Lottoshaker.MainPage.Lottery.Lottario:
                    highestNum = 45;
                    numsToPick = 6;
                    break;
                case Lottoshaker.MainPage.Lottery.Ontario49:
                    highestNum = 49;
                    numsToPick = 6;
                    break;
                case Lottoshaker.MainPage.Lottery.Powerball:
                    highestNum = 45;
                    numsToPick = 6;
                    break;
                case Lottoshaker.MainPage.Lottery.Sweet:
                    highestNum = 45;
                    numsToPick = 6;
                    break;
                case Lottoshaker.MainPage.Lottery.NYLotto:
                    highestNum = 59;
                    numsToPick = 6;
                    break;
            }
        }

        private void PickNumbers()
        {
            for (int i = 0; i < numsToPick; i++)
            {
                int num = rndNum.Next(1, highestNum + 1);
                while (isNumberChosen(num)){
                    num = rndNum.Next(1, highestNum + 1);
                }
                lottoNums.Add(num);

            }

        }

        private void ShowNumbers()
        {
            int blockNum = 1;
            foreach (int num in lottoNums)
            {
                string name = "Pick" + blockNum.ToString() + "_Block";
                TextBlock curBlock = (TextBlock)this.FindName(name);

                if (curBlock != null)
                {
                    curBlock.Text = num.ToString();
                }
                blockNum++;

                if (blockNum > 6)
                {
                    break;
                }
                
            }
        }

        private bool isNumberChosen(int num)
        {
            bool found = false;
            foreach (int lottoNum in lottoNums) {
                if (lottoNum == num)
                {
                    found = true;
                }
            }
            return found;

        }


        private void Pick_Button_Click_1(object sender, RoutedEventArgs e)
        {
            myShaker.StartAccelerometer();
            myShaker.Shook += new EventHandler(ShookDevice);
           
        }

    }
}