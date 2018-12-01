using Life_On_Mars.Downloads;
using Microsoft.Samples.Kinect.CoordinateMappingBasics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Life_On_Mars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EnumRover currentRover;
        private EnumCamera currentCamera;
        private List<Photo> currentPhotos;

        private int MaxSol = 0;
        private DateTime MinDate ;
        private DateTime MaxDate ;
        private int currentPage = 1;
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void changeRover(EnumRover rover)
        {
            
            currentRover = rover;
            if (cameraFHAZ != null)
            {
                photoList.Items.Clear();
                cameraFHAZ.IsChecked = false;
                cameraRHAZ.IsChecked = false;
                cameraMAST.IsChecked = false;
                cameraCHEMCAM.IsChecked = false;
                cameraMAHLI.IsChecked = false;
                cameraMARDI.IsChecked = false;
                cameraNAVCAM.IsChecked = false;
                cameraPANCAM.IsChecked = false;
                cameraMINITES.IsChecked = false;
                switch (rover)
                {
                    case EnumRover.Curiosity:
                        cameraFHAZ.IsEnabled = true;
                        cameraRHAZ.IsEnabled = true;
                        cameraMAST.IsEnabled = true;
                        cameraCHEMCAM.IsEnabled = true;
                        cameraMAHLI.IsEnabled = true;
                        cameraMARDI.IsEnabled = true;
                        cameraNAVCAM.IsEnabled = true;
                        cameraPANCAM.IsEnabled = false;
                        cameraMINITES.IsEnabled = false;
                        break;
                    case EnumRover.Opportunity:
                        cameraFHAZ.IsEnabled = true;
                        cameraRHAZ.IsEnabled = true;
                        cameraMAST.IsEnabled = false;
                        cameraCHEMCAM.IsEnabled = false;
                        cameraMAHLI.IsEnabled = false;
                        cameraMARDI.IsEnabled = false;
                        cameraNAVCAM.IsEnabled = true;
                        cameraPANCAM.IsEnabled = true;
                        cameraMINITES.IsEnabled = true;
                        break;
                    case EnumRover.Spirit:
                        cameraFHAZ.IsEnabled = true;
                        cameraRHAZ.IsEnabled = true;
                        cameraMAST.IsEnabled = false;
                        cameraCHEMCAM.IsEnabled = false;
                        cameraMAHLI.IsEnabled = false;
                        cameraMARDI.IsEnabled = false;
                        cameraNAVCAM.IsEnabled = true;
                        cameraPANCAM.IsEnabled = true;
                        cameraMINITES.IsEnabled = true;
                        break;
                }
                
            }
        }


        private void changeCamera(EnumCamera camera)
        {
            if(photoList!=null)
            {
                photoList.Items.Clear();
            }

            List<Photo> example = DownloadManager.GetPhotosBySol(currentRover, currentCamera, 0);
            if(example!=null && example.Count>0)
            {
                if (solText != null)
                {
                    MaxSol = example[0].Rover.MaxSol;
                    solText.Text = MaxSol.ToString();

                    MinDate = Convert.ToDateTime(example[0].Rover.LandingDate);
                    MaxDate = Convert.ToDateTime(example[0].Rover.MaxDate);
                    datePick.SelectedDate = MaxDate;
                }
            }
            currentCamera = camera;
        }
        private void opportunityRadio_Checked(object sender, RoutedEventArgs e)
        {
            changeRover(EnumRover.Opportunity);
        }

        private void cameraFHAZ_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.FHAZ);
        }


        private void cameraRHAZ_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.RHAZ);
        }

        private void cameraMAST_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.MAST);
        }

        private void cameraCHEMCAM_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.CHEMCAM);
        }

        private void cameraMAHLI_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.MAHLI);
        }

        private void cameraMARDI_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.MARDI);
        }

        private void cameraNAVCAM_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.NAVCAM);
        }

        private void cameraPANCAM_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.PANCAM);
        }

        //
        private void cameraMINITES_Checked(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.MINITES);
        }
        private void spiritRadio_Checked(object sender, RoutedEventArgs e)
        {
            changeRover(EnumRover.Spirit);
        }

        private void curiosityRadio_Checked(object sender, RoutedEventArgs e)
        {
            changeRover(EnumRover.Curiosity);
        }

        private void changePage(int page)
        {
            currentPage = page;
            
            if (dateSol.IsChecked ?? false)
            {
                int sol = Int32.Parse(solText.Text);
                if(sol>MaxSol)
                {
                    MessageBox.Show("Sorry, that is above the max sol, setting sol to "+MaxSol);
                    sol = MaxSol;
                }
                currentPhotos = DownloadManager.GetPhotosBySol(currentRover, currentCamera, sol, currentPage);
            }
            else
            {
                DateTime? date = datePick.SelectedDate;
                if(date==null)
                {
                    MessageBox.Show("Please input a date, using current Max");
                    date = MaxDate;
                }
                if(date<MinDate)
                {
                    MessageBox.Show("Date must be after "+ MinDate.ToString("yyyy-MM-dd"));
                    date = MinDate;
                }

                if (date > MaxDate)
                {
                    MessageBox.Show("Date must be before " + MaxDate.ToString("yyyy-MM-dd"));
                    date = MaxDate;
                }
                currentPhotos = DownloadManager.GetPhotosByDate(currentRover, currentCamera, date.Value.ToString("yyyy-MM-dd"), currentPage);
            }
            labelPage.Content = "Page: " + currentPage;
            listPhotos();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            changePage(1);
            
        }

        private void listPhotos()
        {
            photoList.Items.Clear();
            foreach(Photo photo in currentPhotos)
            {
                photoList.Items.Add(photo);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(currentPage>1)
            {
                changePage(currentPage-1);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            changePage(currentPage + 1);
        }

        private static readonly Regex _regex = new Regex("[^0-9.]+");
        private void solText_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private void solText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            changeCamera(EnumCamera.FHAZ);
        }

        private void photoList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            TempWindow wind=new TempWindow((Photo)photoList.SelectedItem);
            wind.Show();
            this.Close();
        }
    }
}
