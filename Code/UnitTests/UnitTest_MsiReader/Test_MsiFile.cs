using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SUT = MsiReader.MsiFile;

namespace UnitTest_MsiReader
{
    [TestClass]
    public class Test_MsiFile
    {
        private static SUT msiFile;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            msiFile = new SUT(@"..\..\..\..\..\Test materials\7z1602.msi");
        }

        [TestMethod]
        public void Constructor_Should_ReadProperties()
        {
            // Arrange        
            string actualMsiProductCode;
            string actualMsiProductName ;
            string actualMsiManufacturer ;
            string actualMsiProductVersion;
            string actualMsiUpgradeCode;
            string expectedMsiProductCode = "{23170F69-40C1-2701-1602-000001000000}";
            string expectedMsiProductName = "7-Zip 16.02";
            string expectedMsiManufacturer = "Igor Pavlov";
            string expectedMsiProductVersion = "16.02.00.0";
            string expectedMsiUpgradeCode = "{23170F69-40C1-2701-0000-000004000000}";

            // Act            
            actualMsiProductCode = msiFile.ProductCode;
            actualMsiProductName = msiFile.ProductName;
            actualMsiManufacturer = msiFile.Manufacturer;
            actualMsiProductVersion = msiFile.ProductVersion;
            actualMsiUpgradeCode = msiFile.UpgradeCode;

            // Assert
            Assert.AreEqual(expectedMsiProductCode, actualMsiProductCode, true);
            Assert.AreEqual(expectedMsiProductName, actualMsiProductName, true);
            Assert.AreEqual(expectedMsiManufacturer, actualMsiManufacturer, true);
            Assert.AreEqual(expectedMsiProductVersion, actualMsiProductVersion, true);
            Assert.AreEqual(expectedMsiUpgradeCode, actualMsiUpgradeCode, true);
        }

        [TestMethod]
        public void GetAllProperties_Should_ReturnAllProperties()
        {
            // Arrange
            MsiReader.Table actualValue;

            // Act
            actualValue = msiFile.GetAllProperties();

            // Assert
            Assert.AreEqual(2, actualValue.Columns.Count);
            Assert.AreEqual(35, actualValue.Columns[0].Values.Count);
            Assert.AreEqual(35, actualValue.Columns[1].Values.Count);
        }

        [TestMethod]
        public void GetPropertyValue_Should_Return_StringEmpty_When_PropertyDoesNotExists()
        {
            // Arrange
            string actualValue;
            string expectedValue = String.Empty;

            // Act
            actualValue = msiFile.GetPropertyValue("unknownProperty");

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GetPropertyValue_Should_Return_TheCorrectValue()
        {
            // Arrange
            string actualValue;
            string expectedValue = msiFile.ProductCode;
            
            // Act            
            actualValue = msiFile.GetPropertyValue(SUT.PropertyName.ProductCode.ToString());

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
