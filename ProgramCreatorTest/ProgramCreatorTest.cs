using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;

namespace ProgramCreatorTest
{
    [TestClass]
    public class ProgramCreatorTest
    {
        [TestMethod]
        public void NewProgramName_SetsCorrectly()
        {
            string name = "MyProgram";
            Program program = new Program(name);
            Assert.AreEqual(name, program.Name, "The Program Name Is Not Correct");


        }
        [TestMethod]
        public void FolderPathCorrect_FirstConstructor()
        {
            Program program = new Program();
            String expected = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs";
            Assert.AreEqual(expected, program.folderPathString, "The Folder Path Is Not Setting Correcting In The First Program Constructor");
        }

        [TestMethod]
        public void FolderPathCorrect_SecondConstructor()
        {
            Program program = new Program("Hello");
            String expected = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs";
            Assert.AreEqual(expected, program.folderPathString, "The Folder Path Is Not Setting Correcting In The First Program Constructor");
        }
        [TestMethod]
        public void FeaturesAddedCorrectly_ToProgram()
        {
            Program program = new Program();
            Feature feature = new Feature("New Feature");
            program.addFeature(feature);

            Assert.AreEqual(1, program.numberOfFeatures(), "Features Are Not Being Adding Correctly To Programs");
        }

        [TestMethod]
        public void FeaturesRemovedCorrectly_FromProgram()
        {
            Program program = new Program();
            Feature feature = new Feature("New Feature");
            program.addFeature(feature);
            program.removeFeature(feature);

            Assert.AreEqual(0, program.numberOfFeatures(), "Features Are Not Being Removed Correctly From Programs");
        }



    }
}
