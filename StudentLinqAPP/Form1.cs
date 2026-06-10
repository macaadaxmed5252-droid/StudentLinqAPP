using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentLinqAPP
{
    public partial class Form1 : Form
    {

        CollegeDataDataContext db = new CollegeDataDataContext();
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            // to_list() waxay si toos ah u keenaysaa xogta oo dhan
            dataGridView1.DataSource = db.Students.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtCourse.Text))
            {
                MessageBox.Show("Fadlan buuxi Magaca iyo Koorsada!");
                return;
            }

            // Abuur Object cusub oo ka dhashay shaxda Students
            Student newStudent = new Student
            {
                FullName = txtFullName.Text,
                Course = txtCourse.Text,
                Phone = txtPhone.Text,
                Semester = txtSemester.Text
            };

            // SQL Command badalkeed: Kaliya u sheeg LINQ inuu ku daro ka dibna submit dheh
            db.Students.InsertOnSubmit(newStudent);
            db.SubmitChanges();

            MessageBox.Show("Ardayga waa la diwaangeliyay!");
            ClearFields();
            LoadData();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Geli Student ID-ga aad raadinayso!");
                return;
            }

            int id = Convert.ToInt32(txtStudentID.Text);

            // Lambda Expression (p => p.ID) oo loo isticmaalo raadinta kooban
            var student = db.Students.FirstOrDefault(s => s.StudentID == id);

            if (student != null)
            {
                txtFullName.Text = student.FullName;
                txtCourse.Text = student.Course;
                txtPhone.Text = student.Phone;
                txtSemester.Text = student.Semester;
            }
            else
            {
                MessageBox.Show("Ardaygan lama helin!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Fadlan marka hore geli Student ID-ga!");
                return;
            }

            int id = Convert.ToInt32(txtStudentID.Text);
            var student = db.Students.FirstOrDefault(s => s.StudentID == id);

            if (student != null)
            {
                // Kaliya u baddal qiimaha Objects-ka caadiga ah
                student.FullName = txtFullName.Text;
                student.Course = txtCourse.Text;
                student.Phone = txtPhone.Text;
                student.Semester = txtSemester.Text;

                db.SubmitChanges(); // Ku keydi isbeddelka Database-ka
                MessageBox.Show("Xogta ardayga waa la cusboonaysiiyay!");
                ClearFields();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStudentID.Text))
            {
                MessageBox.Show("Fadlan geli Student ID!");
                return;
            }

            int id = Convert.ToInt32(txtStudentID.Text);
            var student = db.Students.FirstOrDefault(s => s.StudentID == id);

            if (student != null)
            {
                db.Students.DeleteOnSubmit(student);
                db.SubmitChanges(); // Ka tiri database-ka

                MessageBox.Show("Xogta ardayga waa la tirtiray!");
                ClearFields();
                LoadData();
            }
        }

        private void ClearFields()
        {
            txtStudentID.Clear();
            txtFullName.Clear();
            txtCourse.Clear();
            txtPhone.Clear();
            txtSemester.Clear();
            txtFullName.Focus();
        }
    }
}
