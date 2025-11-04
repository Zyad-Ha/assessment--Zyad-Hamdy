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

namespace Zyad_Hamdy_assessment
{
    /// <summary>
    /// Interaction logic for AdminReq.xaml
    /// </summary>
    public partial class AdminReq : Window
    {
        Context context = new Context();
        public AdminReq()
        {
            InitializeComponent();
            load();
        }


        void load()
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
            var id = Rid.Text;
            var status = (string)CBS.SelectionBoxItem;

            var result = context.LeaveRequest.Include(x => x.User).Where(x=>x.R_id == int.Parse(id)).FirstOrDefault();

             result.status = status;

            context.SaveChanges();
            load();
            MessageBox.Show("status edited");

        }
    }
}
