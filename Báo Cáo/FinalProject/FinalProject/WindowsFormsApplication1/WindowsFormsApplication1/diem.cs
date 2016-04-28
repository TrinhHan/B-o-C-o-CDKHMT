using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class diem : Form
    {
        public diem()
        {
            InitializeComponent();
        }

        private void dIEMBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dIEMBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.finalProjectDataSet);

        }

        private void diem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalProjectDataSet.DIEM' table. You can move, or remove it, as needed.
            this.dIEMTableAdapter.Fill(this.finalProjectDataSet.DIEM);

        }

        private void mAMONHOCLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            mAHOCSINHTextBox.Focus();
            this.dIEMBindingSource.AddNew();
            this.tableAdapterManager.UpdateAll(this.finalProjectDataSet);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            mAHOCSINHTextBox.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.dIEMBindingSource.RemoveCurrent();
                this.tableAdapterManager.UpdateAll(this.finalProjectDataSet);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            FinalProjectDataSetTableAdapters.QueriesTableAdapter qr = new FinalProjectDataSetTableAdapters.QueriesTableAdapter();
            if (mAHOCSINHTextBox.TextLength == 0)
                MessageBox.Show("Mã học sinh không được để trống");
           else
                if (mAMONHOCTextBox.Text.Length == 0)
                MessageBox.Show("Mã môn học không được để trống");
            else 
                    if (hOCKYTextBox.Text.Length == 0)
                MessageBox.Show("Học kỳ không được để trống");
            else 
                        if (nAMHOCTextBox.Text.Length == 0)
                MessageBox.Show("Năm học không được để trống");
             else
                         if (qr.check1hocsinh(this.mAHOCSINHTextBox.Text) == 0)
                                MessageBox.Show("Mã học sinh không tồn tại, bạn có thể thêm vào trong mục quản lý lớp học");
              else
                          if (qr.checkmonhoc(this.mAMONHOCTextBox.Text) == 0)
                                 MessageBox.Show("Mã môn học không tồn tại, bạn có thể thêm vào trong mục quản lý lớp học");
              else
                          if (qr.checkhockynamhoc(this.hOCKYTextBox.Text, this.nAMHOCTextBox.Text) == 0)
                                  MessageBox.Show("Học kỳ và năm học không tồn tại, bạn có thể thêm vào trong mục quản lý lớp học");
            else
                              try
                                    {
                                       this.Validate();
                                       this.dIEMBindingSource.EndEdit();
                                       this.tableAdapterManager.UpdateAll(this.finalProjectDataSet);
                                 }
                              catch
                              {
                                  
                              }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.dIEMBindingSource.CancelEdit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
