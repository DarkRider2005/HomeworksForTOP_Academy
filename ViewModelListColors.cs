using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFProject
{
    public class ViewModelListColors : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ModelListColors _modelListColors;

        public ViewModelListColors(Color color)
        {
            _modelListColors = new ModelListColors();
            _modelListColors.Color = color;
        }

        public Color Color => _modelListColors.Color;

        public string HexColor => _modelListColors.HexColor;

        public ICommand DeleteColorFromColCommand
        {
            get => _modelListColors.DeleteColorFromColCommand;
            set
            {
                _modelListColors.DeleteColorFromColCommand = value;
                OnPropertyChanged(nameof(DeleteColorFromColCommand));
            }
        }

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
