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
using System.Data;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using Business;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static OleDbConnection conn;
        public static OleDbCommand cmd;
        public static OleDbDataAdapter da;
        public static DataTable dt;

        public static void GetItem()
        {
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Stock1.mdb");
            OleDbCommand cmd = new OleDbCommand();
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Items";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainWindow_Loaded(object sender, EventArgs e)
        {
            GetItem();
            mdbViewer.ItemsSource = dt.AsDataView();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();
            MainWindow_Loaded(sender, e);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Items WHERE ItemName LIKE '" + txtFind.Text + "%'";
            da = new OleDbDataAdapter(query, conn);
            dt.Clear();
            da.Fill(dt);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_Loaded(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
                //Gets the ID number of item to be deleted
                int iD = Int32.Parse(Interaction.InputBox("Please enter the ID number of the item you wish to delete.", "Delete Items"));
            
                string query = "Delete FROM Items WHERE ID=@id";
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", iD);
                if (conn.State == ConnectionState.Closed) { conn.Open(); }
                cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open) { conn.Close(); }
        
                //Reloads DataGrid
                MainWindow_Loaded(sender, e);

        }
    }
}
