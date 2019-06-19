#region System namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Custom namespace
using TransformSystem.Extensions;
using TransformSystem.Model;
#endregion

namespace TransformSystem.Transformer
{
    /// <summary>
    /// Concrete class to perform validation and transformation on List of InputFormatTwo and convert it to standard format.
    /// </summary>
    public class FormatTwoTransformer : ITransformer
    {
        private List<InputFormatTwo> _inputFormat;

        /// <summary>
        /// Parameterized constructor to instantiate object of FormatOneTransformer
        /// </summary>
        /// <param name="InputFormat"></param>
        public FormatTwoTransformer(List<InputFormatTwo> InputFormat)
        {
            _inputFormat = InputFormat;
        }

        /// <summary>
        /// Concrete method to perform transformation on List of InputFormatTwo type and convert it to standard format
        /// </summary>
        /// <returns>It returns List of StandardFormat</returns>
        public List<StandardFormat> PerformTransformation()
        {
            List<StandardFormat> standardFormatList = new List<StandardFormat>();
            
            foreach (InputFormatTwo item in _inputFormat)
            {
                try
                {
                    standardFormatList.Add(item.ToStandardFormat());
                }
                catch (Exception ex)
                {
                    //TODO: Enhance code as per business need
                    //Custom code for detail exception handling can be added here.
                    //Error loging, Alert Email, etc
                    //Error logging can be done in Log file, Event Viewer, Database, etc
                }
            }
            return standardFormatList;
        }

        /// <summary>
        /// Concrete method to perfomr validation on List of InputFormatOne type before processing
        /// </summary>
        /// <returns>It returns the boolean result True or False</returns>
        public bool ValidateInput()
        {
            //TODO: Enhance code as per business need
            //Custom code to validate input details will be added here based on business requirement.
            //Either skip the row which has faulty data OR skip processing entire file.
            return true;
        }
    }
}
