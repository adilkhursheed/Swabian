using OxyPlot;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphSystem.Core.FittingModels
{
    public interface IFittingModel
    {
        List<DataPoint> CalculatePoints(List<DataPoint> points);
    }
}
