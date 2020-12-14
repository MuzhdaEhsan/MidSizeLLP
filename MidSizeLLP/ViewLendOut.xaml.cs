using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;

namespace MidSizeLLP
{
    /// <summary>
    /// Interaction logic for ViewLendOut.xaml
    /// </summary>
    public partial class ViewLendOut : UserControl
    {
        public ViewLendOut()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            try
            {
                string connectString = Properties.Settings.Default.connect_string; 
                SqlConnection cn = new SqlConnection(connectString);
                //opening the connection
                cn.Open();
                //This is the SQL query we want to run.
                string selectionQuery = "SELECT * FROM equipment";
                //Creating a command and passing the SqlCommand method the query and the connection.
                SqlCommand command = new SqlCommand(selectionQuery, cn);
                /*Use an SqlDataAdapter
                 * A DataAdapter is used to retrieve data from a data source and populate tables within a DataSet
                 * How do I know this? Read the documentation for SqlClient!  
                 */
                SqlDataAdapter sda = new SqlDataAdapter(command);
                /*Make sure you import "using System.Data;"
                 * This datatable is being linked with the Cars table.
                 */
                DataTable dt = new DataTable("equipment");
                //sda is the SqlDataAdapter, remember the dataadapter is used to retrieve data from a data source and populate tables within a dataset.
                sda.Fill(dt);

                /*carsGrid is being bound to the datatable.
                 *cars grid is a data grid which is just an element in our XAML
                 * that is being bound and used to display the data from our datatable.
                 */

                equipmentGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }



        }
    }
}
