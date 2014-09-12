using System;
using System.IO;

namespace OverlappingRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    string[] values = line.Split(',');
                    int[] coords = Array.ConvertAll<string, int>(values, int.Parse);

                    var rect1 = new Rectangle(coords[0], coords[1], coords[2], coords[3]);
                    var rect2 = new Rectangle(coords[4], coords[5], coords[6], coords[7]);

                    Console.WriteLine("{0}", rect1.IsOverlapping(rect2).ToString());
                }

            Console.ReadKey();
        }
    }

    class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        public Rectangle(int left, int top, int right, int bottom)
        {
            Top = top;
            Left = left;
            Right = right;
            Bottom = bottom;
        }

        public bool IsOverlapping(Rectangle rect)
        {
            if (Right < rect.Left || Left > rect.Right) return false;
            if (Bottom > rect.Top  || Top < rect.Bottom) return false;

            return true;
        }
    }
}
