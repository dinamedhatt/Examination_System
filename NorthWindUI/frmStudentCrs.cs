using BizLL.EntityLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BizLL.EntityManager;

namespace ExamSystem
{
    public partial class frmStudentCrs : Form
    {
        frmLogin formLogin;
        CourseList courses;
        BindingSource crsBS;
        frmStdExam formQ;

        public static string CrsID;

        public frmStudentCrs()
        {
            InitializeComponent();
        }

        private void logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formLogin = new frmLogin();
            this.Hide();
            formLogin.Show();
        }

        private void frmStudentCrs_Load(object sender, EventArgs e)
        {
            formQ = new frmStdExam();
            #region Binding Courses Combobox
            courses = CourseManager.studentCourses(Convert.ToInt32(frmLogin.StID));
            crsBS = new BindingSource(courses, "");
            crsCombo.DataSource = crsBS;
            crsCombo.ValueMember = "Crs_Id";
            crsCombo.DisplayMember = "Crs_Name";
            #endregion

            //this.Text = CrsID;
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            crsBS.EndEdit();
            St_AnswerManager.ExamGeneration(Convert.ToInt32(frmLogin.StID),Convert.ToInt32(crsCombo.SelectedValue.ToString()));         
            CrsID = crsCombo.SelectedValue.ToString();

            this.Hide();
            formQ.Show();
        }
    }
}
