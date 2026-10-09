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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtBrLogVar = new Label();
            cmBoxBrLogVar = new ComboBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // txtBrLogVar
            // 
            txtBrLogVar.AutoSize = true;
            txtBrLogVar.BackColor = Color.Transparent;
            txtBrLogVar.Font = new Font("BankGothic Md BT", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBrLogVar.ForeColor = Color.SteelBlue;
            txtBrLogVar.Location = new Point(13, 21);
            txtBrLogVar.Margin = new Padding(4, 0, 4, 0);
            txtBrLogVar.Name = "txtBrLogVar";
            txtBrLogVar.Size = new Size(321, 16);
            txtBrLogVar.TabIndex = 0;
            txtBrLogVar.Text = "Odaberite broj logičkih varijabli";
            // 
            // cmBoxBrLogVar
            // 
            cmBoxBrLogVar.FormattingEnabled = true;
            cmBoxBrLogVar.Location = new Point(342, 20);
            cmBoxBrLogVar.Margin = new Padding(4, 3, 4, 3);
            cmBoxBrLogVar.Name = "cmBoxBrLogVar";
            cmBoxBrLogVar.Size = new Size(136, 21);
            cmBoxBrLogVar.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.SteelBlue;
            btnSend.FlatStyle = FlatStyle.Popup;
            btnSend.Font = new Font("BankGothic Md BT", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(188, 70);
            btnSend.Margin = new Padding(4, 3, 4, 3);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(104, 30);
            btnSend.TabIndex = 2;
            btnSend.Text = "Nastavi";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(482, 147);
            Controls.Add(btnSend);
            Controls.Add(cmBoxBrLogVar);
            Controls.Add(txtBrLogVar);
            Font = new Font("BankGothic Md BT", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
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
