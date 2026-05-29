using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace GymGUI
{
    public partial class Classes : Form
    {
        string conStr = @"Data Source=.;Initial Catalog=GymMembership;Integrated Security=True;TrustServerCertificate=True";
        public Classes()
        {
            InitializeComponent();

            SetPlaceholder(txtClassName, "Enter Class Name");
            SetPlaceholder(txtCapacity, "Enter Capacity");
            SetPlaceholder(cmbName, "Search By Class Name");
            SetPlaceholder(cmbCapacity, "Search By Capacity");

            this.Load += Classes_Load;

            btnLoadAll.Click += btnLoadAll_Click;
            btnViewByPlan.Click += btnViewByPlan_Click;
            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
            btnViewByName.Click += btnViewByName_Click;
            btnViewByCapacity.Click += btnViewByCapacity_Click;
            btnBack.Click += btnBack_Click;

            dgvClasses.CellClick += dgvClasses_CellClick;
        }
        void ApplyStyle()
        {
            this.BackColor = Color.Black;

            // GRID STYLE
            dgvClasses.BackgroundColor = Color.Black;
            dgvClasses.BorderStyle = BorderStyle.None;
            dgvClasses.GridColor = Color.FromArgb(60, 60, 60);

            dgvClasses.DefaultCellStyle.BackColor = Color.Black;
            dgvClasses.DefaultCellStyle.ForeColor = Color.Goldenrod;
            dgvClasses.DefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            dgvClasses.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvClasses.ColumnHeadersDefaultCellStyle.BackColor = Color.Goldenrod;
            dgvClasses.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvClasses.EnableHeadersVisualStyles = false;

            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // BUTTONS
            StyleButton(btnAdd);
            StyleButton(btnDelete);
            StyleButton(btnClear);
            StyleButton(btnLoadAll);
            StyleButton(btnViewByPlan);
            StyleButton(btnViewByName);
            StyleButton(btnViewByCapacity);

            // BACK BUTTON (special red)
            btnBack.BackColor = Color.DarkRed;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;

            // TEXTBOXES
            StyleTextBox(txtClassName);
            StyleTextBox(txtCapacity);
            StyleTextBox(cmbName);
            StyleTextBox(cmbCapacity);

            // COMBOBOX
            cmbPlanID.BackColor = Color.FromArgb(25, 25, 25);
            cmbPlanID.ForeColor = Color.Goldenrod;
            cmbPlanID.FlatStyle = FlatStyle.Flat;

            // LABELS
            label1.ForeColor = Color.Goldenrod;
            label2.ForeColor = Color.Goldenrod;
            label3.ForeColor = Color.Goldenrod;
            label4.ForeColor = Color.Goldenrod;
            label5.ForeColor = Color.Goldenrod;
        }
        void StyleButton(Button btn)
        {
            btn.BackColor = Color.Goldenrod;
            btn.ForeColor = Color.Black;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        void StyleTextBox(TextBox txt)
        {
            txt.BackColor = Color.FromArgb(25, 25, 25);
            txt.ForeColor = Color.Goldenrod;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.GotFocus += (s, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Goldenrod;
                }
            };

            txt.LostFocus += (s, e) =>
            {
                if (txt.Text.Trim() == "")
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        private void Classes_Load(object? sender, EventArgs e)
        {
            ApplyStyle();

            LoadPlans();
            LoadAllClasses();
        }
        private void LoadPlans()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT planID FROM SubscriptionPlan ORDER BY planID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPlanID.DataSource = dt;
                cmbPlanID.DisplayMember = "planID";
                cmbPlanID.ValueMember = "planID";
            }
        }

        private void LoadAllClasses()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT P_ID, ClassName, Capacity FROM Classes ORDER BY P_ID, ClassName";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClasses.DataSource = dt;
            }
        }

        private void btnLoadAll_Click(object? sender, EventArgs e)
        {
            LoadAllClasses();
        }

        private void btnViewByPlan_Click(object? sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = @"
                    SELECT P_ID, ClassName, Capacity
                    FROM Classes
                    WHERE P_ID = @pid
                    ORDER BY ClassName";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pid", cmbPlanID.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClasses.DataSource = dt;
            }
        }

        private void btnViewByName_Click(object? sender, EventArgs e)
        {
            if (cmbName.Text.Trim() == "" || cmbName.Text == "Search By Class Name")
            {
                MessageBox.Show("Enter class name to search.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = @"
            SELECT P_ID, ClassName, Capacity
            FROM Classes
            WHERE ClassName LIKE @name";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", "%" + cmbName.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No class found with this name.");
                    dgvClasses.DataSource = null;
                    return;
                }

                dgvClasses.DataSource = dt;
            }
        }

        private void btnViewByCapacity_Click(object? sender, EventArgs e)
        {
            if (cmbCapacity.Text.Trim() == "" || cmbCapacity.Text == "Search By Capacity")
            {
                MessageBox.Show("Enter capacity to search.");
                return;
            }

            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Capacity must be a positive number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = @"
            SELECT P_ID, ClassName, Capacity
            FROM Classes
            WHERE Capacity = @capacity";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@capacity", capacity);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No class found with this capacity.");
                    dgvClasses.DataSource = null;
                    return;
                }

                dgvClasses.DataSource = dt;
            }
        }
        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (txtClassName.Text.Trim() == "" || txtClassName.Text == "Enter Class Name" ||
                txtCapacity.Text.Trim() == "" || txtCapacity.Text == "Enter Capacity")
            {
                MessageBox.Show("Enter class name and capacity.");
                return;
            }

            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity))
            {
                MessageBox.Show("Capacity must be a number.");
                return;
            }

            if (capacity <= 0)
            {
                MessageBox.Show("Capacity must be greater than 0.");
                return;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand(
                        "INSERT INTO Classes(P_ID, ClassName, Capacity) VALUES(@pid, @name, @cap)",
                        con,
                        trans
                    );

                    cmd1.Parameters.AddWithValue("@pid", cmbPlanID.SelectedValue);
                    cmd1.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                    cmd1.Parameters.AddWithValue("@cap", capacity);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(
                        "INSERT INTO incl(planID, className) VALUES(@pid, @name)",
                        con,
                        trans
                    );

                    cmd2.Parameters.AddWithValue("@pid", cmbPlanID.SelectedValue);
                    cmd2.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                    cmd2.ExecuteNonQuery();

                    trans.Commit();

                    MessageBox.Show("Class added successfully.");
                    LoadAllClasses();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    trans.Rollback();

                    if (ex.Message.Contains("PRIMARY KEY"))
                        MessageBox.Show("This class already exists in this plan.");
                    else
                        MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (txtClassName.Text.Trim() == "" || txtClassName.Text == "Enter Class Name")
            {
                MessageBox.Show("Select or enter class name.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this class?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlTransaction trans = con.BeginTransaction();

                try
                {
                    SqlCommand cmd1 = new SqlCommand(
                        "DELETE FROM incl WHERE planID = @pid AND className = @name",
                        con,
                        trans
                    );

                    cmd1.Parameters.AddWithValue("@pid", cmbPlanID.SelectedValue);
                    cmd1.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand(
                        "DELETE FROM Classes WHERE P_ID = @pid AND ClassName = @name",
                        con,
                        trans
                    );

                    cmd2.Parameters.AddWithValue("@pid", cmbPlanID.SelectedValue);
                    cmd2.Parameters.AddWithValue("@name", txtClassName.Text.Trim());
                    cmd2.ExecuteNonQuery();

                    trans.Commit();

                    MessageBox.Show("Class deleted successfully.");
                    LoadAllClasses();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            SetPlaceholder(txtClassName, "Enter Class Name");
            SetPlaceholder(txtCapacity, "Enter Capacity");
            SetPlaceholder(cmbName, "Search By Class Name");
            SetPlaceholder(cmbCapacity, "Search By Capacity");
        }

        private void dgvClasses_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cmbPlanID.Text = dgvClasses.Rows[e.RowIndex].Cells["P_ID"].Value.ToString();

                txtClassName.ForeColor = Color.Black;
                txtCapacity.ForeColor = Color.Black;

                txtClassName.Text = dgvClasses.Rows[e.RowIndex].Cells["ClassName"].Value.ToString();
                txtCapacity.Text = dgvClasses.Rows[e.RowIndex].Cells["Capacity"].Value.ToString();
            }
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Classes_Load_1(object sender, EventArgs e)
        {

        }
    }
}