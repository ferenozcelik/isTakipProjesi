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

namespace isTakipProjesi.Formlar
{
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
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
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad = TxtAd.Text;
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            Listele();
            XtraMessageBox.Show("Yeni departman eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TblDepartmanlar.Find(id);
            db.TblDepartmanlar.Remove(value);
            db.SaveChanges();
            Listele();
            XtraMessageBox.Show("Departman silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            TxtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtID.Text);
            var value = db.TblDepartmanlar.Find(id);
            value.Ad = TxtAd.Text; // veritabanındaki tablodaki "Ad" değerini, Formdaki textbox'daki değer ile değiştir
            db.SaveChanges();
            Listele();
            XtraMessageBox.Show("Departman güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
