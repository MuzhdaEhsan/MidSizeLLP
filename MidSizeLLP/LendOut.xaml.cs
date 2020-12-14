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
    /// Interaction logic for LendOut.xaml
    /// </summary>
    public partial class LendOut : UserControl
    {
        public LendOut()
        {
            InitializeComponent();
        }
        private void addLendOut(object sender, RoutedEventArgs e)
        {

            try
            {
                //object Properties = null;

                if (String.IsNullOrEmpty(txtEmployeeID.Text) || String.IsNullOrEmpty(txtName.Text) || String.IsNullOrEmpty(txtDescEquipment.Text) || String.IsNullOrEmpty(txtContactNumber.Text))
                {
                    //pop up to show error
                    MessageBox.Show("You must fill all the fields.");
                }
                else
                {
                    int empID;
                    if (!int.TryParse(txtEmployeeID.Text, out empID))
                    {
                        //pop up to show error
                        MessageBox.Show("ID must be numeric.");
                    }
                    else
                    {
                        string connectString = Properties.Settings.Default.connect_string; //Properties.Settings.Default.connect_string;

                        //string connectString = Properties.Settings.connect_string;
                        SqlConnection cn = new SqlConnection(connectString);
                        //opening the connection
                        cn.Open();

                        //Inserting query
                        string insertQuery = "INSERT INTO equipment (empID, name, description, phone) VALUES('" + empID + "', '" + txtName.Text + "', '" + txtDescEquipment.Text + "', '" + txtContactNumber.Text + "')";
                        //creating a new command and passing it the query + the connection.
                        SqlCommand command = new SqlCommand(insertQuery, cn);
                        //executing the query. 
                        command.ExecuteNonQuery();
                        //closing the connection (good practice).
                        cn.Close();
                        //Show a pop up message box if the record was added successfully.
                        MessageBox.Show("Record was added successfully!");
                        //Empty everything if the record was added successfully.
                        txtEmployeeID.Text = string.Empty;
                        txtName.Text = string.Empty;
                        txtDescEquipment.Text = string.Empty;
                        txtContactNumber.Text = string.Empty;
                    }
                }

            }
            //catching any sort of exceptions that might occur.
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
