using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_Final_Project
{
    static public class DBSCAN
    {
        public static List<List<IrisData>> GetClusters(List<IrisData> list, double eps, int minPts)
        {
            if (list == null) return null;
            List<List<IrisData>> clusters = new List<List<IrisData>>();
            eps *= eps; // square eps
            int clusterId = 1;
            for (int i = 0; i < list.Count; i++)
            {
                IrisData p = list[i];
                if (p.ClusterId == IrisData.UNCLASSIFIED)
                {
                    if (ExpandCluster(list, p, clusterId, eps, minPts)) clusterId++;
                }
            }
            // sort out points into their clusters, if any
            int maxClusterId = list.OrderBy(p => p.ClusterId).Last().ClusterId;
            if (maxClusterId < 1) return clusters; // no clusters, so list is empty
            for (int i = 0; i < maxClusterId; i++) clusters.Add(new List<IrisData>());
            foreach (IrisData p in list)
            {
                if (p.ClusterId > 0) clusters[p.ClusterId - 1].Add(p);
            }
            return clusters;
        }

        static bool ExpandCluster(List<IrisData> list, IrisData p, int clusterId, double eps, int minPts)
        {
            List<IrisData> seeds = GetRegion(list, p, eps);
            if (seeds.Count < minPts) // no core point
            {
                p.ClusterId = IrisData.NOISE;
                return false;
            }

            else // all points in seeds are density reachable from point 'p'
            {
                for (int i = 0; i < seeds.Count; i++) seeds[i].ClusterId = clusterId;
                seeds.Remove(p);
                while (seeds.Count > 0)
                {
                    IrisData currentP = seeds[0];
                    List<IrisData> result = GetRegion(list, currentP, eps);
                    if (result.Count >= minPts)
                    {
                        for (int i = 0; i < result.Count; i++)
                        {
                            IrisData resultP = result[i];
                            if (resultP.ClusterId == IrisData.UNCLASSIFIED || resultP.ClusterId == IrisData.NOISE)
                            {
                                if (resultP.ClusterId == IrisData.UNCLASSIFIED) seeds.Add(resultP);
                                resultP.ClusterId = clusterId;
                            }
                        }
                    }
                    seeds.Remove(currentP);
                }
                return true;
            }

        }

        static List<IrisData> GetRegion(List<IrisData> list, IrisData p, double eps)
        {
            List<IrisData> region = new List<IrisData>();
            for (int i = 0; i < list.Count; i++)
            {
                float distSquared = IrisData.DistanceSquared(p, list[i]);
                if (distSquared <= eps) region.Add(list[i]);
            }
            return region;
        }
    }
}
