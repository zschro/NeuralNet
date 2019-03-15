using System;
using System.Linq;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var mnistFiles = DataDownloader.DownloadMNIST();
            Console.WriteLine("Loading Data...");
            var dataLoader = new DataLoader();

            var trainingDataSet = dataLoader.LoadDataSetFromIdxFiles(mnistFiles.First(file => file.Name.Contains("train-images")),
                mnistFiles.First(file => file.Name.Contains("train-labels")));

            Console.WriteLine($"Loaded Training Data: {trainingDataSet.Count}");

            var testingDataSet = dataLoader.LoadDataSetFromIdxFiles(mnistFiles.First(file => file.Name.Contains("t10k-images")),
                mnistFiles.First(file => file.Name.Contains("t10k-labels")));

            Console.WriteLine($"Loaded Testing Data:  {testingDataSet.Count}");

            //initialize neural network

            //train

            //test

            //save trained network weights

            
            Console.ReadLine();
        }
    }
}
