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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace YOS.Pages.Outputs
{
	/// <summary>
	/// Interaction logic for About.xaml
	/// </summary>
	public partial class AllSelect : UserControl
	{
		public AllSelect()
		{
			InitializeComponent();
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string strConn = "User Id=scott;Password=tiger;Data Source=ORCL";

            OracleDataAdapter oraDA = new OracleDataAdapter("SELECT * FROM LECTURER2", strConn);
            DataTable dt = new DataTable();
            oraDA.Fill(dt);

            dataGrid.ItemsSource = dt.DefaultView;

            oraDA.Update(dt);  

        }
    }
}
