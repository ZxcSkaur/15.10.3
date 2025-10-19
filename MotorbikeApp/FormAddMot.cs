using MotorbikeApp.ModelEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotorbikeApp
{
    public partial class FormAddMot : Form
    {
        private string Pic_name;
        private List<Table_Motorbike> vsmotorbikes = FormShowMot.MotorbikeDB.Table_Motorbike.ToList();
        public FormAddMot()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormShowMot formShowMot = new FormShowMot();
            formShowMot.Visible = true;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Pic_name))
            {
                MessageBox.Show("Невозможно найти файл!");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png) |*.bmp;*.jpg;*.png";
            DialogResult result = openFileDialog.ShowDialog();
            if (DialogResult.OK == result)
            {
                    Pic_name = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(Pic_name);
            }
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        // Добавляем проверку ввода цифр для числовых полей
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void txtHorsepower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void FormAddMot_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> dictBrand = new List<string>();
            foreach (Table_Motorbike TB in vsmotorbikes)
                dictBrand.Add(TB.Brand);
            dictBrand = dictBrand.Distinct().ToList();
            comboBoxBrand.DataSource = dictBrand;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            FormShowMot form = new FormShowMot();
            form.Visible = true;
            this.Close();
        }

        private void textBoxIntData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
                e.Handled = true;
        }

        private void labelModel_Click(object sender, EventArgs e)
        {

        }

        private void labelBrand_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxBrand.Text) || String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Заполните Все поля Модель и Марка!");
                return;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox4.Text);
                Convert.ToInt32(textBox5.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("В полях Л/С и Пробег, могут быть только целочисленные данные");
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToSingle(textBox3.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("В поле Цена, могут быть только числа с плавающей точкой");
                return;
            }
        }
    }
}
