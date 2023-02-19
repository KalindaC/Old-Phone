using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Old_Phone;

namespace UnitTestProject_Old_Test_ament
{
    /// <summary>
    /// Test class for the OldPhoneConverter
    /// </summary>
    [TestClass]
    public class TestsOldPhoneConverter
    {

        [TestMethod]
        public void OldPhonePadCorrectInputTest()
        {
            const string input = "4433555 555666#";
            const string output = "HELLO";
            if (OldPhoneConverter.OldPhonePad(input) == output)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Exception e = new Exception("FAILED");
                throw e;
            }
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OldPhonePadWrongInputTest()
        {
            const string input = "THIS IS INVALID#";
            OldPhoneConverter.OldPhonePad(input);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OldPhoneEmptyInputTest()
        {
            const string input = "";
            OldPhoneConverter.OldPhonePad(input);

        }

        [TestMethod]
        public void OldPhoneBackspaceTest()
        {
            const string input = "4433555 555666*#";
            const string output = "HELL";
            string result = OldPhoneConverter.OldPhonePad(input);
            if (result == output)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("Result: {0}", result);
                Exception e = new Exception("FAILED");
                throw e;
            }

        }
        [TestMethod]
        public void OldPhoneBackspaceOnEmptyInputTest()
        {
            const string input = "555 55 ***** 4433555 555666#";
            const string output = "HELLO";
            string result = OldPhoneConverter.OldPhonePad(input);
            if (result == output)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("Result: {0}", result);
                Exception e = new Exception("FAILED");
                throw e;
            }

        }

        [TestMethod]
        public void OldPhoneSendTest()
        {
            const string input = "4433555 555#666#";
            const string output = "HELL";
            string result = OldPhoneConverter.OldPhonePad(input);
            if (OldPhoneConverter.OldPhonePad(input) == output)
            {
                Console.WriteLine("PASSED");
            }
            else
            {
                Console.WriteLine("Result: {0}", result);
                Exception e = new Exception("FAILED");
                throw e;
            }

        }




    }
}
