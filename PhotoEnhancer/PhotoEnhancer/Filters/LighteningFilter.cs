using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class LighteningFilter : PixelFilter
    {
        public LighteningFilter() : base(new LighteningParameters()) { }

        public override Pixel ProcessPixel(Pixel p, IParameters parameters)
        {
            return p * (parameters as LighteningParameters).Coefficient;
        } 

        public override string ToString()
        {
            return "Осветление/затемнение";
        }
    }
}
