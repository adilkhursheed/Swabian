using GraphSystem.Core.Extensions;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphSystem.Core.IO
{
    public class CSVFileReader : IFileReader
    {
        public List<DataPoint> Points { get; set; } = new List<DataPoint>();

        /// <summary>
        /// Reads the file and loads the point into Points property
        /// </summary>
        /// <param name="fileName"> input file </param>
        /// <returns></returns>
        public bool ReadFile(string fileName)
        {
            var fileText = string.Empty;

            if (System.IO.File.Exists(fileName))
            {
                fileText = File.ReadAllText(fileName);
            }
            else
            {
                return false;
            }
            if (fileText.Length > 0)
            {
                foreach (var item in fileText.Split(';'))
                {
                    var points = item.Split(',');
                    if (points.Length == 2)
                    {
                        this.Points.Add(new DataPoint(points[0].ToDouble(), points[1].ToDouble()));
                    }
                    else if (!string.IsNullOrEmpty(item) && !string.IsNullOrEmpty(item))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
