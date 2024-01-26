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

namespace WordPad_FinallyProject.Model
{
    public class ModelInputBox
    {
        private string _title;
        private string _value;

        public string TitleAction { get { return _title; } set { _title = value; Debug.WriteLine("Зашел из Model"); } }
        public string Value { get { return _value; } set { _value = value; } }

        public ModelInputBox(string title)
        {
            _title = title;
            _value = "";
        }

        public ModelInputBox() : this("Действие") { }
    }
}
