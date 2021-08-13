using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isTakipProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmDepartmanlar frmDepartman = new Formlar.FrmDepartmanlar();
            frmDepartman.MdiParent = this;
            frmDepartman.Show();
        }

        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersoneller frmPersonel = new Formlar.FrmPersoneller();
            frmPersonel.MdiParent = this;
            frmPersonel.Show();
        }

        private void BtnPersonelİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmPersonelİstatistik frmPersonelİstatistik = new Formlar.FrmPersonelİstatistik();
            frmPersonelİstatistik.MdiParent = this;
            frmPersonelİstatistik.Show();
        }


        Formlar.FrmGorevListesi frmGorevListesi;
        private void BtnGorevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmGorevListesi == null || frmGorevListesi.IsDisposed)
            {
                frmGorevListesi = new Formlar.FrmGorevListesi();
                frmGorevListesi.MdiParent = this;
                frmGorevListesi.Show();
            }
        }

        private void BtnYeniGorev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmYeniGorev frmYeniGorev = new Formlar.FrmYeniGorev();
            frmYeniGorev.Show();
        }

        private void BtnGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FrmGorevDetay frmGorevDetay = new Formlar.FrmGorevDetay();
            frmGorevDetay.Show();
        }


        Formlar.FrmAnaForm frmAnaForm;
        private void BtnAnaForm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAnaForm == null || frmAnaForm.IsDisposed)
            {
                frmAnaForm = new Formlar.FrmAnaForm();
                frmAnaForm.MdiParent = this;
                frmAnaForm.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Formlar.FrmAnaForm frmAnaForm = new Formlar.FrmAnaForm();
            frmAnaForm.MdiParent = this;
            frmAnaForm.Show();
        }
    }
}
