using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Bai5
{
    public partial class Form1 : Form
    {
        private CXuLyPhieuThue xuly=new CXuLyPhieuThue();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            xuly.them(new CPhieuThue("pt01", DateTime.Today, new DateTime(2023, 11, 9), "Cong", KieuLoaiPhong.A));
            xuly.them(new CPhieuThue("pt02", DateTime.Today, new DateTime(2023, 11, 10), "Hai", KieuLoaiPhong.B));
            xuly.them(new CPhieuThue("pt03", DateTime.Today, new DateTime(2023, 11, 11), "Hau", KieuLoaiPhong.C));
            xuly.them(new CPhieuThue("pt04", DateTime.Today, new DateTime(2023, 11, 12), "Ban", KieuLoaiPhong.D));
            hienthi();
        }
        private void hienthi()
        {
            BindingSource bs=new BindingSource();
            bs.DataSource = xuly.LayDSPhieuThue();
            dgvPT.DataSource = bs;
            clear();
        }
        private void clear()
        {
            txtMaPT.Text = "";
            dtpNgayBD.Value = dtpNgayKT.Value = DateTime.Today;
            rbtA.Checked = true;
        }
    }
}
