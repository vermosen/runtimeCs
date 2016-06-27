using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using baseRuntime;
using System.Reflection;
using System.Threading;
using System.IO;

namespace testRuntime
{
    public class wrapper
    {
        AutoResetEvent m = new AutoResetEvent(false);
        public wrapper()
        {
            Assembly assembly = Assembly.LoadFrom(@"C:\Git\testRuntime\testDll\bin\Debug\testDll.dll");
            Type t = assembly.GetType("testDll.worker");
            object[] a = new object[1];
            a[0] = "bla";

            taskBase task = (taskBase)Activator.CreateInstance(t, a);

            task.log = new logDelegate(log);
            task.res = new resultDelegate(res);

            task.doWork();
            m.WaitOne();
        }

        void log(string s)
        {
            Console.WriteLine(s);
        }
        void res(bool b)
        {
            if (b == true)
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("failure");
            }
            m.Set();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // load dll at runtime
            wrapper w = new wrapper();

            Console.ReadKey();
        }
    }
}
