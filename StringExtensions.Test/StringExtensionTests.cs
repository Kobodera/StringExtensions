using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringExtensions;

namespace StringExtensions.Test
{
    [TestClass]
    public class StringExtensionTests
    {
        #region ToInt

        [TestMethod]
        public void ToInt_Success()
        {
            string value = "1234";
            int expected = 1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_WithPlusSign_Success()
        {
            string value = "+1234";
            int expected = 1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_NegativeValue_Success()
        {
            string value = "-1234";
            int expected = -1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_WithSpace_Success()
        {
            string value = "1 234";
            int expected = 1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_WithHtmlNbsp_Success()
        {
            string value = "1&nbsp;234";
            int expected = 1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_WithHtmlNbspUpperCase_Success()
        {
            string value = "1&NBSP;234";
            int expected = 1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_WithNonBreakingSpace_Success()
        {
            string value = "1\u00A0234";
            int expected = 1234;

            int result = value.ToInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToInt_InvalidStringWithDefaultValue_Success()
        {
            string value = "Hello world!";
            int defaultValue = -1;
            int expected = -1;

            int result = value.ToInt(defaultValue);

            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_InvalidStringNoDefaultValue_Exception()
        {
            string value = "Hello world!";

            int result = value.ToInt();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_DoubleValueDot_Exception()
        {
            string value = "1234.12";

            int result = value.ToInt();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToInt_DoubleValueComma_Exception()
        {
            string value = "1234,12";

            int result = value.ToInt();
        }

        #endregion ToInt

        #region ToNullableInt

        [TestMethod]
        public void ToNullableInt_EmptyString_Success()
        {
            string value = string.Empty;
            int? expected = null;

            int? result = value.ToNullableInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToNullableInt_HtmlNonBreakingSpace_Success()
        {
            string value = "&nbsp;&NBSP;";
            int? expected = null;

            int? result = value.ToNullableInt();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToNullableInt_NullString_Exception()
        {
            string value = null;

            int? result = value.ToNullableInt();
        }

        #endregion ToNullableInt

        #region ToDouble

        [TestMethod]
        public void ToDouble_IntegerValue_Success()
        {
            string value = "1234";
            double expected = 1234;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_DoubleValueDot_Success()
        {
            string value = "1234.12";
            double expected = 1234.12;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_DoubleValueComma_Success()
        {
            string value = "1234,12";
            double expected = 1234.12;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_WithSpace_Success()
        {
            string value = "1 234.12";
            double expected = 1234.12;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_WithHtmlNbsp_Success()
        {
            string value = "1&nbsp;234.12";
            double expected = 1234.12;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_WithHtmlNbspUppderCase_Success()
        {
            string value = "1&NBSP;234.12";
            double expected = 1234.12;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_WithNonBreakingSpace_Success()
        {
            string value = "1\u00A0234.12";
            double expected = 1234.12;

            double result = value.ToDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToDouble_InvalidStringWithDefaultValue_Success()
        {
            string value = "Hello world!";
            double defaultValue = -1;
            double expected = -1;

            double result = value.ToDouble(defaultValue);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDouble_InvalidStringNoDefaultValue_Exception()
        {
            string value = "Hello world!";

            double result = value.ToDouble();
        }

        #endregion ToDouble

        #region ToNullableDouble

        [TestMethod]
        public void ToNullableDouble_EmptyString_Success()
        {
            string value = string.Empty;
            double? expected = null;

            double? result = value.ToNullableDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToNullableDouble_HtmlNonBreakingSpace_Success()
        {
            string value = "&nbsp;&NBSP;";
            double? expected = null;

            double? result = value.ToNullableDouble();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToNullableDouble_NullString_Exception()
        {
            string value = null;

            int? result = value.ToNullableInt();
        }

        #endregion ToNullableDouble

        #region Cleanup

        [TestMethod]
        public void Cleanup_Single_Success()
        {
            string value = "Hello world!";
            string expected = "Hello !";

            string result = value.Cleanup("World");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cleanup_Multipe_Success()
        {
            string value = "Hello world!";
            string expected = "Hello";

            string result = value.Cleanup("!", "World");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Cleanup_NoMatch_Success()
        {
            string value = "Hello world!";
            string expected = "Hello world!";

            string result = value.Cleanup("No match");

            Assert.AreEqual(expected, result);
        }

        #endregion Cleanup

        #region Replace

        [TestMethod]
        public void Replace_CaseSensitive_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello world!";

            string result = value.Replace("WORLD", "world");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseSensitiveNotFound_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace("world", "world");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseInsensitive_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello world!";

            string result = value.Replace("world", "world", true);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Replace_ReplaceEmptyString_Exception()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace("", "world");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseSensitiveReplaceEmptyString_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace("", "world", false);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseInsensitiveReplaceEmptyString_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace("", "world", true);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Replace_ReplaceNull_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace(null, "world");

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void Replace_CaseSensitiveReplaceNull_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace(null, "world", false);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseInsensitiveReplaceNull_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello WORLD!";

            string result = value.Replace(null, "world", true);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_ReplaceWithNull_Success()
        {
            string value = "Hello WORLD!";
            string expected = "Hello !";

            string result = value.Replace("WORLD", null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseSensitiveMultipleInstances_Success()
        {
            string value = "Hello WORLD! There are many worlds out there";
            string expected = "Hello people! There are many worlds out there";

            string result = value.Replace("WORLD", "people");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_CaseInsensitiveMultipleInstances_Success()
        {
            string value = "Hello WORLD! There are many worlds out there";
            string expected = "Hello people! There are many peoples out there";

            string result = value.Replace("WORLD", "people", true);

            Assert.AreEqual(expected, result);
        }

        #endregion Replace

        #region HashPassword

        [TestMethod]
        public void HashAndVerifyPassword()
        {
            string hashedPassword = "password".HashPassword();
            Assert.AreEqual(true, hashedPassword.VerifyPasswordHash("password"));
        }

        [TestMethod]
        public void HashAndVerifyPassword_WrongPassword()
        {
            string hashedPassword = "password".HashPassword();
            Assert.AreEqual(false, hashedPassword.VerifyPasswordHash("password2"));
        }

        [TestMethod]
        public void HashAndVerifyPassword_WrongItterations()
        {
            string hashedPassword = "password".HashPassword();
            Assert.AreEqual(false, hashedPassword.VerifyPasswordHash("password", 9999));
        }

        [TestMethod]
        public void HashPasswordTwice_NotSameHash()
        {
            string hashedPassword1 = "password".HashPassword();
            string hashedPassword2 = "password".HashPassword();

            Assert.AreNotEqual(hashedPassword1, hashedPassword2);
        }

        #endregion HashPassword

    }
}
