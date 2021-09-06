using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace HappyDummyWFA
{
    public partial class Home : Form
    {

        System.Timers.Timer timer;
        int counter = 0;
        Random timeEvent;
        Random timeBetweenEvents;
        List<LogExe> listlog = new List<LogExe>();
        string[] show = new string[2];
        ListViewItem list;
        int createdTimer = 0;
        int auxMoviment = -1;

        int auxLogFileDate = -1;
        string auxFileName = "";
        double auxTimeTimer = 0.0;

        bool firstTime = false;

        string browsedLogPath = "";

        public Home()
        {
            InitializeComponent();

            SetupHomeForm();
            SetupHistoricExecution();

            firstTime = true;
        }

        #region Setup UI

        private void SetupHomeForm()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            this.Activate();
            this.TopMost = true;
        }

        private void SetupHistoricExecution()
        {
            listView.View = View.Details;
            listView.Columns.Add("Data/Hora", 137);
            listView.Columns.Add("Qtd executada", 105);
        }

        #endregion

        #region Buttons


        private void Start_Click(object sender, EventArgs e)
        {
            start.Enabled = false;
            statusLog.Text = "Status : Executando";
            createdTimer = 1;
            timeEvent = new Random();
            timeBetweenEvents = new Random();


            double tempoTimerLogTeste = TimeSpan.FromMinutes(Utils.GetTimeInterval(timeEvent)).TotalMilliseconds; //entre 3 e 14
            //Console.WriteLine("Tempo do timer é :" + tempoTimerLogTeste.ToString());

            nextExecution.Text = "Proxima Execução em : " + (tempoTimerLogTeste / 1000 / 60).ToString() + " minutos.";
            
            auxTimeTimer = tempoTimerLogTeste;

            timer = new System.Timers.Timer(tempoTimerLogTeste)
            {
                AutoReset = true
            }; //TimeSpan.FromMinutes(r.Next(4, 14)).TotalMilliseconds); //240000 ,840000

            timer.Elapsed += new ElapsedEventHandler(Movements);
            timer.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (createdTimer == 1)
            {
                timer.Stop();
                timer.Dispose();
                statusLog.Text = "Status : Finalizado";
                createdTimer = 0;
                start.Enabled = true;
            }
            else
            {
                MessageBox.Show("Você precisa iniciar a aplicação para depois pausar!");
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Application.Exit();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void HappyDummy_SizeChanged(object sender, EventArgs e)
        {
            bool MousePointerNotOnTaskBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                this.notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = false;
        }

        private void CopyPathLog_Click(object sender, EventArgs e)
        {
            if (historicPath.Text != "C:\\")
                Clipboard.SetText(historicPath.Text);
        }


        private void BrowsePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                browsedLogPath = folderBrowserDialog1.SelectedPath;
                historicPath.Text = browsedLogPath;
            }
        }

        #endregion



        #region Events

        private void Movements(object e, ElapsedEventArgs d)
        {
            
            timer.Stop();

            timer.Interval = TimeSpan.FromMinutes(Utils.GetTimeInterval(timeEvent)).TotalMilliseconds;

            while (auxTimeTimer == timer.Interval)
            {
                timer.Interval = TimeSpan.FromMinutes(Utils.GetTimeInterval(timeEvent)).TotalMilliseconds;
            }
            auxTimeTimer = timer.Interval;

            string textLabelUpdate = "Proxima Execução em : " + (timer.Interval / 1000 / 60).ToString() + " minutos.";
            SetLabelNextExecutionByThread(textLabelUpdate);
            UpdatingButtonStopByThread(false);

            timer.Start();

            LogExe log = new LogExe
            {
                dateTimeLog = DateTime.Now
            };

            counter++;
            log.executedQuantityLog = counter;



            UpdateStatusLog(log);

            RandomMoviments();

            UpdatingButtonStopByThread(true);

        }

        private void SetLabelNextExecutionByThread(string textLabelUpdate)
        {
            MethodInvoker inv = delegate
            {
                nextExecution.Visible = true;
                this.nextExecution.Text = textLabelUpdate;
            };
            this.Invoke(inv);
        }

        private void UpdatingButtonStopByThread(bool value)
        {
            MethodInvoker inv = delegate
            {
                stop.Enabled = value;
                if (value)
                {
                    stop.Text = "Parar";
                }
                else
                {
                    stop.Text = "Aguarde...";
                }
            };
            this.Invoke(inv);

        }

        private void RandomMoviments()
        {

            for (int i = 0; i < 4; i++)
            {
                int currentMoviment = new Random().Next(3);
                while (currentMoviment == auxMoviment)
                {
                    currentMoviment = new Random().Next(3);
                }
                auxMoviment = currentMoviment;


                if (currentMoviment == 0)
                {
                    SendKeys.SendWait(MovimentKeyboard.movimentRight());
                }
                else if (currentMoviment == 1)
                {
                    SendKeys.SendWait(MovimentKeyboard.movimentLeft());
                }
                else if (currentMoviment == 2)
                {
                    SendKeys.SendWait(MovimentKeyboard.movimentNorth());
                }
                else
                {
                    SendKeys.SendWait(MovimentKeyboard.movimentSouth());
                }

                Thread.Sleep(timeBetweenEvents.Next(1000, 3000));

            }
        }

        delegate void UpdateStatusLogCallback(LogExe log);
        private void UpdateStatusLog(LogExe log)
        {
            listlog = new List<LogExe>();
            if (InvokeRequired)
            {
                UpdateStatusLogCallback callback = UpdateStatusLog;
                Invoke(callback, log);
            }
            else
            {
                statusLog.Text = "Status : Executando, atualizando dados.";
                listlog.Add(log); // somente para armazenar os valores

                show[0] = log.dateTimeLog.ToString();
                show[1] = log.executedQuantityLog.ToString();

                list = new ListViewItem(show);
                listView.Items.Add(list);

                string arq = log.dateTimeLog.ToString() + ", " + log.executedQuantityLog.ToString() + " vezes";
                string fileName = "";
                if (auxLogFileDate != log.dateTimeLog.Day)
                {
                    fileName = log.dateTimeLog.Day + "-" + log.dateTimeLog.Month + "-" + log.dateTimeLog.Year;
                    auxLogFileDate = log.dateTimeLog.Day;
                    auxFileName = fileName;
                }
                else
                {
                    fileName = auxFileName;
                }

                try
                {
                    
                    string path = Utils.CreateLog(arq, fileName, browsedLogPath);
                    if (firstTime)
                    {
                        UpdatingHistoricPath(path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void UpdatingHistoricPath(string homePath)
        {
            MethodInvoker inv = delegate
            {
                firstTime = false;
                historicPath.Visible = true;
                historicPath.Text = homePath;
            };
            this.Invoke(inv);

        }

        #endregion

    }
}
