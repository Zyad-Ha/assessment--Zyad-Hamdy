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
    /// Interaction logic for ERequestsWindow1.xaml
    /// </summary>
    public partial class ERequestsWindow1 : Window
    {
        Context context = new Context();
        public ERequestsWindow1()
        {
            InitializeComponent();
            loadData();
        }


        void loadData()
        {
            var result = context.LeaveRequest.Include(x => x.User)
                .Select(x => new
                {
                    x.R_id,
                    x.User.Uname,
                    x.User.U_id,
                    x.startDate,
                    x.endDate,
                    x.LeaveType,
                    x.status,

                }).ToList();

            RDG.ItemsSource = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var req = new LeaveRequest()
            {
                UserID = 2,
                LeaveType = LeaveTypetxtb.Text,
                endDate = DateOnly.Parse(Edatetxtb.Text),
                startDate = DateOnly.Parse(Sdattxtbe.Text),
                status = "Pending",

            };
            context.LeaveRequest.Add(req);
            context.SaveChanges();
            loadData();
            Sdattxtbe.Clear();
            LeaveTypetxtb.Clear();
            Edatetxtb.Clear();
            MessageBox.Show("Request sent successfully.");


            
        }
    }
}
