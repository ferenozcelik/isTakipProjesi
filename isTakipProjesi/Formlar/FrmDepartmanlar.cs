using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using isTakipProjesi.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using isTakipProjesi.Constants;

namespace isTakipProjesi.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        DbisTakipEntities db = new DbisTakipEntities();

        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            DepartmanListele();
        }

        void DepartmanListele()
        {
            var values = (from x in db.TblDepartmanlar // sadece ID ve Ad getir
                          select new
                          {
                              x.ID,
                              x.Ad
                          }).ToList();

            gridControl1.DataSource = values;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            DepartmanListele();
        }

        void DepartmanEkle()
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad = TxtAd.Text;
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            DepartmanListele();
            XtraMessageBox.Show("Yeni departman eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                DepartmanEkle();
            }
            else { }
        }


        void DepartmanSil()
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TblDepartmanlar.Find(id);
            db.TblDepartmanlar.Remove(value);
            db.SaveChanges();
            DepartmanListele();
            XtraMessageBox.Show("Departman kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                DepartmanSil();
            }
            else { }
        }


        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }


        void DepartmanGuncelle()
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TblDepartmanlar.Find(id);
            value.Ad = TxtAd.Text; // veritabanındaki tablodaki "Ad" değerini, Formdaki textbox'daki değer ile değiştir
            db.SaveChanges();
            DepartmanListele();
            XtraMessageBox.Show("Departman güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                DepartmanGuncelle();
            }
            else { }
        }



        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtAd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void TxtID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
