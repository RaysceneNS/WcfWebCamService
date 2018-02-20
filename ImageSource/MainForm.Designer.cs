namespace ImageSource
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCamera = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUploadFrequency = new System.Windows.Forms.ComboBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonVideoSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxImage.Image = global::ImageSource.Properties.Resources.NoImageAvailable;
            this.pictureBoxImage.Location = new System.Drawing.Point(32, 112);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(300, 225);
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select camera:";
            // 
            // comboBoxCamera
            // 
            this.comboBoxCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCamera.FormattingEnabled = true;
            this.comboBoxCamera.Location = new System.Drawing.Point(142, 28);
            this.comboBoxCamera.Name = "comboBoxCamera";
            this.comboBoxCamera.Size = new System.Drawing.Size(190, 21);
            this.comboBoxCamera.TabIndex = 3;
            this.comboBoxCamera.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCamera_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Upload Frequency:";
            // 
            // comboBoxUploadFrequency
            // 
            this.comboBoxUploadFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUploadFrequency.FormattingEnabled = true;
            this.comboBoxUploadFrequency.Location = new System.Drawing.Point(143, 55);
            this.comboBoxUploadFrequency.Name = "comboBoxUploadFrequency";
            this.comboBoxUploadFrequency.Size = new System.Drawing.Size(189, 21);
            this.comboBoxUploadFrequency.TabIndex = 5;
            this.comboBoxUploadFrequency.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSnapshotInterval_SelectedIndexChanged);
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(29, 343);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(0, 13);
            this.labelMessage.TabIndex = 6;
            // 
            // buttonVideoSettings
            // 
            this.buttonVideoSettings.Location = new System.Drawing.Point(226, 83);
            this.buttonVideoSettings.Name = "buttonVideoSettings";
            this.buttonVideoSettings.Size = new System.Drawing.Size(106, 23);
            this.buttonVideoSettings.TabIndex = 7;
            this.buttonVideoSettings.Text = "Video Settings";
            this.buttonVideoSettings.UseVisualStyleBackColor = true;
            this.buttonVideoSettings.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 365);
            this.Controls.Add(this.buttonVideoSettings);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.comboBoxUploadFrequency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCamera);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxImage);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Image Source";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxCamera;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxUploadFrequency;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.Button buttonVideoSettings;
	}
}