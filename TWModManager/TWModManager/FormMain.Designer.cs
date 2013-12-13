namespace TWModManager
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.listViewMod = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.conflictColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteProfileButton = new System.Windows.Forms.Button();
            this.saveProfileButton = new System.Windows.Forms.Button();
            this.lbl_profiles = new System.Windows.Forms.Label();
            this.profilesComboBox = new System.Windows.Forms.ComboBox();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.launchGameButton = new System.Windows.Forms.Button();
            this.listViewMovie = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelMovie = new System.Windows.Forms.Label();
            this.labelMod = new System.Windows.Forms.Label();
            this.labelActivated = new System.Windows.Forms.Label();
            this.groupBoxProfiles = new System.Windows.Forms.GroupBox();
            this.labelOrderInfo = new System.Windows.Forms.Label();
            this.findR2TWPathFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.revertToVanillaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectGameDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelDataPath = new System.Windows.Forms.Label();
            this.groupBoxConvert = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonConvertMovie = new System.Windows.Forms.Button();
            this.timerForm = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerLaunch = new System.Windows.Forms.Timer(this.components);
            this.timerLauncher = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewContentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelWorkshop = new System.Windows.Forms.Label();
            this.groupBoxProfiles.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.groupBoxConvert.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMod
            // 
            this.listViewMod.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewMod.CheckBoxes = true;
            this.listViewMod.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.conflictColumn});
            this.listViewMod.FullRowSelect = true;
            this.listViewMod.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMod.HideSelection = false;
            this.listViewMod.Location = new System.Drawing.Point(12, 53);
            this.listViewMod.MultiSelect = false;
            this.listViewMod.Name = "listViewMod";
            this.listViewMod.Size = new System.Drawing.Size(357, 203);
            this.listViewMod.TabIndex = 3;
            this.listViewMod.UseCompatibleStateImageBehavior = false;
            this.listViewMod.View = System.Windows.Forms.View.Details;
            this.listViewMod.SelectedIndexChanged += new System.EventHandler(this.listViewMod_SelectedIndexChanged);
            this.listViewMod.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewMod_MouseClick);
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 211;
            // 
            // conflictColumn
            // 
            this.conflictColumn.Text = "Conflicts";
            this.conflictColumn.Width = 131;
            // 
            // deleteProfileButton
            // 
            this.deleteProfileButton.Enabled = false;
            this.deleteProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteProfileButton.Location = new System.Drawing.Point(101, 68);
            this.deleteProfileButton.Name = "deleteProfileButton";
            this.deleteProfileButton.Size = new System.Drawing.Size(70, 23);
            this.deleteProfileButton.TabIndex = 19;
            this.deleteProfileButton.Text = "&Delete";
            this.deleteProfileButton.UseVisualStyleBackColor = true;
            this.deleteProfileButton.Click += new System.EventHandler(this.deleteProfileButton_Click);
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveProfileButton.Location = new System.Drawing.Point(24, 68);
            this.saveProfileButton.Name = "saveProfileButton";
            this.saveProfileButton.Size = new System.Drawing.Size(70, 23);
            this.saveProfileButton.TabIndex = 18;
            this.saveProfileButton.Text = "&Save";
            this.saveProfileButton.UseVisualStyleBackColor = true;
            this.saveProfileButton.Click += new System.EventHandler(this.saveProfileButton_Click);
            // 
            // lbl_profiles
            // 
            this.lbl_profiles.AutoSize = true;
            this.lbl_profiles.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_profiles.Location = new System.Drawing.Point(21, 24);
            this.lbl_profiles.Name = "lbl_profiles";
            this.lbl_profiles.Size = new System.Drawing.Size(87, 13);
            this.lbl_profiles.TabIndex = 16;
            this.lbl_profiles.Text = "Select &Profile:";
            this.lbl_profiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // profilesComboBox
            // 
            this.profilesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilesComboBox.FormattingEnabled = true;
            this.profilesComboBox.Location = new System.Drawing.Point(24, 40);
            this.profilesComboBox.Name = "profilesComboBox";
            this.profilesComboBox.Size = new System.Drawing.Size(147, 24);
            this.profilesComboBox.TabIndex = 17;
            this.profilesComboBox.SelectedIndexChanged += new System.EventHandler(this.profilesComboBox_SelectedIndexChanged);
            this.profilesComboBox.Click += new System.EventHandler(this.profilesComboBox_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Font = new System.Drawing.Font("Wingdings", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDownButton.Location = new System.Drawing.Point(372, 95);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(29, 27);
            this.moveDownButton.TabIndex = 14;
            this.moveDownButton.Text = "ê";
            this.moveDownButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.moveDownButton.UseCompatibleTextRendering = true;
            this.moveDownButton.UseMnemonic = false;
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Font = new System.Drawing.Font("Wingdings", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUpButton.Location = new System.Drawing.Point(372, 67);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(29, 27);
            this.moveUpButton.TabIndex = 13;
            this.moveUpButton.Text = "é";
            this.moveUpButton.UseCompatibleTextRendering = true;
            this.moveUpButton.UseMnemonic = false;
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // launchGameButton
            // 
            this.launchGameButton.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchGameButton.Image = ((System.Drawing.Image)(resources.GetObject("launchGameButton.Image")));
            this.launchGameButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launchGameButton.Location = new System.Drawing.Point(383, 403);
            this.launchGameButton.Name = "launchGameButton";
            this.launchGameButton.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.launchGameButton.Size = new System.Drawing.Size(204, 81);
            this.launchGameButton.TabIndex = 15;
            this.launchGameButton.Text = "&Launch";
            this.launchGameButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.launchGameButton.UseVisualStyleBackColor = true;
            this.launchGameButton.Click += new System.EventHandler(this.launchGameButton_Click);
            // 
            // listViewMovie
            // 
            this.listViewMovie.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewMovie.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewMovie.FullRowSelect = true;
            this.listViewMovie.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMovie.Location = new System.Drawing.Point(12, 284);
            this.listViewMovie.MultiSelect = false;
            this.listViewMovie.Name = "listViewMovie";
            this.listViewMovie.Size = new System.Drawing.Size(357, 203);
            this.listViewMovie.TabIndex = 20;
            this.listViewMovie.UseCompatibleStateImageBehavior = false;
            this.listViewMovie.View = System.Windows.Forms.View.Details;
            this.listViewMovie.SelectedIndexChanged += new System.EventHandler(this.listViewMovie_SelectedIndexChanged);
            this.listViewMovie.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewMovie_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 211;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Conflicts";
            this.columnHeader2.Width = 131;
            // 
            // labelMovie
            // 
            this.labelMovie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMovie.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovie.Location = new System.Drawing.Point(12, 259);
            this.labelMovie.Name = "labelMovie";
            this.labelMovie.Size = new System.Drawing.Size(357, 22);
            this.labelMovie.TabIndex = 21;
            this.labelMovie.Text = "Movie Packs";
            this.labelMovie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMod
            // 
            this.labelMod.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMod.Location = new System.Drawing.Point(12, 28);
            this.labelMod.Name = "labelMod";
            this.labelMod.Size = new System.Drawing.Size(357, 22);
            this.labelMod.TabIndex = 22;
            this.labelMod.Text = "Mod Packs";
            this.labelMod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelActivated
            // 
            this.labelActivated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelActivated.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActivated.Location = new System.Drawing.Point(130, 259);
            this.labelActivated.Name = "labelActivated";
            this.labelActivated.Size = new System.Drawing.Size(140, 22);
            this.labelActivated.TabIndex = 23;
            this.labelActivated.Text = "(Always activated)";
            this.labelActivated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxProfiles
            // 
            this.groupBoxProfiles.Controls.Add(this.deleteProfileButton);
            this.groupBoxProfiles.Controls.Add(this.profilesComboBox);
            this.groupBoxProfiles.Controls.Add(this.lbl_profiles);
            this.groupBoxProfiles.Controls.Add(this.saveProfileButton);
            this.groupBoxProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProfiles.Location = new System.Drawing.Point(383, 156);
            this.groupBoxProfiles.Name = "groupBoxProfiles";
            this.groupBoxProfiles.Size = new System.Drawing.Size(200, 100);
            this.groupBoxProfiles.TabIndex = 24;
            this.groupBoxProfiles.TabStop = false;
            this.groupBoxProfiles.Text = "Mod Profiles";
            // 
            // labelOrderInfo
            // 
            this.labelOrderInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelOrderInfo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderInfo.Location = new System.Drawing.Point(405, 55);
            this.labelOrderInfo.Name = "labelOrderInfo";
            this.labelOrderInfo.Size = new System.Drawing.Size(186, 79);
            this.labelOrderInfo.TabIndex = 25;
            this.labelOrderInfo.Text = "Moving a mod higher up will mean its contents will load over any conflicting file" +
    "s in the mods below it.";
            this.labelOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // findR2TWPathFolderBrowserDialog
            // 
            this.findR2TWPathFolderBrowserDialog.Description = "Unable to automatically find the path to Rome2.exe, please locate it manually.";
            this.findR2TWPathFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.findR2TWPathFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionsToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(596, 24);
            this.menuStrip.TabIndex = 26;
            this.menuStrip.Text = "menuStrip1";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchGameToolStripMenuItem,
            this.revertToVanillaToolStripMenuItem,
            this.toolStripMenuItem1,
            this.selectGameDirectoryToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.functionsToolStripMenuItem.Text = "&Tool";
            // 
            // launchGameToolStripMenuItem
            // 
            this.launchGameToolStripMenuItem.Name = "launchGameToolStripMenuItem";
            this.launchGameToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.launchGameToolStripMenuItem.Text = "&Launch Game";
            this.launchGameToolStripMenuItem.Click += new System.EventHandler(this.launchGameToolStripMenuItem_Click);
            // 
            // revertToVanillaToolStripMenuItem
            // 
            this.revertToVanillaToolStripMenuItem.Name = "revertToVanillaToolStripMenuItem";
            this.revertToVanillaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.revertToVanillaToolStripMenuItem.Text = "&Revert to Vanilla";
            this.revertToVanillaToolStripMenuItem.Click += new System.EventHandler(this.revertToVanillaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // selectGameDirectoryToolStripMenuItem
            // 
            this.selectGameDirectoryToolStripMenuItem.Name = "selectGameDirectoryToolStripMenuItem";
            this.selectGameDirectoryToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.selectGameDirectoryToolStripMenuItem.Text = "Set Game Directory";
            this.selectGameDirectoryToolStripMenuItem.Click += new System.EventHandler(this.selectGameDirectoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "&Information";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // labelDataPath
            // 
            this.labelDataPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDataPath.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataPath.Location = new System.Drawing.Point(0, 492);
            this.labelDataPath.Name = "labelDataPath";
            this.labelDataPath.Size = new System.Drawing.Size(596, 16);
            this.labelDataPath.TabIndex = 27;
            this.labelDataPath.Text = "C:\\";
            this.labelDataPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDataPath.DoubleClick += new System.EventHandler(this.labelDataPath_DoubleClick);
            // 
            // groupBoxConvert
            // 
            this.groupBoxConvert.Controls.Add(this.label5);
            this.groupBoxConvert.Controls.Add(this.buttonConvertMovie);
            this.groupBoxConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxConvert.Location = new System.Drawing.Point(383, 279);
            this.groupBoxConvert.Name = "groupBoxConvert";
            this.groupBoxConvert.Size = new System.Drawing.Size(200, 112);
            this.groupBoxConvert.TabIndex = 28;
            this.groupBoxConvert.TabStop = false;
            this.groupBoxConvert.Text = "Convert Movie to Mod";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 58);
            this.label5.TabIndex = 19;
            this.label5.Text = "This will allow you to convert a movie format pack into a mod format pack so it c" +
    "an be controlled by Mod Manager.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConvertMovie
            // 
            this.buttonConvertMovie.Enabled = false;
            this.buttonConvertMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvertMovie.Location = new System.Drawing.Point(9, 81);
            this.buttonConvertMovie.Name = "buttonConvertMovie";
            this.buttonConvertMovie.Size = new System.Drawing.Size(185, 23);
            this.buttonConvertMovie.TabIndex = 18;
            this.buttonConvertMovie.Text = "&Convert selected...";
            this.buttonConvertMovie.UseVisualStyleBackColor = true;
            this.buttonConvertMovie.Click += new System.EventHandler(this.buttonConvertMovie_Click);
            // 
            // timerForm
            // 
            this.timerForm.Interval = 40;
            this.timerForm.Tick += new System.EventHandler(this.timerForm_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 509);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(575, 23);
            this.progressBar.TabIndex = 29;
            this.progressBar.Visible = false;
            // 
            // timerLaunch
            // 
            this.timerLaunch.Tick += new System.EventHandler(this.timerLaunch_Tick);
            // 
            // timerLauncher
            // 
            this.timerLauncher.Tick += new System.EventHandler(this.timerLauncher_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContentsToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(151, 26);
            // 
            // viewContentsToolStripMenuItem
            // 
            this.viewContentsToolStripMenuItem.Name = "viewContentsToolStripMenuItem";
            this.viewContentsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.viewContentsToolStripMenuItem.Text = "View Contents";
            this.viewContentsToolStripMenuItem.Click += new System.EventHandler(this.viewContentsToolStripMenuItem_Click);
            // 
            // labelWorkshop
            // 
            this.labelWorkshop.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWorkshop.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelWorkshop.Location = new System.Drawing.Point(131, 27);
            this.labelWorkshop.Name = "labelWorkshop";
            this.labelWorkshop.Size = new System.Drawing.Size(460, 20);
            this.labelWorkshop.TabIndex = 30;
            this.labelWorkshop.Text = "Blue = Steam Workshop Mod (Right click Mod for more info)";
            this.labelWorkshop.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelWorkshop.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(596, 508);
            this.Controls.Add(this.labelWorkshop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxConvert);
            this.Controls.Add(this.labelDataPath);
            this.Controls.Add(this.labelOrderInfo);
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.groupBoxProfiles);
            this.Controls.Add(this.labelActivated);
            this.Controls.Add(this.labelMod);
            this.Controls.Add(this.labelMovie);
            this.Controls.Add(this.listViewMovie);
            this.Controls.Add(this.launchGameButton);
            this.Controls.Add(this.listViewMod);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total War: Rome 2 - Mod Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBoxProfiles.ResumeLayout(false);
            this.groupBoxProfiles.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxConvert.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewMod;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader conflictColumn;
        private System.Windows.Forms.Button deleteProfileButton;
        private System.Windows.Forms.Button saveProfileButton;
        private System.Windows.Forms.Label lbl_profiles;
        private System.Windows.Forms.ComboBox profilesComboBox;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button launchGameButton;
        private System.Windows.Forms.ListView listViewMovie;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label labelMovie;
        private System.Windows.Forms.Label labelMod;
        private System.Windows.Forms.Label labelActivated;
        private System.Windows.Forms.GroupBox groupBoxProfiles;
        private System.Windows.Forms.Label labelOrderInfo;
        private System.Windows.Forms.FolderBrowserDialog findR2TWPathFolderBrowserDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem revertToVanillaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label labelDataPath;
        private System.Windows.Forms.GroupBox groupBoxConvert;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonConvertMovie;
        private System.Windows.Forms.Timer timerForm;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timerLaunch;
        private System.Windows.Forms.Timer timerLauncher;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewContentsToolStripMenuItem;
        private System.Windows.Forms.Label labelWorkshop;
        private System.Windows.Forms.ToolStripMenuItem selectGameDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

