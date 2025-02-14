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
    public partial class TrBooks: Form
    {
        private Point dragStartPoint;
        private bool isDragging = false;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False");
        public TrBooks()
        {
            InitializeComponent();
            rjButton1.MouseDown += rjButton1_MouseDown;
            rjButton1.MouseMove += rjButton1_MouseMove;
            rjButton1.MouseUp += rjButton1_MouseUp;
        }
        #region Tabloda Veri arama
        private void bul(string sorgu)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlDataAdapter da = new SqlDataAdapter(sorgu, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bunifuDataGridView1.DataSource = dt;
                con.Close();


            }
            catch (Exception hata) { MessageBox.Show(hata.Message); }
        }
        #endregion
        #region sql den tabloya veri çekme işlemi
        private void tlist()
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("select * from TrRoman", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
            con.Close();
        }
        #endregion
        #region form haraketleri
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
        #region Form kapatma Buttonu
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region form küçültme
        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region Form açılınca çalışan kodlar
        private void TrBooks_Load(object sender, EventArgs e)
        {
            Close.BringToFront();
            CenterToScreen();
            tlist();
            txtid.Width= 260; txtid.Height = 37;
            txtBookName.Width = 260; txtBookName.Height = 37;
            txtBookid.Width = 260; txtBookid.Height = 37;
            txtBookAuthor.Width = 260; txtBookAuthor.Height = 37;
            txtBookAuthor.Width = 260;txtBookAuthor.Height = 37;
            txtSearchBookid.Width = 260; txtSearchBookid.Height = 37;
            txtSearchBookName.Width = 260; txtSearchBookName.Height = 37;
            txtSearchBookAuthor.Width = 260; txtSearchBookAuthor.Height = 37;

        }
        #endregion
        #region Tablo Yenileme
        private void BtnReload_Click(object sender, EventArgs e)
        {
            tlist();
        }
#endregion
        #region Silme işlemleri
        int trselected = 0;
        private void BtnBookDel_Click(object sender, EventArgs e)
        {
            try 
            {
                if (bunifuDataGridView1.CurrentRow != null)
                {
                    trselected = Convert.ToInt32(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (con.State == ConnectionState.Closed)
                    { con.Open(); }
                    SqlCommand cmd = new SqlCommand("DELETE FROM TrRoman WHERE id=" + trselected + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi");
                    con.Close();
                    tlist();
                }
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
#endregion
        #region Ekleme işlemleri
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("insert into TrRoman (KitapNo,KitapAdi,KitapYazar) values (@p1,@p3,@p4)", con);
                cmd.Parameters.AddWithValue("@p1", txtBookid.Text);
                cmd.Parameters.AddWithValue("@p3", txtBookName.Text);
                cmd.Parameters.AddWithValue("@p4", txtBookAuthor.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                tlist();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
#endregion
        #region Güncelleme işlemleri
        private void BtnBookUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand komutguncelle = new SqlCommand("Update TrRoman set KitapNo=@a1,KitapAdi=@a3,KitapYazar=@a4 where id=@a5", con);
                komutguncelle.Parameters.AddWithValue("@a1", txtBookid.Text);
                komutguncelle.Parameters.AddWithValue("@a3", txtBookName.Text);
                komutguncelle.Parameters.AddWithValue("@a4", txtBookAuthor.Text);
                komutguncelle.Parameters.AddWithValue("@a5", txtid.Text);
                komutguncelle.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Güncellendi.");
                tlist();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        #region Arama
        private void txtSearchBookid_TextChanged(object sender, EventArgs e)
        {
            bul("select * from TrRoman where KitapNo like '%" + txtSearchBookid.Text + "%'");
        }

        private void txtSearchBookName_TextChanged(object sender, EventArgs e)
        {
            bul("select * from TrRoman where KitapAdi like '%" + txtSearchBookName.Text + "%'");
        }

        private void txtSearchBookAuthor_TextChanged(object sender, EventArgs e)
        {
            bul("select * from TrRoman where KitapYazar like '%" + txtSearchBookAuthor.Text + "%'");
        }
        #endregion
        #region tablodan textbox'a veri aktarma
        private void bunifuDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBookName.Text = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtBookAuthor.Text = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtBookid.Text = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        #endregion
    }
}
