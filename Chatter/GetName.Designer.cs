namespace Chatter {
    partial class GetName {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblEnterName = new System.Windows.Forms.Label();
            this.txtScreenName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterName
            // 
            this.lblEnterName.AutoSize = true;
            this.lblEnterName.Location = new System.Drawing.Point(12, 15);
            this.lblEnterName.Name = "lblEnterName";
            this.lblEnterName.Size = new System.Drawing.Size(103, 13);
            this.lblEnterName.TabIndex = 0;
            this.lblEnterName.Text = "Enter Screen Name:";
            // 
            // txtScreenName
            // 
            this.txtScreenName.Location = new System.Drawing.Point(121, 12);
            this.txtScreenName.Name = "txtScreenName";
            this.txtScreenName.Size = new System.Drawing.Size(100, 20);
            this.txtScreenName.TabIndex = 1;
            this.txtScreenName.TextChanged += new System.EventHandler(this.txtScreenName_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(91, 52);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GetName
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 87);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtScreenName);
            this.Controls.Add(this.lblEnterName);
            this.Name = "GetName";
            this.Text = "GetName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterName;
        private System.Windows.Forms.TextBox txtScreenName;
        private System.Windows.Forms.Button btnOK;
    }
}