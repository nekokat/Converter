using System;
using System.Windows;

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
            double t = Mesuarement.Convertation(24*7, Mesuarement.Unit.Time, Mesuarement.Time.Hour, Mesuarement.Time.Day);
            Console.WriteLine(t);
        }
    }
}
