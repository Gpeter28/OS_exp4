using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OSS_EXP4;
using static OSS_EXP4.Eprocess;
using Timer = System.Timers.Timer;

namespace OSS_EXP4
{
    public partial class Form1 : Form
    {
        private Boolean IsStart = false;
        private Timer timer;
         void SetTimer()
        {
            double seconds = 1500;
            timer = new Timer(seconds);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StartSimulate();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(!IsStart)
            {
                Method.AddRanmodProcess();
                Init();
            }
            else
            {
                if (Method.ProcessArray.Count < 10)
                {
                    Eprocess p = new Eprocess();
                    var seed = Guid.NewGuid().GetHashCode();
                    Random r = new Random(seed);
                    int Rname = r.Next(1, 10000);
                    // 增加相同id的重新分配
                    int Rprimary = r.Next(50, 100);
                    int Rtimes = r.Next(1, 50);
                    p.status = 1;
                    p.name = Rname;
                    p.primary = Rprimary;
                    p.times = Rtimes;
                    RR.Add(new Eprocess(p.name, p.status, p.primary, p.times));
                    DP.Add(new Eprocess(p.name, p.status, p.primary, p.times));
                    SRT.Add(new Eprocess(p.name, p.status, p.primary, p.times));
                    SPN.Add(new Eprocess(p.name, p.status, p.primary, p.times));
                }

            }
        }

        private void buttonAddMax_Click(object sender, EventArgs e)
        {
            Method.CreateRandomProcess(5);
            Init();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {            
            SetTimer();
            IsStart = true;
            // StartSimulate();
        }

        private static List<Eprocess> RR = new List<Eprocess>();
        private static List<Eprocess> DP = new List<Eprocess>();
        private static List<Eprocess> SRT = new List<Eprocess>();
        private static List<Eprocess> SPN = new List<Eprocess>();

        private void StartSimulate()
        {
            // 增加每一段时间进行Update的控制
            RR = Method.RR(RR);
            DP = Method.DP(DP);
            SRT = Method.SRT(SRT); //?
            SPN = Method.SPN(SPN);
            Update(RR, DP, SRT, SPN);

            if(SRT.Count == 0 && DP.Count == 0 && SPN.Count == 0)
            {
                SRTListView.Items.Clear();
                DPListView.Items.Clear();
                SPNListView.Items.Clear();
                timer.Enabled = false;
                IsStart = false;
            }

        }

        private void Update(List<Eprocess> RR, List<Eprocess> DP, List<Eprocess> SRT, List<Eprocess> SPN)
        {
            RRListView.Items.Clear();
            for (int i = 0; i < RR.Count; ++i)
            {
                ListViewItem item = new ListViewItem(RR[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                item.SubItems.Add(RR[i].status.ToString());
                RRListView.Items.Add(item);
            }

            DPListView.Items.Clear();
            for (int i = 0; i < DP.Count; ++i)
            {
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(DP[i].primary.ToString());
                item.SubItems.Add(DP[i].times.ToString());
                item.SubItems.Add(DP[i].status.ToString());
                DPListView.Items.Add(item);
            }
            DP = DP.OrderByDescending(x => x.primary)
                .ToList();

            SRTListView.Items.Clear();

            for (int i = 0; i < SRT.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                item.SubItems.Add(SRT[i].status.ToString());
                SRTListView.Items.Add(item);
            }
            SRT.Sort();

            SPNListView.Items.Clear();
            for (int i = 0; i < SPN.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SPN[i].primary.ToString());
                item.SubItems.Add(SPN[i].times.ToString());
                item.SubItems.Add(SPN[i].status.ToString());
                SPNListView.Items.Add(item);
            }
            SPN.Sort();                     // first base on time and then base on Status( 2 => processing 1 => waiting)
            SPN = SPN.OrderByDescending(x => x.status)
                .ToList();
        }


        // RR DP SRT SPN
        private void Init()
        {

            // https://stackoverflow.com/questions/14007405/how-create-a-new-deep-copy-clone-of-a-listt
            RR = Method.ProcessArray;
            DP = RR.ConvertAll(i => new Eprocess(i.name, i.status, i.primary, i.times));
            SRT = RR.ConvertAll(i => new Eprocess(i.name, i.status, i.primary, i.times));
            SPN = RR.ConvertAll(i => new Eprocess(i.name, i.status, i.primary, i.times));

            RRListView.Items.Clear();
            for (int i = 0; i < RR.Count; ++i)
            {
                ListViewItem item = new ListViewItem(RR[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                item.SubItems.Add(RR[i].status.ToString());
                RRListView.Items.Add(item);
            }


            DPListView.Items.Clear();
            for(int i = 0; i < DP.Count; ++i)
            {
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(DP[i].primary.ToString());
                item.SubItems.Add(DP[i].times.ToString());
                item.SubItems.Add(DP[i].status.ToString());
                DPListView.Items.Add(item);
            }

            // https://www.techiedelight.com/sort-list-by-multiple-fields-csharp/
             DP = DP.OrderByDescending(x => x.primary) 
                .ToList();

            SRTListView.Items.Clear();
            for (int i = 0; i < SRT.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                item.SubItems.Add(SRT[i].status.ToString());
                SRTListView.Items.Add(item);
            }
            SRT.Sort(); // base on time

            SPNListView.Items.Clear();
            for (int i = 0; i < SPN.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SPN[i].primary.ToString());
                item.SubItems.Add(SPN[i].times.ToString());
                item.SubItems.Add(SPN[i].status.ToString());
                SPNListView.Items.Add(item);
            }
            SPN.Sort();                     // first base on time and then base on Status( 2 => processing 1 => waiting)
            SPN = SPN.OrderByDescending(x => x.status)
                .ToList();
        }


    }
}
