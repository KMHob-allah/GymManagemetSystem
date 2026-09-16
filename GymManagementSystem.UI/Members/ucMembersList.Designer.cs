namespace Gym.Members
{
    partial class ucMembersList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAddMember = new FontAwesome.Sharp.IconButton();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.colMemberID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJoinDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsActive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsMembers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.cbActivation = new System.Windows.Forms.ComboBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.cmsMembers.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1000, 112);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(147)))), ((int)(((byte)(157)))));
            this.lblSubtitle.Location = new System.Drawing.Point(12, 36);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(284, 15);
            this.lblSubtitle.TabIndex = 3;
            this.lblSubtitle.Text = "Manage all gym members, plans, and subscriptions";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(13, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(231, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Members Management";
            // 
            // btnAddMember
            // 
            this.btnAddMember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnAddMember.FlatAppearance.BorderSize = 0;
            this.btnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.btnAddMember.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddMember.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.btnAddMember.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddMember.IconSize = 20;
            this.btnAddMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMember.Location = new System.Drawing.Point(838, 10);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(127, 25);
            this.btnAddMember.TabIndex = 2;
            this.btnAddMember.Text = "     Add Member";
            this.btnAddMember.UseVisualStyleBackColor = false;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.dgvMembers);
            this.pnlMainContent.Controls.Add(this.pnlFooter);
            this.pnlMainContent.Controls.Add(this.pnlToolbar);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 112);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(15, 5, 15, 15);
            this.pnlMainContent.Size = new System.Drawing.Size(1000, 538);
            this.pnlMainContent.TabIndex = 1;
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(24)))));
            this.dgvMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMembers.ColumnHeadersHeight = 40;
            this.dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMemberID,
            this.colFullName,
            this.colPhoneNumber,
            this.colGender,
            this.colAge,
            this.colJoinDate,
            this.colArea,
            this.colIsActive});
            this.dgvMembers.ContextMenuStrip = this.cmsMembers;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(43)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMembers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMembers.EnableHeadersVisualStyles = false;
            this.dgvMembers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.dgvMembers.Location = new System.Drawing.Point(15, 58);
            this.dgvMembers.Margin = new System.Windows.Forms.Padding(5);
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.RowTemplate.Height = 35;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(970, 425);
            this.dgvMembers.TabIndex = 1;
            // 
            // colMemberID
            // 
            this.colMemberID.FillWeight = 60F;
            this.colMemberID.HeaderText = "ID";
            this.colMemberID.Name = "colMemberID";
            this.colMemberID.ReadOnly = true;
            // 
            // colFullName
            // 
            this.colFullName.FillWeight = 140F;
            this.colFullName.HeaderText = "Full Name";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.FillWeight = 110F;
            this.colPhoneNumber.HeaderText = "Phone Number";
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.FillWeight = 70F;
            this.colGender.HeaderText = "Gender";
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            // 
            // colAge
            // 
            this.colAge.FillWeight = 50F;
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            this.colAge.ReadOnly = true;
            // 
            // colJoinDate
            // 
            this.colJoinDate.FillWeight = 90F;
            this.colJoinDate.HeaderText = "Join Date";
            this.colJoinDate.Name = "colJoinDate";
            this.colJoinDate.ReadOnly = true;
            // 
            // colArea
            // 
            this.colArea.HeaderText = "Area";
            this.colArea.Name = "colArea";
            this.colArea.ReadOnly = true;
            // 
            // colIsActive
            // 
            this.colIsActive.FillWeight = 70F;
            this.colIsActive.HeaderText = "Is Active";
            this.colIsActive.Name = "colIsActive";
            this.colIsActive.ReadOnly = true;
            // 
            // cmsMembers
            // 
            this.cmsMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.cmsMembers.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmsMembers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.toolStripMenuItem2,
            this.activateToolStripMenuItem,
            this.deactivateToolStripMenuItem});
            this.cmsMembers.Name = "cmsMembers";
            this.cmsMembers.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsMembers.Size = new System.Drawing.Size(181, 126);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.activateToolStripMenuItem.Text = "Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // deactivateToolStripMenuItem
            // 
            this.deactivateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.deactivateToolStripMenuItem.Name = "deactivateToolStripMenuItem";
            this.deactivateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deactivateToolStripMenuItem.Text = "Deactivate";
            this.deactivateToolStripMenuItem.Click += new System.EventHandler(this.deactivateToolStripMenuItem_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblRecords);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(15, 483);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(970, 40);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(147)))), ((int)(((byte)(157)))));
            this.lblRecords.Location = new System.Drawing.Point(0, 12);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(83, 19);
            this.lblRecords.TabIndex = 0;
            this.lblRecords.Text = "Records : 0";
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.Controls.Add(this.cbGender);
            this.pnlToolbar.Controls.Add(this.txtSearchBox);
            this.pnlToolbar.Controls.Add(this.cbActivation);
            this.pnlToolbar.Controls.Add(this.btnAddMember);
            this.pnlToolbar.Controls.Add(this.cbFilter);
            this.pnlToolbar.Controls.Add(this.lblFilterTitle);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(15, 5);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(970, 53);
            this.pnlToolbar.TabIndex = 0;
            // 
            // cbGender
            // 
            this.cbGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbGender.ForeColor = System.Drawing.Color.White;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "None",
            "MemberID",
            "Name",
            "Area",
            "Gender",
            "IsActive"});
            this.cbGender.Location = new System.Drawing.Point(298, 10);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(220, 25);
            this.cbGender.TabIndex = 3;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchBox.ForeColor = System.Drawing.Color.White;
            this.txtSearchBox.Location = new System.Drawing.Point(298, 10);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(220, 25);
            this.txtSearchBox.TabIndex = 2;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            this.txtSearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchBox_KeyPress);
            // 
            // cbActivation
            // 
            this.cbActivation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.cbActivation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbActivation.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbActivation.ForeColor = System.Drawing.Color.White;
            this.cbActivation.FormattingEnabled = true;
            this.cbActivation.Items.AddRange(new object[] {
            "None",
            "MemberID",
            "Name",
            "Area",
            "Gender",
            "IsActive"});
            this.cbActivation.Location = new System.Drawing.Point(298, 10);
            this.cbActivation.Name = "cbActivation";
            this.cbActivation.Size = new System.Drawing.Size(220, 25);
            this.cbActivation.TabIndex = 4;
            this.cbActivation.SelectedIndexChanged += new System.EventHandler(this.cbActivation_SelectedIndexChanged);
            // 
            // cbFilter
            // 
            this.cbFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(34)))));
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbFilter.ForeColor = System.Drawing.Color.White;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "MemberID",
            "Name",
            "Area",
            "Gender",
            "IsActive"});
            this.cbFilter.Location = new System.Drawing.Point(60, 10);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(220, 25);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // lblFilterTitle
            // 
            this.lblFilterTitle.AutoSize = true;
            this.lblFilterTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterTitle.ForeColor = System.Drawing.Color.White;
            this.lblFilterTitle.Location = new System.Drawing.Point(3, 12);
            this.lblFilterTitle.Name = "lblFilterTitle";
            this.lblFilterTitle.Size = new System.Drawing.Size(51, 19);
            this.lblFilterTitle.TabIndex = 0;
            this.lblFilterTitle.Text = "Filter :";
            // 
            // ucMembersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ucMembersList";
            this.Size = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.ucMembersList_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.cmsMembers.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitle;
        private FontAwesome.Sharp.IconButton btnAddMember;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.DataGridView dgvMembers;
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblFilterTitle;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMemberID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJoinDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsActive;
        private System.Windows.Forms.ContextMenuStrip cmsMembers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox cbActivation;
    }
}