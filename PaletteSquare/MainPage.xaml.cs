using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PaletteSquare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {





        Random rnd = new Random();
        const byte MaxByteValue = 255;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Color> _myColors;

        public ObservableCollection<Color> MyColors
        {
            get { return _myColors; }
            set
            {
                _myColors = value;
                NotifyPropertyChanged();
            }
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainPage()
        {
            this.InitializeComponent();
            MyColors = new ObservableCollection<Color>();
        }

        private void AddColorButton_Click(object sender, RoutedEventArgs e)
        {
            AddRandomColor();
        }

        private void AddRandomColor()
        {
            byte[] rgbBuffer = new byte[3];
            rnd.NextBytes(rgbBuffer);
            var randomColor = Color.FromArgb(MaxByteValue, rgbBuffer[0], rgbBuffer[1], rgbBuffer[2]);
            MyColors.Add(randomColor);
        }

        private void RemoveColorButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyColors.Count > 0)
            {
                int lastIndex = MyColors.Count - 1;
                MyColors.RemoveAt(lastIndex);
            }
        }

        private void ShuffleColorsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
