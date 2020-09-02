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
using System.Data.SqlClient;
using System.Data.Common;

namespace KURSACH_22
{
    public class DBSQLServerUtils
    {
        static bool isCreated = false;
        static SqlConnection myConnection;
        private DBSQLServerUtils() { }
        static void CreateDBConnection(string datasource, string database, string username, string password)
        {
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            myConnection = new SqlConnection(connString);
            isCreated = true;
        }
        public static SqlConnection GetDBConnection()
        {
            if(isCreated)
            {
                return myConnection;
            }
            else
            {
                CreateDBConnection(@"DESKTOP-A6O74Q8\SQLEXPRESS", "LogExpTest","Course_admin","12345");
                return myConnection;
            }
        }

    }
    public static class Builder
    {
        public static void setId(Human a,int b) { a.id = b; }
        public static void setName(Human a,string b) { a.name = b; }
        public static void setSName(Human a,string b) { a.surname = b; }
        public static void setShopId(Human a,int b) { a.shopId = b; }
        public static void setTaskId(Human a,int b) { a.choodesTaskId = b; }
        public static void setWhId(Human a,int b) { a.choodesWhId = b; }
    }
    public class Human
    {
        public int id;
        public string name;
        public string surname;
        public int shopId;
        public int choodesTaskId;
        public int choodesWhId;
    }
    public partial class MainWindow : Window
    {
        public static Human worker = new Human();
        public MainWindow()
        {
            InitializeComponent();
            this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/CommonDictionary.xaml") };
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if(login.Text == "" || login.Text == null)
            {
                MessageBox.Show("Заполните поле логина");
                return;
            }
            if (pass.Text == "" || pass.Text == null)
            {
                MessageBox.Show("Заполните поле пароля");
                return;
            }
            string sql = "Select id,position,pass, F_name, surname from workers";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int IdIndex = reader.GetOrdinal("id");
                            int FNIndex = reader.GetOrdinal("f_name");
                            int SNIndex = reader.GetOrdinal("surname");
                            int PassIndex = reader.GetOrdinal("pass");
                            int PosIndex = reader.GetOrdinal("position");
                            if (reader.GetString(FNIndex) + "_" + reader.GetString(SNIndex) == login.Text)
                            {
                                if(reader.GetInt32(PassIndex).ToString() == pass.Text.GetHashCode().ToString())
                                {
                                    Builder.setId(worker, reader.GetInt32(IdIndex));
                                    Builder.setName(worker, reader.GetString(FNIndex));
                                    Builder.setSName(worker, reader.GetString(SNIndex));
                                    if (reader.GetInt32(PosIndex) == 1)
                                    {
                                        sc.Close();
                                        DriverChill dc = new DriverChill(worker);
              
                                        dc.Show();
                                        
                                        this.Close();
                                        return;
                                    }
                                    if (reader.GetInt32(PosIndex) == 2)
                                    {
                                        sc.Close();
                                        Manager man = new Manager(worker);
                               
                                        man.Show();
                                       
                                        this.Close();
                                        return;
                                    }
                                    if (reader.GetInt32(PosIndex) == 3)
                                    {
                                        string sqlShop = "Select shop_id from SHOPS_MANAGERS where worker_id=" + worker.id;
                                        sc.Close();
                                        sc.Open();
                                        cmd.Connection = sc;
                                        cmd.CommandText = sqlShop;
                                        using (DbDataReader reader_sec = cmd.ExecuteReader())
                                        {
                                            if (reader_sec.HasRows)
                                            {
                                                while (reader_sec.Read())
                                                {
                                                    int ShopIdIndex = reader_sec.GetOrdinal("shop_id");
                                                    Builder.setShopId(worker, reader_sec.GetInt32(ShopIdIndex));
                                                }
                                            }
                                        }
                                        sc.Close();
                                        ShopOrdering so = new ShopOrdering(worker);
                                        so.Show();
                                        this.Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ошибка авторизации: P");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка авторизации: L");
                    }
                }
                MessageBox.Show("Ошибка авторизации: NR");
            }
            catch (Exception ed)
            {
                MessageBox.Show(ed + ed.StackTrace);
            }
            finally
            {
                sc.Close();
            }
        }
    }
}
