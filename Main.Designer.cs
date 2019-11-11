namespace WindowsFormsApplication1
{
    partial class Main
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
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.name = new System.Windows.Forms.DataGridViewLinkColumn();
            this.src = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rstate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.school = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.record = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.主要ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回收站ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.用户名密码管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excel操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.将系统数据导出到ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.将Excel模板内容导入系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置学校最大数量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据备份与还原ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(413, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 35);
            this.label2.TabIndex = 29;
            this.label2.Tag = "9999";
            this.label2.Text = "客户信息概览";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(604, 42);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 41);
            this.button5.TabIndex = 27;
            this.button5.Text = "筛选查询";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(150, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 41);
            this.button4.TabIndex = 26;
            this.button4.Text = "刷新数据（复位）";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(442, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 41);
            this.button2.TabIndex = 24;
            this.button2.Text = "删除所选客户";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 41);
            this.button1.TabIndex = 23;
            this.button1.Text = "增加新客户";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rid,
            this.name,
            this.src,
            this.rstate,
            this.date,
            this.consult,
            this.school,
            this.level,
            this.record});
            this.dataGridView1.Location = new System.Drawing.Point(55, 157);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(932, 581);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // rid
            // 
            this.rid.HeaderText = "资源号";
            this.rid.Name = "rid";
            this.rid.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // src
            // 
            this.src.HeaderText = "资源来源";
            this.src.Name = "src";
            this.src.ReadOnly = true;
            // 
            // rstate
            // 
            this.rstate.HeaderText = "资源状态";
            this.rstate.Name = "rstate";
            this.rstate.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "签约日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // consult
            // 
            this.consult.HeaderText = "顾问";
            this.consult.Name = "consult";
            this.consult.ReadOnly = true;
            // 
            // school
            // 
            this.school.HeaderText = "在读学校";
            this.school.Name = "school";
            this.school.ReadOnly = true;
            // 
            // level
            // 
            this.level.HeaderText = "级别";
            this.level.Name = "level";
            this.level.ReadOnly = true;
            // 
            // record
            // 
            this.record.HeaderText = "回访记录";
            this.record.Name = "record";
            this.record.ReadOnly = true;
            // 
            // 主要ToolStripMenuItem
            // 
            this.主要ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.回收站ToolStripMenuItem1,
            this.用户名密码管理ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.主要ToolStripMenuItem.Name = "主要ToolStripMenuItem";
            this.主要ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.主要ToolStripMenuItem.Text = "系统";
            // 
            // 回收站ToolStripMenuItem1
            // 
            this.回收站ToolStripMenuItem1.Enabled = false;
            this.回收站ToolStripMenuItem1.Name = "回收站ToolStripMenuItem1";
            this.回收站ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.回收站ToolStripMenuItem1.Text = "回收站";
            this.回收站ToolStripMenuItem1.Click += new System.EventHandler(this.回收站ToolStripMenuItem1_Click);
            // 
            // 用户名密码管理ToolStripMenuItem
            // 
            this.用户名密码管理ToolStripMenuItem.Enabled = false;
            this.用户名密码管理ToolStripMenuItem.Name = "用户名密码管理ToolStripMenuItem";
            this.用户名密码管理ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.用户名密码管理ToolStripMenuItem.Text = "用户账号管理";
            this.用户名密码管理ToolStripMenuItem.Click += new System.EventHandler(this.用户名密码管理ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // excel操作ToolStripMenuItem
            // 
            this.excel操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.将系统数据导出到ExcelToolStripMenuItem,
            this.将Excel模板内容导入系统ToolStripMenuItem});
            this.excel操作ToolStripMenuItem.Enabled = false;
            this.excel操作ToolStripMenuItem.Name = "excel操作ToolStripMenuItem";
            this.excel操作ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.excel操作ToolStripMenuItem.Text = "数据导入导出";
            // 
            // 将系统数据导出到ExcelToolStripMenuItem
            // 
            this.将系统数据导出到ExcelToolStripMenuItem.Name = "将系统数据导出到ExcelToolStripMenuItem";
            this.将系统数据导出到ExcelToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.将系统数据导出到ExcelToolStripMenuItem.Text = "将系统数据导出到Excel";
            this.将系统数据导出到ExcelToolStripMenuItem.Click += new System.EventHandler(this.将系统数据导出到ExcelToolStripMenuItem_Click);
            // 
            // 将Excel模板内容导入系统ToolStripMenuItem
            // 
            this.将Excel模板内容导入系统ToolStripMenuItem.Name = "将Excel模板内容导入系统ToolStripMenuItem";
            this.将Excel模板内容导入系统ToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.将Excel模板内容导入系统ToolStripMenuItem.Text = "将Excel模板内容导入系统";
            this.将Excel模板内容导入系统ToolStripMenuItem.Click += new System.EventHandler(this.将Excel模板内容导入系统ToolStripMenuItem_Click);
            // 
            // 设置学校最大数量ToolStripMenuItem
            // 
            this.设置学校最大数量ToolStripMenuItem.Name = "设置学校最大数量ToolStripMenuItem";
            this.设置学校最大数量ToolStripMenuItem.Size = new System.Drawing.Size(116, 21);
            this.设置学校最大数量ToolStripMenuItem.Text = "设置学校最大数量";
            this.设置学校最大数量ToolStripMenuItem.Click += new System.EventHandler(this.设置学校最大数量ToolStripMenuItem_Click);
            // 
            // 数据备份与还原ToolStripMenuItem
            // 
            this.数据备份与还原ToolStripMenuItem.Name = "数据备份与还原ToolStripMenuItem";
            this.数据备份与还原ToolStripMenuItem.Size = new System.Drawing.Size(104, 21);
            this.数据备份与还原ToolStripMenuItem.Text = "数据备份与还原";
            this.数据备份与还原ToolStripMenuItem.Click += new System.EventHandler(this.数据备份与还原ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Enabled = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.主要ToolStripMenuItem,
            this.excel操作ToolStripMenuItem,
            this.设置学校最大数量ToolStripMenuItem,
            this.数据备份与还原ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1043, 25);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Tag = "9999";
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 761);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "Main";
            this.Text = "客户信息管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewLinkColumn rid;
        private System.Windows.Forms.DataGridViewLinkColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn src;
        private System.Windows.Forms.DataGridViewTextBoxColumn rstate;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn consult;
        private System.Windows.Forms.DataGridViewTextBoxColumn school;
        private System.Windows.Forms.DataGridViewTextBoxColumn level;
        private System.Windows.Forms.DataGridViewTextBoxColumn record;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 主要ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 回收站ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 用户名密码管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excel操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 将系统数据导出到ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 将Excel模板内容导入系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置学校最大数量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据备份与还原ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}