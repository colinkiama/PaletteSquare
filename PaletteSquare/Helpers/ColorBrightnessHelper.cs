using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace PaletteSquare.Helpers
{
    public static class ColorBrightnessHelper
    {
        const int BrightnessFormulaRed = 299;
        const int BrightnessFormulaGreen = 587;
        const int BrightnessFormulaBlue = 114;
        const int BrightnessThreshold = 123;

        // If color is bright enough, return black, otherwise, return white.
        public static Color GetContrastingForeground(Color color)
        {
            Color colorToReturn = Colors.White;
            var brightness = ((color.R * BrightnessFormulaRed) +
                (color.G * BrightnessFormulaGreen) +
                (color.B * BrightnessFormulaBlue)) / 1000f;
            if (brightness > BrightnessThreshold)
            {
                colorToReturn = Colors.Black;
            }
            return colorToReturn;
        }
    }
}
