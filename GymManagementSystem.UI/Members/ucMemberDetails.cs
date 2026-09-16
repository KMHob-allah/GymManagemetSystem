using GymManagementSystem.BLL;
using GymManagementSystem.DTO;
using GymManagementSystem.UI.Properties;
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

namespace Gym.Members
{
    public partial class ucMemberDetails : UserControl
    {
        private OperationResult<Member> _Member;
        private int? _MemberID = null;

        public int? MemberID { get; private set; } = null;
         public OperationResult<Member> SelectedMemberInfo => _Member;

        public ucMemberDetails()
        {
            InitializeComponent();
        }

        private void ucMemberDetails_Load(object sender, EventArgs e)
        {
        }

        public void LoadMemberInfo(int MemberID)
        {
            _MemberID = MemberID;
             _Member = MembersBusiness.GetMemberByID(_MemberID.Value);

            if (!_Member.Success)
            {
                ResetMemberInfo();
                MessageBox.Show(_Member.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillMemberInfo();
        }                    

        private void _FillMemberInfo()
        {

            this.MemberID = _Member.Data.MemberID;
            lblMemberID.Text = _Member.Data.MemberID.ToString();
            lblFullName.Text = _Member.Data.FullName;
            lblPhoneNumber.Text = _Member.Data.PhoneNumber;
            lblEmergencyPhone.Text = _Member.Data.EmergencyPhone;

            lblGender.Text = _Member.Data.IsMale() ? "Male" : "Female";

            lblAge.Text = _Member.Data.GetAge().ToString(); 
            lblBirthDate.Text = _Member.Data.BirthDate.ToShortDateString();

            lblJoinDate.Text = _Member.Data.JoinDate.ToShortDateString();
            lblArea.Text = _Member.Data.Area; 

            lblIsActive.Text = _Member.Data.IsActive ? "Yes" : "No";
            lblIsActive.ForeColor = _Member.Data.IsActive ? Color.LightGreen : Color.Maroon;
            
            _SetDefaultImage();
        }       

        private void _SetDefaultImage()
        {
            pbMemberImage.Image = (_Member.Data.IsMale() ? Resources.DefaultMale : Resources.DefaultWoman);           
        }

        public void ResetMemberInfo()
        {
            this.MemberID = null;
            lblMemberID.Text = "[???]";
            lblFullName.Text = "[???]";
            lblPhoneNumber.Text = "[???]";
            lblEmergencyPhone.Text = "[???]";
            lblGender.Text = "[???]";
            lblAge.Text = "[???]";
            lblBirthDate.Text = "[???]";
            lblJoinDate.Text = "[???]";
            lblArea.Text = "[???]";
            lblIsActive.Text = "[???]";
            lblIsActive.ForeColor = Color.White;
            
            pbMemberImage.Image = null;
        }
    }
}