using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    public class Neuron
    {
        public double[] InputWeights;
        public double Bias;
        public Neuron(int numberOfInputs)
        {
            var random = new Random();
            Bias = random.NextDouble();
            InputWeights = new double[numberOfInputs];
            for (int i = 0; i < numberOfInputs; i++)
            {
                InputWeights[i] = random.NextDouble();
            }
        }
    }
}
