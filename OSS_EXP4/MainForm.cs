using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static OSS_EXP4.Eprocess;
using Timer = System.Timers.Timer;

namespace OSS_EXP4
{
    public partial class MainForm : Form
    {
        public static Double Seconds = 1000;
        private Boolean IsStart = false;
        private Timer timer;
        // private string spaceMargin = "                ";

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
        public MainForm()
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
            Method.CreateRandomProcess(Method.MaxProcess);
            Init();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {            
            IsStart = true;
            SetTimer();
            timer.Start();
            // Init();
            // StartSimulate();
            label_Working.Visible = true;
            label_Working.Text = "调度中";
            txtb_speed.Enabled = false;
            btn_SetTime.Enabled = false;
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            Method.ClearArray();
            Init();
            if(timer != null)
            {
                timer.Stop();
            }
            IsStart = false;
            label_Working.Visible = false;
            AllProgressBarReset();
            txtb_speed.Text = "500";
            txtb_speed.Enabled = true;
            btn_SetTime.Enabled = true;
        }

        private static List<Eprocess> RR = new List<Eprocess>();
        private static List<Eprocess> DP = new List<Eprocess>();
        private static List<Eprocess> SRT = new List<Eprocess>();
        private static List<Eprocess> SPN = new List<Eprocess>();

        private void StartSimulate()
        {
            // 增加每一段时间进行Update的控制
            ;
            RR = Method.RR(RR);
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
                    label_Working.Text = "调度结束";
            }
        }


        private void Update(List<Eprocess> RR, List<Eprocess> DP, List<Eprocess> SRT, List<Eprocess> SPN)
        {
            double[] RRArray = new double[10];
            double[] DPArray = new double[10];
            double[] SRTArray = new double[10];
            double[] SPNArray = new double[10];
            RRListView.Items.Clear();
            for (int i = 0; i < RR.Count; ++i)
            {
                double p = (RR[i].percentage - RR[i].times) / (double)RR[i].percentage;
                ListViewItem item = new ListViewItem(RR[i].name.ToString());
                // item.SubItems.Add((p * 100).ToString());
                p *= 100;
                item.SubItems.Add(p.ToString("F1") + "%");
                item.SubItems.Add(RR[i].primary.ToString());
                item.SubItems.Add(RR[i].times.ToString());
                item.SubItems.Add(RR[i].status.ToString());
                RRListView.Items.Add(item);
                RRArray[i] = p;
                // https://stackoverflow.com/questions/39181805/accessing-progressbar-in-listview

            }


            DPListView.Items.Clear();
            for (int i = 0; i < DP.Count; ++i)
            {
                double p = (DP[i].percentage - DP[i].times) / (double)DP[i].percentage;
                ListViewItem item = new ListViewItem(DP[i].name.ToString());
                p *= 100;
                item.SubItems.Add(p.ToString("F1") + "%");
                item.SubItems.Add(DP[i].primary.ToString());
                item.SubItems.Add(DP[i].times.ToString());
                item.SubItems.Add(DP[i].status.ToString());
                DPListView.Items.Add(item);
                DPArray[i] = p;
            }
            /*DP = DP.OrderByDescending(x => x.primary)
                .ToList();*/

            SRTListView.Items.Clear();

            for (int i = 0; i < SRT.Count; ++i)
            {
                double p = (SRT[i].percentage - SRT[i].times) / (double)SRT[i].percentage;
                ListViewItem item = new ListViewItem(SRT[i].name.ToString());
                p *= 100;
                item.SubItems.Add(p.ToString("F1") + "%");
                item.SubItems.Add(SRT[i].primary.ToString());
                item.SubItems.Add(SRT[i].times.ToString());
                item.SubItems.Add(SRT[i].status.ToString());
                SRTListView.Items.Add(item);
                SRTArray[i] = p;
            }
           /* SRT = SRT.OrderByDescending(x => x.times)
                .ToList();*/

            SPNListView.Items.Clear();
            for (int i = 0; i < SPN.Count; ++i)
            {
                double p = (SPN[i].percentage - SPN[i].times) / (double)SPN[i].percentage;
                ListViewItem item = new ListViewItem(SPN[i].name.ToString());
                p *= 100;
                item.SubItems.Add(p.ToString("F1") + "%");
                item.SubItems.Add(SPN[i].primary.ToString());
                item.SubItems.Add(SPN[i].times.ToString());
                item.SubItems.Add(SPN[i].status.ToString());
                SPNListView.Items.Add(item);
                SPNArray[i] = p;
            }
            UpdateRRProgressBar(RRArray);
            UpdateDPProgressBar(DPArray);
            UpdateSRTProgressBar(SRTArray);
            UpdateSPNProgressBar(SPNArray);
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
                pb.Parent = RRListView;
                //item.ListView.Controls.Add(pb);
                pb.Name = "RR" + i;*/
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



        private void MainForm_Load(object sender, EventArgs e)
        {
            // SetTimer();
            
        }


        // 如果使用如DP那样的方法 可以瞬间完成进度条的显示， 但是会导致莫名其妙的bug 因为这算是个小hack。就不修了
        private void UpdateRRProgressBar(double[] Array)
        {
            RRpb0.Value = (int)Array[0];

            RRpb1.Value = (int)Array[1];

            RRpb2.Value = (int)Array[2];

            RRpb3.Value = (int)Array[3];

            RRpb4.Value = (int)Array[4];

            RRpb5.Value = (int)Array[5];

            RRpb6.Value = (int)Array[6];

            RRpb7.Value = (int)Array[7];

            RRpb8.Value = (int)Array[8];

            RRpb9.Value = (int)Array[9];
        }

        private void UpdateDPProgressBar(double[] Array)
        {
            DPpb0.Value = (int)Array[0];
            //DPpb0.Value = (int)Array[0] - 1;
            //DPpb0.Value = (int)Array[0];

            DPpb1.Value = (int)Array[1];
            //DPpb1.Value = (int)Array[1] - 1;
            //DPpb1.Value = (int)Array[1];

            DPpb2.Value = (int)Array[2];
            //DPpb2.Value = (int)Array[2] - 1;
            //DPpb2.Value = (int)Array[2];


            DPpb3.Value = (int)Array[3];
            //DPpb3.Value = (int)Array[3] - 1;
            //DPpb3.Value = (int)Array[3];

            DPpb4.Value = (int)Array[4];
            //DPpb4.Value = (int)Array[4] - 1;
            //DPpb4.Value = (int)Array[4];

            DPpb5.Value = (int)Array[5];
            //DPpb5.Value = (int)Array[5] - 1;
            //DPpb5.Value = (int)Array[5];

            DPpb6.Value = (int)Array[6];
            //DPpb6.Value = (int)Array[6] - 1;
            //DPpb6.Value = (int)Array[6];

            DPpb7.Value = (int)Array[7];
            //DPpb7.Value = (int)Array[7] - 1;
            //DPpb7.Value = (int)Array[7];

            DPpb8.Value = (int)Array[8];
            //DPpb8.Value = (int)Array[8] - 1;
            //DPpb8.Value = (int)Array[8];

            DPpb9.Value = (int)Array[9];
            //DPpb9.Value = (int)Array[9] - 1;
            //DPpb9.Value = (int)Array[9];
        }

        private void UpdateSRTProgressBar(double[] Array)
        {
            SRTpb0.Value = (int)Array[0];

            SRTpb1.Value = (int)Array[1];

            SRTpb2.Value = (int)Array[2];

            SRTpb3.Value = (int)Array[3];

            SRTpb4.Value = (int)Array[4];

            SRTpb5.Value = (int)Array[5];

            SRTpb6.Value = (int)Array[6];

            SRTpb7.Value = (int)Array[7];

            SRTpb8.Value = (int)Array[8];

            SRTpb9.Value = (int)Array[9];
        }

        private void UpdateSPNProgressBar(double[] Array)
        {
            SPNpb0.Value = (int)Array[0];

            SPNpb1.Value = (int)Array[1];

            SPNpb2.Value = (int)Array[2];

            SPNpb3.Value = (int)Array[3];

            SPNpb4.Value = (int)Array[4];

            SPNpb5.Value = (int)Array[5];

            SPNpb6.Value = (int)Array[6];

            SPNpb7.Value = (int)Array[7];

            SPNpb8.Value = (int)Array[8];

            SPNpb9.Value = (int)Array[9];
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("如果你觉得这个软件有帮助, 请到GitHub点个Star吧.", "嘤嘤嘤",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://github.com/Gpeter28/OS_exp4");
            }
        }

        private void AllProgressBarReset()
        {
            RRpb0.Value = 0;
            RRpb1.Value = 0;
            RRpb2.Value = 0;
            RRpb3.Value = 0;
            RRpb4.Value = 0;
            RRpb5.Value = 0;
            RRpb6.Value = 0;
            RRpb7.Value = 0;
            RRpb8.Value = 0;
            RRpb9.Value = 0;

            DPpb0.Value = 0;
            DPpb1.Value = 0;
            DPpb2.Value = 0;
            DPpb3.Value = 0;
            DPpb4.Value = 0;
            DPpb5.Value = 0;
            DPpb6.Value = 0;
            DPpb7.Value = 0;
            DPpb8.Value = 0;
            DPpb9.Value = 0;

            SRTpb0.Value = 0;
            SRTpb1.Value = 0;
            SRTpb2.Value = 0;
            SRTpb3.Value = 0;
            SRTpb4.Value = 0;
            SRTpb5.Value = 0;
            SRTpb6.Value = 0;
            SRTpb7.Value = 0;
            SRTpb8.Value = 0;
            SRTpb9.Value = 0;

            SPNpb0.Value = 0;
            SPNpb1.Value = 0;
            SPNpb2.Value = 0;
            SPNpb3.Value = 0;
            SPNpb4.Value = 0;
            SPNpb5.Value = 0;
            SPNpb6.Value = 0;
            SPNpb7.Value = 0;
            SPNpb8.Value = 0;
            SPNpb9.Value = 0;
        }

        private void btn_SetTime_Click(object sender, EventArgs e)
        {
            string text = txtb_speed.Text;
            int num = 1000;
            try
            {
                num = Int32.Parse(text);
            }
            catch (FormatException)
            {
                MessageBox.Show("错误输入");
            }
            if(num < 100)
            {
                MessageBox.Show("错误输入");
            }
            else
            {
                MainForm.Seconds = num;
                MessageBox.Show("成功设置");
            }
        }
    }
}


