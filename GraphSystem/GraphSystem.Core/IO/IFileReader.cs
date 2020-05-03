using OxyPlot;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphSystem.Core.IO
{
    public interface IFileReader
    {
        List<DataPoint> Points { get; set; }

        /// <summary>
        /// Reads the file and loads the point into Points property
        /// </summary>
        /// <param name="fileName"> input file </param>
        /// <returns></returns>
        public bool ReadFile(string fileName);
    }
}
