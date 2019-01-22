using System;

namespace NeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            DataDownloader.DownloadMNIST();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
