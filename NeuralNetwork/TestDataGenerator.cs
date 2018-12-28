using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TestDataGenerator
    {
        public static List<DataPoint> GenerateNANDTestData(int size)
        {
            var r = new Random();
            var result = new List<DataPoint>();
            for (int i = 0; i < size; i++)
            {
                int input1 = r.Next(0,2);
                int input2 = r.Next(0,2);
                double output = input1 == 1 & input2 == 1 ? 0.0 : 1.0;
                var dataPoint = new DataPoint()
                {
                    Input1 = (double)input1,
                    Input2 = (double)input2,
                    Output = output
                };
                result.Add(dataPoint);
            }
            return result;
        }

        public class DataPoint
        {
            public double Input1;
            public double Input2;
            public double Output;
            public override string ToString()
            {
                return $"Input1: {Input1}, Input2: {Input2}, Output: {Output}";
            }
        }
    }
}
