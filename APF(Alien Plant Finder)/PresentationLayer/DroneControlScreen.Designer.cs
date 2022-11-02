namespace APF_Alien_Plant_Finder_.PresentationLayer
{
    partial class DroneControlScreen
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
            this.DroneView = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.btn_rotateLeft = new System.Windows.Forms.Button();
            this.btn_rotateRight = new System.Windows.Forms.Button();
            this.btn_throttle = new System.Windows.Forms.Button();
            this.btn_descend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DroneView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DroneView
            // 
            this.DroneView.Location = new System.Drawing.Point(31, 26);
            this.DroneView.Name = "DroneView";
            this.DroneView.Size = new System.Drawing.Size(937, 502);
            this.DroneView.TabIndex = 0;
            this.DroneView.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1021, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(288, 521);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Up
            // 
            this.btn_Up.Location = new System.Drawing.Point(123, 534);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(86, 50);
            this.btn_Up.TabIndex = 2;
            this.btn_Up.Text = "forward (W)";
            this.btn_Up.UseVisualStyleBackColor = true;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(123, 590);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(86, 50);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text = "Back (S)";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(31, 590);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(86, 50);
            this.btn_left.TabIndex = 4;
            this.btn_left.Text = "Left (A)";
            this.btn_left.UseVisualStyleBackColor = true;
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(215, 590);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(86, 50);
            this.btn_right.TabIndex = 5;
            this.btn_right.Text = "Right (D)";
            this.btn_right.UseVisualStyleBackColor = true;
            // 
            // btn_Scan
            // 
            this.btn_Scan.Location = new System.Drawing.Point(1021, 554);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(115, 53);
            this.btn_Scan.TabIndex = 6;
            this.btn_Scan.Text = "Scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            // 
            // btn_rotateLeft
            // 
            this.btn_rotateLeft.Location = new System.Drawing.Point(31, 534);
            this.btn_rotateLeft.Name = "btn_rotateLeft";
            this.btn_rotateLeft.Size = new System.Drawing.Size(86, 50);
            this.btn_rotateLeft.TabIndex = 7;
            this.btn_rotateLeft.Text = "Rotate L (Arrow Left)";
            this.btn_rotateLeft.UseVisualStyleBackColor = true;
            // 
            // btn_rotateRight
            // 
            this.btn_rotateRight.Location = new System.Drawing.Point(215, 534);
            this.btn_rotateRight.Name = "btn_rotateRight";
            this.btn_rotateRight.Size = new System.Drawing.Size(86, 50);
            this.btn_rotateRight.TabIndex = 8;
            this.btn_rotateRight.Text = "Rotate R (Arrow Right)";
            this.btn_rotateRight.UseVisualStyleBackColor = true;
            // 
            // btn_throttle
            // 
            this.btn_throttle.Location = new System.Drawing.Point(31, 646);
            this.btn_throttle.Name = "btn_throttle";
            this.btn_throttle.Size = new System.Drawing.Size(126, 50);
            this.btn_throttle.TabIndex = 9;
            this.btn_throttle.Text = "Throttle (Shift)";
            this.btn_throttle.UseVisualStyleBackColor = true;
            // 
            // btn_descend
            // 
            this.btn_descend.Location = new System.Drawing.Point(31, 702);
            this.btn_descend.Name = "btn_descend";
            this.btn_descend.Size = new System.Drawing.Size(75, 50);
            this.btn_descend.TabIndex = 10;
            this.btn_descend.Text = "Descend (CTRL)";
            this.btn_descend.UseVisualStyleBackColor = true;
            // 
            // DroneControlScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(1338, 773);
            this.Controls.Add(this.btn_descend);
            this.Controls.Add(this.btn_throttle);
            this.Controls.Add(this.btn_rotateRight);
            this.Controls.Add(this.btn_rotateLeft);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_Up);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.DroneView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DroneControlScreen";
            this.Text = "DroneControlScreen";
            ((System.ComponentModel.ISupportInitialize)(this.DroneView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DroneView;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_Scan;
        private System.Windows.Forms.Button btn_rotateLeft;
        private System.Windows.Forms.Button btn_rotateRight;
        private System.Windows.Forms.Button btn_throttle;
        private System.Windows.Forms.Button btn_descend;
    }
}