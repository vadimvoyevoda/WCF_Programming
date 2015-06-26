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
using System.ServiceModel;
using WcfServiceLibrary;

namespace MyService
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost sh;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (sh != null)
            {
                sh.Close();
                sh = null;
            }

            sh = new ServiceHost(typeof(MyMath));
            sh.Open();
        }

        protected override void OnStop()
        {
            if (sh != null)
            {
                sh.Close();
                sh = null;
            }
        }        
    }
}
