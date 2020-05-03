using MathNet.Numerics;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphSystem.Core.FittingModels
{
    public class LinearFittingModel : IFittingModel
    {
        public List<DataPoint> CalculatePoints(List<DataPoint> points)
        {
            var pointsLine = new List<DataPoint>();
            Tuple<double, double> p = Fit.Line(points.Select(x => x.X).ToArray(), points.Select(x => x.Y).ToArray());
            double a = p.Item1; 
            double b = p.Item2; 
            foreach (var item in points)
            {
                var y = b * item.X + a;
                pointsLine.Add(new DataPoint(item.X, y));
            }

            return pointsLine;
        }
    }
}
