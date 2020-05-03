using System;
using System.Collections.Generic;
using System.Text;

namespace GraphSystem.Core.FittingModels
{
    public class FittingModelFactory
    {
        public static IFittingModel CreateModel(FittingModelsEnum modelsEnum)
        {
            IFittingModel model = null;
            switch (modelsEnum)
            {
                case FittingModelsEnum.Linear:
                    model = new LinearFittingModel();
                    break;
                case FittingModelsEnum.Exponential:
                    model = new ExponentialFittingModel();
                    break;
                case FittingModelsEnum.Power:
                    model = new PowerFittingModel();
                    break;
            }
            return model;
        }
    }
}
