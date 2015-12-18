using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Util.GUI
{
    public class TickBarWithValues : TickBar
    {
        protected override void OnRender(DrawingContext dc)
        {
            Size size = new Size(base.ActualWidth, base.ActualHeight);
            double num = this.Maximum - this.Minimum;
            Point point = new Point(0, 0);
            Point point2 = new Point(0, 0);
            double y = this.ReservedSpace * 0.5;
            FormattedText formattedText = null;
            for (int i = 0; i < 10; i++)
            {
                formattedText = new FormattedText(
            i.ToString(),
            CultureInfo.GetCultureInfo("en-us"),
            FlowDirection.LeftToRight,
            new Typeface("Verdana"),
            8,
            Brushes.Black);

                dc.DrawText(formattedText, new Point((i * (size.Width / 10)), 0));
            }
        }
    } 
}
