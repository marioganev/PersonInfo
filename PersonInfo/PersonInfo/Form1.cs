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

namespace PersonInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=LENOVO6;Initial Catalog=PersonInfoNew;Integrated Security=True"))
            {
                string sqlQuery = "insert into dbo.PersonInfo (FirstName, LastName, ModifiedDate) values(@FirstName, @LastName, @ModifiedDate)";
 using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {

                    cmd.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@ModifiedDate", textBox4.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i != 0)
                    {
                        MessageBox.Show(i + "Data Saved");
                    }
                }
            }
        }

    }
}