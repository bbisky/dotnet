using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GraphicTools
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("生成缩略图...");
            string dir = Environment.CurrentDirectory;
            string imageFile = Path.Combine(dir.Remove(dir.LastIndexOf("\\bin")),"test.jpg");
            Console.WriteLine(GraphicTools.Thumbnail.GenerateThumbnail(imageFile, 256, 256, false, 85, imageFile.Insert(imageFile.LastIndexOf("."),"thumb")));
            Console.WriteLine("按回车退出...");
            Console.ReadLine();
        }
    }
}
