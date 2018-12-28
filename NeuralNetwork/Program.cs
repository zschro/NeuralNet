using System;
using System.Collections.Generic;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var neuron = new Neuron();
            var firingNeuron = new FiringNeuron(neuron);
            var result = firingNeuron.Fire(.1,.1);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static List<DataPoint> GenerateTestData(int size)
        {
            var r = new Random();
            bool input1 = r.Next(0,2) >= 1;
            bool input2 = r.Next(0,2) >= 1;
            var result = new DataPoint()
            {
                Input1 = (double)input1,
                Input2 = (double)input2,
                Output = (double) !(input1 | input2)
            }
        }
    }
    public class DataPoint
    {
        public double Input1;
        public double Input2;
        public double Output;
    }
}
