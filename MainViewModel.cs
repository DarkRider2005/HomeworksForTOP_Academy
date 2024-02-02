using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFProject
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ViewModelListColors> _colors;

        private Color _currentColor;

        private byte _alfa;
        private byte _red;
        private byte _green;
        private byte _blue;

        private ModelCommand _addColorInCollectionModelCommand;
        private ICommand _addColorInCollectionCommand;

        public MainViewModel()
        {
            _colors = new ObservableCollection<ViewModelListColors>();

            UpdateColorCollection();

            _addColorInCollectionModelCommand = new ViewModelCommand(
            () =>
            {
                bool add = true;
                foreach (ViewModelListColors color in ColorCollection)
                    if (color.Color != CurrentColor)
                        add = true;
                    else add = false;

                return add;
            },
            () =>
            {
                ColorCollection.Add(new ViewModelListColors(CurrentColor));
                UpdateColorCollection();
                _addColorInCollectionModelCommand.RaiseCanExecute();
            }
            );

            _addColorInCollectionCommand = _addColorInCollectionModelCommand;
        }

        public ObservableCollection<ViewModelListColors> ColorCollection => _colors;

        public ICommand AddColorInCollectionCommand => _addColorInCollectionCommand;

        public Color CurrentColor
        {
            get => _currentColor;
            set
            {
                _currentColor = value;
                OnPropertyChanged(nameof(CurrentColor));
            }
        }

        public byte CurrentAlfa
        {
            get => _alfa;
            set
            {
                _alfa = value;
                OnPropertyChanged(nameof(CurrentAlfa));
                CurrentColor = NewColor(CurrentAlfa, CurrentRed, CurrentGreen, CurrentBlue);
                _addColorInCollectionModelCommand.RaiseCanExecute();
            }
        }
        public byte CurrentRed
        {
            get => _red;
            set
            {
                _red = value;
                OnPropertyChanged(nameof(CurrentRed));
                CurrentColor = NewColor(CurrentAlfa, CurrentRed, CurrentGreen, CurrentBlue);
                _addColorInCollectionModelCommand.RaiseCanExecute();
            }
        }
        public byte CurrentGreen
        {
            get => _green;
            set
            {
                _green = value;
                OnPropertyChanged(nameof(CurrentGreen));
                CurrentColor = NewColor(CurrentAlfa, CurrentRed, CurrentGreen, CurrentBlue);
                _addColorInCollectionModelCommand.RaiseCanExecute();
            }
        }
        public byte CurrentBlue
        {
            get => _blue;
            set
            {
                _blue = value;
                OnPropertyChanged(nameof(CurrentBlue));
                CurrentColor = NewColor(CurrentAlfa, CurrentRed, CurrentGreen, CurrentBlue);
                _addColorInCollectionModelCommand.RaiseCanExecute();
            }
        }

        private Color NewColor(byte a, byte r, byte g, byte b)
        {
            Color color = new Color();
            color.A = a;
            color.R = r;
            color.G = g;
            color.B = b;

            return color;
        }

        private void UpdateColorCollection()
        {
            foreach (ViewModelListColors color in ColorCollection)
                color.DeleteColorFromColCommand = new ViewModelCommand(() => true, () => { ColorCollection.Remove(color); _addColorInCollectionModelCommand.RaiseCanExecute(); });
        }

        public void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}