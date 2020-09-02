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
using System.Data.SqlClient;
using System.Data.Common;

namespace KURSACH_22
{
    static class taskds_st
    {
        public static string tskID { get; set; }
        public static string wareHID { get; set; }
    }
    class taskds
    {
        public string tskID { get; set; }
        public string wareHID { get; set; }
    }
    public partial class DriverChill : Window
    {
        bool isChoosed = false;
        public static Human worker;
        private DriverChill()
        {
            InitializeComponent();
        }
        public DriverChill(Human h)
        {
            worker = h;
            InitializeComponent();
            //
            string sql = "select task_id,wh_id from tasks where DRIVER_ID is NULL";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            taskds buff;
            
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            buff = new taskds();
                            int task_id = reader.GetOrdinal("task_id");
                            int wh_id = reader.GetOrdinal("wh_id");
                            buff.tskID = (reader.GetInt32(task_id)).ToString();
                            buff.wareHID = (reader.GetInt32(wh_id)).ToString();
                            taskers.Items.Add(buff);
                        }
                    }
                }
            }
            catch (Exception ed)
            {
                MessageBox.Show(ed + ed.StackTrace);
            }
            finally
            {
                sc.Close();
            }
            //
          
        }

        private void chooseTask(object sender, SelectionChangedEventArgs e)
        {
            isChoosed = true;
            taskds_st.tskID = (taskers.SelectedItem as taskds).tskID;
            taskds_st.wareHID = (taskers.SelectedItem as taskds).wareHID;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!isChoosed)
            {
                MessageBox.Show("Вы должны выбрать задачу");
                return;
            }
            Builder.setTaskId(worker,Int32.Parse(taskds_st.tskID));
            Builder.setWhId(worker,Int32.Parse(taskds_st.wareHID));
            string buff = "UPDATE TASKS SET DRIVER_ID="; buff += worker.id;
            buff += " WHERE TASK_ID="; buff +=worker.choodesTaskId;
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = buff;
            cmd.ExecuteNonQuery();
            sc.Close();
            DriverWork dw = new DriverWork(worker);
            dw.Show();
            this.Close();
        }
    }
}
