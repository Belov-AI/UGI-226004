using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class Pixel
    {
        private double r;
        public double R
        {
            get => r; 
            set => r = CheckValue(value);
        }

        private double g;
        public double G
        {
            get => g; 
            set => g = CheckValue(value);
        }

        private double b;
        public double B
        {
            get => b; 
            set => b = CheckValue(value);
        }

        public Pixel(double red, double green, double blue) 
        { 
            R = red;
            G = green;
            B = blue;
        }

        public Pixel() : this(0, 0, 0) { }

        private double CheckValue(double val)
        {
            if (val > 1 || val < 0)
                throw new ArgumentException("Неверное значение для интенсивности канала");

            return val;
        }
    }
}
