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
using isTakipProjesi.Constants;
using isTakipProjesi.Entity;

namespace isTakipProjesi.Formlar
{
    public partial class FrmPersoneller : Form
    {
        DbisTakipEntities db = new DbisTakipEntities();


        public FrmPersoneller()
        {
            InitializeComponent();
        }


        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            PersonelListele();


            var departments = (from x in db.TblDepartmanlar
                               select new
                               {
                                   x.ID,
                                   x.Ad
                               }).ToList();

            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departments;
        }


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
                             Departman = x.TblDepartmanlar.Ad,
                             x.Durum
                         };
            gridControl1.DataSource = values.Where(x => x.Durum == true).ToList();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            PersonelListele();
        }


        void PersonelEkle()
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
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                PersonelEkle();   
            }
            else { }
        }


        void PersonelSil()
        {
            var id = int.Parse(TxtID.Text);
            var value = db.TblPersonel.Find(id);
            value.Durum = false;
            db.SaveChanges();
            PersonelListele();
            XtraMessageBox.Show("Personel kaydı silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                PersonelSil();
            }
            else { }
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            TxtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            TxtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            //TxtGorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
        }


        void PersonelGuncelle()
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TblPersonel.Find(id);
            value.Ad = TxtAd.Text;
            value.Soyad = TxtSoyad.Text;
            value.Mail = TxtMail.Text;
            value.Gorsel = TxtGorsel.Text;
            value.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            PersonelListele();
            XtraMessageBox.Show("Personel güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                PersonelGuncelle();
            }
            else { }
        }
    }
}


