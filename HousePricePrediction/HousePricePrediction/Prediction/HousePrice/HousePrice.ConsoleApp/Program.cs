//*****************************************************************************************
//*                                                                                       *
//* This is an auto-generated file by Microsoft ML.NET CLI (Command-Line Interface) tool. *
//*                                                                                       *
//*****************************************************************************************

using System;
using HousePrice.Model;

namespace HousePrice.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Date = @"20141013T000000",
                Bedrooms = 3F,
                Bathrooms = 1F,
                Sqft_living = 1180F,
                Sqft_lot = 5650F,
                Floors = 1F,
                View = 0F,
                Condition = 3F,
                Grade = 7F,
                Sqft_basement = 0F,
                Yr_built = 1955F,
                Yr_renovated = 0F,
                Zipcode = 98178F,
                Lat = 47.5112F,
                Long = -122.257F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Price with predicted Price from sample data...\n\n");
            Console.WriteLine($"Date: {sampleData.Date}");
            Console.WriteLine($"Bedrooms: {sampleData.Bedrooms}");
            Console.WriteLine($"Bathrooms: {sampleData.Bathrooms}");
            Console.WriteLine($"Sqft_living: {sampleData.Sqft_living}");
            Console.WriteLine($"Sqft_lot: {sampleData.Sqft_lot}");
            Console.WriteLine($"Floors: {sampleData.Floors}");
            Console.WriteLine($"View: {sampleData.View}");
            Console.WriteLine($"Condition: {sampleData.Condition}");
            Console.WriteLine($"Grade: {sampleData.Grade}");
            Console.WriteLine($"Sqft_basement: {sampleData.Sqft_basement}");
            Console.WriteLine($"Yr_built: {sampleData.Yr_built}");
            Console.WriteLine($"Yr_renovated: {sampleData.Yr_renovated}");
            Console.WriteLine($"Zipcode: {sampleData.Zipcode}");
            Console.WriteLine($"Lat: {sampleData.Lat}");
            Console.WriteLine($"Long: {sampleData.Long}");
            Console.WriteLine($"\n\nPredicted Price: {predictionResult.Score}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
