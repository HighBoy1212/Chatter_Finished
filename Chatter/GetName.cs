using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatter {
    public partial class GetName : Form {
        public GetName() {
            InitializeComponent();
        }

        // Property to get the screen name entered by the user.
        public string ScreenName {
            get {
                return txtScreenName.Text;
            }
        }

        private void txtScreenName_TextChanged(object sender, EventArgs e) {
            btnOK.Enabled = (txtScreenName.Text != "");
        }

        private void btnOK_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
