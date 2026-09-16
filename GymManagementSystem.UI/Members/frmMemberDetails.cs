using System;
using System.Windows.Forms;

namespace Gym.Members
{
    public partial class frmMemberDetails : Form
    {
        private int _memberID;

        // الكونستركتور ليستقبل الـ MemberID عند فتح الفورم
        public frmMemberDetails(int memberID)
        {
            InitializeComponent();
            _memberID = memberID;
        }

        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            // تمرير الـ ID لليوزر كونترول ليقوم بجلب وعرض البيانات
            ucMemberDetails1.LoadMemberInfo(_memberID);
        }

        private void CenterUserControl()
        {
            // حساب المنتصف أفقياً وعمودياً بناءً على حجم الـ Panel وحجم الـ UC
            int x = (panel1.Width - ucMemberDetails1.Width) / 2;
            int y = (panel1.Height - ucMemberDetails1.Height) / 2;

            // التأكد من عدم خروج الإحداثيات عن حدود البانل لو كانت أصغر
            ucMemberDetails1.Location = new System.Drawing.Point(Math.Max(x, 0), Math.Max(y, 0));
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            CenterUserControl();
        }
    }
}