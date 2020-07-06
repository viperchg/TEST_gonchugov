using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BL;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        BusinessLogic Bl = new BusinessLogic();
        void alldatashow()
        {
            Bl.LoadItems();
            var alldata = Bl.AllItems();
            dataGridView1.DataSource = alldata.Local.ToBindingList();
        }
        private void EndTaskBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                if (radioButton1.Checked)
                {
                    radioButton1_CheckedChanged(sender, e);
                }
                else
                if (radioButton2.Checked)
                {
                    radioButton2_CheckedChanged(sender, e);
                }
                else
                {
                    Bl.CheckItem(id);
                    alldatashow();
                }
            }
            else
                MessageBox.Show("Выберите строку!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            alldatashow();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Fr = new Add();
            Fr.id = 1;
            Fr.ShowDialog();
            alldatashow();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                var fr = new BusinessLogic();
                fr.DeleteItem(id);
                MessageBox.Show("Запись была удалена!");
                alldatashow();
            }
            else
                MessageBox.Show("Выберите строку!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Fr = new Add();
            Fr.id = 2;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                var name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Fr.textBox1.Text = name;
                Fr.ShowDialog();
                var lb = new BusinessLogic();
                lb.EditItem(id, Fr.textBox1.Text);
                alldatashow();
            }
            else
                MessageBox.Show("Выберите строку!");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var filtered = Bl.ActiveItems();
                dataGridView1.DataSource = filtered.Local.ToBindingList();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                var filtered = Bl.EndedItems();
                dataGridView1.DataSource = filtered.Local.ToBindingList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alldatashow();
        }
    }
}
