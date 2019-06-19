#region System namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Custom namespace
using TransformSystem.Model;
using TransformSystem.Transformer;
#endregion

namespace TransformSystem.Factory
{
    /// <summary>
    /// Interface for Transformer Factory
    /// Operation CreateTransformer() is create an instance of Transformer 
    /// </summary>
    public interface ITransformerFactory
    {
        ITransformer CreateTransformer();
    }
}
