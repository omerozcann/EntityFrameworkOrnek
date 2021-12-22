using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EntityOrnek
{
    public partial class entityFrm : Form
    {
        musteri model = new musteri();
        KayitEntities db = new KayitEntities();
        BindingSource bs = new BindingSource();
        public entityFrm()
        {
            InitializeComponent();
        }

        private void kaydetbtn_Click(object sender, EventArgs e)
        {
            model.adi = aditxt.Text;
            model.soyadi = soyaditxt.Text;
            model.sehir = sehirtxt.Text;
            model.adres = adresrtb.Text;
            db.musteri.Add(model);
            db.SaveChanges();
            bs.DataSource = db.musteri.ToList();
            tablegrd.DataSource = bs;
            
   
        }

        private void temizlebtn_Click(object sender, EventArgs e)
        {
            aditxt.Clear();
            soyaditxt.Clear();
            sehirtxt.Clear();
            adresrtb.Clear();
        }

        private void silbtn_Click(object sender, EventArgs e)
        {
            model = db.musteri.Find(tablegrd.Rows[tablegrd.SelectedRows[0].Index].Cells[0].Value);
            db.musteri.Remove(model);
            db.SaveChanges();
            bs.DataSource = db.musteri.ToList();
            tablegrd.DataSource = bs;
        }

        private void entityFrm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kayitDataSet.musteri' table. You can move, or remove it, as needed.
            this.musteriTableAdapter.Fill(this.kayitDataSet.musteri);

        }

        private void guncellebtn_Click(object sender, EventArgs e)
        {
            model.adi = aditxt.Text;
            model.soyadi = soyaditxt.Text;
            model.sehir = sehirtxt.Text;
            model.adres = adresrtb.Text;
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            bs.DataSource = db.musteri.ToList();
            tablegrd.DataSource = bs;
        }

        private void tablegrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tablegrd_Click(object sender, EventArgs e)
        {
            model = db.musteri.Find(tablegrd.Rows[tablegrd.SelectedRows[0].Index].Cells[0].Value);
            aditxt.Text = model.adi;
            soyaditxt.Text = model.soyadi;
            sehirtxt.Text = model.sehir;
            adresrtb.Text = model.adres;

        }
    }
}
