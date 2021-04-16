using BizLL.Entities;
using BizLL.EntityLists;
using BizLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExamSystem
{
    public partial class frmCrsGrade : Form
    {
        frmStudentCrs formCourse;
        frmLogin formLogin;

        BindingSource BS;
        Student_CrsList SC;
        
        public frmCrsGrade()
        {
            InitializeComponent();
        }

        private void profile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            formCourse.Show();
        }

        private void logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            formLogin.Show();
        }

        private void frmCrsGrade_Load(object sender, EventArgs e)
        {
            formCourse = new frmStudentCrs();
            formLogin = new frmLogin();

            SC = Student_CrsManager.getCrsGrade(Convert.ToInt32(frmLogin.StID),
                Convert.ToInt32(frmStudentCrs.CrsID));
            BS = new BindingSource(SC, "");

            gradeLabel.DataBindings.Add("Text", BS, "Crs_Grade", true);

            gradeLabel.Text = (Convert.ToDecimal(gradeLabel.Text) * 100 / 40) + "";
        }
    }
}
