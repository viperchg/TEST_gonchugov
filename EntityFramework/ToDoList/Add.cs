using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
namespace ToDoList
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        public int id;
        private void button1_Click(object sender, EventArgs e)
        {
            switch (id)
            {
                case 1:
                    var Fr = new BusinessLogic();
                    Fr.AddNewItem(textBox1.Text);
                    MessageBox.Show("Запись успешно добавлена!");
                    this.Close();
                    break;
                case 2:
                    MessageBox.Show("Запись обновлена!");
                    this.Close();
                    break;
            }
        }
    }
}
