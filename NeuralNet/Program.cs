using System;
using System.Linq;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var mnistFiles = DataDownloader.DownloadMNIST();
            var trainingDataSet = new DataSet(mnistFiles.First(file => file.Name.Contains("train-images")), mnistFiles.First(file => file.Name.Contains("train-labels")));
            foreach (var image in trainingDataSet.Images)
            {
                Console.WriteLine(image.Label);
            }
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
