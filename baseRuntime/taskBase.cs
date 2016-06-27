using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baseRuntime
{
    public delegate void logDelegate(string s);
    public delegate void resultDelegate(bool b);
    public abstract class taskBase
    {
        protected logDelegate log_;
        protected resultDelegate res_;

        public taskBase(string preferences)
        {
            res_ = res;
            log_ = log;
        }

        public logDelegate log 
        {
            get
            {
                return log_;
            }
            set
            {
                log_ = value;
            }
        }

        public resultDelegate res
        {
            get
            {
                return res_;
            }
            set
            {
                res_ = value;
            }
        }

        public abstract void doWork();
    }
}
