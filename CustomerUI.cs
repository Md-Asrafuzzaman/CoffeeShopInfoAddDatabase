using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopDataStore
{
    public partial class CustomerUI : Form
    {
        public CustomerUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddCustomerInfo();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            ShowCustomerInfo();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateCustomerInfo();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchCustomerInfo();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteCustomerInfo();
        }

        private void AddCustomerInfo()
        {
            try
            { // SQL connection 
                string connectionString = @"Server=localhost; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "INSERT INTO Customer(CustomerId,CustomerName,CustomerAddress,CustomerContact) VALUES ('" + customerIdTextBox.Text + "','" + customerNameTextBox.Text + "','" + customerAddressTextBox.Text + "','" + contactTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    MessageBox.Show("Successfully Inserted");
                }
                else
                {
                    MessageBox.Show("Insertion Failed");
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowCustomerInfo()
        {
            try
            { // SQL connection 
                string connectionString = @"Server=localhost; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "SELECT * FROM Customer";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    showDataGridView.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Data Set Empty");
                }

                sqlConnection.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateCustomerInfo()
        {
            try
            {// SQL connection 
                string connectionString = @"Server=localhost; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = @"UPDATE Customer SET CustomerName ='" + customerNameTextBox.Text + "', CustomerAddress = '"+ customerAddressTextBox.Text + "',CustomerContact = '" + contactTextBox.Text + "' WHERE CustomerId ='" + customerIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    MessageBox.Show("Successfully Updated");
                }
                else
                {
                    MessageBox.Show("Updated Failed");
                }

                sqlConnection.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchCustomerInfo()
        {
            try
            {// SQL connection 
                string connectionString = @"Server=localhost; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "SELECT * FROM Customer WHERE CustomerId ='" + customerIdTextBox.Text +"'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Search Match");
                    showDataGridView.DataSource = dataTable;

                }
                else
                {
                    MessageBox.Show("Search Data Not Match");
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeleteCustomerInfo()
        {
            try
            { // SQL connection 
                string connectionString = @"Server=localhost; DataBase=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //Sql Command

                string commandString = "DELETE FROM Customer WHERE CustomerId ='" + customerIdTextBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                //Execute
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    MessageBox.Show("Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }

                sqlConnection.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
