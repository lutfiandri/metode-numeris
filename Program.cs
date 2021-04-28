using System;
using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace regression_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize firestore
            string path = AppDomain.CurrentDomain.BaseDirectory + @"firebaseConfig.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            Action action = new Action();
            action.Intro();
            action.SelectWhatNext();  
        }

    }
}
