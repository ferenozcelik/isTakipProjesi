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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();
        
        /// <summary>
        /// Personel tablosundan ID, Ad, Soyad, Mail, Departman kolonlarını al ve values'e kaydet.
        /// gridControl DataSource içine values'u listeleyerek ver.
        /// </summary>
        void PersonelListele()
        {
            var values = from x in db.TblPersonel
                         select new
                         {
                             x.ID,
                             x.Ad,
                             x.Soyad,
                             x.Mail,
                             x.Departman
                         };
            gridControl1.DataSource = values.ToList();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            PersonelListele();


            var departmants = (from x in db.TblDepartmanlar
                              select new
                              {
                                  x.ID,
                                  x.Ad
                              }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmants;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            PersonelListele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblPersonel t = new TblPersonel();
            t.Ad = TxtAd.Text;
            t.Soyad = TxtSoyad.Text;
            t.Mail = TxtMail.Text;
            t.Gorsel = TxtGorsel.Text;
            t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.TblPersonel.Add(t);
            db.SaveChanges();

            PersonelListele();
            XtraMessageBox.Show("Yeni personel eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
