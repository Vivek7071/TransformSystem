#region System namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Custom namespace
using TransformSystem.Factory;
using TransformSystem.Helper;
using TransformSystem.Model;
using TransformSystem.Transformer;
#endregion

namespace TransformSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select an option to run transformation");
            Console.WriteLine("Enter 1 for transformation using Formatter One");
            Console.WriteLine("Enter 2 for transformation using Formatter Two");
            var userInput = Console.ReadLine();

            int selectedOption = 0;
            int.TryParse(userInput, out selectedOption);

            while (selectedOption != 1 && selectedOption != 2)
            { 
                Console.WriteLine("Invalid entry. Please enter 1 or 2");
                userInput = Console.ReadLine();
                int.TryParse(userInput, out selectedOption);
            }

            try
            {
                List<InputFormatOne> inputFormateOneList = LoadFormatOne(); //Load Input format one from mock
                List<InputFormatTwo> inputFormateTwoList = LoadFormatTwo(); //Load Input format two from mock

                ITransformer transformer = null;
                FormatTransformerFactory formatTransformerFactory = null;

                switch (selectedOption)
                {
                    case 1:
                        formatTransformerFactory = new FormatTransformerFactory(inputFormateOneList.Cast<BaseInputFormat>().ToList(), TransformerEnum.FormatOneTransformer);
                        break;
                    case 2:
                        formatTransformerFactory = new FormatTransformerFactory(inputFormateTwoList.Cast<BaseInputFormat>().ToList(), TransformerEnum.FormatTwoTransformer);
                        break;
                }

                transformer = formatTransformerFactory.CreateTransformer();
                if (transformer.ValidateInput())
                {
                    List<StandardFormat> standardFormatList = transformer.PerformTransformation();
                    Utility.ExportToStandardFormat(standardFormatList, ExportFormat.XML);
                }
                else
                {
                    Console.WriteLine("Validation failed for input details");
                    Console.ReadLine();
                }
                
                Console.WriteLine("File transformed successfully !!!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                //TODO: Enhance this code as per business need
                //Custom code for detail exception handling can be added here.
                //Error loging, Alert Email, etc
                //Error logging can be done in Log file, Event Viewer, Database, etc
                Console.WriteLine("Error occured while processing.");
                Console.ReadLine();
            }
        }

        #region Mock Code To Populate Details
        /// <summary>
        /// Mock code to load Input format one data
        /// </summary>
        /// <returns></returns>
        //TODO: Replace this code with actual code to read the details from CSV file
        static private List<InputFormatOne> LoadFormatOne()
        {
            List<InputFormatOne> inputFormaterList = new List<InputFormatOne>();
            InputFormatOne item1 = new InputFormatOne
            {
                Identifier = "123|AbcCode",
                Name = "My Account",
                Type = 1,
                Opened = Convert.ToDateTime("01-01-2018"),
                Currency = "CD"
            };
            inputFormaterList.Add(item1);

            InputFormatOne item2 = new InputFormatOne
            {
                Identifier = "456|TestCode",
                Name = "Test Account",
                Type = 2,
                Opened = Convert.ToDateTime("03-02-2018"),
                Currency = "US"
            };
            inputFormaterList.Add(item2);

            InputFormatOne item3 = new InputFormatOne
            {
                Identifier = "789|SomeCode",
                Name = "Some Account",
                Type = 3,
                Opened = Convert.ToDateTime("03-12-2018"),
                Currency = "CD"
            };
            inputFormaterList.Add(item3);

            return inputFormaterList;
        }

        /// <summary>
        /// Mock code to load Input format two data
        /// </summary>
        /// <returns></returns>
        //TODO: Replace this code with actual code to read the details from CSV file
        static private List<InputFormatTwo> LoadFormatTwo()
        {
            List<InputFormatTwo> inputFormaterList = new List<InputFormatTwo>();

            InputFormatTwo item1 = new InputFormatTwo
            {
                Name = "My Account",
                Type = "Fund",
                Currency = "C",
                CustodianCode = "NewCode"
            };
            inputFormaterList.Add(item1);

            InputFormatTwo item2 = new InputFormatTwo
            {
                Name = "XYZ Account",
                Type = "RESP",
                Currency = "U",
                CustodianCode = "RandomCode"
            };
            inputFormaterList.Add(item2);

            InputFormatTwo item3 = new InputFormatTwo
            {
                Name = "Your Account",
                Type = "Trading",
                Currency = "C",
                CustodianCode = "HashCode"
            };
            inputFormaterList.Add(item3);

            return inputFormaterList;
        }
        #endregion Mock Code To Populate Details
    }
}
