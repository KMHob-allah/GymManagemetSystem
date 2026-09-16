using GymManagementSystem.BLL;
using GymManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Gym.Members
{
    public partial class ucMembersList : UserControl
    {
        public ucMembersList()
        {
            InitializeComponent();            
        }

        private void ucMembersList_Load(object sender, EventArgs e)
        {
            if (this.DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }
            _LoadMembersList();
            _ResetRecords();
            _FillFilters();
        }

        private void _LoadMembersList()
        {
            OperationResult<List<Member>> result =
                MembersBusiness.GetAllMembers();

            if (!result.Success)
            {
                MessageBox.Show(
                    result.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            dgvMembers.Rows.Clear();

            foreach (Member member in result.Data)
            {
                int rowIndex = dgvMembers.Rows.Add();

                DataGridViewRow row = dgvMembers.Rows[rowIndex];

                row.Cells["colMemberID"].Value = member.MemberID;
                row.Cells["colFullName"].Value = member.FullName;
                row.Cells["colPhoneNumber"].Value = member.PhoneNumber;
                row.Cells["colGender"].Value =
                    member.IsMale() ? "Male" : "Female";
                row.Cells["colAge"].Value = member.GetAge();
                row.Cells["colJoinDate"].Value =
                    member.JoinDate.ToString("dd/MM/yyyy");
                row.Cells["colArea"].Value = member.Area;
                row.Cells["colIsActive"].Value =
                    member.IsActive ? "Active" : "Inactive";

                row.Tag = member;
            }
        }

        private void _ResetRecords()
        {
            lblRecords.Text = "Records: " + dgvMembers.RowCount.ToString();
        }

        private void _Refresh()
        {
            _LoadMembersList();
            _ResetRecords();
        }

        private void _FillFilters()
        {
            cbFilter.Items.Clear();
            cbFilter.Items.Add("None");
            cbFilter.Items.Add("Member ID");
            cbFilter.Items.Add("Name");
            cbFilter.Items.Add("Area");
            cbFilter.Items.Add("Gender");
            cbFilter.Items.Add("Is Active");

            cbFilter.SelectedIndex = 0;
        }       

        private void _FillActivationComboBox()
        {
            cbActivation.Items.Clear();
            cbActivation.Items.Add("All");
            cbActivation.Items.Add("Active");
            cbActivation.Items.Add("Unactive");

            cbActivation.SelectedIndex = 0;
        }

        private void _FillGenderComboBox()
        {
            cbGender.Items.Clear();
            cbGender.Items.Add("All");
            cbGender.Items.Add("Male");
            cbGender.Items.Add("Female");

            cbGender.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem == null) return;

            string selectedFilter = cbFilter.SelectedItem.ToString();

            txtSearchBox.Visible = false;
            cbGender.Visible = false;
            cbActivation.Visible = false;

            txtSearchBox.Clear();
            if (cbGender.Items.Count > 0) cbGender.SelectedIndex = 0;
            if (cbActivation.Items.Count > 0) cbActivation.SelectedIndex = 0;

            switch (selectedFilter)
            {
                case "None":
                    _LoadMembersList();
                    break;

                case "Member ID":
                case "Name":
                case "Area":
                    txtSearchBox.Visible = true;
                    txtSearchBox.Focus();
                    break;

                case "Gender":
                    cbGender.Visible = true;
                    _FillGenderComboBox();
                    cbGender.Focus();
                    break;

                case "Is Active":
                    cbActivation.Visible = true;
                    _FillActivationComboBox();
                    cbActivation.Focus();
                    break;
            }

            _FilterData();
        }

        private void _FilterData()
        {
            if (cbFilter.SelectedItem == null) return;

            string selectedFilter = cbFilter.SelectedItem.ToString();

            if (selectedFilter == "None")
            {
                _LoadMembersList();
                return;
            }

            string filterColumn = "";
            string searchValue = "";

            switch (selectedFilter)
            {
                case "Member ID":
                    filterColumn = "colMemberID";
                    searchValue = txtSearchBox.Text.Trim();
                    break;
                case "Name":
                    filterColumn = "colFullName";
                    searchValue = txtSearchBox.Text.Trim();
                    break;
                case "Area":
                    filterColumn = "colArea";
                    searchValue = txtSearchBox.Text.Trim();
                    break;
                case "Gender":
                    filterColumn = "colGender";
                    searchValue = cbGender.SelectedItem?.ToString() ?? "";
                    break;
                case "Is Active":
                    filterColumn = "colIsActive";
                    searchValue = cbActivation.SelectedItem?.ToString() ?? "";
                    break;
            }

            int matchedRecordsCount = 0;

            foreach (DataGridViewRow row in dgvMembers.Rows)
            {
                if (row.Cells[filterColumn].Value != null)
                {
                    string cellValue = row.Cells[filterColumn].Value.ToString();
                    bool isMatch = false;

                    if (string.IsNullOrEmpty(searchValue))
                    {
                        isMatch = true;
                    }
                    else
                    {
                        if (selectedFilter == "Gender" || selectedFilter == "Is Active")
                        {
                            if (searchValue.Equals("All", StringComparison.OrdinalIgnoreCase))
                            {
                                isMatch = true;
                            }
                            else
                            {
                                isMatch = cellValue.Equals(searchValue, StringComparison.OrdinalIgnoreCase);
                            }
                        }
                        else if (selectedFilter == "Member ID")
                        {
                            // مطابقة تامة للـ ID
                            isMatch = cellValue.Equals(searchValue, StringComparison.OrdinalIgnoreCase);
                        }
                        else if (selectedFilter == "Name" || selectedFilter == "Area")
                        {
                            // البحث من أول الاسم/المنطقة لآخرها
                            isMatch = cellValue.StartsWith(searchValue, StringComparison.OrdinalIgnoreCase);
                        }
                    }

                    if (isMatch)
                    {
                        row.Visible = true;
                        matchedRecordsCount++;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }

            lblRecords.Text = "Records: " + matchedRecordsCount.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void cbActivation_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterData();
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem != null && cbFilter.SelectedItem.ToString() == "Member ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        

        private void _ChangeMemberStatus(bool activate)
        {
            if (dgvMembers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a member first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvMembers.SelectedRows[0];
            Member member = selectedRow.Tag as Member;

            if (member == null) return;

            if (member.IsActive == activate)
            {
                string statusText = (activate ? "already active" : "already inactive");
                MessageBox.Show($"This member is {statusText}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            OperationResult<bool> success;

            if (activate) success = MembersBusiness.ActivateMember(member.MemberID);
            else success = MembersBusiness.DeactivateMember(member.MemberID);

            if (success.Success)
            {
                if (activate) 
                { 
                    member.Activate();
                    selectedRow.Cells["colIsActive"].Value = "Active";
                }
                else
                { 
                    member.Deactivate(); 
                    selectedRow.Cells["colIsActive"].Value = "Inactive";
                }


                string actionName = activate ? "activated" : "deactivated";
                MessageBox.Show($"Member successfully {actionName}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _Refresh();     
            }

            else
            {
                MessageBox.Show("Failed to update member status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChangeMemberStatus(true);
        }

        private void deactivateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChangeMemberStatus(false);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMembers.CurrentRow != null)
            {
                int memberID = Convert.ToInt32(dgvMembers.CurrentRow.Cells[0].Value);

                frmMemberDetails frm = new frmMemberDetails(memberID);
                frm.ShowDialog();
            }
        }
    }
}


