using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WordPad_FinallyProject.Model;

namespace WordPad_FinallyProject.ViewModel
{
    public class ViewModelWriteTextBox
    {
        private ModelWriteTextBox _writeTextBox;

        private ICollection<int> _fontSizes;
        private List<Color> _colors;

        public ViewModelWriteTextBox()
        {
            _writeTextBox = new ModelWriteTextBox();

            _fontSizes = new List<int>();
            _colors = new List<Color>();
            _fontSizes.Add(6); _fontSizes.Add(7); _fontSizes.Add(8);
            _fontSizes.Add(9); _fontSizes.Add(10); _fontSizes.Add(11);
            _fontSizes.Add(12); _fontSizes.Add(13); _fontSizes.Add(14);
            _fontSizes.Add(15); _fontSizes.Add(16); _fontSizes.Add(17);
            _fontSizes.Add(18); _fontSizes.Add(19); _fontSizes.Add(20);
            _fontSizes.Add(22); _fontSizes.Add(24); _fontSizes.Add(26);
            _fontSizes.Add(28); _fontSizes.Add(36); _fontSizes.Add(48);
            _fontSizes.Add(72);

            _colors.Add(Colors.Red);
            _colors.Add(Colors.Blue);
            _colors.Add(Colors.Yellow);
            _colors.Add(Colors.Black);
            _colors.Add(Colors.Pink);
            _colors.Add(Colors.Orange);
            _colors.Add(Colors.Gray);
            _colors.Add(Colors.Green);
            _colors.Add(Colors.Purple);
        }
        public ViewModelWriteTextBox(ModelWriteTextBox modelWriteTextBox)
        {
            _writeTextBox = modelWriteTextBox;
        }

        public ICollection<int> FontSizes { get { return _fontSizes; } }
        public List<Color> FontColors { get { return _colors; } }

        public string WriteText
        {
            get => _writeTextBox.WriteText;
            set
            {
                _writeTextBox.WriteText = value;
            }
        }

        public int FontSize
        {
            get => _writeTextBox.FontSize;
            set
            {
                _writeTextBox.FontSize = value;
            }
        }

        public double IndentLeft
        {
            get => _writeTextBox.IndentLeft;
            set
            {
                _writeTextBox.IndentLeft = value;
            }
        }

        public double IndentRight
        {
            get => _writeTextBox.IndentRight;
            set
            {
                _writeTextBox.IndentRight = value;
            }
        }

        public double IndentUp
        {
            get => _writeTextBox.IndentUp;
            set
            {
                _writeTextBox.IndentUp = value;
            }
        }

        public double IndentDown
        {
            get => _writeTextBox.IndentDown;
            set
            {
                _writeTextBox.IndentDown = value;
            }
        }

        public FontFamily FontFamily
        {
            get => new FontFamily(_writeTextBox.FontFamily);
            set
            {
                _writeTextBox.FontFamily = value.Source;
            }
        }

        public FontStyle FontStyle
        {
            get => _writeTextBox.FontStyle;
            set
            {
                _writeTextBox.FontStyle = value;
            }
        }

        public FontWeight FontWeight
        {
            get => _writeTextBox.FontWeight;
            set
            {
                _writeTextBox.FontWeight = value;
            }
        }

        public Thickness Thickness
        {
            get
            {
                _writeTextBox.Thickness = new Thickness(IndentLeft, IndentUp, IndentRight, IndentDown);
                return _writeTextBox.Thickness;
            }
            set
            {
                _writeTextBox.Thickness = value;
            }
        }

        public Color FontColor
        {
            get => _writeTextBox.FontColor;
            set
            {
                _writeTextBox.FontColor = value;
            }
        }

        public Color SelectionFontColor
        {
            get => _writeTextBox.SelectionFontColor;
            set
            {
                _writeTextBox.SelectionFontColor = value;
            }
        }
    }
}