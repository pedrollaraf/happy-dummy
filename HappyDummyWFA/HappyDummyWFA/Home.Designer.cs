
namespace HappyDummyWFA
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.start = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.statusLog = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.close = new System.Windows.Forms.Button();
            this.minimize = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.nextExecution = new System.Windows.Forms.Label();
            this.historic = new System.Windows.Forms.Label();
            this.historicPath = new System.Windows.Forms.Label();
            this.browsePath = new System.Windows.Forms.Button();
            this.copyPathLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(145, 371);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(64, 25);
            this.start.TabIndex = 0;
            this.start.Text = "Iniciar";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(60, 371);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(64, 25);
            this.stop.TabIndex = 1;
            this.stop.Text = "Parar";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // statusLog
            // 
            this.statusLog.AutoSize = true;
            this.statusLog.Location = new System.Drawing.Point(7, 347);
            this.statusLog.Name = "statusLog";
            this.statusLog.Size = new System.Drawing.Size(100, 13);
            this.statusLog.TabIndex = 2;
            this.statusLog.Text = "Status : Sem Status";
            // 
            // listView
            // 
            this.listView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(10, 46);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(245, 243);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(235, 10);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(20, 20);
            this.close.TabIndex = 4;
            this.close.Text = "X";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.Close_Click);
            // 
            // minimize
            // 
            this.minimize.Location = new System.Drawing.Point(211, 10);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(19, 20);
            this.minimize.TabIndex = 5;
            this.minimize.Text = "-";
            this.minimize.UseVisualStyleBackColor = true;
            this.minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Happy Dummy";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // nextExecution
            // 
            this.nextExecution.AutoSize = true;
            this.nextExecution.Location = new System.Drawing.Point(7, 329);
            this.nextExecution.Name = "nextExecution";
            this.nextExecution.Size = new System.Drawing.Size(180, 13);
            this.nextExecution.TabIndex = 6;
            this.nextExecution.Text = "Proxima execução em : Não Iniciado";
            // 
            // historic
            // 
            this.historic.AutoSize = true;
            this.historic.Location = new System.Drawing.Point(7, 30);
            this.historic.Name = "historic";
            this.historic.Size = new System.Drawing.Size(54, 13);
            this.historic.TabIndex = 7;
            this.historic.Text = "Historico :";
            // 
            // historicPath
            // 
            this.historicPath.AutoEllipsis = true;
            this.historicPath.Location = new System.Drawing.Point(7, 300);
            this.historicPath.Name = "historicPath";
            this.historicPath.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.historicPath.Size = new System.Drawing.Size(159, 13);
            this.historicPath.TabIndex = 8;
            this.historicPath.Text = "C:\\\\";
            // 
            // browsePath
            // 
            this.browsePath.Location = new System.Drawing.Point(225, 294);
            this.browsePath.Name = "browsePath";
            this.browsePath.Size = new System.Drawing.Size(30, 25);
            this.browsePath.TabIndex = 9;
            this.browsePath.Text = "...";
            this.browsePath.UseVisualStyleBackColor = true;
            this.browsePath.Click += new System.EventHandler(this.BrowsePath_Click);
            // 
            // copyPathLog
            // 
            this.copyPathLog.Location = new System.Drawing.Point(172, 294);
            this.copyPathLog.Name = "copyPathLog";
            this.copyPathLog.Size = new System.Drawing.Size(50, 25);
            this.copyPathLog.TabIndex = 10;
            this.copyPathLog.Text = "Copiar";
            this.copyPathLog.UseVisualStyleBackColor = true;
            this.copyPathLog.Click += new System.EventHandler(this.CopyPathLog_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 408);
            this.Controls.Add(this.copyPathLog);
            this.Controls.Add(this.browsePath);
            this.Controls.Add(this.historicPath);
            this.Controls.Add(this.historic);
            this.Controls.Add(this.nextExecution);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.close);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.statusLog);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Happy Dummy";
            this.SizeChanged += new System.EventHandler(this.HappyDummy_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label statusLog;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button minimize;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label nextExecution;
        private System.Windows.Forms.Label historic;
        private System.Windows.Forms.Label historicPath;
        private System.Windows.Forms.Button browsePath;
        private System.Windows.Forms.Button copyPathLog;
    }
}

