﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class GrayScaleFilter : PixelFilter
    {
        public GrayScaleFilter() : base(new EmptyParameters()) { }

        public override Pixel ProcessPixel(Pixel p, IParameters parameters)
        {
            var lightness = 0.3 * p.R + 0.6 * p.G + 0.1 * p.B;
            return new Pixel(lightness, lightness, lightness);
        }

        public override string ToString()
        {
            return "Оттенки серого";
        }
    }
}
