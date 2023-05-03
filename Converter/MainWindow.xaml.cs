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
            Area l = new Area(1, UnitArea.SquareMile);
            l.As(UnitArea.SquareMile);
            Console.WriteLine(l.ToString());
            l.As(UnitArea.SquareMeter);
            Console.WriteLine(l.ToString());
        }
    }
}
