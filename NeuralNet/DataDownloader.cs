using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace NeuralNet
{
    public static class DataDownloader
    {
        public static List<FileInfo> DownloadMNIST()
        {
            var result = new List<FileInfo>();
            using (var client = new WebClient())
            {
                if(!File.Exists($"{Directory.GetCurrentDirectory()}/train-images-idx3-ubyte.gz"))
                    client.DownloadFile("http://yann.lecun.com/exdb/mnist/train-images-idx3-ubyte.gz", "train-images-idx3-ubyte.gz");
                if (!File.Exists($"{Directory.GetCurrentDirectory()}/train-labels-idx1-ubyte.gz"))
                    client.DownloadFile("http://yann.lecun.com/exdb/mnist/train-labels-idx1-ubyte.gz", "train-labels-idx1-ubyte.gz");
                if (!File.Exists($"{Directory.GetCurrentDirectory()}/t10k-images-idx3-ubyte.gz"))
                    client.DownloadFile("http://yann.lecun.com/exdb/mnist/t10k-images-idx3-ubyte.gz", "t10k-images-idx3-ubyte.gz");
                if (!File.Exists($"{Directory.GetCurrentDirectory()}/t10k-labels-idx1-ubyte.gz"))
                    client.DownloadFile("http://yann.lecun.com/exdb/mnist/t10k-labels-idx1-ubyte.gz", "t10k-labels-idx1-ubyte.gz");
                foreach (FileInfo fileToDecompress in new DirectoryInfo(Directory.GetCurrentDirectory()).GetFiles("*.gz"))
                {
                    result.Add(Decompress(fileToDecompress));
                }
            }
            return result;
        }
        public static FileInfo Decompress(FileInfo fileToDecompress)
        {
            string currentFileName = fileToDecompress.FullName;
            string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
            return new FileInfo(newFileName);
        }
    }
}
