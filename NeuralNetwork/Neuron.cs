using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class Neuron
    {
        private double inputWeight1;
        private double inputWeight2;
        private double bias;

        public Neuron()
        {
            InputWeight1 = GetSmallRandom();
            InputWeight2 = GetSmallRandom();
            Bias = GetSmallRandom();
        }

        public double InputWeight1 { get => inputWeight1; set => inputWeight1 = value; }
        public double InputWeight2 { get => inputWeight2; set => inputWeight2 = value; }
        public double Bias { get => bias; set => bias = value; }

        private double GetSmallRandom()
        {
            var random = new Random();
            return random.NextDouble() * 2 - 1;
        }

    }
    public class FiringNeuron
    {
        private Neuron _neuron;
        private static readonly double learningRate = 0.02;
        public double TotalInput;

        public FiringNeuron(Neuron neuron)
        {
            _neuron = neuron;
        }
        public double Fire(double input1, double input2)
        {
            TotalInput = input1 * _neuron.InputWeight1 +
                input2 * _neuron.InputWeight2 +
                _neuron.Bias;

            var output = TotalInput > 0 ? TotalInput : TotalInput / 100; //ReLu
            return output;
        }
        public void Learn(double input1, double input2, double desiredOutput)
        {
            var output = Fire(input1, input2);

            double outputVotes = desiredOutput - output;

            double slopeOfRelu = TotalInput >= 0 ? 1 : 0.01;
            double inputVotes = outputVotes * slopeOfRelu;

            var adjustment = inputVotes * learningRate;
            _neuron.Bias += adjustment;
            _neuron.InputWeight1 += adjustment * input1;
            _neuron.InputWeight2 += adjustment * input2;
        }

    }
}
