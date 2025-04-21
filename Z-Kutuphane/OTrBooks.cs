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
    public partial class OTrBooks : Form
    {
        #region Tabloda Veri arama
        private void OTrbul(string sorgu)
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
        public OTrBooks()
        {
            InitializeComponent(); 
            rjButton1.MouseDown += rjButton1_MouseDown;
            rjButton1.MouseMove += rjButton1_MouseMove;
            rjButton1.MouseUp += rjButton1_MouseUp;
        }
        SqlConnection con = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=DbKutuphane;Integrated Security=True;Encrypt=False");
        private void OTrlist()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from TrRoman", con);
                DataTable dTable = new DataTable();
                sqlDataAdapter.Fill(dTable);
                bunifuDataGridView1.DataSource = dTable;
                if (con.State == ConnectionState.Open)
                { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OTrBooks_Load(object sender, EventArgs e)
        {
            OTrlist();
            txtSearchBookNo.Width = 260; txtSearchBookNo.Height = 37;
            txtSearchBookName.Width = 260; txtSearchBookName.Height = 37;
            txtBookAuthor.Width = 260; txtBookAuthor.Height = 37;
        }
        #region form haraketleri
        private Point dragStartPoint;
        private bool isDragging = false;
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

        private void rjButton1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            dragStartPoint = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
        }
        #endregion

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchBookNo_TextChanged(object sender, EventArgs e)
        {
            OTrbul("select * from TrRoman where KitapNo like '%" + txtSearchBookNo.Text + "%'");
        }
        public string KitapAdi;
        public int KitapNo =0;
        public string KitapYazar;
        private void bunifuDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            KitapAdi = bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString();
            KitapYazar = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
            KitapNo = Convert.ToInt32(bunifuDataGridView1.CurrentRow.Cells[3].Value);
        }

        private void txtSearchBookName_TextChanged(object sender, EventArgs e)
        {
            OTrbul("select * from TrRoman where KitapAdi like '%" + txtSearchBookName.Text + "%'");
        }

        private void txtBookAuthor_TextChanged(object sender, EventArgs e)
        {
            OTrbul("select * from TrRoman where KitapYazar like '%" + txtBookAuthor.Text + "%'");
        }
    }
}
