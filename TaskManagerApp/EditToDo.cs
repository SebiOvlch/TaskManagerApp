using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace TaskManagerApp
{
    public partial class EditToDo : Form
    {
        public string EditedValue { get; private set; } // Tárolja a szerkesztett értéket
        public EditToDo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Mentjük a szerkesztett értéket
            EditedValue = txtEdit.Text;

            // Bezárjuk az űrlapot
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
