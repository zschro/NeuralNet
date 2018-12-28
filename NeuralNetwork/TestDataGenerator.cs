using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetwork
{
    public class TestDataGenerator
    {
        public static List<DataPoint> GenerateNANDTestData(int size)
        {
            var result = GenerateRandomBinaryInputs(size);
            foreach (var dataPoint in result)
            {
                dataPoint.Output = dataPoint.Input1 == 1 & dataPoint.Input2 ==1 ? 0.0 : 1.0;
            }
            return result;
        }
        private static List<DataPoint> GenerateRandomBinaryInputs(int size)
        {
            var r = new Random();
            var result = new List<DataPoint>();
            for (int i = 0; i < size; i++)
            {
                int input1 = r.Next(0,2);
                int input2 = r.Next(0,2);
                var dataPoint = new DataPoint()
                {
                    Input1 = (double)input1,
                    Input2 = (double)input2,
                };
                result.Add(dataPoint);
            }
            return result;
        }

        public static List<DataPoint> GenerateNORTestData(int size)
        {
            var result = GenerateRandomBinaryInputs(size);
            foreach (var dataPoint in result)
            {
                dataPoint.Output = dataPoint.Input1 == 0 & dataPoint.Input2 == 0 ? 1.0 : 0.0;
            }
            return result;
        }

        public static List<DataPoint> GenerateXORTestData(int size)
        {
            var result = GenerateRandomBinaryInputs(size);
            foreach (var dataPoint in result)
            {
                //XOR 1 if input1 and input2 are different
                dataPoint.Output = dataPoint.Input1 == 0 & dataPoint.Input2 == 1 ? 1.0 :
                    dataPoint.Input1 == 1 & dataPoint.Input2 == 0 ? 1.0 : 0.0;
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
