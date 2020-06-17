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
using static OSS_EXP4.Exp_process;
using Timer = System.Timers.Timer;

namespace OSS_EXP4
{
    public partial class Form1 : Form
    {
        private Timer timer;
         void SetTimer()
        {
            double seconds = 100;
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
            Method.CreateRandomProcess(10);
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {            
            Init();
            SetTimer();
            // StartSimulate();
        }

        private static List<Exp_process> RR = new List<Exp_process>();
        private static List<Exp_process> DP = new List<Exp_process>();
        private static List<Exp_process> SRT = new List<Exp_process>();
        private static List<Exp_process> SPN = new List<Exp_process>();

        private void StartSimulate()
        {
            // 增加每一段时间进行Update的控制
            RR = Method.RR(RR);
            DP = Method.DP(DP);
            SRT = Method.SRT(SRT); //?
            SPN = Method.SPN(SPN);
            Update(RR, DP, SRT, SPN);

            if(SRT.Count == 6)
            {
                timer.Enabled = false;
            }

        }

        private void Update(List<Exp_process> RR, List<Exp_process> DP, List<Exp_process> SRT, List<Exp_process> SPN)
        {
            RRListView.Items.Clear();
            for (int i = 0; i < RR.Count; ++i)
            {
                ListViewItem item = new ListViewItem(RR[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                RRListView.Items.Add(item);
            }

            DPListView.Items.Clear();
            for (int i = 0; i < DP.Count; ++i)
            {
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(DP[i].primary.ToString());
                item.SubItems.Add(DP[i].times.ToString());
                DPListView.Items.Add(item);
            }

            SRTListView.Items.Clear();
            for (int i = 0; i < SRT.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                SRTListView.Items.Add(item);
            }

            SPNListView.Items.Clear();
            for (int i = 0; i < SPN.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SPN[i].primary.ToString());
                item.SubItems.Add(SPN[i].times.ToString());
                SPNListView.Items.Add(item);
            }
        }


        // RR DP SRT SPN
        private void Init()
        {

            // https://stackoverflow.com/questions/14007405/how-create-a-new-deep-copy-clone-of-a-listt
            RR = Method.ProcessArray;
            DP = RR.ConvertAll(i => new Exp_process(i.name, i.status, i.primary, i.times));
            SRT = RR.ConvertAll(i => new Exp_process(i.name, i.status, i.primary, i.times));
            SPN = RR.ConvertAll(i => new Exp_process(i.name, i.status, i.primary, i.times));
            MessageBox.Show("Successful Init");

            for (int i = 0; i < RR.Count; ++i)
            {
                ListViewItem item = new ListViewItem(RR[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                RRListView.Items.Add(item);
            }



            for(int i = 0; i < DP.Count; ++i)
            {
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(DP[i].primary.ToString());
                item.SubItems.Add(DP[i].times.ToString());
                DPListView.Items.Add(item);
            }

            // https://www.techiedelight.com/sort-list-by-multiple-fields-csharp/
            DP = DP.OrderByDescending(x => x.primary) 
                .ToList();
                
            


            
            for (int i = 0; i < SRT.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                SRTListView.Items.Add(item);
            }
            SRT.Sort(); // base on time

            for (int i = 0; i < SPN.Count; ++i)
            {
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                item.SubItems.Add("");
                item.SubItems.Add(SPN[i].primary.ToString());
                item.SubItems.Add(SPN[i].times.ToString());
                SPNListView.Items.Add(item);
            }
        }

    }
}
