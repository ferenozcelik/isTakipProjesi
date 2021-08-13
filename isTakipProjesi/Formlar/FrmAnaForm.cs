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
    public partial class FrmAnaForm : Form
    {
        DbisTakipEntities db = new DbisTakipEntities();

        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           x.Aciklama,
                                           AtananPersonel = x.TblPersonel1.Ad + " " + x.TblPersonel1.Soyad,
                                           x.Durum
                                       }).Where(x => x.Durum == true).ToList();

            gridView1.Columns["Aciklama"].Caption = "Açıklama";
            gridView1.Columns["Durum"].Visible = false;


            // bugünkü görevler
            DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
            gridControl2.DataSource = (from x in db.TblGorevDetaylar
                                       select new
                                       {
                                           Görev = x.TblGorevler.Aciklama,
                                           Açıklama = x.Aciklama,
                                           x.Tarih
                                       }).Where(x => x.Tarih == today).ToList();


            // aktif çağrılar
            gridControl3.DataSource = (from x in db.TblCagrilar
                                       select new
                                       {
                                           x.TblFirmalar.Ad,
                                           x.Konu,
                                           x.Tarih,
                                           x.Durum
                                       }).Where(x => x.Durum == true).ToList();
            gridView3.Columns["Durum"].Visible = false;



            // fihrist
            gridControl4.DataSource = (from x in db.TblFirmalar
                                       select new
                                       {
                                           x.Ad,
                                           x.Telefon,
                                           x.Mail
                                       }).ToList();


            // çağrı grafiği
            int aktif_cagrilar = db.TblCagrilar.Where(x => x.Durum == true).Count();
            int pasif_cagrilar = db.TblCagrilar.Where(x => x.Durum == false).Count();

            chartControl1.Series["Series 1"].Points.AddPoint("Aktif Çağrılar", aktif_cagrilar);
            chartControl1.Series["Series 1"].Points.AddPoint("Pasif Çağrılar", pasif_cagrilar);
        }
    }
}
