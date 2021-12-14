using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBoxResult readData = MessageBox.Show("Czy chcesz wczytać dane z pliku?",
                "Odczyt", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (readData == MessageBoxResult.Yes)
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                if (openDialog.ShowDialog() == true)
                {
                    string allData = File.ReadAllText(openDialog.FileName);
                    string[] dataToRead = allData.Split('\n');

                    graduateWorkType.SelectedIndex = int.Parse(elementToRead(dataToRead[0]));
                    university.Text = elementToRead(dataToRead[1]);
                    fieldOfStudy.Text = elementToRead(dataToRead[2]);
                    studiesExtent.Text = elementToRead(dataToRead[3]);
                    studiesProfile.Text = elementToRead(dataToRead[4]);
                    studiesForm.Text = elementToRead(dataToRead[5]);
                    studiesLevel.Text = elementToRead(dataToRead[6]);

                    student1.Text = elementToRead(dataToRead[7]);
                    studentId1.Text = elementToRead(dataToRead[8]);
                    studentDate1.Text = elementToRead(dataToRead[9]);

                    student2.Text = elementToRead(dataToRead[10]);
                    studentId2.Text = elementToRead(dataToRead[11]);
                    studentDate2.Text = elementToRead(dataToRead[12]);

                    student3.Text = elementToRead(dataToRead[13]);
                    studentId3.Text = elementToRead(dataToRead[14]);
                    studentDate3.Text = elementToRead(dataToRead[15]);

                    student4.Text = elementToRead(dataToRead[16]);
                    studentId4.Text = elementToRead(dataToRead[17]);
                    studentDate4.Text = elementToRead(dataToRead[18]);

                    title.Text = elementToRead(dataToRead[19]);
                    engTitle.Text = elementToRead(dataToRead[20]);
                    thesisExtent.Text = elementToRead(dataToRead[21]);
                    deadline.Text = elementToRead(dataToRead[22]);
                    supervisor.Text = elementToRead(dataToRead[23]);
                    inputData.Text = elementToRead(dataToRead[24]);

                    signatureManager.Text = elementToRead(dataToRead[25]);
                    signatureDean.Text = elementToRead(dataToRead[26]);
                }
            }
        }

        private string elementToRead(string element)
        {
            string toRead = "";
            if (element != ".")
                toRead = element;
            return toRead;
        }

        private string elementToSave(string element)
        {
            string toAdd = "";
            if(element == "")
                toAdd = "." + '\n';
            else
                toAdd = element + '\n';
            return toAdd;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz zapisać zawartość?",
                "Zapis", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string dataToSave = "";

                dataToSave += elementToSave(graduateWorkType.SelectedIndex.ToString());
                dataToSave += elementToSave(university.Text);
                dataToSave += elementToSave(fieldOfStudy.Text);
                dataToSave += elementToSave(studiesExtent.Text);
                dataToSave += elementToSave(studiesProfile.Text);
                dataToSave += elementToSave(studiesForm.Text);
                dataToSave += elementToSave(studiesLevel.Text);

                dataToSave += elementToSave(student1.Text);
                dataToSave += elementToSave(studentId1.Text);
                dataToSave += elementToSave(studentDate1.Text);

                dataToSave += elementToSave(student2.Text);
                dataToSave += elementToSave(studentId2.Text);
                dataToSave += elementToSave(studentDate2.Text);

                dataToSave += elementToSave(student3.Text);
                dataToSave += elementToSave(studentId3.Text);
                dataToSave += elementToSave(studentDate3.Text);

                dataToSave += elementToSave(student4.Text);
                dataToSave += elementToSave(studentId4.Text);
                dataToSave += elementToSave(studentDate4.Text);

                dataToSave += elementToSave(title.Text);
                dataToSave += elementToSave(engTitle.Text);
                dataToSave += elementToSave(thesisExtent.Text);
                dataToSave += elementToSave(deadline.Text);
                dataToSave += elementToSave(supervisor.Text);
                dataToSave += elementToSave(inputData.Text);

                dataToSave += elementToSave(signatureManager.Text);
                dataToSave += elementToSave(signatureDean.Text);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "txt files(.txt)|*.txt|all Files(*.*)|*.*";
                if (saveFileDialog.ShowDialog() == true)
                    File.WriteAllText(saveFileDialog.FileName, dataToSave);
            }
        }
    }
}
