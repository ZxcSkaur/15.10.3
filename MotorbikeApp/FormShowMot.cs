using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MotorbikeApp.ModelEF;

namespace MotorbikeApp
{
    public partial class FormShowMot : Form
    {

        public static MotorbikeDB MotorbikeDB = new MotorbikeDB();
        public FormShowMot()
        {
            InitializeComponent();
        }
        private string Pic_Name;
        private int Flplus1()
        {
            int max = 0;
            foreach (Table_Motorbike TB in vsMotorbike)
                if (max < TB.ID) max = TB.ID;
            return ++max;
        }
        private List<Table_Motorbike> vsMotorbike = FormShowMot.MotorbikeDB.Table_Motorbike.ToList();
        private void FormShowMot_Load(object sender, EventArgs e)
        {

            tableMotorbikeBindingSource.DataSource = MotorbikeDB.Table_Motorbike.ToList();

            if  (MotorbikeDB.Table_Motorbike.ToList().Count == 0) return;
            int ID = (int)dgvMotorbikes.CurrentRow.Cells[0].Value;
            pictureBox1.Image = Image.FromFile($@"Pictures\{MotorbikeDB.Table_Motorbike.Find(ID).ImageName}");
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormShowMot form = new FormShowMot();
            this.Visible = false;
            form.Show();


        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MotorbikeDB.Table_Motorbike.ToList().Count == 0)
            {
                MessageBox.Show("Данные отсутствуют!");
                return;

            }
        }

        private void dgvMotorbikes_Click(object sender, EventArgs e)
        {

        }

        private void dgvMotorbikes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

               if (MotorbikeDB.Table_Motorbike.ToList().Count == 0) return;
               int ID = (int)dgvMotorbikes.CurrentRow.Cells[0].Value;
               pictureBox1.Image = Image.FromFile($@"Pictures\{MotorbikeDB.Table_Motorbike.Find(ID).ImageName}");
               Table_Motorbike CurrentMoto = MotorbikeDB.Table_Motorbike.Find((int)dgvMotorbikes.CurrentRow.Cells[0].Value);
             DialogResult result = MessageBox.Show(
                $@"Вы действительно хотите удалить объект с ID - {CurrentMoto.ID}",
                "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    MotorbikeDB.Table_Motorbike.Remove(CurrentMoto);
                    MotorbikeDB.SaveChanges();
                    File.Delete($@"Pictures\{CurrentMoto.ImageName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tableMotorbikeBindingSource.DataSource = MotorbikeDB.Table_Motorbike.ToList();
                    pictureBox1.Image = null;
                }

            }
        }

    }
}

