using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_Final_Project
{
     public class IrisData
    {
        [LoadColumn(0)]
        public float SepalLength;

        [LoadColumn(1)]
        public float SepalWidth;

        [LoadColumn(2)]
        public float PetalLength;

        [LoadColumn(3)]
        public float PetalWidth;

        public const int NOISE = -1;
        public const int UNCLASSIFIED = 0;

        [LoadColumn(5)]
        public int ClusterId;

        public override string ToString()
        {
            return String.Format($"({SepalLength}, {SepalWidth}, {PetalLength}, {PetalWidth})");
        }

        public static float DistanceSquared(IrisData iris1, IrisData iris2)
        {
            float diffSepalLength = iris2.SepalLength - iris1.SepalLength;
            float diffSepalWidth =  iris2.SepalWidth - iris1.SepalWidth;
            float diffPetalLength = iris2.PetalLength - iris1.PetalLength;
            float diffPetalWidth = iris2.PetalWidth - iris1.PetalWidth;

            return (diffSepalLength * diffSepalLength) + (diffSepalWidth * diffSepalWidth) + (diffPetalLength * diffPetalLength) + (diffPetalWidth * diffPetalWidth);
        }

    }
}
