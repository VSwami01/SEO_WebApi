using NUnit.Framework;
using SEO_WebApi.Constants;
using SEO_WebApi.Helpers;
using System.Collections.Generic;

namespace SEO_WebApi_Test
{
    public class HtmlHelperTest
    {
        private readonly IHtmlHelper _htmlHelper;
        public HtmlHelperTest()
        {
            _htmlHelper = new HtmlHelper(new RegexHelper());
        }

        /// <summary>
        /// Test with empty htmlText parameter returning empty list
        /// </summary>
        [Test]
        public void GetAllCiteTags_EmptyHtmlText_ReturnEmptyList()
        {
            // Arrange
            var htmlText = string.Empty;
            var htmlTag = HtmlTags.CITE;
            var expected = new List<string>();

            // Act
            var actual = _htmlHelper.GetAllTags(htmlText, htmlTag);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null htmlText parameter returning empty list
        /// </summary>
        [Test]
        public void GetAllCiteTags_NullHtmlText_ReturnEmptyList()
        {
            // Arrange
            string htmlText = null;
            var htmlTag = HtmlTags.CITE;
            var expected = new List<string>();

            // Act
            var actual = _htmlHelper.GetAllTags(htmlText, htmlTag);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Test with empty htmlTag parameter returning empty list
        /// </summary>
        [Test]
        public void GetAllCiteTags_EmptyHtmlTag_ReturnEmptyList()
        {
            // Arrange
            var htmlText = "<cite>test<cite>";
            var htmlTag = string.Empty;
            var expected = new List<string>();

            // Act
            var actual = _htmlHelper.GetAllTags(htmlText, htmlTag);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null htmlText parameter returning empty list
        /// </summary>
        [Test]
        public void GetAllCiteTags_NullHtmlTag_ReturnEmptyList()
        {
            // Arrange
            var htmlText = "<cite>test<cite>";
            string htmlTag = null;
            var expected = new List<string>();

            // Act
            var actual = _htmlHelper.GetAllTags(htmlText, htmlTag);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Test with parameters mataching one cite tag returning list with exactly one match
        /// </summary>
        [Test]
        public void GetAllCiteTags_OneCiteTag_ReturnListWithOneMatch()
        {
            // Arrange
            var htmlText = "<cite>test</cite>";
            string htmlTag = HtmlTags.CITE;
            var expected = new List<string>()
            {
                "<cite>test</cite>"
            };

            // Act
            var actual = _htmlHelper.GetAllTags(htmlText, htmlTag);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with parameters mataching multiple cite tags returning list with all matches
        /// </summary>
        [Test]
        public void GetAllCiteTags_MultipleCiteTags_ReturnListWithMatches()
        {
            // Arrange
            var htmlText = "<cite>test 1</cite><cite>test 2</cite><cite>test 3</cite>";
            string htmlTag = HtmlTags.CITE;
            var expected = new List<string>()
            {
                "<cite>test 1</cite>",
                "<cite>test 2</cite>",
                "<cite>test 3</cite>"
            };

            // Act
            var actual = _htmlHelper.GetAllTags(htmlText, htmlTag);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }


    }
}
