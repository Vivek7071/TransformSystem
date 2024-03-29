﻿#region System namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TransformSystem.Model
{
    /// <summary>
    /// Abstract Base Format class to serve as base class for all new input formates
    /// </summary>
    public abstract class BaseInputFormat
    {
        public string Name { get; set; }
        public string Currency { get; set; }
    }
}
