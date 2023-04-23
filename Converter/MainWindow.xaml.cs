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
            //Console.WriteLine(Test<Volume>.ToDictionary());
            double t = Mesuarement.Convertation(24*7, Unit.Time, Time.Hour, Time.Day);
            Console.WriteLine(t);
        }
    }
}
