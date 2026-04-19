namespace MediaTekDocuments.view
{
    partial class FrmRevue
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
            this.txtTitre = new System.Windows.Forms.TextBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnAjout = new System.Windows.Forms.Button();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.cboGenre = new System.Windows.Forms.ComboBox();
            this.cboRayon = new System.Windows.Forms.ComboBox();
            this.lblDelaiDispo = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblPeriodicite = new System.Windows.Forms.Label();
            this.lblPublic = new System.Windows.Forms.Label();
            this.lblRayon = new System.Windows.Forms.Label();
            this.lblTitre = new System.Windows.Forms.Label();
            this.cboPeriodicite = new System.Windows.Forms.ComboBox();
            this.txtDelaiDispo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cboPublic
            // 
            this.cboPublic.FormattingEnabled = true;
            this.cboPublic.Location = new System.Drawing.Point(97, 65);
            this.cboPublic.Name = "cboPublic";
            this.cboPublic.Size = new System.Drawing.Size(163, 21);
            this.cboPublic.TabIndex = 2;
            this.cboPublic.Text = "-- Choisir le public --";
            // 
            // txtTitre
            // 
            this.txtTitre.Location = new System.Drawing.Point(97, 12);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(163, 20);
            this.txtTitre.TabIndex = 0;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(431, 118);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(519, 118);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 23);
            this.btnAjout.TabIndex = 8;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // txtImage
            // 
            this.txtImage.Location = new System.Drawing.Point(431, 65);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(163, 20);
            this.txtImage.TabIndex = 5;
            // 
            // cboGenre
            // 
            this.cboGenre.FormattingEnabled = true;
            this.cboGenre.Location = new System.Drawing.Point(431, 38);
            this.cboGenre.Name = "cboGenre";
            this.cboGenre.Size = new System.Drawing.Size(163, 21);
            this.cboGenre.TabIndex = 4;
            this.cboGenre.Text = "-- Choisir le genre --";
            // 
            // cboRayon
            // 
            this.cboRayon.FormattingEnabled = true;
            this.cboRayon.Location = new System.Drawing.Point(97, 38);
            this.cboRayon.Name = "cboRayon";
            this.cboRayon.Size = new System.Drawing.Size(163, 21);
            this.cboRayon.TabIndex = 1;
            this.cboRayon.Text = "-- Choisir le rayon --";
            // 
            // lblDelaiDispo
            // 
            this.lblDelaiDispo.AutoSize = true;
            this.lblDelaiDispo.Location = new System.Drawing.Point(256, 95);
            this.lblDelaiDispo.Name = "lblDelaiDispo";
            this.lblDelaiDispo.Size = new System.Drawing.Size(137, 13);
            this.lblDelaiDispo.TabIndex = 26;
            this.lblDelaiDispo.Text = "Délai de mise à disposition :";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Location = new System.Drawing.Point(287, 68);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(106, 13);
            this.lblImage.TabIndex = 25;
            this.lblImage.Text = "Chemin vers l\'image :";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(351, 41);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(42, 13);
            this.lblGenre.TabIndex = 24;
            this.lblGenre.Text = "Genre :";
            // 
            // lblPeriodicite
            // 
            this.lblPeriodicite.AutoSize = true;
            this.lblPeriodicite.Location = new System.Drawing.Point(331, 15);
            this.lblPeriodicite.Name = "lblPeriodicite";
            this.lblPeriodicite.Size = new System.Drawing.Size(62, 13);
            this.lblPeriodicite.TabIndex = 23;
            this.lblPeriodicite.Text = "Périodicité :";
            // 
            // lblPublic
            // 
            this.lblPublic.AutoSize = true;
            this.lblPublic.Location = new System.Drawing.Point(15, 67);
            this.lblPublic.Name = "lblPublic";
            this.lblPublic.Size = new System.Drawing.Size(42, 13);
            this.lblPublic.TabIndex = 22;
            this.lblPublic.Text = "Public :";
            // 
            // lblRayon
            // 
            this.lblRayon.AutoSize = true;
            this.lblRayon.Location = new System.Drawing.Point(13, 41);
            this.lblRayon.Name = "lblRayon";
            this.lblRayon.Size = new System.Drawing.Size(44, 13);
            this.lblRayon.TabIndex = 21;
            this.lblRayon.Text = "Rayon :";
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(23, 15);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(34, 13);
            this.lblTitre.TabIndex = 20;
            this.lblTitre.Text = "Titre :";
            // 
            // cboPeriodicite
            // 
            this.cboPeriodicite.FormattingEnabled = true;
            this.cboPeriodicite.Location = new System.Drawing.Point(431, 11);
            this.cboPeriodicite.Name = "cboPeriodicite";
            this.cboPeriodicite.Size = new System.Drawing.Size(163, 21);
            this.cboPeriodicite.TabIndex = 3;
            this.cboPeriodicite.Text = "-- Choisir la périodicité --";
            // 
            // txtDelaiDispo
            // 
            this.txtDelaiDispo.Location = new System.Drawing.Point(431, 91);
            this.txtDelaiDispo.Name = "txtDelaiDispo";
            this.txtDelaiDispo.Size = new System.Drawing.Size(163, 20);
            this.txtDelaiDispo.TabIndex = 6;
            // 
            // FrmRevue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 161);
            this.Controls.Add(this.txtDelaiDispo);
            this.Controls.Add(this.cboPeriodicite);
            this.Controls.Add(this.cboPublic);
            this.Controls.Add(this.txtTitre);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.cboGenre);
            this.Controls.Add(this.cboRayon);
            this.Controls.Add(this.lblDelaiDispo);
            this.Controls.Add(this.lblImage);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblPeriodicite);
            this.Controls.Add(this.lblPublic);
            this.Controls.Add(this.lblRayon);
            this.Controls.Add(this.lblTitre);
            this.Name = "FrmRevue";
            this.Text = "Ajouter une revue";
            this.Load += new System.EventHandler(this.FrmRevue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPublic;
        private System.Windows.Forms.TextBox txtTitre;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.ComboBox cboGenre;
        private System.Windows.Forms.ComboBox cboRayon;
        private System.Windows.Forms.Label lblDelaiDispo;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblPeriodicite;
        private System.Windows.Forms.Label lblPublic;
        private System.Windows.Forms.Label lblRayon;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.ComboBox cboPeriodicite;
        private System.Windows.Forms.TextBox txtDelaiDispo;
    }
}