using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using Timer = System.Timers.Timer;

namespace OSS_EXP4
{


    [Serializable]
    public class Eprocess : IComparable
    {
 
        public int name;
        public int status;  // 0 stop    1 wait     2 moving
        public int primary;
        public int times;
        // private int percentage (用来计算完成比率)

        public static int MaxProcess = 10;

        public Eprocess(int name, int status, int primary, int times)
        {
            this.name = name;
            this.status = status;
            this.primary = primary;
            this.times = times;
        }

        public Eprocess()
        {

        }


        public int CompareTo(object obj)
        {
   
                Eprocess p = (Eprocess)obj;
                if (this.times > p.times)
                {
                    return 1;
                }
                if (this.times < p.times)
                {
                    return -1;
                }
                return 0;
        }








        public class Method
        {
            public static List<Eprocess> ProcessArray = new List<Eprocess>();
            // public static Exp_process[] ProcessArray = new Exp_process[10];
            public static void ClearArray()
            {
                ProcessArray = new List<Eprocess>();
            }
            public static void CreateRandomProcess(int nums)
            {
                ClearArray();
                for (int i = 0; i < nums; ++i)
                {
                    Eprocess pr = new Eprocess();
                    var seed = Guid.NewGuid().GetHashCode();
                    Random r = new Random(seed);
                    int Rname = r.Next(1, 10000);
                    // 增加相同id的重新分配
                    int Rprimary = r.Next(50, 100); 
                    int Rtimes = r.Next(1, 50);
                    pr.status = 1;
                    pr.name = Rname;
                    pr.primary = Rprimary;
                    pr.times = Rtimes;
                    ProcessArray.Add(pr);
                }
            }

            public static void AddRanmodProcess()
            {
                    Eprocess pr = new Eprocess();
                    var seed = Guid.NewGuid().GetHashCode();
                    Random r = new Random(seed);
                    int Rname = r.Next(1, 10000);
                    // 增加相同id的重新分配
                    int Rprimary = r.Next(50, 100);
                    int Rtimes = r.Next(1, 50);
                    pr.status = 1;
                    pr.name = Rname;
                    pr.primary = Rprimary;
                    pr.times = Rtimes;
                    ProcessArray.Add(pr);
            }

            public static List<Eprocess> RR(List<Eprocess> RR)
            {


                return RR;
            }

            public static List<Eprocess> DP(List<Eprocess> DP)
            {
                if(DP[0].times > 0)
                {
                    DP[0].times--;
                    DP[0].primary--;
                    DP[0].status = 2;
                }
                if(DP[0].times == 0)
                {
                    DP[0].status = 0;
                    DP.RemoveAt(0);
                }
                DP = DP.OrderByDescending(x => x.primary)
                .ToList();
                DP[0].status = 2;
                for (int i = 1; i < DP.Count; ++i)
                {
                    DP[i].status = 1;
                }
                return DP;
            }

            // 按最短剩余时间进行排序和减少。
            public static List<Eprocess> SRT(List<Eprocess> SRT) // shortest remain time
            {
                // 抢占
                if(SRT[0].times > 0)
                {
                    SRT[0].times--;
                    SRT[0].status = 2;
                }
                if (SRT[0].times == 0)
                {
                    SRT[0].status = 0;
                    SRT.RemoveAt(0);
                }
                return SRT;
            }

            public static List<Eprocess> SPN(List<Eprocess> SPN) // shortest process 
            {
                // 不抢占
                if(SPN[0].times > 0 && SPN[0].status == 1)
                {
                    SPN[0].status = 2;
                }
                if(SPN[0].status == 2 && SPN[0].times > 0)
                {
                    SPN[0].times--;
                }
                if(SPN[0].status == 2 && SPN[0].times == 0)
                {
                    SPN[0].status = 0;
                    SPN.RemoveAt(0);
                }


                return SPN;
            }
        }
    }
}
