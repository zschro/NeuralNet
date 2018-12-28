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
        public FiringNeuron(Neuron neuron)
        {
            _neuron = neuron;
        }
        public double Fire(double input1, double input2)
        {
            var totalInput = input1 * _neuron.InputWeight1 +
                input2 * _neuron.InputWeight2 +
                _neuron.Bias;

            var output = totalInput > 0 ? totalInput : 0; //ReLu
            return output;
        }
        public double Learn()
        {
            return 0.0;
        }

    }
}
