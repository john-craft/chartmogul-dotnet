﻿using OConnors.ChartMogul.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OConnors.ChartMogul.API
{
    public class Refund : AbstractTransaction
    {
        public new string Type
        { get { return "refund"; } }
    }
}