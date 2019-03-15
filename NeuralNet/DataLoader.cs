using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NeuralNet
{
    public class DataLoader
    {
        public List<HandwrittenDigitInfo> LoadDataSetFromIdxFiles(FileInfo sourceImages, FileInfo sourceLabels)
        {
            var digits = new List<HandwrittenDigitInfo>();
            digits = LoadImagesIntoDigitList(sourceImages, digits);
            digits = LoadLabelsIntoDigitList(sourceLabels, digits);
            return digits;
        }

        private List<HandwrittenDigitInfo> LoadLabelsIntoDigitList(FileInfo sourceLabels, List<HandwrittenDigitInfo> digits)
        {
            using (FileStream sourceImagesStream = sourceLabels.OpenRead())
            {
                var magicNumber = ReadInt32(sourceImagesStream);
                if (magicNumber != 2049)
                {
                    throw new Exception("Magic number is wrong for labels");
                }
                var numberOfLabels = ReadInt32(sourceImagesStream);

                for (int labelIndex = 0; labelIndex < numberOfLabels; labelIndex++)
                {
                    var label = sourceImagesStream.ReadByte();
                    digits[labelIndex].Label = label;
                }
            }
            return digits;
        }

        private List<HandwrittenDigitInfo> LoadImagesIntoDigitList(FileInfo sourceImages, List<HandwrittenDigitInfo> digits)
        {
            using (FileStream sourceImagesStream = sourceImages.OpenRead())
            {
                // idx file format explained here: http://yann.lecun.com/exdb/mnist/
                var magicNumber = ReadInt32(sourceImagesStream);
                if (magicNumber != 2051)
                {
                    throw new Exception("Magic number is wrong for images");
                }
                var numberOfImages = ReadInt32(sourceImagesStream);
                var numberOfRows = ReadInt32(sourceImagesStream);
                var numberOfColumns = ReadInt32(sourceImagesStream);
                var numberOfBytes = numberOfRows * numberOfColumns;

                for (int imageIndex = 0; imageIndex < numberOfImages; imageIndex++)
                {
                    var pixelData = new byte[numberOfBytes];
                    sourceImagesStream.Read(pixelData, 0, numberOfBytes);
                    digits.Add(new HandwrittenDigitInfo() {PixelData = pixelData });
                }
            }
            return digits;
        }
        
        private int ReadInt32(FileStream fileStream)
        {
            byte[] buffer = new byte[4];
            fileStream.Read(buffer);
            Array.Reverse(buffer);
            return BitConverter.ToInt32(buffer);
        }

    }
}
