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
    
    public partial class MainWindow : Window
        
    {
        public ArrayList programList, featureList;
        public MainWindow()
        {
          
            InitializeComponent();
            programList = new ArrayList();
            programList = FileHandler.filesInDirectory(@"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Programs", programList);
            featureList = new ArrayList();
            featureList = FileHandler.filesInDirectory(@"C:\Users\HelenBelen\Documents\ProgramCreatorFolder\Features", featureList);
            foreach (string name in programList)
            {
                program_listbox.Items.Add(name);
            }
            foreach(string name in featureList)
            {
                myFeature_listview.Items.Add(name);
            }


        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            Program_Output.Text = FileHandler.runCode(@"C:\Users\HelenBelen\Documents\Visual Studio 2017\Projects\ProgramCreator\ProgramCreatorTest\bin\Debug\Feature1.OutFile.exe");
           
        }
    }
}



