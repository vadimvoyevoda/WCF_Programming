﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }
}
