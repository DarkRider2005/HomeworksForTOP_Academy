using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WordPad_FinallyProject.Model
{
    public class ModelWriteTextBox
    {
        private string _writeText;
        public string WriteText { get { return _writeText; } set { _writeText = value; } }

        private int _fontSize;
        public int FontSize { get { return _fontSize; } set { _fontSize = value; } }

        private string _fontFamily;
        public string FontFamily { get { return _fontFamily; } set { _fontFamily = value; } }

        private double _indentLeft, _indentRight, _indentUp, _indentDown;
        public double IndentLeft { get { return _indentLeft; } set { _indentLeft = value; } }
        public double IndentRight { get { return _indentRight; } set { _indentRight = value; } }
        public double IndentUp { get { return _indentUp; } set { _indentUp = value; } }
        public double IndentDown { get { return _indentDown; } set { _indentDown = value; } }

        private FontStyle _fontStyle;
        private FontWeight _fontWeight;
        private Thickness _thickness;
        private Color _colorFont;
        private Color _colorSelectionFont;
        private TextAlignment _alignment;

        public FontStyle FontStyle { get { return _fontStyle; } set { _fontStyle = value; } }
        public FontWeight FontWeight { get { return _fontWeight; } set { _fontWeight = value; } }
        public Thickness Thickness { get => _thickness; set { _thickness = value; } }
        public Color FontColor { get { return _colorFont; } set { _colorFont = value; } }
        public Color SelectionFontColor { get { return _colorSelectionFont; } set { _colorSelectionFont = value; } }
        public TextAlignment Alignment { get => _alignment; set { _alignment = value; } }

        public ModelWriteTextBox(string writeText, int fontSize, string fontFamily, double indentLeft, double indentRight, double indentUp, double indentDown,
            FontWeight fontWeight, FontStyle fontStyle, Color colorFont, Color colorSelectionFont, Thickness thickness, TextAlignment alignment)
        {
            _writeText = writeText;
            _fontSize = fontSize;
            _fontFamily = fontFamily;
            _indentLeft = indentLeft;
            _indentRight = indentRight;
            _indentUp = indentUp;
            _indentDown = indentDown;
            _fontWeight = fontWeight;
            _fontStyle = fontStyle;
            _colorFont = colorFont;
            _colorSelectionFont = colorSelectionFont;
            _thickness = thickness;
            _alignment = alignment;
        }

        public ModelWriteTextBox() : this(string.Empty, 0, string.Empty, 10d, 15d, 20d, 30d,
            FontWeights.Normal, FontStyles.Normal, Colors.Black, Colors.AliceBlue, new Thickness(), TextAlignment.Left)
        { }
    }
}