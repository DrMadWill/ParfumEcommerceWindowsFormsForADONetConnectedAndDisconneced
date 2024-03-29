﻿using ParfumUI.Parfum.Brend;
using ParfumUI.Parfum.Load;
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

namespace ParfumUI
{
    public partial class ParfumAdd : Form
    {
        
        public ParfumAdd()
        {
            InitializeComponent();
            
        }
        private void ParfumAdd_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
            {
                // Load Parfum Items
                LoadParfumItems.LoadBrend(sqlConnection, true, combBrend);
                LoadParfumItems.LoadDensity(sqlConnection, false, combDensity);
                LoadParfumItems.LoadGender(sqlConnection, false, combGender);

                

            }
            combBrend.SelectedIndex = 0;
            combDensity.SelectedIndex = 0;
            combGender.SelectedIndex = 0;
            textImage.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Save Click
            if (LoadParfumItems.IsAreYouSure("Created"))
            {
                string name = textName.Text.Trim();
                string image =  @textImage.Text.Trim();
                string decrip = textDescription.Text.Trim();
                string brend = combBrend.SelectedItem.ToString().Trim();
                string gender = combGender.SelectedItem.ToString().Trim();
                string density = combDensity.SelectedItem.ToString().Trim();


                if (!RefresData.parfum_Function.IsAdd(name, brend))
                {
                    LoadParfumItems.MessengeWarning("This is Already Added");
                    return;
                }

                

                using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
                {
                    Parfum.Parfum.CreateParfum(name,image,decrip, brend, gender, density, sqlConnection);
                }

                // Change DataGridView
                RefresData.parfum_Function.ChangeParfum();

                // Clear Boxs
                textName.Text = "";
                textDescription.Text ="";
                combBrend.SelectedIndex =0;
                combGender.SelectedIndex = 0;
                combDensity.SelectedIndex = 0;
            }
        }

        

        

        public void ChangeBrend()
        {
            using (SqlConnection sqlConnection = new SqlConnection(LoadParfumItems.connectionString))
            {
                // Refres Brend 
                LoadParfumItems.LoadBrend(sqlConnection, true, combBrend);
                combBrend.SelectedIndex = 0;
            }
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            DialogResult dialog = openFileDialog1.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                string image = openFileDialog1.FileName;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Load(image);
                textImage.Text = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
