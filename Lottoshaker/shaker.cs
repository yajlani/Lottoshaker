using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Devices.Sensors;
using System.Windows;
using System.Windows.Threading;

namespace Lottoshaker
{
    public class shaker
    {
        public Accelerometer accelerometer;   // the accelerometer
        private AccelerometerReading lastReading;  // store the last reading for delta's
        const float ReadingThreshold = 0.1f;  // the threshold we use to determine how much we shake

        public event EventHandler Shook; // Holds the Shaker event we will send to the UI

         public shaker()
        {
            if (!Accelerometer.IsSupported)
                MessageBox.Show("Accelerometer not Supported.");
        }

        public void StartAccelerometer()
        {
            if (accelerometer == null)
            {
                // Instantiate the Accelerometer.
                accelerometer = new Accelerometer();
                accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(500); // how fast to recieve data
                accelerometer.CurrentValueChanged += new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(accelerometer_CurrentValueChanged); // handler when changed
            }
            try
            {
                accelerometer.Start();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Failed to start accel.");
            }

        }

         public void StopAccelerometer()
       {
            if (accelerometer != null)
            {
                // Stop the accelerometer.
                accelerometer.Stop();
            }
        }


         void accelerometer_CurrentValueChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {     
            if (Math.Abs(lastReading.Acceleration.X - e.SensorReading.Acceleration.X) > ReadingThreshold)
            {
                if (Shook != null)
                    Shook(this, e); // Call shook event every time we shake
            }
            lastReading = e.SensorReading;
          }

    }
}
