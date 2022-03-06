using NUnit.Framework;
using SEO_WebApi.Helpers;
using System.Collections.Generic;

namespace SEO_WebApi_Test
{
    public class RegexHelperTest
    {
        private readonly IRegexHelper _regexHelper;
        public RegexHelperTest()
        {
            _regexHelper = new RegexHelper();
        }

        /// <summary>
        /// Test with empty text parameter returning empty list
        /// </summary>
        [Test]
        public void GetAllUrls_EmptyText_ReturnEmptyList()
        {
            // Arrange
            var text = string.Empty;
            var expected = new List<string> { };

            // Act
            var actual = _regexHelper.GetAllUrls(text);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null text parameter returning empty list
        /// </summary>
        [Test]
        public void GetAllUrls_NullText_ReturnEmptyList()
        {
            // Arrange
            string text = null;
            var expected = new List<string> { };

            // Act
            var actual = _regexHelper.GetAllUrls(text);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with text having 2 Urls returning list with exact 2 urls
        /// </summary>
        [Test]
        public void GetAllUrls_TextWithTwoUrls_ReturnListWithTwoUrls()
        {
            // Arrange
            string text = @"First Url https://www.smokeball.com.au second url https://www.leapconveyancer.com.au/";
            var expected = new List<string>
            {
                "https://www.smokeball.com.au",
                "https://www.leapconveyancer.com.au/"
            };

            // Act
            var actual = _regexHelper.GetAllUrls(text);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with text parameter with no Urls returning empty list
        /// </summary>
        [Test]
        public void GetAllUrls_TextWithNoUrls_ReturnEmptyList()
        {
            // Arrange
            string text = "First Url second url ";
            var expected = new List<string>();

            // Act
            var actual = _regexHelper.GetAllUrls(text);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with text parameter with 2 http url returning list with 2 http urls
        /// </summary>
        [Test]
        public void GetAllUrls_TextWithHttpUrls_ReturnListWithTwoUrls()
        {
            // Arrange
            string text = @"First Url http://www.smokeball.com.au second url http://www.leapconveyancer.com.au/";
            var expected = new List<string>
            {
                "http://www.smokeball.com.au",
                "http://www.leapconveyancer.com.au/"
            };

            // Act
            var actual = _regexHelper.GetAllUrls(text);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}