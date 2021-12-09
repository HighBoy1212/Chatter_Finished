namespace Chatter {
    partial class MainForm {
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rtbConversation = new System.Windows.Forms.RichTextBox();
            this.lblConversation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 25);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(520, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(538, 23);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(50, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(9, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message";
            // 
            // rtbConversation
            // 
            this.rtbConversation.Location = new System.Drawing.Point(12, 81);
            this.rtbConversation.Name = "rtbConversation";
            this.rtbConversation.ReadOnly = true;
            this.rtbConversation.Size = new System.Drawing.Size(576, 320);
            this.rtbConversation.TabIndex = 3;
            this.rtbConversation.Text = "";
            // 
            // lblConversation
            // 
            this.lblConversation.AutoSize = true;
            this.lblConversation.Location = new System.Drawing.Point(9, 65);
            this.lblConversation.Name = "lblConversation";
            this.lblConversation.Size = new System.Drawing.Size(69, 13);
            this.lblConversation.TabIndex = 4;
            this.lblConversation.Text = "Conversation";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 413);
            this.Controls.Add(this.lblConversation);
            this.Controls.Add(this.rtbConversation);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Name = "MainForm";
            this.Text = "Messenger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RichTextBox rtbConversation;
        private System.Windows.Forms.Label lblConversation;
    }
}

