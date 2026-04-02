namespace MediaTekDocuments.view
{
    partial class FrmDvd
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
            this.cboPublic = new System.Windows.Forms.ComboBox();
            this.txtDuree = new System.Windows.Forms.TextBox();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnAjout = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.txtRealisateur = new System.Windows.Forms.TextBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblRealisateur = new System.Windows.Forms.Label();
            this.lblPublic = new System.Windows.Forms.Label();
            this.lblDuree = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblSynopsis = new System.Windows.Forms.Label();
            this.rtbSynopsis = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cboPublic
            // 
            this.cboPublic.FormattingEnabled = true;
            this.cboPublic.Location = new System.Drawing.Point(108, 65);
            this.cboPublic.Name = "cboPublic";
            this.cboPublic.Size = new System.Drawing.Size(163, 21);
            this.cboPublic.TabIndex = 2;
            this.cboPublic.Text = "-- Choisir le public --";
            // 
            // txtDuree
            // 
            this.txtDuree.Location = new System.Drawing.Point(108, 38);
            this.txtDuree.Name = "txtDuree";
            this.txtDuree.Size = new System.Drawing.Size(163, 20);
            this.txtDuree.TabIndex = 1;
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(107, 12);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(163, 20);
            this.txtTitre.TabIndex = 0;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(432, 159);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(520, 159);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 23);
            this.btnAjout.TabIndex = 8;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(432, 65);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(163, 20);
            this.txtImage.TabIndex = 6;
            // 
            // txtRealisateur
            // 
            this.txtRealisateur.Location = new System.Drawing.Point(432, 12);
            this.txtRealisateur.Name = "txtRealisateur";
            this.txtRealisateur.Size = new System.Drawing.Size(163, 20);
            this.txtRealisateur.TabIndex = 4;
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(432, 38);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(163, 21);
            this.cboGenre.TabIndex = 5;
            this.cboGenre.Text = "-- Choisir le genre --";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(288, 68);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(106, 13);
            this.lblImage.TabIndex = 26;
            this.lblImage.Text = "Chemin vers l\'image :";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(352, 41);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(42, 13);
            this.lblGenre.TabIndex = 24;
            this.lblGenre.Text = "Genre :";
            // 
            // lblRealisateur
            // 
            this.lblRealisateur.AutoSize = true;
            this.lblRealisateur.Location = new System.Drawing.Point(302, 15);
            this.lblRealisateur.Name = "lblRealisateur";
            this.lblRealisateur.Size = new System.Drawing.Size(92, 13);
            this.lblRealisateur.TabIndex = 23;
            this.lblRealisateur.Text = "Réalisateur(trice) :";
            // 
            // lblPublic
            // 
            this.lblPublic.AutoSize = true;
            this.lblPublic.Location = new System.Drawing.Point(26, 67);
            this.lblPublic.Name = "lblPublic";
            this.lblPublic.Size = new System.Drawing.Size(42, 13);
            this.lblPublic.TabIndex = 22;
            this.lblPublic.Text = "Public :";
            // 
            // lblDuree
            // 
            this.lblDuree.AutoSize = true;
            this.lblDuree.Location = new System.Drawing.Point(26, 41);
            this.lblDuree.Name = "lblDuree";
            this.lblDuree.Size = new System.Drawing.Size(42, 13);
            this.lblDuree.TabIndex = 21;
            this.lblDuree.Text = "Durée :";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(34, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(34, 13);
            this.lblTitre.TabIndex = 20;
            this.lblTitre.Text = "Titre :";
            // 
            // lblSynopsis
            // 
            this.lblSynopsis.AutoSize = true;
            this.lblSynopsis.Location = new System.Drawing.Point(13, 95);
            this.lblSynopsis.Name = "lblSynopsis";
            this.lblSynopsis.Size = new System.Drawing.Size(55, 13);
            this.lblSynopsis.TabIndex = 36;
            this.lblSynopsis.Text = "Synopsis :";
            // 
            // rtbSynopsis
            // 
            this.rtbSynopsis.Location = new System.Drawing.Point(108, 95);
            this.rtbSynopsis.Name = "rtbSynopsis";
            this.rtbSynopsis.Size = new System.Drawing.Size(163, 87);
            this.rtbSynopsis.TabIndex = 3;
            this.rtbSynopsis.Text = "";
            // 
            // FrmDvd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 191);
            this.Controls.Add(this.rtbSynopsis);
            this.Controls.Add(this.lblSynopsis);
            this.Controls.Add(this.cboPublic);
            this.Controls.Add(this.txtDuree);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.txtRealisateur);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblRealisateur);
            this.Controls.Add(this.lblPublic);
            this.Controls.Add(this.lblDuree);
            this.Controls.Add(this.lblTitre);
            this.Name = "FrmDvd";
            this.Text = "Ajouter un DVD";
            this.Load += new System.EventHandler(this.FrmDvd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPublic;
        private System.Windows.Forms.TextBox txtDuree;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.TextBox txtRealisateur;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRealisateur;
        private System.Windows.Forms.Label lblPublic;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblSynopsis;
        private System.Windows.Forms.RichTextBox rtbSynopsis;
    }
}