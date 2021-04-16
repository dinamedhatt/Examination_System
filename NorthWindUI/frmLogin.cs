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
    public partial class frmLogin : Form
    {
        static int StudentAttemp = 3;
        static int InstructorAttemp = 3;
        public static string ID;
        public static string StID;
        frmInstructorView formInstructor;
        frmStudentCrs formStudent;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            formInstructor = new frmInstructorView();
            formStudent = new frmStudentCrs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userCombo.SelectedItem == null)
            {
                MessageBox.Show("Select Login User!","Missing Data",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            else if (userCombo.SelectedItem.ToString() == "Student")
            {
                if (StudentManager.StudentLogin(Convert.ToInt32(txtID.Text), txtPW.Text))
                {
                    StID = txtID.Text;
                    this.Hide();
                    formStudent.Show();
                    attemptLbl.Text = "";
                    StudentAttemp = 3;
                }
                else
                {
                    --StudentAttemp;
                    if (StudentAttemp == 0)
                    {
                        MessageBox.Show("You have ran out of attempts!", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID or Password","Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtID.Clear();
                    txtPW.Clear();
                    attemptLbl.Text = "Attempts Left: " + StudentAttemp;
                }
            }


            else if (userCombo.SelectedItem.ToString() == "Instructor")
            {
                if (InstructorManager.InstructorLogin(Convert.ToInt32(txtID.Text), txtPW.Text))
                {
                    ID = txtID.Text;
                    this.Hide();
                    formInstructor.Show();
                    attemptLbl.Text = "";
                    InstructorAttemp = 3;
                }

                else
                {
                    --InstructorAttemp;
                    if (InstructorAttemp == 0)
                    {
                        MessageBox.Show("You have ran out of attempts!","Timeout",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID or Password", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtID.Clear();
                    txtPW.Clear();
                    attemptLbl.Text = "Attempts Left: " + InstructorAttemp;
                }
            }


        }

    }
}
