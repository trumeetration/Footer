﻿using Android.App;
using Android.Content;
using Android.Hardware;
using Android.Runtime;
using Android.Widget;
using Footer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Java.Util;

namespace Footer.Droid
{
    public class StepCounter : Java.Lang.Object, IStepCounter, ISensorEventListener
    {

        private int StepsCounter = 0;
        private SensorManager sManager;
        private double MagnitudePrevious = 0;
        private float[] gravity = {0f,0f,0f};
        private List<double> zscoreCalculationValues = new List<double>();
        private int DATA_SAMPLING_SIZE = 15;
        private int LAG_SIZE = 5;
        private int peakCount = 0;

        public int Steps
        {
            get { return StepsCounter; }
            set { StepsCounter = value; }
        }

        public new void Dispose()
        {
            sManager.UnregisterListener(this);
            sManager.Dispose();
        }

        public void InitSensorService()
        {

            sManager = Android.App.Application.Context.GetSystemService(Context.SensorService) as SensorManager;

            sManager.RegisterListener(this, sManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Normal);
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {


            Console.WriteLine("OnAccuracyChanged called");
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if (e.Sensor.Type == SensorType.Accelerometer)
            {
                float x_acc = e.Values[0];
                float y_acc = e.Values[1];
                float z_acc = e.Values[2];

                float alpha = 0.8f;
                gravity[0] = alpha * gravity[0] + (1 - alpha) * x_acc;
                gravity[1] = alpha * gravity[1] + (1 - alpha) * y_acc;
                gravity[2] = alpha * gravity[2] + (1 - alpha) * z_acc;
                x_acc = x_acc - gravity[0];
                y_acc = y_acc - gravity[1];
                z_acc = z_acc - gravity[2];

                double Magnitude = Math.Sqrt(x_acc * x_acc + y_acc * y_acc + z_acc * z_acc);
                if (zscoreCalculationValues.Count < DATA_SAMPLING_SIZE)
                {
                    zscoreCalculationValues.Add(Magnitude);
                }
                else if (zscoreCalculationValues.Count == DATA_SAMPLING_SIZE)
                {
                    Steps += DetectPeak(zscoreCalculationValues, LAG_SIZE, 3d, 0.2d);
                    zscoreCalculationValues.Clear();
                    zscoreCalculationValues.Add(Magnitude);
                }
            }
            else
            {
                Toast.MakeText(Application.Context, $"{e.Sensor.Type.ToString()}", ToastLength.Short).Show();
            }


            Console.WriteLine(e.ToString());
        }

        public int DetectPeak(List<double> inputs, int lag, double threshold, double influence)
        {
            int peaksDetected = 0;
            List<double> stats = new List<double>();
            List<int> signals = new List<int>(new int[inputs.Count]);
            List<double> filteredY = new List<double>(new double[inputs.Count]);
            List<double> avgFilter = new List<double>(new double[inputs.Count]);
            List<double> stdFilter = new List<double>(new double[inputs.Count]);

            for (int i = 0; i < lag; i++)
            {
                stats.Add(inputs[i]);
                filteredY.Add(inputs[i]);
            }
            avgFilter[lag - 1] = stats.Average();
            stdFilter[lag - 1] = Math.Sqrt(stats.Sum(x => (x - stats.Average()) * (x - stats.Average())) / stats.Count);
            stats.Clear();
            peakCount += LAG_SIZE;
            for (int i = lag; i < inputs.Count; i++)
            {
                peakCount++;
                if (Math.Abs(inputs[i] - avgFilter[i-1]) > threshold * stdFilter[i-1])
                {
                    if (inputs[i] > avgFilter[i-1])
                    {
                        signals[i] = 1;
                        if (inputs[i] > 1.5 && inputs[i] < 4.0)
                        {
                            peaksDetected++;
                        }
                    }
                    else
                    {
                        signals[i] = -1;
                    }

                    filteredY[i] = influence * inputs[i] + (1 - influence) * filteredY[i - 1];
                }
                else
                {
                    signals[i] = 0;
                    filteredY[i] = inputs[i];
                }

                for (int j = i - lag; j < i; j++)
                {
                    stats.Add(filteredY[j]);
                }

                avgFilter[i] = stats.Average();
                stdFilter[i] = Math.Sqrt(stats.Sum(x => (x - stats.Average()) * (x - stats.Average())) / stats.Count);
            }

            return peaksDetected;
        }

        public void StopSensorService()
        {
            sManager.UnregisterListener(this);
        }

        public bool IsAvailable()
        {
            return Android.App.Application.Context.PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureSensorStepCounter) && Android.App.Application.Context.PackageManager.HasSystemFeature(Android.Content.PM.PackageManager.FeatureSensorStepDetector);
        }
    }
}