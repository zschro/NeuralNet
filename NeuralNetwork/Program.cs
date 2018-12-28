using System;
using System.Collections.Generic;
using System.Linq;
using static NeuralNetwork.TestDataGenerator;

namespace NeuralNetwork
{
    class Program
    {
        private static readonly int totalSamples = 100000;

        static void Main(string[] args)
        {
            var testData = TestDataGenerator.GenerateNANDTestData(totalSamples);
            Console.WriteLine("NAND test:");
            RunTest(testData);
            testData = TestDataGenerator.GenerateNORTestData(totalSamples);
            Console.WriteLine("NOR test:");
            RunTest(testData);
            testData = TestDataGenerator.GenerateXORTestData(totalSamples);
            Console.WriteLine("XOR test:");
            RunTest(testData);
            Console.ReadLine();
        }

        private static void RunTest(List<DataPoint> testData)
        {
            var trainingSetSize = totalSamples * 8/10;
            var trainingSet = testData.Take(trainingSetSize);
            var testingSet = testData.Skip(trainingSetSize);

            var neuron = new Neuron();
            var firingNeuron = new FiringNeuron(neuron);

            foreach (var dataPoint in trainingSet)
            {
                firingNeuron.Learn(dataPoint.Input1, dataPoint.Input2, dataPoint.Output);
            }
            double totalError = 0.0;
            double numberFailed = 0;
            foreach (var dataPoint in testingSet)
            {
                var neuronOutput = firingNeuron.Fire(dataPoint.Input1, dataPoint.Input2);
                bool success = (neuronOutput >= 0.5) == (dataPoint.Output == 1);
                if (!success)
                {
                    numberFailed++;
                }
                var error = neuronOutput - dataPoint.Output;
                totalError +=error;
            }
            
            Console.WriteLine($"Total Error: {totalError}");
            var successRatePercent = (testingSet.Count() - numberFailed) / testingSet.Count() * 100;
            Console.WriteLine($"Number Of Failures: {numberFailed}. Success Rate: {successRatePercent}%\n");
        }

    }
}
