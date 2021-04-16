using BizLL.EntityLists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BizLL.EntityManager;
using System.Linq;

namespace ExamSystem
{
    public partial class frmStdExam : Form
    {
        QuestionList questions;
        BindingSource qBS;
        frmCrsGrade formGrade;
        ChoiceList choices;
        BindingSource chBS;
        ComboBox[] myCombos;
        Timer T1 = new Timer();

        ExamList exam;
        BindingSource examBS;
        int duration = 0;

        public frmStdExam()
        {
            InitializeComponent();
        }

        private void frmStdExam_Load(object sender, EventArgs e)
        {
            myCombos = new ComboBox[] {comboBox1,comboBox2,comboBox3,comboBox4,comboBox5,comboBox6,comboBox7,comboBox8,comboBox9,comboBox10};

            questions = QuestionManager.getQuestionList(Convert.ToInt32(frmLogin.StID), Convert.ToInt32(frmStudentCrs.CrsID));
            qBS = new BindingSource(questions, "");
            quesGrid.DataSource = qBS;
            quesGrid.ReadOnly = true;
            quesGrid.Columns["Q_Id"].Visible = false;
            quesGrid.Columns["Q_Ans"].Visible = false;
            quesGrid.Columns["State"].Visible = false;
            quesGrid.Columns["Q_Type"].Visible = false;
            quesGrid.Columns["Q_Grade"].Visible = false;
            quesGrid.Columns["Q_Desc"].HeaderText = "Questions:";
            quesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            quesGrid.ColumnHeadersVisible = false;
            quesGrid.RowHeadersVisible = false;

            foreach (DataGridViewRow x in quesGrid.Rows)
            {
                x.MinimumHeight = 40;
            }

            quesGrid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.LightSkyBlue;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            quesGrid.EnableHeadersVisualStyles = false;
            quesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            for(int i=0; i<myCombos.Length; i++)
            {
                int id = Convert.ToInt32(quesGrid.Rows[i].Cells[0].Value.ToString());
                choices = ChoiceManager.questionChoices(id);
                chBS = new BindingSource(choices, "");
                myCombos[i].DataSource = chBS;

                //string combo = c.Name;

                myCombos[i].DisplayMember = "Choice1";
                myCombos[i].ValueMember = "Q_Id";
            }


            formGrade = new frmCrsGrade();
            exam = ExamManager.getExamDuration(Convert.ToInt32(frmStudentCrs.CrsID));
            examBS = new BindingSource(exam, "");
            durationLbl.DataBindings.Add("Text",examBS,"Ex_duration",true);
            
        }

        public void generateBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (ComboBox c in panel1.Controls)
            {
                St_AnswerManager.answerQuestion(
                Convert.ToInt32(c.SelectedValue.ToString()),
                Convert.ToInt32(frmLogin.StID),
                Convert.ToInt32(frmStudentCrs.CrsID),
                c.GetItemText(c.SelectedItem)
             );
                 
                i++;
            }

            St_AnswerManager.AnswerCorrection(
                Convert.ToInt32(frmLogin.StID),
                Convert.ToInt32(frmStudentCrs.CrsID)
                );

            this.Hide();
            formGrade.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(duration >= 0 && duration < Convert.ToInt32(durationLbl.Text))
            {
                ++duration;
                //this.Text = duration.ToString();

                if(duration == Convert.ToInt32(durationLbl.Text))
                {
                    MessageBox.Show("You have ran out of time!","Time out",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    this.generateBtn_Click(sender,e);
                    this.Hide();
                    formGrade.Show();
                }
            }
        }


    }
}
