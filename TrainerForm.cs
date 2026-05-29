using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GymGUI
{
    public partial class TrainerForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=GymMembership;Integrated Security=True;TrustServerCertificate=True");

        public TrainerForm()
        {
            InitializeComponent();
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            LoadData();
        }

        void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM trainer", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Using column names based on SQLQuery1.sql schema
                txtFName.Text = row.Cells["TFname"].Value.ToString();
                txtLName.Text = row.Cells["TLname"].Value.ToString();
                txtPhone.Text = row.Cells["PN"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrWhiteSpace(txtLName.Text)) return;

            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                SqlCommand cmd = new SqlCommand("INSERT INTO trainer (TFname, TLname, PN) VALUES (@f, @l, @p)", con);
                cmd.Parameters.AddWithValue("@f", txtFName.Text);
                cmd.Parameters.AddWithValue("@l", txtLName.Text);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Trainer added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            int trainerId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["trainerID"].Value);

            // Prevent deleting the placeholder record
            if (trainerId == 0)
            {
                MessageBox.Show("Cannot delete the system 'No Trainer' record.", "Protected Record");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this trainer? Any members assigned to them will be set to 'No Trainer'.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            try
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Open();

                // STEP 1: Unassign from all members
                SqlCommand cmdUpdate = new SqlCommand("UPDATE membr SET T_ID = 0 WHERE T_ID = @id", con);
                cmdUpdate.Parameters.AddWithValue("@id", trainerId);
                cmdUpdate.ExecuteNonQuery();

                // STEP 2: Remove the trainer from the 'Gives' classes schedule
                SqlCommand cmdGives = new SqlCommand("DELETE FROM Gives WHERE T_ID = @id", con);
                cmdGives.Parameters.AddWithValue("@id", trainerId);
                cmdGives.ExecuteNonQuery();

                // STEP 3: Now delete the trainer
                SqlCommand cmdDelete = new SqlCommand("DELETE FROM trainer WHERE trainerID = @id", con);
                cmdDelete.Parameters.AddWithValue("@id", trainerId);
                cmdDelete.ExecuteNonQuery();

                MessageBox.Show("Trainer deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting trainer: " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData(); // Assuming you have this method to refresh the grid
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- NEW/UPDATED FUNCTIONS START HERE ---

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Clears the search box and reloads the full list
            if (txtSearch != null) txtSearch.Clear();
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a trainer from the list to update.", "Selection Required");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["trainerID"].Value);

            // Prevent updating the placeholder record[cite: 1]
            if (id == 0)
            {
                MessageBox.Show("Cannot modify the system 'No Trainer' record.", "Protected Record");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFName.Text) || string.IsNullOrWhiteSpace(txtLName.Text))
            {
                MessageBox.Show("First Name and Last Name are required.", "Missing Information");
                return;
            }

            try
            {
                if (con.State == ConnectionState.Open) con.Close();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE trainer SET TFname=@f, TLname=@l, PN=@p WHERE trainerID=@id", con);
                cmd.Parameters.AddWithValue("@f", txtFName.Text);
                cmd.Parameters.AddWithValue("@l", txtLName.Text);
                cmd.Parameters.AddWithValue("@p", txtPhone.Text);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Trainer updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating trainer: " + ex.Message);
            }
            finally
            {
                con.Close();
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadData(); // If search is empty, just load everything
                return;
            }

            try
            {
                // Searches by First Name, Last Name, or Phone Number based on your schema[cite: 1]
                string query = @"SELECT * FROM trainer 
                                 WHERE TFname LIKE @search 
                                 OR TLname LIKE @search 
                                 OR CAST(PN AS VARCHAR) LIKE @search";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }
        // --- NEW/UPDATED FUNCTIONS END HERE ---

        void ApplyStyle()
        {
            this.Text = "Trainer Management";
            this.BackColor = Color.Black;

            dataGridView1.BackgroundColor = Color.Black;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.GridColor = Color.FromArgb(60, 60, 60);

            dataGridView1.DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Goldenrod;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            StyleButton(btnAdd);
            StyleButton(btnLoad);
            StyleButton(btnUpdate);
            StyleButton(btnBack);
            StyleButton(btnSearch);

            btnDelete.BackColor = Color.DarkRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            StyleTextBox(txtFName);
            StyleTextBox(txtLName);
            StyleTextBox(txtPhone);
            StyleTextBox(txtSearch);
        }

        void StyleButton(Button btn)
        {
            btn.BackColor = Color.Goldenrod;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Width = 100;
            btn.Height = 35;
        }

        void StyleTextBox(TextBox txt)
        {
            txt.BackColor = Color.FromArgb(25, 25, 25);
            txt.ForeColor = Color.Goldenrod;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }
    }
}