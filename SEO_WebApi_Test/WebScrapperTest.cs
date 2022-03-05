using NUnit.Framework;
using SEO_WebApi.Helpers;

namespace SEO_WebApi_Test
{
    public class WebScrapperTest
    {
        IWebScrapper _webScrapper;

        public WebScrapperTest()
        {
            _webScrapper = new WebScrapper();
        }


        /// <summary>
        /// Test with empty text parameter returning empty
        /// </summary>
        [Test]
        public void GetHTMLText_EmptyText_ReturnEmpty()
        {
            // Arrange
            string url = string.Empty;
            var expected = string.Empty;

            // Act
            var actual = _webScrapper.GetHTMLText(url);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null text parameter returning empty
        /// </summary>
        [Test]
        public void GetHTMLText_NullText_ReturnEmpty()
        {
            // Arrange
            string url = null;
            var expected = string.Empty;

            // Act
            var actual = _webScrapper.GetHTMLText(url);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null text parameter returning empty
        /// </summary>
        [Test]
        public void GetHTMLText_ValidUrl_ReturnText()
        {
            // Arrange
            string url = "https://www.google.com";
            var expected = true;

            // Act
            var actual = _webScrapper.GetHTMLText(url).Length > 0;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}