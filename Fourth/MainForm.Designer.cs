namespace Fourth
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startServiceBtn = new System.Windows.Forms.Button();
            this.stopServiceBtn = new System.Windows.Forms.Button();
            this.servicesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.servicesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // startServiceBtn
            // 
            this.startServiceBtn.Enabled = false;
            this.startServiceBtn.Location = new System.Drawing.Point(12, 411);
            this.startServiceBtn.Name = "startServiceBtn";
            this.startServiceBtn.Size = new System.Drawing.Size(75, 23);
            this.startServiceBtn.TabIndex = 0;
            this.startServiceBtn.Text = "Start";
            this.startServiceBtn.UseVisualStyleBackColor = true;
            this.startServiceBtn.Click += new System.EventHandler(this.startServiceBtn_Click);
            // 
            // stopServiceBtn
            // 
            this.stopServiceBtn.Enabled = false;
            this.stopServiceBtn.Location = new System.Drawing.Point(93, 411);
            this.stopServiceBtn.Name = "stopServiceBtn";
            this.stopServiceBtn.Size = new System.Drawing.Size(75, 23);
            this.stopServiceBtn.TabIndex = 1;
            this.stopServiceBtn.Text = "Stop";
            this.stopServiceBtn.UseVisualStyleBackColor = true;
            this.stopServiceBtn.Click += new System.EventHandler(this.stopServiceBtn_Click);
            // 
            // servicesGridView
            // 
            this.servicesGridView.AllowUserToAddRows = false;
            this.servicesGridView.AllowUserToDeleteRows = false;
            this.servicesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesGridView.Location = new System.Drawing.Point(12, 12);
            this.servicesGridView.Name = "servicesGridView";
            this.servicesGridView.ReadOnly = true;
            this.servicesGridView.Size = new System.Drawing.Size(596, 393);
            this.servicesGridView.TabIndex = 2;
            this.servicesGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.servicesGridView_CellClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 446);
            this.Controls.Add(this.servicesGridView);
            this.Controls.Add(this.stopServiceBtn);
            this.Controls.Add(this.startServiceBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(636, 485);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(636, 485);
            this.Name = "MainForm";
            this.Text = "Windows services";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servicesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startServiceBtn;
        private System.Windows.Forms.Button stopServiceBtn;
        private System.Windows.Forms.DataGridView servicesGridView;
    }
}

