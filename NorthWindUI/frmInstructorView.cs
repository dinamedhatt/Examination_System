using BizLL.EntityLists;
using BizLL.Entities;
using BizLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ExamSystem
{
    public partial class frmInstructorView : Form
    {
        frmLogin formLogin = new frmLogin();
        ExamList exams;
        BindingSource exBS;
        CourseList courses;
        BindingSource crsBS;

        string instID;

        public frmInstructorView()
        {
            InitializeComponent();
        }

        public void gridView()
        {
            examGrid.ReadOnly = true;

            #region Binding ExamList Grid
            exams = ExamManager.examTable();
            exBS = new BindingSource(exams, "");
            examGrid.DataSource = exBS;

            examGrid.Columns["State"].Visible = false;
            examGrid.Columns["Ex_startTime"].Visible = false;
            examGrid.Columns["Exam_Id"].Visible = false;

            examGrid.Columns["Crs_Id"].HeaderText = "Course ID";
            examGrid.Columns["Ex_Duration"].HeaderText = "Duration";
            #endregion

            #region Styling Header of Grid
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.LightSkyBlue;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            examGrid.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            examGrid.EnableHeadersVisualStyles = false;
            examGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }

        private void frmInstructorView_Load(object sender, EventArgs e)
        {
            instID = frmLogin.ID;

            this.gridView();

            #region Binding Courses Combobox
            courses = CourseManager.InstructorCrs(Convert.ToInt32(instID));
            crsBS = new BindingSource(courses, "");
            crsCombo.DataSource = crsBS;
            crsCombo.DisplayMember = "Crs_Name";
            crsCombo.ValueMember = "Crs_Id";
            crsCombo.DataBindings.Add("SelectedValue", exBS, "Crs_Id",true);
            #endregion

            #region Binding Duration textBox
            txtDur.DataBindings.Add("Text", exBS, "Ex_Duration", true);
            #endregion
            //examGrid.Update();
        }

        private void logoutLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            formLogin.Show();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            ExamManager.ExamCreate(Convert.ToInt32(txtDur.Text), Convert.ToInt32(crsCombo.SelectedValue.ToString()));
            exBS.EndEdit();
            MessageBox.Show("Exam Created Successfully!");
            this.gridView();
        }

    }
}
