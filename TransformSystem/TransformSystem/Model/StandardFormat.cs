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
    /// Class Standard output format
    /// </summary>
    public class StandardFormat
    {
        public string AccountCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? OpenDate { get; set; }
        public string Currency { get; set; }
    }
}
