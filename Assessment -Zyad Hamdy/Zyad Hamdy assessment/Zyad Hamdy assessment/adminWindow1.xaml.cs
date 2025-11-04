using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zyad_Hamdy_assessment.Data;
using Zyad_Hamdy_assessment.Models;

namespace Zyad_Hamdy_assessment
{
    /// <summary>
    /// Interaction logic for adminWindow1.xaml
    /// </summary>
    public partial class adminWindow1 : Window
    {
        Context context = new Context();
        public adminWindow1()
        {
            InitializeComponent();
            loadEDG();
        }


        void loadEDG()
        {
            var result = context.User.Include(x=>x.Department)
                .Where(x=>x.role == "emp")
                .Select(x => new
            {
                x.U_id,
                x.Uname,
                x.Department.D_id,
                x.Department.Dname,
                x.Email,
                x.address,
                x.salary,
                x.jop_title,

            }).ToList();

            empDG.ItemsSource = result;
        }
        void clears()
        {
            salarytxtb.Clear();
            passtxtb2.Clear();
            Didtxtb.Clear();
            emailtxtb2.Clear();
            idtxtb.Clear();
            jtitletxtb.Clear();
            nametxtb2.Clear();
            salarytxtb.Clear();
            addresstxtb.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(addresstxtb.Text)||
                string.IsNullOrWhiteSpace(Didtxtb.Text) ||
                string.IsNullOrWhiteSpace(emailtxtb2.Text) ||
                string.IsNullOrWhiteSpace(addresstxtb.Text) ||
                string.IsNullOrWhiteSpace(jtitletxtb.Text) ||
                string.IsNullOrWhiteSpace(nametxtb2.Text) ||
                string.IsNullOrWhiteSpace(passtxtb2.Text) ||
                string.IsNullOrWhiteSpace(salarytxtb.Text))
            {
                MessageBox.Show("please fill all boxes ","Error message" , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            var dep = Didtxtb.Text; 
            
            var addB = context.User.Where(x => x.role == "emp").FirstOrDefault();

            var newUser = new User()
            {
                address = addresstxtb.Text,
                Uname = nametxtb2.Text,
                Password = passtxtb2.Text,
                Email = emailtxtb2.Text,
                jop_title = jtitletxtb.Text,
                salary = salarytxtb.Text,
                DepartmentID = int.Parse(dep),
                role = "emp",
            };
            context.User.Add(newUser);
            MessageBox.Show("Employee added successfully.");
            context.SaveChanges();
            loadEDG();
            clears();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtb.Text)||
                string.IsNullOrWhiteSpace(Didtxtb.Text))
            {
                MessageBox.Show("you should fill User id and Dep. id with correct data.", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var id = idtxtb.Text;
            var dep = Didtxtb.Text;
            var thing = (from x in context.User
                        join q in context.Department on x.DepartmentID equals q.D_id
                        where(x.U_id == int.Parse(id))
                        select x).FirstOrDefault();

            if (thing!= null)
            {
                thing.Uname  = nametxtb2.Text;
                thing.Email = emailtxtb2.Text;
                thing.DepartmentID = int.Parse(dep);
                thing.jop_title = jtitletxtb.Text;
                thing.Password = passtxtb2.Text;
                thing.salary = salarytxtb.Text;
                thing.address = addresstxtb.Text;
                context.SaveChanges();
                loadEDG();
                clears();
                MessageBox.Show("Employee updated successfully.");
            }
            else
            {
                return; 
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var id = idtxtb.Text;
            var dep = Didtxtb.Text;
            var thing = (from x in context.User
                         join q in context.Department on x.DepartmentID equals q.D_id
                         where (x.U_id == int.Parse(id))
                         select x).FirstOrDefault();

            context.User.Remove(thing);
            context.SaveChanges();
            loadEDG();
            clears();
            MessageBox.Show("Employee Removed successfully.");
        }

        private void empDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic row = empDG.SelectedItem;
            if (row != null)
            {
                addresstxtb.Text = row.address;
                Didtxtb.Text = row.D_id.ToString();
                emailtxtb2.Text = row.Email;
                idtxtb.Text = row.U_id.ToString();
                jtitletxtb.Text = row.jop_title;
                nametxtb2.Text = row.Uname;
                salarytxtb.Text = row.salary;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AdminReq adminReq = new AdminReq();
            adminReq.Show();
        }
    }
}
