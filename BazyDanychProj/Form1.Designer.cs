namespace BazyDanychProj
{
    partial class FormLogowanie
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelHaslo = new System.Windows.Forms.Label();
            this.labelLogowanie = new System.Windows.Forms.Label();
            this.buttonLogowanie = new System.Windows.Forms.Button();
            this.buttonZmianaLogowania = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(142, 69);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(100, 20);
            this.textBoxLogin.TabIndex = 0;
            this.textBoxLogin.TextChanged += new System.EventHandler(this.textBoxLogin_TextChanged);
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Location = new System.Drawing.Point(142, 105);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.PasswordChar = '*';
            this.textBoxHaslo.Size = new System.Drawing.Size(100, 20);
            this.textBoxHaslo.TabIndex = 1;
            this.textBoxHaslo.TextChanged += new System.EventHandler(this.textBoxHaslo_TextChanged);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(47, 72);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(89, 13);
            this.labelLogin.TabIndex = 2;
            this.labelLogin.Text = "Podaj swój login: ";
            // 
            // labelHaslo
            // 
            this.labelHaslo.AutoSize = true;
            this.labelHaslo.Location = new System.Drawing.Point(36, 108);
            this.labelHaslo.Name = "labelHaslo";
            this.labelHaslo.Size = new System.Drawing.Size(100, 13);
            this.labelHaslo.TabIndex = 3;
            this.labelHaslo.Text = "Podaj swoje hasło: ";
            // 
            // labelLogowanie
            // 
            this.labelLogowanie.AutoSize = true;
            this.labelLogowanie.Location = new System.Drawing.Point(105, 17);
            this.labelLogowanie.Name = "labelLogowanie";
            this.labelLogowanie.Size = new System.Drawing.Size(94, 13);
            this.labelLogowanie.TabIndex = 4;
            this.labelLogowanie.Text = "Logowanie Klienta";
            // 
            // buttonLogowanie
            // 
            this.buttonLogowanie.Location = new System.Drawing.Point(142, 140);
            this.buttonLogowanie.Name = "buttonLogowanie";
            this.buttonLogowanie.Size = new System.Drawing.Size(97, 25);
            this.buttonLogowanie.TabIndex = 5;
            this.buttonLogowanie.Text = "Zaloguj";
            this.buttonLogowanie.UseVisualStyleBackColor = true;
            this.buttonLogowanie.Click += new System.EventHandler(this.buttonLogowanie_Click);
            // 
            // buttonZmianaLogowania
            // 
            this.buttonZmianaLogowania.Location = new System.Drawing.Point(108, 171);
            this.buttonZmianaLogowania.Name = "buttonZmianaLogowania";
            this.buttonZmianaLogowania.Size = new System.Drawing.Size(158, 23);
            this.buttonZmianaLogowania.TabIndex = 6;
            this.buttonZmianaLogowania.Text = "Zaloguj jako Administrator";
            this.buttonZmianaLogowania.UseVisualStyleBackColor = true;
            this.buttonZmianaLogowania.Click += new System.EventHandler(this.buttonZmianaLogowania_Click);
            // 
            // FormLogowanie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 244);
            this.Controls.Add(this.buttonZmianaLogowania);
            this.Controls.Add(this.buttonLogowanie);
            this.Controls.Add(this.labelLogowanie);
            this.Controls.Add(this.labelHaslo);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxHaslo);
            this.Controls.Add(this.textBoxLogin);
            this.Name = "FormLogowanie";
            this.Text = "Logowanie do aplikacji";
            this.Load += new System.EventHandler(this.FormLogowanie_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelHaslo;
        private System.Windows.Forms.Label labelLogowanie;
        private System.Windows.Forms.Button buttonLogowanie;
        private System.Windows.Forms.Button buttonZmianaLogowania;
    }
}

