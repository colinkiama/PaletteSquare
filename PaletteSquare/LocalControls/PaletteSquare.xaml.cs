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
using Microsoft.Toolkit.Uwp.UI.Animations;
using PaletteSquare.Helpers;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PaletteSquare.LocalControls
{
    public sealed partial class PaletteSquare : UserControl
    {

        public ObservableCollection<Color> Colors { get; set; }

        private Color _overflowTextForeground;

        public Color OverflowTextForeground
        {
            get { return _overflowTextForeground; }
            set
            {
                _overflowTextForeground = value;
                NotifyPropertyChanged();
            }
        }


        private int _numOfOverflowColors;

        private int NumOfOverflowColors
        {
            get { return _numOfOverflowColors; }
            set
            {
                _numOfOverflowColors = value;
                NotifyPropertyChanged();
            }
        }

        private Color _topColor0;

        private Color TopColor0
        {
            get { return _topColor0; }
            set
            {
                _topColor0 = value;
                NotifyPropertyChanged();
            }
        }

        private Color _topColor1;

        private Color TopColor1
        {
            get { return _topColor1; }
            set
            {
                _topColor1 = value;
                NotifyPropertyChanged();
            }
        }

        private Color _topColor2;

        private Color TopColor2
        {
            get { return _topColor2; }
            set
            {
                _topColor2 = value;
                NotifyPropertyChanged();
            }
        }

        private Color _topColor3;

        private Color TopColor3
        {
            get { return _topColor3; }
            set
            {
                _topColor3 = value;
                NotifyPropertyChanged();
            }
        }


        public ObservableCollection<Color> ColorsSource
        {
            get { return (ObservableCollection<Color>)GetValue(ColorsSourceProperty); }
            set
            {
                SetValue(ColorsSourceProperty, value);
                value.CollectionChanged += ColorsSource_CollectionChanged;
                UpdateUI(value);
            }
        }


        // Using a DependencyProperty as the backing store for ColorsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorsSourceProperty =
            DependencyProperty.Register("ColorsSource", typeof(ObservableCollection<Color>), typeof(PaletteSquare), null);

        public event PropertyChangedEventHandler PropertyChanged;


        public PaletteSquare()
        {
            this.InitializeComponent();
            ColorsSource = new ObservableCollection<Color>();
            ColorsSource.CollectionChanged += ColorsSource_CollectionChanged;
        }

        private void ColorsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (sender is ObservableCollection<Color> freshCollection)
            {
                UpdateUI(freshCollection);
            }
        }

        private void UpdateUI(ObservableCollection<Color> freshCollection)
        {
            ClearAllTopColors();
            int[] indexesToChange = { };
            int numOfColors = freshCollection.Count;
            UpdateNumOfOverflowColors(numOfColors);

            if (numOfColors > 0 && numOfColors <= 4)
            {
                indexesToChange = CheckIfTopColorsHaveChanged(freshCollection, numOfColors);
            }
            else if (numOfColors > 4)
            {
                indexesToChange = CheckIfTopColorsHaveChanged(freshCollection);
            }


            UpdateTopColors(freshCollection, indexesToChange);
            TryUpdatingOverflowTextForeground();

        }

        private void TryUpdatingOverflowTextForeground()
        {
            if (TopColor3 != Windows.UI.Colors.Transparent)
            {
                OverflowTextForeground = ColorBrightnessHelper.GetContrastingForeground(TopColor3);
            }
        }

        private void UpdateNumOfOverflowColors(int numOfColors)
        {
            NumOfOverflowColors = numOfColors - 4;
        }

        private void UpdateTopColors(ObservableCollection<Color> freshCollection, int[] indexesToChange)
        {
            foreach (int index in indexesToChange)
            {
                switch (index)
                {
                    case 0:
                        TopColor0 = freshCollection[index];
                        break;
                    case 1:
                        TopColor1 = freshCollection[index];
                        break;
                    case 2:
                        TopColor2 = freshCollection[index];
                        break;
                    case 3:
                        TopColor3 = freshCollection[index];
                        break;
                }
            }


        }


        private void ClearAllTopColors()
        {
            TopColor0 = Windows.UI.Colors.Transparent;
            TopColor1 = Windows.UI.Colors.Transparent;
            TopColor2 = Windows.UI.Colors.Transparent;
            TopColor3 = Windows.UI.Colors.Transparent;
        }

        private int[] CheckIfTopColorsHaveChanged(ObservableCollection<Color> freshCollection, int numOfColors)
        {
            int[] indexesToChange = new int[numOfColors];
            for (int i = 0; i < indexesToChange.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                    case 1:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                    case 2:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                    case 3:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                }
            }
            return indexesToChange;
        }

        private int[] CheckIfTopColorsHaveChanged(ObservableCollection<Color> freshCollection)
        {
            int[] indexesToChange = new int[4];
            for (int i = 0; i < indexesToChange.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                    case 1:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                    case 2:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                    case 3:
                        if (TopColor0 != freshCollection[i])
                        {
                            indexesToChange[i] = i;
                        }
                        break;
                }
            }
            return indexesToChange;
        }



        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void DropShadowPanel_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            float centerX = (float)RootGrid.ActualWidth / 2;
            float centerY = (float)RootGrid.ActualHeight / 2;
            const float scale = 1.1f;
            await ShadowPanel.Scale(scale, scale, centerX, centerY).StartAsync();
        }

        private async void DropShadowPanel_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            float centerX = (float)RootGrid.ActualWidth / 2;
            float centerY = (float)RootGrid.ActualHeight / 2;
            const float scale = 1f;
            await ShadowPanel.Scale(scale, scale, centerX, centerY).StartAsync();
        }
    }
}

