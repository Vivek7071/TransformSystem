#region System namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace TransformSystem.Model
{
    /// <summary>
    /// Derived input format class for input format one   
    /// </summary>
    public class InputFormatOne : BaseInputFormat
    { 
        public string Identifier { get; set; }
        public Int16 Type { get; set; }
        public DateTime Opened { get; set; }
    }

}
