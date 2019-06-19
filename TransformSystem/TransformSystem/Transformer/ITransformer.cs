#region System-namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion System-namespace

#region Custom namespace
using TransformSystem.Model;
#endregion

namespace TransformSystem.Transformer
{
    /// <summary>
    /// Interface for Format Transformer
    /// Operation PerformTransformation() is to Transform the Input format into standard format
    /// Operation ValidateInput() is to perform the validation of Input format
    /// </summary>
    public interface ITransformer
    {
        List<StandardFormat> PerformTransformation();
        bool ValidateInput();
    }
}
