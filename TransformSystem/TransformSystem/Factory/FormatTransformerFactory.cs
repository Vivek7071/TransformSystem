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
    /// Factory class to instantiate object of Format Transformer
    /// </summary>
    public class FormatTransformerFactory : ITransformerFactory
    {
        TransformerEnum _transformerType;
        List<BaseInputFormat> _inputFormatList;

        /// <summary>
        /// Parameterized constructor to instantiate object of FormatTransformerFactory
        /// </summary>
        /// <param name="InputFormatList">Input format list</param>
        /// <param name="TransformerType">Type of Transformer to initialize</param>
        public FormatTransformerFactory(List<BaseInputFormat> InputFormatList, TransformerEnum TransformerType)
        {
            _inputFormatList = InputFormatList;
            _transformerType = TransformerType;
        }

        /// <summary>
        /// Function to instantiate object of Format Transformer
        /// </summary>
        /// <returns></returns>
        public ITransformer CreateTransformer()
        {
            ITransformer transformer = null;

            try
            {
                switch (_transformerType)
                {
                    case TransformerEnum.FormatOneTransformer:
                        transformer = new FormatOneTransformer(_inputFormatList.Cast<InputFormatOne>().ToList());
                        break;
                    case TransformerEnum.FormatTwoTransformer:
                        transformer = new FormatTwoTransformer(_inputFormatList.Cast<InputFormatTwo>().ToList());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                //TODO: Enhace this code
                //Custom code for detail exception handling can be added here.
            }

            return transformer;
        }
    }
}
