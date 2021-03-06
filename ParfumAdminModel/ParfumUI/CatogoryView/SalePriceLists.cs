using ParfumUI.Parfum.Brend;
using ParfumUI.Parfum.Load;
using ParfumUI.SalePriceFolder;
using ParfumUI.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ParfumUI.CatogoryView
{
    public partial class SalePriceLists : Form
    {
        DataTable dataTable = new DataTable();

        private string _username;
        public string UserName { get { return _username; } }

        
        public SalePriceLists(string admin_name)
        {
            InitializeComponent();
            _username = admin_name;

        }

        private void SalePriceLists_Load(object sender, EventArgs e)
        {
            textUser.Text = UserName;
            LoadCatogory();
            ChangeData();
            using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
            {
                string command = "select Count(*) from ParfumLoginUsers";
                using (SqlCommand sqlCommand = new SqlCommand(command,sqlConnection))
                {
                    sqlConnection.Open();
                   textLogin.Text="Login Access : "+ sqlCommand.ExecuteScalar().ToString();
                }

                
            }
        }


        public void ChangeData()
        {

            using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
            {

                
                dataGridView1.DataSource = null;
                dataGridShearch.DataSource = null;
                dataTable.Rows.Clear();
                string command = "select * from FullDetailParfum";
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection);
                sqlDataAdapter.Fill(dataTable);
                

                dataGridView1.DataSource = dataTable;
                textcatogory.Text = "All Parfums";
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {

            dataGridShearch.DataSource =null;
            string name = textSearchName.Text.Trim();

            List<string> lis = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {

                if ( row["Name"].ToString().Trim().ToLower().Contains(name.ToLower()))
                {
                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        lis.Add(row[dataColumn].ToString());
                    }
                    //Table add
                    dataGridShearch.Rows.Add(lis[0], lis[1], lis[2].ToString(), lis[3], lis[4], lis[5], lis[6], lis[7], lis[8]);
                    lis.Clear();
                }

            }
           
        }

        

        

        // Sale Price
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalePrice salePrice = new SalePrice();
            RefresData.salePrice = salePrice;
            salePrice.ShowDialog();
        }


        private void btn_allparfums_Click(object sender, EventArgs e)
        {
            ChangeData();
        }


        public void LoadCatogory()
        {
            using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
            {
                string commandSize = "select * from Catogory";
                using (SqlCommand sqlCommand = new SqlCommand(commandSize, sqlConnection))
                {
                    // Connection Open 
                    sqlConnection.Open();

                    // Data Clear
                    combCatogory.Items.Clear();
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            combCatogory.Items.Add(sqlDataReader[1].ToString().Trim());
                        }
                    }
                    combCatogory.DropDownStyle = ComboBoxStyle.DropDownList;
                    combCatogory.SelectedIndex = 0;
                }
            }
        }

        private void combCatogory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeCatogory();
        }



        public void ChangeCatogory()
        {

            string catogory = combCatogory.SelectedItem.ToString().Trim();
            using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
            {
                dataGridView1.DataSource = null;
                dataGridShearch.DataSource = null;
                dataTable.Rows.Clear();

                string command = "EXECUTE usp_ShowCategoryParfums '" + catogory + "'";
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command, sqlConnection);
                sqlDataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                textcatogory.Text = catogory;
            }
        }


        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CategoryAdd categoryAdd = new CategoryAdd();
            categoryAdd.ShowDialog();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryRemove categoryRemove = new CategoryRemove();
            categoryRemove.ShowDialog();
            
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryCreate categoryCreate = new CategoryCreate();
            categoryCreate.ShowDialog();
        }

        private void userActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserActivity userActivity = new UserActivity();
            userActivity.ShowDialog();
        }

        private void acivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserActivityMonitor userActivityMonitor = new UserActivityMonitor();
            userActivityMonitor.ShowDialog();
        }

        private void saleAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSaleMonitor userSaleMonitor = new UserSaleMonitor();
            userSaleMonitor.ShowDialog();
        }

       
        private void addToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            BrendAdd brendAdd = new BrendAdd();
            brendAdd.ShowDialog();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BrendUpdateDelete brendUpdate = new BrendUpdateDelete();
            brendUpdate.ShowDialog();
        }

        private void createAndEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parfum_Function parfum_Function = new Parfum_Function();
            RefresData.parfum_Function = parfum_Function;
            parfum_Function.ShowDialog();
        }
    }
}
