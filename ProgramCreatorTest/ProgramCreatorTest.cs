using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System.IO;
using System.Collections;

namespace ProgramCreatorTest
{
    [TestClass]
    public class ProgramCreatorTest
    {
        //TEST OF PROGRAM CLASS
        [TestMethod]
        public void NewProgramName_SetsCorrectly()
        {
            string name = "MyProgram";
            Program program = new Program(name, "Hey");
            Assert.AreEqual(name, program.Name, "The Program Name Is Not Correct");


        }
       
        [TestMethod]
        public void FolderPathCorrect_FirstConstructor()
        {
            Program program = new Program("My Program", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            String expected = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs";
            Assert.AreEqual(expected, program.folderPathString, "The Folder Path Is Not Setting Correcting In The First Program Constructor");
        }

       

        [TestMethod]
        public void FeaturesAddedCorrectly_ToProgram()
        {
            Program program = new Program("My Program", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            Feature feature = new Feature("New Feature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features");
            program.addFeature(feature);
            int expected = 1;
            int actual = program.numberOfFeatures();
            
            Assert.AreEqual(expected, actual, "Features Are Not Being Adding Correctly To Programs");
        }

        [TestMethod]
        public void FeaturesRemovedCorrectly_FromProgram()
        {
            Program program = new Program("My Program", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            Feature feature = new Feature("New Feature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features");
            program.addFeature(feature);
            program.removeFeature(feature);

            Assert.AreEqual(0, program.numberOfFeatures(), "Features Are Not Being Removed Correctly From Programs");
        }

        [TestMethod]
        public void DuplicateFeaturesNotAdded_ToProgram()
        {
            Program program = new Program("My Program", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            Feature feature = new Feature("New Feature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features");
            Feature feature1 = new Feature("New Feature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features");
            program.addFeature(feature);
            program.addFeature(feature1);
            

            Assert.AreEqual(1, program.numberOfFeatures(), "Duplicate Features Are Being Added To One Program");
        }

        //TEST OF FILE HANDLER CLASS
        [TestMethod]
        public void FileHandlerReadingCorrectly_FromFeatureSourceFile()
        {
            
            string filePath = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features\Test.txt";
            
            string actual = FileHandler.getCode(filePath);
            string expected = "This is a test of the get code method.Trying to see if it's working.Maybe it is not.";




            Assert.AreEqual(expected, actual, "File Handler Is Not Reading From File Correctly");
        }

        [TestMethod]
        public void FileHandlerWritingCorrectly_ToFeatureSourceFile()
        {
            
            string filepath = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs\InProgress.txt";
            string codetoWrite = "Hey Guys this is my new program!";
            string returnfilepath = FileHandler.WriteCode(filepath,codetoWrite);

            string actual = FileHandler.getCode(returnfilepath);
            string expected = codetoWrite;

            


            Assert.AreEqual(expected, actual, "File Handler Is Not Writing To File Correctly");
        }

        [TestMethod]
        public void CreateFileCorrectly_ForProgram()
        {
            Program p = new Program("Hello", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            FileHandler.CreateFile(p);
            bool actual = File.Exists(p.sourcePath);
            bool expected = true;
            Assert.AreEqual(expected, actual, "File Handler Is Not Creating File Correctly");
        }
        [TestMethod]
        public void Test_Compiler()
        {
            Feature f = new Feature("Feature1", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs\");
            f.sourcePath = @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs\BoilerPlate1.txt";
            bool actual = FileHandler.CompileCode(f);
            bool expected = true;

            Assert.AreEqual(expected, actual, "The Compiler isn't working");
        }
        [TestMethod]
        public void ReadFilesInDirectory_Correctly()
        {
            FileHandler.CreateFile(new Program("P1", @"C: \Users\HelenBelen\Documents\ProgramCreatorFolder\Programs"));
            FileHandler.CreateFile(new Program("P2", @"C: \Users\HelenBelen\Documents\ProgramCreatorFolder\Programs"));
            FileHandler.CreateFile(new Program("P3", @"C: \Users\HelenBelen\Documents\ProgramCreatorFolder\Programs"));
            ArrayList a = new ArrayList();
            a = FileHandler.filesInDirectory(@"C: \Users\HelenBelen\Documents\ProgramCreatorFolder\Programs", a);
            bool actual = false;
            if(a.Contains("P1.txt") && a.Contains("P2.txt") && a.Contains("P3.txt"))
            {
                actual = true;
            }
           bool expected = true;
            Assert.AreEqual(expected, actual, "FileHandler Is Not Getting The Corret Number Of FIles");
        }

        //Test The Program Factory
        [TestMethod]
        public void MakesProgram_Correcly()
        {
            Program p = new Program("Test1", @"C: \Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            p.addFeature(new Feature("HelloWOrldFeature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features"));
            p.addFeature(new Feature("PrintTimeFeature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features"));
            p.addFeature(new Feature("SimpleMathFeature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features"));
            p.addFeature(new Feature("WebsitePrinterFeature", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features"));
            SimpleFactory factory = new SimpleFactory(p);
            factory.makeProgram();
            String expected = p.getBeginningofFile() + FileHandler.getCode(@"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features\TestCheck.txt") + p.getEndofFile();
            string actual = FileHandler.getCode(p.sourcePath);
            
            Assert.AreEqual(expected, actual, "Factory Did Not Create Program");
        }


    }
}
