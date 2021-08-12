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
    public partial class FrmPersonelİstatistik : Form
    {
        DbisTakipEntities db = new DbisTakipEntities();

        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }

        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;

            LabelToplamPersonel.Text = db.TblPersonel.Count().ToString();
            LabelToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            LabelAktifis.Text = db.TblGorevler.Count(x => x.Durum == true).ToString();
            LabelPasifis.Text = db.TblGorevler.Count(x => x.Durum == false).ToString();
            LabelToplamFirma.Text = db.TblFirmalar.Count().ToString();
            LabelSehirSayisi.Text = db.TblFirmalar.Select(x => x.il).Distinct().Count().ToString();
            LabelMevcutGunlukGorevler.Text = db.TblGorevler.Count(x => x.Tarih == today).ToString();

            LabelSonGorev.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Aciklama).FirstOrDefault();
            // OrderByDescending(x => x.ID) ile ID'ye göre azalan sıralama yapıyor yani listeyi tersine çeviriyor
            // Select(x => x.Aciklama) ile görevin açıklamasını seçiyor
            // FirstOrDefault() ile ilk gördüğü değeri alıyor

            LabelSonGorevTarihi.Text = db.TblGorevler.OrderByDescending(x => x.ID).Select(x => x.Tarih).FirstOrDefault().ToString();

            LabelSektorSayisi.Text = db.TblFirmalar.Select(x => x.Sektor).Distinct().Count().ToString();

            var enDegerliPersonelID = db.TblGorevler.GroupBy(x => x.GorevAlan).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();
            LabelEnDegerliPersonel.Text = db.TblPersonel.Where(x => x.ID == enDegerliPersonelID).Select(x => x.Ad + " " + x.Soyad).FirstOrDefault().ToString();

            LabelEnDegerliDepartman.Text = db.TblDepartmanlar
                .Where(x => x.ID == db.TblPersonel.Where(p => p.ID == enDegerliPersonelID).Select(p => p.Departman).FirstOrDefault())
                .Select(x => x.Ad).FirstOrDefault().ToString();
        }
    }
}
