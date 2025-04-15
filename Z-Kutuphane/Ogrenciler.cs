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
    public partial class Ogrenciler: Form
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False");
        public Ogrenciler()
        {
            InitializeComponent();
            rjButton1.MouseDown += rjButton1_MouseDown;
            rjButton1.MouseMove += rjButton1_MouseMove;
            rjButton1.MouseUp += rjButton1_MouseUp;
        }
        #region form haraketleri
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
        #region Tabloda Veri arama
        private void Obul(string sorgu)
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
        private void list()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                { con.Open(); }
                SqlDataAdapter da = new SqlDataAdapter("select * from Ogrenciler", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bunifuDataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public int okulNo;
        public string AdSoyad;
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ogrenciler_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            list();
            txtSearchNo.Width = 260; txtSearchNo.Height = 37;
            txtSearchNameSurname.Width = 260; txtSearchNameSurname.Height = 37;
        }

        private void txtSearchNo_TextChanged(object sender, EventArgs e)
        {
            Obul("select * from Ogrenciler where Okul_no like '%" + txtSearchNo.Text + "%'");
        }

        private void txtSearchNameSurname_TextChanged(object sender, EventArgs e)
        {
            Obul("select * from Ogrenciler where Adi_soyad like '%" + txtSearchNameSurname.Text + "%'");
        }

        private void bunifuDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
             okulNo= Convert.ToInt32(bunifuDataGridView1.CurrentRow.Cells[1].Value);
            AdSoyad = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
