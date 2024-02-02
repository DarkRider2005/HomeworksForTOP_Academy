using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFProject
{
    public class ModelListColors
    {
        public Color Color { get; set; }
        public string HexColor { get { return Color.ToString(); } }
        public ICommand DeleteColorFromColCommand { get; set; }
    }
}