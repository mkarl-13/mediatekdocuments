using MediaTekDocuments.controller;
using System;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    public partial class FrmAuthentification : Form
    {
        private readonly FrmAuthentificationController controller;

        public FrmAuthentification()
        {
            InitializeComponent();
            this.controller = new FrmAuthentificationController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txbLogin.Text;
            string mdp = txbMdp.Text;

            string idService = controller.GetAuthentification(login, mdp);

            if (idService != null)
            {
                if (idService == "3")
                {
                    MessageBox.Show("Vous n'êtes pas autorisé à utiliser l'application", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FrmMediatek frm = new FrmMediatek(idService);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
