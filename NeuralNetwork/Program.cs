using System;
using System.Collections.Generic;
using System.Linq;

namespace NeuralNetwork
{
    class Program
    {
        private static readonly int totalSamples = 1000;
        private static readonly double learningRate = 0.02;

        static void Main(string[] args)
        {
            var testData = TestDataGenerator.GenerateNANDTestData(totalSamples);
            for (int i = 0; i < 10; i++)
            {
                var dataPoint = testData[i];
                Console.WriteLine(dataPoint);
            }
            
            var trainingSet = testData.Take(totalSamples/3);
            var testingSet = testData.Skip(totalSamples/3);

            var neuron = new Neuron();
            var firingNeuron = new FiringNeuron(neuron);
            var result = firingNeuron.Fire(.1,.1);
            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}
