using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WPFProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Color _startColor;
        private Color _endColor;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            _startColor = Colors.Green;
            _endColor = Colors.Blue;

            RadialGradientBrush radial = new RadialGradientBrush();
            GradientStop gradientStop1 = new GradientStop(_startColor, 0);
              GradientStop gradientStop2 = new GradientStop(_endColor, 1f);

              radial.GradientStops.Add(gradientStop1);
               radial.GradientStops.Add(gradientStop2);

            button.Background = radial as Brush;
        }

        public void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;

            _startColor.R = 13;
            _startColor.G = 48;
            _startColor.B = 136;

            _endColor.R = 14;
            _endColor.G = 78;
            _endColor.B = 12;

            LinearGradientBrush linear = new LinearGradientBrush(_startColor, _endColor, new Point(0.5, 0), new Point(0.5, 1));

            button.Background = linear as Brush;
        }
    }
}