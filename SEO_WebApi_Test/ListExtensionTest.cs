using NUnit.Framework;
using System.Collections.Generic;
using SEO_WebApi.Extentions;

namespace SEO_WebApi_Test
{
    public class ListExtensionTest
    {
        /// <summary>
        /// Test with empty list parameter returning empty list
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_EmptyStringList_ReturnEmpty()
        {
            // Arrange
            var emptyStringList = new List<string>();
            var stringMatch = "Test";
            var expected = new List<int> { };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null list parameter returning empty list
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_NullStringList_ReturnEmpty()
        {
            // Arrange
            List<string> emptyStringList = null;
            var stringMatch = "Test";
            var expected = new List<int> { };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with empty match parameter returning empty list
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_EmptyMatch_ReturnEmpty()
        {
            // Arrange
            var emptyStringList = new List<string>()
            {
                "one",
                "two"
            };
            var stringMatch = "";
            var expected = new List<int> { };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with null match parameter returning empty list
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_NullMatch_ReturnEmpty()
        {
            // Arrange
            var emptyStringList = new List<string>()
            {
                "one",
                "two"
            };
            string stringMatch = null;
            var expected = new List<int> { };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with perfect match parameter returning list with exactly one index
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_PerfectMatch_ReturnOnetemList()
        {
            // Arrange
            var emptyStringList = new List<string>()
            {
                "one",
                "two",
                "three",
                "four"
            };
            string stringMatch = "three";
            var expected = new List<int> { 3 };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with multiple matches returning list with more than one indexes
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_MultipleMatch_ReturnMultipleItemList()
        {
            // Arrange
            var emptyStringList = new List<string>()
            {
                "one",
                "two",
                "two",
                "three",
                "four",
                "two",
            };
            string stringMatch = "two";
            var expected = new List<int> { 2, 3, 6 };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test with no match parameter returning empty list
        /// </summary>
        [Test]
        public void FindAllIndexOffsetOne_NoMatch_ReturnEmpty()
        {
            // Arrange
            var emptyStringList = new List<string>()
            {
                "one",
                "two",
                "two",
                "three",
                "four",
                "two",
            };
            string stringMatch = "seven";
            var expected = new List<int> { };

            // Act
            var actual = emptyStringList.FindAllIndexOffsetOne(stringMatch);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}