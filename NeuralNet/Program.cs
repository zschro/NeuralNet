using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NeuralNet
{
    class Program
    {
        private const int hiddenLayerSize = 60;
        private const int imageSize = 28;
        private const int outputSize = 10;

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
            var layerSizes = new List<int>() { imageSize * imageSize, hiddenLayerSize, outputSize };
            var neuralNetwork = new NeuralNetwork(layerSizes);

            //train


            //test

            //save trained network weights
            Console.WriteLine("Saving Neural Network");
            var serializedNetwork = JsonConvert.SerializeObject(neuralNetwork);
            var path = System.IO.Directory.GetCurrentDirectory();
            File.WriteAllText(path + "\\serialized-neural-network.json", serializedNetwork);
            Console.WriteLine("Neural Network Saved");

            Console.ReadLine();
        }
    }
}
