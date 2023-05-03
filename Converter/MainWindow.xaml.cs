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
            Area l = new Area(1, UnitArea.SquareMeter);
            l.As(UnitArea.SquareYard);
            Console.WriteLine(l.ToString());
            l.As(UnitArea.SquareMeter);
            Console.WriteLine(l.ToString());
        }
    }
}
