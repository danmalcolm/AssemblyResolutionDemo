using System;
using MyLibrary;
using ThirdPartyLibrary;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I reference v2 directly: {0}", typeof(ThirdPartyLibrary.ThirdPartyUtil).Assembly.FullName);
            Console.WriteLine("ThirdPartyUtil.Info returns: {0}", ThirdPartyUtil.Info);

            MyUtil.Initialise();
            Console.WriteLine("MyLibrary referenced ThirdPartyLibrary version 1.0.0.0 when built, but should now be using 2.0.0.0");
            Console.WriteLine("MyUtil.Info returns: {0}", MyUtil.Info);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
