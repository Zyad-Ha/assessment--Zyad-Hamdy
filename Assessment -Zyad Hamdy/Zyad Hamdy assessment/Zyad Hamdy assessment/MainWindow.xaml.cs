using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zyad_Hamdy_assessment.Data;

namespace Zyad_Hamdy_assessment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Context context = new Context();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nametxtb.Text)||
                string.IsNullOrWhiteSpace(passtxtb.Password))
            {
                MessageBox.Show("Please fill all boxes");
                return; 
            }

            var query = (from x in context.User
                         where (x.Password == passtxtb.Password && x.Uname == nametxtb.Text)
                         select x).FirstOrDefault();

            string name = nametxtb.Text;
            if (query != null)
            {
                if (query.role == "admin")
                {
                    adminWindow1 adminWindow1 = new adminWindow1(); 
                    adminWindow1.Show();
                    this.Close();
                    MessageBox.Show("login successfully.");
                }
                else if (query.role == "emp")
                {
                    empWindow1 empWindow1 = new empWindow1(name);
                    empWindow1.Show();
                    this.Close();
                    MessageBox.Show("login successfully.");
                }
                else
                {
                    MessageBox.Show("invalid name or password.");
                    return;
                }

            }

        }
    }
}