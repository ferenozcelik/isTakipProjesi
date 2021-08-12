using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using isTakipProjesi.Entity;

namespace isTakipProjesi.Formlar
{
    public partial class FrmYeniGorev : Form
    {
        DbisTakipEntities db = new DbisTakipEntities();        

        public FrmYeniGorev()
        {
            InitializeComponent();
        }

        private void FrmYeniGorev_Load(object sender, EventArgs e)
        {
            var values = (from x in db.TblPersonel
                               select new
                               {
                                   x.ID,
                                   AdSoyad = x.Ad + " " +  x.Soyad
                               }).ToList();

            lookUpEditGorevAlan.Properties.ValueMember = "ID";
            lookUpEditGorevAlan.Properties.DisplayMember = "AdSoyad";
            lookUpEditGorevAlan.Properties.DataSource = values;
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblGorevler t = new TblGorevler();
            t.GorevVeren = int.Parse(TextGorevVeren.Text);
            t.GorevAlan = int.Parse(lookUpEditGorevAlan.EditValue.ToString());
            t.Durum = true;
            t.Tarih = DateTime.Parse(TextTarih.Text);
            t.Aciklama = TextAciklama.Text;
            db.TblGorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Yeni görev tanımlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
