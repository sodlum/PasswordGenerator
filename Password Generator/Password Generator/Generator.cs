using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Password_Generator
{
    class Generator
    {
        static void Main(string[] args)
        {
            var validSpecials = ConfigurationManager.AppSettings["ValidSpecials"].Split(',');
            var ranges = new AsciiRange[] { new AsciiRange(65, 91), new AsciiRange(97, 123), new AsciiRange(48, 58) };
            var output = new StringBuilder();
            var rnd = new Random();
            var rerun = false;

            do
            {
                output.Clear();
                Console.Clear();

                for (var i = 0; i < 15; i++)
                {
                    var range = ranges[rnd.Next(3)];
                    var c = Convert.ToChar(rnd.Next(range.Min, range.Max));

                    output.Append(c);
                }

                var ts = rnd.Next(1, 5);

                for (var i = 0; i < ts; i++)
                {
                    var ix = rnd.Next(15);
                    var s = validSpecials[rnd.Next(validSpecials.Length)];

                    output.Remove(ix, 1);
                    output.Insert(ix, s);
                }

                Console.WriteLine(output.ToString());
                Console.WriteLine("Generate New? ");
                rerun = Console.ReadLine() == "y";
            } while (rerun);
        }
    }

    struct AsciiRange
    {
        /// <summary>
        /// Inclusive Min Value
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// Exclusive Max Value
        /// </summary>
        public int Max { get; private set; }

        public AsciiRange(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
