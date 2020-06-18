using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static OSS_EXP4.Eprocess;
using Timer = System.Timers.Timer;

namespace OSS_EXP4
{
    public partial class Form1 : Form
    {
        private Double Seconds = 100;
        private Boolean IsStart = false;
        private Timer timer;

        private void SetTimer()
        {
            // double seconds = 100;
            timer = new Timer(Seconds);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
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
            IsStart = true;
            SetTimer();
            timer.Start();
            // StartSimulate();
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            Method.ClearArray();
            Init();
            /*RRListView.Clear();
            DPListView.Clear();
            SRTListView.Clear();
            SPNListView.Cleer();*/
            timer.Stop();
            IsStart = false;

        }

        private static List<Eprocess> RR = new List<Eprocess>();
        private static List<Eprocess> DP = new List<Eprocess>();
        private static List<Eprocess> SRT = new List<Eprocess>();
        private static List<Eprocess> SPN = new List<Eprocess>();

        private void StartSimulate()
        {
            // 增加每一段时间进行Update的控制
            RR = Method.RR(RR);

            // 程序在这里中断了
            


            DP = Method.DP(DP);
            SRT = Method.SRT(SRT); //?
            SPN = Method.SPN(SPN);
            Update(RR, DP, SRT, SPN);



            if (SRT.Count == 0 && DP.Count == 0 && SPN.Count == 0 && RR.Count == 0)
            {
                    SRTListView.Items.Clear();
                    DPListView.Items.Clear();
                    SPNListView.Items.Clear();
                    RRListView.Items.Clear();
                    timer.Stop();
                    IsStart = false;
            }
        }


        private void Update(List<Eprocess> RR, List<Eprocess> DP, List<Eprocess> SRT, List<Eprocess> SPN)
        {
            RRListView.Items.Clear();
            RRListView.Controls.Clear();
            // MessageBox.Show(RRListView.Controls.Count.ToString());
            for (int i = 0; i < RR.Count; ++i)
            {
                double p = (RR[i].percentage - RR[i].times) / (double)RR[i].percentage;
                ListViewItem item = new ListViewItem(RR[i].name.ToString());
                // item.SubItems.Add((p * 100).ToString());
                item.SubItems.Add(p.ToString());
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                item.SubItems.Add(RR[i].status.ToString());
                RRListView.Items.Add(item);
                // https://stackoverflow.com/questions/39181805/accessing-progressbar-in-listview

                /*foreach(Control it in RRListView.Controls)
                {
                    if(it.Name == RR[i].name.ToString())
                    {
                        ProgressBar bar = (ProgressBar)it;
                        bar.Value = (int)(p * 100);
                    }
                }*/
            }

            DPListView.Items.Clear();
            for (int i = 0; i < DP.Count; ++i)
            {
                double p = (DP[i].percentage - DP[i].times) / (double)DP[i].percentage;
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                item.SubItems.Add(p.ToString());
                item.SubItems.Add(DP[i].primary.ToString());
                item.SubItems.Add(DP[i].times.ToString());
                item.SubItems.Add(DP[i].status.ToString());
                DPListView.Items.Add(item);
            }
            /*DP = DP.OrderByDescending(x => x.primary)
                .ToList();*/

            SRTListView.Items.Clear();

            for (int i = 0; i < SRT.Count; ++i)
            {
                double p = (SRT[i].percentage - SRT[i].times) / (double)SRT[i].percentage;
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                item.SubItems.Add(p.ToString());
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                item.SubItems.Add(SRT[i].status.ToString());
                SRTListView.Items.Add(item);
            }
           /* SRT = SRT.OrderByDescending(x => x.times)
                .ToList();*/

            SPNListView.Items.Clear();
            for (int i = 0; i < SPN.Count; ++i)
            {
                double p = (SPN[i].percentage - SPN[i].times) / (double)SPN[i].percentage;
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                item.SubItems.Add(p.ToString());
                item.SubItems.Add(SPN[i].primary.ToString());
                item.SubItems.Add(SPN[i].times.ToString());
                item.SubItems.Add(SPN[i].status.ToString());
                SPNListView.Items.Add(item);
            }
            /*SPN.Sort();                     // first base on time and then base on Status( 2 => processing 1 => waiting)
            SPN = SPN.OrderByDescending(x => x.status)
                .ToList();*/
        }


        // RR DP SRT SPN
        private void Init()
        {

            // https://stackoverflow.com/questions/14007405/how-create-a-new-deep-copy-clone-of-a-listt
            RR = Method.ProcessArray;
            DP = Method.ProcessArray.ConvertAll(i => new Eprocess(i.name, i.status, i.primary, i.times));
            SRT = Method.ProcessArray.ConvertAll(i => new Eprocess(i.name, i.status, i.primary, i.times));
            SPN = Method.ProcessArray.ConvertAll(i => new Eprocess(i.name, i.status, i.primary, i.times));

            RRListView.Items.Clear();
            for (int i = 0; i < RR.Count; ++i)
            {
                double p = 0; // (RR[i].percentage - RR[i].times) / RR[i].percentage;

                ListViewItem item = new ListViewItem(RR[i].name.ToString());

                item.SubItems.Add(p.ToString());
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                item.SubItems.Add(RR[i].status.ToString());
                RRListView.Items.Add(item);

                /*ProgressBar pb = new ProgressBar();

                Rectangle r = item.SubItems[1].Bounds;
                pb.SetBounds(r.X, r.Y, r.Width, r.Height);
                pb.Minimum = 0;
                pb.Maximum = 100;
                pb.Value = (int)(p * 100);
                item.ListView.Controls.Add(pb);
                pb.Name = "RR" + RR[i].name;*/
                // item.Controls.Add(pb);
            }


            DPListView.Items.Clear();
            for(int i = 0; i < DP.Count; ++i)
            {
                double p = 0;
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                item.SubItems.Add(p.ToString());
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
                double p = 0;
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                item.SubItems.Add(p.ToString());
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                item.SubItems.Add(SRT[i].status.ToString());
                SRTListView.Items.Add(item);
            }
            SRT.Sort(); // base on time

            SPNListView.Items.Clear();
            for (int i = 0; i < SPN.Count; ++i)
            {
                double p = 0;
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                item.SubItems.Add(p.ToString());
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
