using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    struct FolderNames{
        private string featureFolder, programFolder;
        public FolderNames(string feaurestring, string programString)
        {
            this.featureFolder = feaurestring;
            this.programFolder = programString;
        }

        public string featureFolderPath
        {
            get {  return featureFolder; }
            set {  featureFolder = value; }
        }

        public string programFolderPath
        {
            get { return programFolder; }
            set { programFolder = value; }
        }

    }
    
    public partial class MainWindow : Window
        
    {
        public ArrayList programList, featureList;
        FolderNames folderPaths;
        public MainWindow()
        {
          
            InitializeComponent();
            programList = new ArrayList();
            featureList = new ArrayList();
            folderPaths = new FolderNames(@"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features", @"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs");
            updateLists();


        }

        private void clearprogram_button_Click(object sender, RoutedEventArgs e)
        {
            if(myFeature_listview.SelectedItems.Count > 0)

            {
                myFeature_listview.SelectedItems.Clear();
         
            }
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            if (myFeature_listview.SelectedItems.Count > 0 && validateText())

            {

               
                Program p = new Program(programname_textbox.Text, folderPaths.programFolderPath);
                foreach (Object o in myFeature_listview.SelectedItems)
                {
                  
                    p.addFeature(new Feature(FileHandler.removeExtensions(o.ToString()), folderPaths.featureFolderPath));

                }

                SimpleFactory factory = new SimpleFactory(p);
                factory.makeProgram();
                updateLists();
                programname_textbox.Clear();
                
                MessageBox.Show("Program Saved! Find It In The List Below and CLick 'Run'", "Success!", MessageBoxButton.OK);
            }
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            //string [] fileArray = new string[2];
            if (program_listbox.SelectedItems.Count > 0)
            {

                Program p = new Program(FileHandler.removeExtensions(program_listbox.SelectedItem.ToString()), folderPaths.programFolderPath);
                FileHandler.CompileCode(p);
                try
                {
                    Program_Output.Text = FileHandler.runCode(p.outputPath);
                }
                catch (OperationCanceledException exception)
                {

                    Program_Output.Text = "Program Could Not Run. See Error File " + exception.Message;
                }

            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (program_listbox.SelectedItems.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Are You Sure You Want To Delete This Program?", "Please Confirm", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    bool success = FileHandler.deleteFile(new Feature(FileHandler.removeExtensions(program_listbox.SelectedItem.ToString()), folderPaths.programFolderPath));

                    if (success)
                    {
                        MessageBox.Show("Your Program was deleted", "Delete Operation Successful", MessageBoxButton.OK);
                        updateLists();
                    }
                    else
                    {
                        MessageBox.Show("An Error Occured. Please Check Error File", "Error", MessageBoxButton.OK);
                    }
                }
            }
         }

        private void updateLists()
        {
            if (programList.Count > 0)
            {
                programList.Clear();
                program_listbox.Items.Clear();
            }
            if (featureList.Count > 0)
            {
                featureList.Clear();
                myFeature_listview.Items.Clear();
            }
            programList = FileHandler.filesInDirectory(@"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs", programList);
           
            featureList = FileHandler.filesInDirectory(@"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features", featureList);
            foreach (string name in programList)
            {
                program_listbox.Items.Add(name);
            }
            foreach (string name in featureList)
            {
                myFeature_listview.Items.Add(name);
            }
        }

       

        private bool validateText()
        {
           String userText = programname_textbox.Text.Trim();
            if(userText.Length <= 2)
            {
                MessageBox.Show("Your Program Name Must Be At Least 3 Characters Long.", "Invalid Program Name", MessageBoxButton.OK);
                return false;
            }
            else if(programList.Contains(userText + ".txt")){
                MessageBox.Show(" There is Already A program with that name. Your Program Name Must Be Unique.", "Invalid Program Name", MessageBoxButton.OK);
                return false;
            }

            return true;
        }

       
    }
}



