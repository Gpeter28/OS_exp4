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
    public class Exp_process : IComparable
    {
 
       



        public int name;
        public int status;  // 0 stop 1 moving 2 done
        public int primary;
        public int times;


        public Exp_process(int name, int status, int primary, int times)
        {
            this.name = name;
            this.status = status;
            this.primary = primary;
            this.times = times;
        }

        public Exp_process()
        {

        }


        public int CompareTo(object obj)
        {
   
                Exp_process p = (Exp_process)obj;
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
            public static List<Exp_process> ProcessArray = new List<Exp_process>();
            // public static Exp_process[] ProcessArray = new Exp_process[10];
            public static void ClearArray()
            {
                ProcessArray = new List<Exp_process>();
            }
            public static void CreateRandomProcess(int nums)
            {
                ClearArray();
                for (int i = 0; i < nums; ++i)
                {
                    Exp_process pr = new Exp_process();
                    var seed = Guid.NewGuid().GetHashCode();
                    Random r = new Random(seed);
                    int Rname = r.Next(1, 10000);
                    // 增加相同id的重新分配
                    int Rprimary = r.Next(1, 100);
                    int Rtimes = r.Next(1, 100);
                    pr.name = Rname;
                    pr.primary = Rprimary;
                    pr.times = Rtimes;
                    ProcessArray.Add(pr);
                }
            }

            public static List<Exp_process> RR(List<Exp_process> RR)
            {
                return RR;
            }

            public static List<Exp_process> DP(List<Exp_process> DP)
            {
                DP[0].times--;
                DP[0].primary--;
                DP = DP.OrderByDescending(x => x.primary)
                .ToList();
                return DP;
            }

            // 按最短剩余时间进行排序和减少。
            public static List<Exp_process> SRT(List<Exp_process> SRT) // shortest remain time
            {
                if(SRT[0].times > 0)
                {
                    SRT[0].times--;
                    SRT[0].status = 1;
                }
                if (SRT[0].times == 0)
                {
                    SRT[0].status = 2;
                    SRT.RemoveAt(0);
                }
                return SRT;
            }

            public static List<Exp_process> SPN(List<Exp_process> SPN) // shortest process 
            {

                return SPN;
            }
            public static void WriteRR()
            {

            }

            public static void WriteDP()
            {

            }

            public static void WriteSRT()
            {

            }

            public static void WriteSPN()
            {

            }
        }
    }
}
