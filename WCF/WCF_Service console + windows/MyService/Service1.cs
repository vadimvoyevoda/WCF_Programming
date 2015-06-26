using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.MyLog("Service Started");
        }

        protected override void OnStop()
        {
            this.MyLog("Service Stopped");
        }

        private void MyLog(string msg)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("D:/srvlog.txt"))
                {
                    sw.WriteLine(DateTime.Now);
                    sw.WriteLine(msg);
                }
            }
            catch (Exception e)
            {
                using (StreamWriter err = new StreamWriter("error"))
                {
                    err.WriteLine(e.Message);
                }
            }
        }
    }
}
