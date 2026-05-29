using System;
using System.Data;
using System.Drawing;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace GymGUI
{
    public partial class PlanForm : Form
    {
        SqlConnection con = new SqlConnection(
    @"Data Source=.;Initial Catalog=GymMembership;Integrated Security=True;TrustServerCertificate=True"
);

        public PlanForm()
        {
            InitializeComponent();
        }

        private void PlanForm_Load(object sender, EventArgs e)
        {
            ApplyStyle();
            LoadData();
        }

        void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SubscriptionPlan", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check empty
            if (string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtInvitations.Text) ||
                string.IsNullOrWhiteSpace(txtDuration.Text) ||
                string.IsNullOrWhiteSpace(txtInbody.Text) ||
                string.IsNullOrWhiteSpace(txtFreeze.Text))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate numbers
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Price must be a number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtInvitations.Text, out int inv) ||
                !int.TryParse(txtDuration.Text, out int duration) ||
                !int.TryParse(txtInbody.Text, out int inbody) ||
                !int.TryParse(txtFreeze.Text, out int freeze))
            {
                MessageBox.Show("Invitations, Duration, Inbody, Freeze must be integers", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO SubscriptionPlan(price, invitations, Duration, inbodycount, freezeduration)
              VALUES(@price, @inv, @dur, @inbody, @freeze)", con);

                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@inv", inv);
                cmd.Parameters.AddWithValue("@dur", duration);
                cmd.Parameters.AddWithValue("@inbody", inbody);
                cmd.Parameters.AddWithValue("@freeze", freeze);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Plan added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                txtPrice.Clear();
                txtInvitations.Clear();
                txtDuration.Clear();
                txtInbody.Clear();
                txtFreeze.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        // 2. FIXED DELETE BUTTON WITH ERROR HANDLING
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a plan from the list first.");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["planID"].Value);

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this plan?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No) return;

            try
            {
                // Safety check: close connection if it was left open by a previous crash
                if (con.State == ConnectionState.Open) con.Close();

                SqlCommand cmd = new SqlCommand("DELETE FROM SubscriptionPlan WHERE planID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Plan deleted successfully", "Success");
            }
            catch (SqlException ex)
            {
                // Handle Foreign Key errors (Error 547)
                if (ex.Number == 547)
                {
                    MessageBox.Show("ERROR: Cannot delete this plan because there are members, classes, or branch access records linked to it. Delete them first.", "Dependency Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Database error: " + ex.Message);
                }
            }
            finally
            {
                // THIS FIXES YOUR ERROR: Always close the connection even if it fails
                con.Close();
                LoadData();
            }
        }

        void ApplyStyle()
        {
            this.Text = "Subscription Plan Management";
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
            StyleButton(btnBack);

            btnDelete.BackColor = Color.DarkRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            StyleTextBox(txtPrice);
            StyleTextBox(txtInvitations);
            StyleTextBox(txtDuration);
            StyleTextBox(txtInbody);
            StyleTextBox(txtFreeze);
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
            txt.Width = 180;
        }

        // 1. USE CELLCLICK INSTEAD OF CELLCONTENTCLICK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a row (not the header) was clicked
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Fill textboxes with data from the row
                // Using string formatting to clean up the 'money' decimal places
                txtPrice.Text = string.Format("{0:0.##}", row.Cells["price"].Value);
                txtInvitations.Text = row.Cells["invitations"].Value.ToString();
                txtDuration.Text = row.Cells["Duration"].Value.ToString();
                txtInbody.Text = row.Cells["inbodycount"].Value.ToString();
                txtFreeze.Text = row.Cells["freezeduration"].Value.ToString();
            }
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}