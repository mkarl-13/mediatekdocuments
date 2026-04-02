namespace MediaTekDocuments.view
{
    partial class FrmLivre
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblCollection = new System.Windows.Forms.Label();
            this.lblPublic = new System.Windows.Forms.Label();
            this.lblAuteur = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblRayon = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.cboRayon = new System.Windows.Forms.ComboBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.txtAuteur = new System.Windows.Forms.TextBox();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.txtCollection = new System.Windows.Forms.TextBox();
            this.cboPublic = new System.Windows.Forms.ComboBox();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(37, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(34, 13);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Titre :";
            this.lblTitre.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblCollection
            // 
            this.lblCollection.AutoSize = true;
            this.lblCollection.Location = new System.Drawing.Point(12, 41);
            this.lblCollection.Name = "lblCollection";
            this.lblCollection.Size = new System.Drawing.Size(59, 13);
            this.lblCollection.TabIndex = 1;
            this.lblCollection.Text = "Collection :";
            // 
            // lblPublic
            // 
            this.lblPublic.AutoSize = true;
            this.lblPublic.Location = new System.Drawing.Point(29, 67);
            this.lblPublic.Name = "lblPublic";
            this.lblPublic.Size = new System.Drawing.Size(42, 13);
            this.lblPublic.TabIndex = 2;
            this.lblPublic.Text = "Public :";
            // 
            // lblAuteur
            // 
            this.lblAuteur.AutoSize = true;
            this.lblAuteur.Location = new System.Drawing.Point(327, 15);
            this.lblAuteur.Name = "lblAuteur";
            this.lblAuteur.Size = new System.Drawing.Size(70, 13);
            this.lblAuteur.TabIndex = 3;
            this.lblAuteur.Text = "Auteur(trice) :";
            this.lblAuteur.Click += new System.EventHandler(this.lblAuteur_Click);
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(355, 41);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(42, 13);
            this.lblGenre.TabIndex = 4;
            this.lblGenre.Text = "Genre :";
            // 
            // lblRayon
            // 
            this.lblRayon.AutoSize = true;
            this.lblRayon.Location = new System.Drawing.Point(353, 68);
            this.lblRayon.Name = "lblRayon";
            this.lblRayon.Size = new System.Drawing.Size(44, 13);
            this.lblRayon.TabIndex = 5;
            this.lblRayon.Text = "Rayon :";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(291, 95);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(106, 13);
            this.lblImage.TabIndex = 6;
            this.lblImage.Text = "Chemin vers l\'image :";
            this.lblImage.Click += new System.EventHandler(this.label7_Click);
            // 
            // cboRayon
            // 
            this.cboRayon.FormattingEnabled = true;
            this.cboRayon.Location = new System.Drawing.Point(435, 65);
            this.cboRayon.Name = "cboRayon";
            this.cboRayon.Size = new System.Drawing.Size(163, 21);
            this.cboRayon.TabIndex = 5;
            this.cboRayon.Text = "-- Choisir le rayon --";
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(435, 38);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(163, 21);
            this.cboGenre.TabIndex = 4;
            this.cboGenre.Text = "-- Choisir le genre --";
            // 
            // txtAuteur
            // 
            this.txtAuteur.Location = new System.Drawing.Point(435, 12);
            this.txtAuteur.Name = "txtAuteur";
            this.txtAuteur.Size = new System.Drawing.Size(163, 20);
            this.txtAuteur.TabIndex = 3;
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(435, 92);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(163, 20);
            this.txtImage.TabIndex = 6;
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(523, 118);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 23);
            this.btnAjout.TabIndex = 8;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(435, 118);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(111, 12);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(163, 20);
            this.txtTitre.TabIndex = 0;
            // 
            // txtCollection
            // 
            this.txtCollection.Location = new System.Drawing.Point(111, 38);
            this.txtCollection.Name = "txtCollection";
            this.txtCollection.Size = new System.Drawing.Size(163, 20);
            this.txtCollection.TabIndex = 1;
            // 
            // cboPublic
            // 
            this.cboPublic.FormattingEnabled = true;
            this.cboPublic.Location = new System.Drawing.Point(111, 65);
            this.cboPublic.Name = "cboPublic";
            this.cboPublic.Size = new System.Drawing.Size(163, 21);
            this.cboPublic.TabIndex = 2;
            this.cboPublic.Text = "-- Choisir le public --";
            // 
            // lblIsbn
            // 
            this.lblIsbn.AutoSize = true;
            this.lblIsbn.Location = new System.Drawing.Point(29, 95);
            this.lblIsbn.Name = "lblIsbn";
            this.lblIsbn.Size = new System.Drawing.Size(38, 13);
            this.lblIsbn.TabIndex = 9;
            this.lblIsbn.Text = "ISBN :";
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(111, 92);
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(163, 20);
            this.txtIsbn.TabIndex = 10;
            // 
            // FrmLivre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 161);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.lblIsbn);
            this.Controls.Add(this.cboPublic);
            this.Controls.Add(this.txtCollection);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.txtAuteur);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.cboRayon);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblRayon);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblAuteur);
            this.Controls.Add(this.lblPublic);
            this.Controls.Add(this.lblCollection);
            this.Controls.Add(this.lblTitre);
            this.Name = "FrmLivre";
            this.Text = "Ajouter un livre";
            this.Load += new System.EventHandler(this.FrmLivre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblCollection;
        private System.Windows.Forms.Label lblPublic;
        private System.Windows.Forms.Label lblAuteur;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblRayon;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.ComboBox cboRayon;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.TextBox txtAuteur;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.TextBox txtCollection;
        private System.Windows.Forms.ComboBox cboPublic;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.TextBox txtIsbn;
    }
}