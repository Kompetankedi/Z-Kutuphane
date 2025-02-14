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
    public partial class EnBooks: Form
    {
        private Point dragStartPoint;
        private bool isDragging = false;
        SqlConnection con = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False");
        public EnBooks()
        {
            InitializeComponent();
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
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region sql den tabloya veri çekme
        private void list()
        {
            if (con.State == ConnectionState.Closed)
            { con.Open(); }
            SqlDataAdapter da = new SqlDataAdapter("select * from YabanciRoman", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bunifuDataGridView1.DataSource = dt;
            con.Close();
        }
        #endregion

        #region form küçültme
        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        #region Form yüklenince çalışacak kodlar
        private void EnBooks_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            list();
            txtid.Width = 260; txtid.Height = 37;
            txtBookName.Width = 260; txtBookName.Height = 37;
            txtBookid.Width = 260; txtBookid.Height = 37;
            txtBookAuthor.Width = 260; txtBookAuthor.Height = 37;
            txtBookAuthor.Width = 260; txtBookAuthor.Height = 37;
            txtSearchBookid.Width = 260; txtSearchBookid.Height = 37;
            txtSearchBookName.Width = 260; txtSearchBookName.Height = 37;
            txtSearchBookAuthor.Width = 260; txtSearchBookAuthor.Height = 37;
        }
        #endregion
        #region Ekleme işlemleri
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand cmd = new SqlCommand("insert into YabanciRoman (KitapNo,KitapAdi,KitapYazar) values (@p1,@p3,@p4)", con);
                cmd.Parameters.AddWithValue("@p1", txtBookid.Text);
                cmd.Parameters.AddWithValue("@p3", txtBookName.Text);
                cmd.Parameters.AddWithValue("@p4", txtBookAuthor.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                list();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        #region TextBoxlara Veri çekme
        private void bunifuDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBookName.Text = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtBookAuthor.Text = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtBookid.Text = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        #endregion
        #region Güncelleme İşlemleri
        private void BtnBookUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlCommand komutguncelle = new SqlCommand("Update YabanciRoman set KitapNo=@a1,KitapAdi=@a3,KitapYazar=@a4 where id=@a5", con);
                komutguncelle.Parameters.AddWithValue("@a1", txtBookid.Text);
                komutguncelle.Parameters.AddWithValue("@a3", txtBookName.Text);
                komutguncelle.Parameters.AddWithValue("@a4", txtBookAuthor.Text);
                komutguncelle.Parameters.AddWithValue("@a5", txtid.Text);
                komutguncelle.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Güncellendi.");
                list();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        #region Silme işlemleri
        int Ybselected = 0;
        private void BtnBookDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDataGridView1.CurrentRow != null)
                {
                    Ybselected = Convert.ToInt32(bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString());
                    if (con.State == ConnectionState.Closed)
                    { con.Open(); }
                    SqlCommand cmd = new SqlCommand("DELETE FROM YabanciRoman WHERE id=" + Ybselected + "", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Silindi");
                    con.Close();
                    list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        #region Tabloyu Yenileme
        private void BtnReload_Click(object sender, EventArgs e)
        {
            list();
        }
        #endregion
        #region Arama Textbox Kodları
        private void txtSearchBookid_TextChanged(object sender, EventArgs e)
        {
            bul("select * from YabanciRoman where KitapNo like '%" + txtSearchBookid.Text + "%'");
        }

        private void txtSearchBookName_TextChanged(object sender, EventArgs e)
        {
            bul("select * from YabanciRoman where KitapAdi like '%" + txtSearchBookName.Text + "%'");
        }

        private void txtSearchBookAuthor_TextChanged(object sender, EventArgs e)
        {
            bul("select * from YabanciRoman where KitapYazar like '%" + txtSearchBookAuthor.Text + "%'");
        }
        #endregion
    }
}
