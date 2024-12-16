using System;
using System.Windows.Forms;

namespace ProjectRapidOOP
{
    public partial class BattleResultForm : Form
    {
        public bool IsYesClicked { get; private set; }

        public BattleResultForm()
        {
            InitializeComponent();
            IsYesClicked = false;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            IsYesClicked = true;
            this.Close();  // Close the BattleResultForm and return to Form1
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
