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
            Temperature t = new Temperature(0, "Kelvin", "Rankine");
            Console.WriteLine(t.Value);
        }
    }
}
