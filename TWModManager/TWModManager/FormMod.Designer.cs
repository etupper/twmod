namespace TWModManager
{
    partial class FormMod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMod));
            this.labelName = new System.Windows.Forms.Label();
            this.imgMod = new System.Windows.Forms.PictureBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgMod)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 8);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(395, 23);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // imgMod
            // 
            this.imgMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgMod.Image = ((System.Drawing.Image)(resources.GetObject("imgMod.Image")));
            this.imgMod.Location = new System.Drawing.Point(12, 38);
            this.imgMod.Name = "imgMod";
            this.imgMod.Size = new System.Drawing.Size(160, 160);
            this.imgMod.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMod.TabIndex = 1;
            this.imgMod.TabStop = false;
            // 
            // labelAuthor
            // 
            this.labelAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(178, 38);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(229, 27);
            this.labelAuthor.TabIndex = 2;
            this.labelAuthor.Text = "Author";
            this.labelAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDesc
            // 
            this.labelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDesc.Location = new System.Drawing.Point(178, 71);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(229, 127);
            this.labelDesc.TabIndex = 3;
            this.labelDesc.Text = "Description";
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 208);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.imgMod);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMod";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mod Info";
            this.Load += new System.EventHandler(this.FormMod_Load);
            this.Shown += new System.EventHandler(this.FormMod_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.imgMod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox imgMod;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelDesc;
    }
}