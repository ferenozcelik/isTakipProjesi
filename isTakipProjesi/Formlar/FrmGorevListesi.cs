using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using isTakipProjesi.Entity;

namespace isTakipProjesi.Formlar
{
    public partial class FrmGorevListesi : Form
    {
        DbisTakipEntities db = new DbisTakipEntities();

        public FrmGorevListesi()
        {
            InitializeComponent();
        }

        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           x.ID,
                                           x.Aciklama
                                       }).ToList();

            LabelToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            LabelAktifGorev.Text = db.TblGorevler.Where(x => x.Durum == true).Count().ToString();
            LabelPasifGorev.Text = db.TblGorevler.Where(x => x.Durum == false).Count().ToString();

            chartControl1.Series["Durum"].Points.AddPoint("AktifGörevler", int.Parse(LabelAktifGorev.Text));
            chartControl1.Series["Durum"].Points.AddPoint("PasifGörevler", int.Parse(LabelPasifGorev.Text));
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////
        private void BtnYenile_Click(object sender, EventArgs e)
        {
            gridControl1.RefreshDataSource();
            gridControl1.Refresh();
            gridView1.RefreshData();
        }
    }
}
