using MathNet.Numerics.Distributions;
using ProjectStrat.Events;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace ProjectStrat
{
    public class HeartRateSensor
    {
        readonly Random random = new();
        readonly double shape = 5.0; // Shape parameter, tune this according to your needs
        readonly double rate = 0.1; // Rate parameter, tune this according to your needs
        int upperBound = 101;
        
        public double SampleHeartRate()
        {
            // Create a new Gamma distribution with the given shape and rate
            Gamma gamma = new Gamma(shape, rate);

            double heartRate;

            // Generate a random number between 0 and 100
            int randomNumber = random.Next(0, upperBound);

            // Assign a 90% chance to generate a number between 50 and 60,
            // and a 10% chance to generate a number outside this range.
            if (randomNumber <= 90)
            {
                heartRate = gamma.Sample() + 50; // Adjust this according to your needs
            }
            else
            {
               
              heartRate = gamma.Sample() + 60; // Adjust this according to your needs
            }
            Debug.WriteLine(heartRate);
            return heartRate;
        }
        internal void Decrease(object? sender, KeyPressEventArgs e)
        {
            if (upperBound > 90 && e.Key == 'd')
                upperBound--;
            Debug.WriteLine("Decreased");
        }
        internal void Increase(object? sender, KeyPressEventArgs e)
        {
            if (upperBound < 120 && e.Key == 'a')
                upperBound++;
            Debug.WriteLine("Increased");
        }
    }
}