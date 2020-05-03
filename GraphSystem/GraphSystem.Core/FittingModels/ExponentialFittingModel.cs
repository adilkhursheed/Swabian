using MathNet.Numerics;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphSystem.Core.FittingModels
{
    public class ExponentialFittingModel : IFittingModel
    {
        public List<DataPoint> CalculatePoints(List<DataPoint> points)
        {
            var pointsLine = new List<DataPoint>();
            Tuple<double, double> p = Fit.Exponential(points.Select(x => x.X).ToArray(), points.Select(x => x.Y).ToArray());
            double a = p.Item1;
            double b = p.Item2;
            foreach (var item in points)
            {
                var y = a * Math.Exp(item.X * b);
                pointsLine.Add(new DataPoint(item.X, y));
            }

            return pointsLine;
        }
    }
}
