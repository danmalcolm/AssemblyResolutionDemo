using System;
using System.Reflection;
using ThirdPartyLibrary;

namespace MyLibrary
{
    public class MyUtil
    {
        private static bool initialised = false;

        public static void Initialise()
        {
            if (!initialised)
            {
                AppDomain.CurrentDomain.AssemblyResolve += ResolveThirdPartyLibrary;
                initialised = true;    
            }
        }

        private static Assembly ResolveThirdPartyLibrary(object sender, ResolveEventArgs args)
        {
            // Check that CLR is loading the version of ThirdPartyLibrary referenced by MyLibrary
            if (args.Name.Equals("ThirdPartyLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=fbcbfac3e44fefed"))
            {
                try
                {
                    // Load from application's base directory. Alternative logic might be needed if you need to 
                    // load from GAC etc. However, note that calling certain overloads of Assembly.Load will result
                    // in the AssemblyResolve event from firing recursively - see recommendations in
                    // http://msdn.microsoft.com/en-us/library/ff527268.aspx for further info
                    var assembly = Assembly.LoadFrom("ThirdPartyLibrary.dll");
                    return assembly;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
            }
            return null;
        }

        public static string Info
        {
            get
            {
                return string.Format("I am using {0}", typeof(ThirdPartyUtil).Assembly.FullName);
            }
        }
    }
}
