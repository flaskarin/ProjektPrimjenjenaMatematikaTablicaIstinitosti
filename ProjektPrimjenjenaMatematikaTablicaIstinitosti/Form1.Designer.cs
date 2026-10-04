namespace ProjektPrimjenjenaMatematikaTablicaIstinitosti
{
    partial class Form1
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
            txtBrLogVar = new Label();
            cmBoxBrLogVar = new ComboBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // txtBrLogVar
            // 
            txtBrLogVar.AutoSize = true;
            txtBrLogVar.Location = new Point(196, 119);
            txtBrLogVar.Name = "txtBrLogVar";
            txtBrLogVar.Size = new Size(172, 15);
            txtBrLogVar.TabIndex = 0;
            txtBrLogVar.Text = "Odaberite broj logičkih varijabli";
            // 
            // cmBoxBrLogVar
            // 
            cmBoxBrLogVar.FormattingEnabled = true;
            cmBoxBrLogVar.Location = new Point(406, 116);
            cmBoxBrLogVar.Name = "cmBoxBrLogVar";
            cmBoxBrLogVar.Size = new Size(121, 23);
            cmBoxBrLogVar.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(342, 206);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Nastavi";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(cmBoxBrLogVar);
            Controls.Add(txtBrLogVar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtBrLogVar;
        private ComboBox cmBoxBrLogVar;
        private Button btnSend;
    }
}
