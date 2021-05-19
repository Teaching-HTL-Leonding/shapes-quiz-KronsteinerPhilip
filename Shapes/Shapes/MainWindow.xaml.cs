using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace Shapes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        List<GeometricElement> list = new List<GeometricElement>();
        private double totalSizeValue;
        public double totalSize
        {
            get { return totalSizeValue; }
            set
            {
                totalSizeValue = value;
                PropertyChanged?.Invoke(this, new(nameof(totalSize)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            totalSize = 0;
            InitializeComponent();
            DataContext = this;
        }

        private void AddRechteck(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(rechteckA.Text);
            double b = Convert.ToDouble(rechteckB.Text);
            double area = a * b;
            GeometricElement rechteck = new GeometricElement(Type.Rechteck, a, b, area);
            list.Add(rechteck);
            FormsList.Items.Add(rechteck.ToString());
            totalSize += area;
        }
        
        private void AddDreieck(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(dreieckA.Text);
            double h = Convert.ToDouble(dreieckH.Text);
            double area = (a * h)/2;
            GeometricElement dreieck = new GeometricElement(Type.Dreieck, a, h, area);
            list.Add(dreieck);
            FormsList.Items.Add(dreieck.ToString());
            totalSize += area;
        }

        private void AddKreis(object sender, RoutedEventArgs e)
        {
            double r = Convert.ToDouble(kreisR.Text);
            double area = Math.PI*Math.Pow(r,2);
            GeometricElement kreis = new GeometricElement(Type.Kreis, r, 0, area);
            list.Add(kreis);
            FormsList.Items.Add(kreis.ToString());
            totalSize += area;
        }
    }
    public class GeometricElement
    {
        public Type type { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double area { get; set; }

        public GeometricElement(Type type, double a, double b, double area)
        {
            this.type = type;
            this.a = a;
            this.b = b;
            this.area = area;
        }

        public override string ToString()
        {
            if (type.Equals(Type.Kreis))
                return type.ToString() + ":  Radius: " + a + "   Area:" + area;
            else if(type.Equals(Type.Dreieck))
                return type.ToString() + ":  Länge: " + a + "  Höhe:" + b + "   Area:" + area;
            else if(type.Equals(Type.Rechteck))
                return type.ToString() + ":  Länge: " + a + "  Breite:" + b + "   Area:" + area;
            else
                return String.Empty;
        }
    }
    public enum Type
    {
        Rechteck,
        Dreieck,
        Kreis
    }

}
