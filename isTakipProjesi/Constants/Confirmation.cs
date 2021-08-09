using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isTakipProjesi.Constants
{
    public class Confirmation
    {
        
        public static DialogResult Confirm()
        {
            return XtraMessageBox.Show("Bu işlemden emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
