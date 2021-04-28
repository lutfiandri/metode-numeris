using System;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace regression_calculator
{
    public class Data
    {
        public static double[] X;
        public static double[] Y;

        // public static List<Dictionary<string, string>> history = new List<Dictionary<string, string>>();

        public static FirestoreDb db = FirestoreDb.Create("regression-calculator");

        public static string ConvertArrToString(double[] arr)
        {
            string result = "";
            foreach (var num in arr)
            {
                result += $"{num} ";
            }
            return result;
        }

        public async static void AddHistory(double[] X, double[] Y, string equation, double determinationCoef)
        {
            try
            {
                string textX = ConvertArrToString(X);
                string textY = ConvertArrToString(Y);

                var historyItem = new Dictionary<string, string>();
                historyItem.Add("X", textX);
                historyItem.Add("Y", textY);
                historyItem.Add("equation", equation);
                historyItem.Add("determinationCoef", Convert.ToString(determinationCoef));

                DocumentReference addedDocRef = db.Collection("histories").Document();
                await addedDocRef.SetAsync(historyItem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async static void SeeHistory()
        {
            try
            {
                CollectionReference usersRef = db.Collection("histories");
                QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    Dictionary<string, object> documentDictionary = document.ToDictionary();
                    Console.WriteLine($"X: {documentDictionary["X"]}");
                    Console.WriteLine($"Y: {documentDictionary["Y"]}");
                    Console.WriteLine($"Equation: {documentDictionary["equation"]}");
                    Console.WriteLine($"Determination Coef: {documentDictionary["determinationCoef"]}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}