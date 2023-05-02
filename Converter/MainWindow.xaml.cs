using System;
using System.Windows;
using Units;

namespace Converter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            //InitializeComponent();
            Length l = new Length(1, UnitLength.Meter);
            l.As(UnitLength.Foot);
            Console.WriteLine(l.ToString());
            l.As(UnitLength.Meter);
            Console.WriteLine(l.Value);
        }
    }
}
