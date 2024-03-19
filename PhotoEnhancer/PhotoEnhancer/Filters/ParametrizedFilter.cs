using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParameters parameters;

        public ParametrizedFilter(IParameters parameters) 
            => this.parameters = parameters;

        public ParameterInfo[] GetParametersInfo() 
            => parameters.GetDescription();

        public Photo Process(Photo original, double[] values)
        {
            parameters.SetValues(values);

            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, IParameters parameters);
    }
}
