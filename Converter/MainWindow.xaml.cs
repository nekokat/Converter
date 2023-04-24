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
        public MainWindow()
        {
            //InitializeComponent();
            double t = Mesuarement.Convertation(24*7, Quantities.Time, Time.Hour, Time.Day);
            Console.WriteLine(t);
        }
    }
}
