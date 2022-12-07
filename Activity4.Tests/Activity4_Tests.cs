using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Activity.Datastore;

namespace Activity4.Test
{
    [TestClass]
    public class ArrayStoreTest
    {
        [TestMethod]
        public void ArrayStore_ValidInput_EmptyArrayGenerated()
        {
            // Arrange & Act
            var testArray = new ArrayStore<string>(4);

            // Assert
            Assert.IsTrue(testArray.Capacity == 4, String.Format("Maximum size of ArrayStore is not 4 as expected, returned: {0}", testArray.Capacity.ToString()));
            Assert.IsTrue(testArray.Count == 0, String.Format("Member count of ArrayStore is not 0 as expected, returned: {0}", testArray.Capacity.ToString()));
            Assert.IsNull(testArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Add_NullInput_ThrowsArgumentNullException()
        {
            // Arrange
            var testArray = new ArrayStore<string>(2);

            // Act
            testArray.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Insert_NullInput_ThrowsArgumentNullException()
        {
            //Arrange
            var testArray = new ArrayStore<string>(2);

            // Act
            testArray.Insert(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Remove_NullInput_ThrowsArgumentNullException()
        {
            var testArray = new ArrayStore<string>(2);
            testArray.Remove(null);
        }

        [DataRow(-1)]
        [DataRow(3)]
        [DataTestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void Insert_InvalidIndex_ThrowsArgumentOutOfRangeException(int index)
        {
            // Arrange
            var testArray = new ArrayStore<string>(3);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");

            // Act
            testArray.Insert("Something4", index);
        }

        [DataRow(-1)]
        [DataRow(3)]
        [DataTestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void RemoveAt_InvalidIndex_ThrowsArgumentOutOfRangeException(int index)
        {
            // Arrange
            var testArray = new ArrayStore<string>(3);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");

            // Act
            testArray.RemoveAt(index);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void Remove_NotInStructure_ThrowInvalidOperationException()
        {
            // Arrange
            var testArray = new ArrayStore<string>(3);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");

            // Act
            testArray.Remove("Nothing");

            // Assert
            Assert.IsTrue(testArray.Count == 3);
            Assert.IsTrue(testArray.Capacity == 3);
            Assert.AreEqual(testArray[0], "Something1");
            Assert.AreEqual(testArray[1], "Something2");
            Assert.AreEqual(testArray[2], "Something3");
        }

        [TestMethod]
        public void Add_FullArray_DoNotAdd()
        {
            // Arrange
            var testArray = new ArrayStore<string>(3);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");

            // Act
            var result = testArray.Add("Something4");

            // Assert
            Assert.AreEqual(-1, result);
            Assert.IsTrue(testArray.Count == 3);
            Assert.IsTrue(testArray.Capacity == 3);
            Assert.AreEqual(testArray[0], "Something1");
            Assert.AreEqual(testArray[1], "Something2");
            Assert.AreEqual(testArray[2], "Something3");
            Assert.IsFalse(testArray.Contains("Something4"));
        }

        [TestMethod]
        public void Insert_FullArray_DoNotInsert()
        {
            // Arrange
            var testArray = new ArrayStore<string>(3);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");

            // Act
            var result = testArray.Insert("Something4", 1);

            // Assert
            Assert.AreEqual(-1, result);
            Assert.IsTrue(testArray.Count == 3);
            Assert.IsTrue(testArray.Capacity == 3);
            Assert.AreEqual(testArray[0], "Something1");
            Assert.AreEqual(testArray[1], "Something2");
            Assert.AreEqual(testArray[2], "Something3");
            Assert.IsFalse(testArray.Contains("Something4"));
        }

        [TestMethod]
        public void Add_ValidInput_ItemAddedToArray()
        {
            // Arrange
            var testArray = new ArrayStore<string>(4);

            // Act
            var result = testArray.Add("Jelgava");

            // Assert
            Assert.AreEqual(0, result);
            Assert.IsTrue(testArray.Count == 1);
            Assert.IsTrue(testArray.Capacity == 4);
            Assert.AreEqual(testArray[0], "Jelgava");
        }

        [TestMethod]
        public void Insert_ValidInput_ItemInsertedInArray()
        {
            // Arrange
            var testArray = new ArrayStore<string>(4);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");

            // Act
            var result = testArray.Insert("Something4", 0);

            // Assert
            Assert.AreEqual(0, result);
            Assert.IsTrue(testArray.Count == 4);
            Assert.IsTrue(testArray.Capacity == 4);
            Assert.AreEqual(testArray[0], "Something4");
            Assert.AreEqual(testArray[1], "Something1");
            Assert.AreEqual(testArray[2], "Something2");
            Assert.AreEqual(testArray[3], "Something3");
        }

        [TestMethod]
        public void RemoveAt_ValidInput_RemovesItem()
        {
            // Arrange
            var testArray = new ArrayStore<string>(4);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");
            testArray.Add("Something4");

            // Act
            testArray.RemoveAt(1);

            // Assert
            Assert.IsTrue(testArray.Count == 3);
            Assert.IsTrue(testArray.Capacity == 4);
            Assert.AreEqual(testArray[0], "Something1");
            Assert.AreEqual(testArray[1], "Something3");
            Assert.AreEqual(testArray[2], "Something4");
            Assert.IsFalse(testArray.Contains("Something2"));
        }

        [TestMethod]
        public void Remove_ValidInput_RemovesItem()
        {
            // Arrange
            var testArray = new ArrayStore<string>(4);
            testArray.Add("Something1");
            testArray.Add("Something2");
            testArray.Add("Something3");
            testArray.Add("Something4");

            // Act
            testArray.Remove("Something4");

            // Assert
            Assert.IsTrue(testArray.Count == 3);
            Assert.IsTrue(testArray.Capacity == 4);
            Assert.AreEqual(testArray[0], "Something1");
            Assert.AreEqual(testArray[1], "Something2");
            Assert.AreEqual(testArray[2], "Something3");
            Assert.IsFalse(testArray.Contains("Something4"));
        }
    }
}
