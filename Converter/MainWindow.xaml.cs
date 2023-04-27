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
            DVolume t = new DVolume(100, Volume.Gallon);
            Console.WriteLine(t.Value);
        }
    }
}
