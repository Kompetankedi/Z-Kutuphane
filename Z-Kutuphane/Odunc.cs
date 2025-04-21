using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Z_Kutuphane
{
    public partial class Odunc: Form
    {
        public Odunc()
        {
            InitializeComponent();
            rjButton1.MouseDown += rjButton1_MouseDown;
            rjButton1.MouseMove += rjButton1_MouseMove;
            rjButton1.MouseUp += rjButton1_MouseUp;
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False");
        private void VeriGoster()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Oislemler", con);
                DataTable dTable = new DataTable();
                sqlDataAdapter.Fill(dTable);
                bunifuDataGridView1.DataSource = dTable;
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Odunc_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            txtid.Width = 260; txtid.Height = 37;
            txtAlıcıAdSyd.Width = 260; txtAlıcıAdSyd.Height = 37;
            txtBookName.Width = 260; txtBookName.Height = 37;
            txtBookNo.Width = 260; txtBookNo.Height = 37;
            txtClass.Width = 260; txtClass.Height = 37;
            txtAcıklamalar.Width = 260; txtAcıklamalar.Height = 37;
            DatePickerVerildigi.Value = DateTime.Now;
            VeriGoster();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #region Form Haraketleri
        private Point dragStartPoint;
        private bool isDragging = false;
        private void rjButton1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragStartPoint = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
        }

        private void rjButton1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point mousePosition = Cursor.Position;
                Location = new Point(mousePosition.X - dragStartPoint.X, mousePosition.Y - dragStartPoint.Y);
            }
        }

        private void rjButton1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
        #endregion
        private void Kaydet()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sorgu = "insert into Oislemler(Oisim,Okitap,Okitapid,Osınıf,Oalındımı,Oalınmatarihi,Oiadetarih) values (@adsoyad,@kitabinadi,@kitapno,@sinif,@aciklamalar,@alindigitarih,@iadetarih)";
                SqlCommand komut = new SqlCommand(sorgu, con);
                //        komut.Parameters.AddWithValue("@id",txtOSQLid.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAlıcıAdSyd.Text);
                komut.Parameters.AddWithValue("@kitabinadi", txtBookName.Text);
                komut.Parameters.AddWithValue("@kitapno", txtBookNo.Text);
                komut.Parameters.AddWithValue("@sinif", txtClass.Text);
                komut.Parameters.AddWithValue("@aciklamalar", txtAcıklamalar.Text);
                komut.Parameters.AddWithValue("@alindigitarih", DatePickerAlindigi.Text);
                komut.Parameters.AddWithValue("@iadetarih", DatePickerVerildigi.Text);
                komut.ExecuteNonQuery();
                con.Close();
                VeriGoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        private void delete()
        {
            if (DialogResult.OK == MessageBox.Show("Seçili Kayıt Silinecektir!", "Kayıt Siliniyor", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string SorguSil = "delete from Oislemler where id=" + txtid.Text;
                    SqlCommand komut = new SqlCommand(SorguSil, con);
                    komut.ExecuteNonQuery();
                    con.Close();
                    VeriGoster();
                    MessageBox.Show("Kayıt Başarıyla Silinmiştir");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void rjButton3_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void Guncelle()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string sorgu = "update  Oislemler set Oisim=@adsoyad,Okitap=@kitabinadi,Okitapid=@kitapno," +
                    "Osınıf=@sinif,Oalındımı=@aciklamalar,Oalınmatarihi=@alindigitarih,Oiadetarih=@iadetarih where id=" + txtid.Text;
                SqlCommand komut = new SqlCommand(sorgu, con);
                komut.Parameters.AddWithValue("@adsoyad", txtAlıcıAdSyd.Text);
                komut.Parameters.AddWithValue("@kitabinadi", txtBookName.Text);
                komut.Parameters.AddWithValue("@kitapno", txtBookNo.Text);
                komut.Parameters.AddWithValue("@sinif", txtClass.Text);
                komut.Parameters.AddWithValue("@aciklamalar", txtAcıklamalar.Text);
                komut.Parameters.AddWithValue("@alindigitarih", DatePickerAlindigi.Text);
                komut.Parameters.AddWithValue("@iadetarih", DatePickerVerildigi.Text);
                komut.ExecuteNonQuery();
                con.Close();
                VeriGoster();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void rjButton4_Click(object sender, EventArgs e)
        {

        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            VeriGoster();
        }

        private void bunifuDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
              txtid.Text = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
              txtAlıcıAdSyd.Text = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
              txtBookName.Text = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
             // DatePickerAlindigi.Text = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
             // DatePickerVerildigi.Text = bunifuDataGridView1.CurrentRow.Cells[4].Value.ToString();
             txtBookNo.Text = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
              txtAcıklamalar.Text = bunifuDataGridView1.CurrentRow.Cells[5].Value.ToString();
              txtClass.Text = bunifuDataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void rjButton6_Click(object sender, EventArgs e)
        {
            Ogrenciler o = new Ogrenciler();
            o.ShowDialog();

            if (!string.IsNullOrEmpty(o.AdSoyad))
            {
                txtAlıcıAdSyd.Text = o.AdSoyad;
            }
        }

        private void rjButton7_Click(object sender, EventArgs e)
        {
            OTrBooks oTrBooks = new OTrBooks();
            oTrBooks.ShowDialog();

            if (!string.IsNullOrEmpty(oTrBooks.KitapAdi))
            {
                txtBookName.Text = oTrBooks.KitapAdi;
            }
            if (oTrBooks.KitapNo != 0)
            {
                txtBookNo.Text = Convert.ToString(oTrBooks.KitapNo) ;
            }
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            OEnBooks oEnBooks = new OEnBooks();
            oEnBooks.ShowDialog();
            if (!string.IsNullOrEmpty(oEnBooks.KitapAdi))
            {
                txtBookName.Text = oEnBooks.KitapAdi;
            }
            if (oEnBooks.KitapNo != 0)
            {
                txtBookNo.Text = Convert.ToString(oEnBooks.KitapNo);
            }

        }
    }
}
