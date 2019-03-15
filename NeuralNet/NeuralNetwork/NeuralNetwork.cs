using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNet
{
    public class NeuralNetwork
    {
        public Neuron[][] Neurons;
        public NeuralNetwork(List<int> numberOfNeuronsPerLayer)
        {
            var numberOfLayers = numberOfNeuronsPerLayer.Count;
            Neurons = new Neuron[numberOfLayers][];
            for (int i = 1; i < numberOfLayers; i++)
            {
                var layerHeight = numberOfNeuronsPerLayer[i];
                Neurons[i-1] = new Neuron[layerHeight];
                for (int j = 0; j < layerHeight; j++)
                {
                    var numberOfInputs = numberOfNeuronsPerLayer[i-1];
                    Neurons[i - 1][j] = new Neuron(numberOfInputs);
                }
            }
        }
    }
}
