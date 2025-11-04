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
    /// Interaction logic for empWindow1.xaml
    /// </summary>
    public partial class empWindow1 : Window
    {
        Context context = new Context();
        private User user = new User();
      
        public empWindow1(string? name)
        {
            InitializeComponent();
            loadEDG2(name);

            user = (from x in context.User
                    where x.Uname == Name
                    select x).FirstOrDefault();
        }

       

       public void loadEDG2(string name)
        {

            user = (from x in context.User
                    where x.Uname == name
                    select x).FirstOrDefault();

            var result = context.User.Include(x => x.Department)
                .Where(x => x.role == "emp" && x.U_id == user.U_id)
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

            empDG2.ItemsSource = result;
        }
        void clears()
        { 
            Didtxtb.Clear();
            emailtxtb2.Clear();
            idtxtb.Clear();
            addresstxtb.Clear();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(idtxtb.Text) ||
                string.IsNullOrWhiteSpace(Didtxtb.Text))
            {
                MessageBox.Show("you should fill User id and Dep. id with correct data.", "Error message", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var id = idtxtb.Text;
            var dep = Didtxtb.Text;
            var thing = (from x in context.User
                         join q in context.Department on x.DepartmentID equals q.D_id
                         where (x.U_id == int.Parse(id))
                         select x).FirstOrDefault();

            if (thing != null)
            {
                thing.Email = emailtxtb2.Text;
                thing.DepartmentID = int.Parse(dep);
                thing.address = addresstxtb.Text;
                context.SaveChanges();
                loadEDG2(thing.Uname);
                clears();
                MessageBox.Show("Employee updated successfully.");
            }
            else
            {
                return;
            }
        }

        private void empDG2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic row = empDG2.SelectedItem;
            if (row != null)
            {
                addresstxtb.Text = row.address;
                Didtxtb.Text = row.D_id.ToString();
                emailtxtb2.Text = row.Email;
                idtxtb.Text = row.U_id.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ERequestsWindow1 eRequestsWindow1 = new ERequestsWindow1();
            eRequestsWindow1.Show();
        }
    }
}
