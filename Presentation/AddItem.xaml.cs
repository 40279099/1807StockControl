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
using System.Data.OleDb;
using System.Data;
using Business;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {

        
        public AddItem()
        {
            InitializeComponent();
            MainWindow.GetItem();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Item newItem = new Item();
            try
            {
                newItem.ItemName = txtItemName.Text;
                newItem.Unit = txtUnit.Text;
                newItem.Cost = decimal.Parse(txtCost.Text);
                newItem.ItemType = txtItemType.Text;
                newItem.Provider = txtProvider.Text;

                string query = "Insert into Items (itemName,unit,cost,itemType,provider) values (@n,@u,@c,@t,@p)";
                MainWindow.cmd = new OleDbCommand(query, MainWindow.conn);
                MainWindow.cmd.Parameters.AddWithValue("@n", newItem.ItemName);
                MainWindow.cmd.Parameters.AddWithValue("@u", newItem.Unit);
                MainWindow.cmd.Parameters.AddWithValue("@c", newItem.Cost);
                MainWindow.cmd.Parameters.AddWithValue("@t", newItem.ItemType);
                MainWindow.cmd.Parameters.AddWithValue("@p", newItem.Provider);
                if (MainWindow.conn.State != ConnectionState.Open) { MainWindow.conn.Open(); }
                MainWindow.cmd.ExecuteNonQuery();
                MainWindow.conn.Close();

                MessageBox.Show("Your item has been added.");
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }

            txtItemName.Clear();
            txtUnit.Clear();
            txtCost.Clear();
            txtItemType.Clear();
            txtProvider.Clear();
        }
    }
}
