//2015.7.29

using System;
using System.Collections.Generic;
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

namespace 坐标计算
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        enum Quadrant
        {
            一,
            二,
            三,
            四,
        }

        private void Calc(object sender, RoutedEventArgs e)
        {
            double deltaX, deltaY, distance, angle;
            try
            {
                Quadrant quadrant = Quadrant.一;
                double X_a = double.Parse(Xa.Text);
                double Y_a = double.Parse(Ya.Text);
                double X_b = double.Parse(Xb.Text);
                double Y_b = double.Parse(Yb.Text);
                deltaX = X_b - X_a;
                deltaY = Y_b - Y_a;
                distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
                angle = Math.Atan(Math.Abs(deltaY / deltaX));
                if (deltaX < 0 && deltaY > 0)
                {
                    angle = Math.PI - angle;
                    quadrant = Quadrant.二;
                }
                else if (deltaX < 0 && deltaY < 0)
                {
                    angle = Math.PI + angle;
                    quadrant = Quadrant.三;
                }
                else if (deltaX > 0 && deltaY < 0)
                {
                    angle = 2 * Math.PI - angle;
                    quadrant = Quadrant.四;
                }

                angle = (angle / Math.PI) * 180;
                
                double degree, minute, second;
                degree = Math.Floor(angle);
                minute= Math.Floor((angle-degree)*60);
                second = Math.Floor((((angle - degree) * 60) - minute)*60);


                distance = Math.Round(distance, 4);
                distanceResult.Text = "距离:" + distance.ToString();
                angleResult.Text = "角度:" + degree.ToString()+"°"+minute.ToString()+"\""+second.ToString()+"'";
                QuadrantText.Text = "象限:第" + quadrant.ToString() + "象限";
            }
            catch (Exception exp)
            {
                distanceResult.Text = exp.Message+"\n请重新输入";
                angleResult.Text = "";
                QuadrantText.Text = "";
            }
        }
    }
}
