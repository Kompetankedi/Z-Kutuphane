using CustomControls.RJControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Z_Kutuphane
{
    public partial class Giris: Form
    {
        private Point dragStartPoint;
        private bool isDragging = false;
        public Giris()
        {
            InitializeComponent();
            rjButton1.MouseDown += rjButton1_MouseDown;
            rjButton1.MouseMove += rjButton1_MouseMove;
            rjButton1.MouseUp += rjButton1_MouseUp;
        }
        #region uygulama kapatma
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        private void Giris_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
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

        private void TrBooks_Click(object sender, EventArgs e)
        {
            TrBooks TrBooks = new TrBooks();
            TrBooks.ShowDialog();
        }

        private void EnBooks_Click(object sender, EventArgs e)
        {
            EnBooks En = new EnBooks();
            En.ShowDialog();
        }

        private void Odunc_Click(object sender, EventArgs e)
        {
            Odunc o = new Odunc();
            o.ShowDialog();
        }
    }
}
