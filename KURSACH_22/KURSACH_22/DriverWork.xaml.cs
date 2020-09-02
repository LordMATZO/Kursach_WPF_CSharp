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
    /// <summary>
    /// Interaction logic for DriverWork.xaml
    /// </summary>
    /// 
    public class thisTask
    {
        public static string tskID;
        public string shopID;
        public string goodID;
        public string quant;
    }
    public class timeStatistic
    {
        public string shpID { get; set; }
        public DateTime aimCompleted { get; set; }
    }
    public class shCoordinates
    {
        public string shpID;
        public int x;
        public int y;
    }
    public class zeroKl
    {
        public int str;
        public int col;
        public double mark;
    }
    public class stringsPare
    {
        public stringsPare(string s1,string s2)
        {
            from = s1;
            to = s2;
        }
        public string from;
        public string to;
    }
    public partial class DriverWork : Window
    {
        bool isClicked = false;
        public static List<thisTask> tt = new List<thisTask>();
        public static List<shCoordinates> shops = new List<shCoordinates>();
        public static List<stringsPare> route = new List<stringsPare>();
        public static List<zeroKl> zKLs = new List<zeroKl>();
        public static List<timeStatistic> ts = new List<timeStatistic>();
        public static double[,] start_kommi;
        public static double length = 0;
        public static Human worker;
        private DriverWork()
        {
            InitializeComponent();
        }
        public DriverWork(Human h)
        {
            
            worker = h;
            InitializeComponent();
            completeBut.IsEnabled = false;
            string sql = "select shop_id,good_id,quantity from tasks_goods where task_id=";
            sql += worker.choodesTaskId;
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            thisTask ttbuff;
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        thisTask.tskID = (worker.choodesTaskId).ToString();
                        while (reader.Read())
                        {
                            ttbuff = new thisTask();
                            int sbuff = reader.GetOrdinal("shop_id");
                            int gbuff = reader.GetOrdinal("good_id");
                            int qbuff = reader.GetOrdinal("quantity");
                            ttbuff.shopID = reader.GetInt32(sbuff).ToString();
                            ttbuff.goodID = reader.GetInt32(gbuff).ToString();
                            ttbuff.quant = reader.GetInt32(qbuff).ToString();
                            tt.Add(ttbuff);
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
            sc.Open();
            cmd.Connection = sc;
            bool isExist = false;
            shCoordinates buff;
            try
            {
                for (int i = 0; i < tt.Count; i++)
                {
                    sql = "select shop_x,shop_y from shops where shop_id="; sql +=tt[i].shopID;
                    cmd.CommandText = sql;
                    for (int j = 0; j < i; j++)
                    {
                        if (tt[i].shopID == tt[j].shopID)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (isExist)
                    {
                        isExist = false;
                        continue;
                    }
                    buff = new shCoordinates();
                    buff.shpID = tt[i].shopID;
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int x_buff= reader.GetOrdinal("shop_x");
                                int y_buff = reader.GetOrdinal("shop_y");
                                buff.x = (reader.GetInt32(x_buff));
                                buff.y = (reader.GetInt32(y_buff));
                            }
                        }
                    }
                    shops.Add(buff);
                }
                sql = "select wh_x,wh_y from warehouses where wh_id="; sql += worker.choodesWhId;
                cmd.CommandText = sql;
                buff = new shCoordinates();
                buff.shpID = "0";
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int x_buff = reader.GetOrdinal("wh_x");
                            int y_buff = reader.GetOrdinal("wh_y");
                            buff.x = (reader.GetInt32(x_buff));
                            buff.y = (reader.GetInt32(y_buff));
                        }
                    }
                }
                shops.Add(buff);
            }
            catch (Exception ed)
            {
                MessageBox.Show(ed + ed.StackTrace);
            }
            finally
            {
                sc.Close();
            }

            #region Kommi
            double[,] kommi = new double[shops.Count,shops.Count];
            start_kommi = new double[shops.Count, shops.Count];
            for (int i =0;i < shops.Count;i++)
            {
                for (int j = 0; j < shops.Count; j++)
                {
                    if (i!=j)
                    {
                        kommi[j, i] = Math.Sqrt(Math.Pow(shops[i].x - shops[j].x, 2) + Math.Pow(shops[i].y - shops[j].y, 2));
                        start_kommi[j, i] = Math.Sqrt(Math.Pow(shops[i].x - shops[j].x, 2) + Math.Pow(shops[i].y - shops[j].y, 2));
                    }
                    else
                    {
                        kommi[i, j] = Double.MaxValue;
                        start_kommi[i, j] = Double.MaxValue;
                    }
                }
            }
            
            double[] strings_min = new double[shops.Count];
            double[] columns_min = new double[shops.Count];
            double min = Double.MaxValue;

            
            while (route.Count != shops.Count)
            {
                min = Double.MaxValue;
                for (int i = 0; i < shops.Count; i++)
                {
                    min = Double.MaxValue;
                    for (int j = 0; j < shops.Count; j++)
                    {
                       if(kommi[i,j]== Double.MaxValue)
                       {
                           continue;
                       }
                       else
                       {
                            if(min>kommi[i,j])
                            {
                                min = kommi[i, j];
                            }
                       }
                    }
                    strings_min[i] = min;
                }
                for (int i = 0; i < shops.Count; i++)
                {
                    for (int j = 0; j < shops.Count; j++)
                    {
                        if (kommi[i, j] == Double.MaxValue)
                        {
                            continue;
                        }
                        else
                        {
                            kommi[i, j] -= strings_min[i];
                        }
                    }
                }
                min = Double.MaxValue;
                for (int i = 0; i < shops.Count; i++)
                {
                    min = Double.MaxValue;
                    for (int j = 0; j < shops.Count; j++)
                    {
                        if (kommi[j, i] == Double.MaxValue)
                        {
                            continue;
                        }
                        else
                        {
                            if (min > kommi[j, i])
                            {
                                min = kommi[j, i];
                            }
                        }
                    }
                    columns_min[i] = min;
                }
                ////
                for (int i = 0; i < shops.Count; i++)
                {
                    for (int j = 0; j < shops.Count; j++)
                    {
                        if (kommi[j, i] == Double.MaxValue)
                        {
                            continue;
                        }
                        else
                        {
                            kommi[j, i] -= columns_min[i];
                        }
                    }
                }
                ////
                
                zeroKl buffZK = new zeroKl();
                double min_str = Double.MaxValue;
                double min_clm = Double.MaxValue;
                for (int i = 0; i < shops.Count; i++)
                {
                    for (int j = 0; j < shops.Count; j++)
                    {
                        if (kommi[i, j] == 0)
                        {
                            buffZK = new zeroKl();
                            for (int k = 0;k < shops.Count;k++)
                            {
                                if(k == j)
                                {
                                    continue;
                                }
                                if(min_str > kommi[i,k])
                                {
                                    min_str = kommi[i, k];
                                }
                            }
                            for (int k = 0; k < shops.Count; k++)
                            {
                                if (k == i)
                                {
                                    continue;
                                }
                                if (min_clm > kommi[k, j])
                                {
                                    min_clm = kommi[k, j];
                                }
                            }
                            buffZK.str = i;
                            buffZK.col = j;
                            buffZK.mark = min_str + min_clm;
                            zKLs.Add(buffZK);
                        }
                        min_str = Double.MaxValue;
                        min_clm = Double.MaxValue;
                    }
                    
                }
                zeroKl with_max_mark = new zeroKl();
                with_max_mark.mark = 0;
                for(int i =0;i<zKLs.Count;i++)
                {
                    if(with_max_mark.mark<=zKLs[i].mark)
                    {
                        with_max_mark.mark = zKLs[i].mark;
                        with_max_mark.str = zKLs[i].str;
                        with_max_mark.col = zKLs[i].col;
                    }
                }                
                //
                route.Add(new stringsPare(shops[with_max_mark.str].shpID,shops[with_max_mark.col].shpID));
                kommi[with_max_mark.str, with_max_mark.col] = Double.MaxValue;
                kommi[with_max_mark.col, with_max_mark.str] = Double.MaxValue;
                for(int i =0;i<shops.Count;i++)
                {
                    kommi[with_max_mark.str,i] = Double.MaxValue;
                    kommi[i, with_max_mark.col] = Double.MaxValue;
                }
                //
                with_max_mark.mark = 0;
                zKLs = new List<zeroKl>();
            }
            #endregion
            

            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            bool isExist = false;
            string sql = "INSERT INTO DRIVERS_HAVE(DRIVER_ID,GOOD_ID,QUANTITY) VALUES(";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            try
            {
                for (int i = 0;i<tt.Count;i++)
                {
                    for(int j = 0; j < i; j++)
                    {
                        if(tt[i].goodID == tt[j].goodID && i!=j)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if(isExist)
                    {
                        isExist = false;
                        continue;
                    }
                    sql = "INSERT INTO DRIVERS_HAVE(DRIVER_ID,GOOD_ID,QUANTITY) VALUES(";
                    sql += worker.id; sql += ",";
                    sql += tt[i].goodID; sql += ",";
                    sql += "0"; sql += ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                for (int i = 0; i < tt.Count; i++)
                {
                    sql = "UPDATE DRIVERS_HAVE SET QUANTITY=QUANTITY+";
                    sql += tt[i].quant; sql += " WHERE DRIVER_ID=";
                    sql += worker.id; sql += " AND GOOD_ID=";
                    sql += tt[i].goodID;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    sql = "UPDATE WH_GOODS SET RESERVED_QUANTITY=RESERVED_QUANTITY-";
                    sql += tt[i].quant; sql += " WHERE WH_ID=";
                    sql += worker.choodesWhId; sql += " AND GOOD_ID=";
                    sql += tt[i].goodID;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
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
            takeBut.IsEnabled = false;
            timeStatistic tsBuff;
            int frID = 0;
            int toID = 0;
            string fromID = "0";
            for (int j = 0; j < route.Count; j++)
            {
                for (int i = 0; i < route.Count; i++)
                {
                    if (route[i].from == fromID)
                    {
                        
                        tsBuff = new timeStatistic();
                        if (fromID == "0")
                        {
                            tsBuff.shpID = "Склад";
                        }
                        else
                        {
                            tsBuff.shpID = route[i].from;
                        }
                        for(int u =0;u<shops.Count;u++)
                        {
                            if(route[i].from == shops[u].shpID)
                            {
                                frID = u;
                                break;
                            }
                        }
                        for (int u = 0; u < route.Count; u++)
                        {
                            if (route[i].to == shops[u].shpID)
                            {
                                toID = u;
                                break;
                            }
                        }
                        
                        fromID = route[i].to;
                        destinations.Items.Add(tsBuff);
                        if (route[i].from == route[i].to)
                        {
                            break;
                        }
                        length += start_kommi[frID, toID];
                        break;
                    }
                }
            }
            completeBut.IsEnabled = true;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if(et.Text == "" || et.Text==null)
            {
                MessageBox.Show("Поле конечного времени должно быть заполненным");
                return;
            }
            if (st.Text == "" || st.Text == null)
            {
                MessageBox.Show("Поле начального времени должно быть заполненным");
                return;
            }
            List<string> opers = new List<string>();
            string sql = "INSERT INTO DRIVERS_HAVE(DRIVER_ID,GOOD_ID,QUANTITY) VALUES(";
            string buff = "";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            try
            {
                for (int i = 0; i < tt.Count; i++)
                {
                    sql = "SELECT * FROM SH_GOODS WHERE SH_ID=";
                    sql += tt[i].shopID; sql += " and GOOD_ID=";
                    sql += tt[i].goodID;
                    cmd.CommandText = sql;
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            buff = "UPDATE SH_GOODS SET QUANTITY=QUANTITY+";
                            buff += tt[i].quant;
                            buff += " WHERE SH_ID="; buff += tt[i].shopID;
                            buff += " and GOOD_ID="; buff += tt[i].goodID;
                        }
                        else
                        {
                            buff = "INSERT INTO SH_GOODS(SH_ID,GOOD_ID,QUANTITY) VALUES(";
                            buff += tt[i].shopID;
                            buff += ","; buff += tt[i].goodID;
                            buff += ","; buff += tt[i].quant; buff += ")";
                        }
                        opers.Add(buff);
                        buff = "UPDATE DRIVERS_HAVE SET QUANTITY=QUANTITY-";
                        buff += tt[i].quant;
                        buff += " WHERE DRIVER_ID="; buff += worker.id;
                        buff += " and GOOD_ID="; buff += tt[i].goodID;
                        opers.Add(buff);
                    }
                }
                for (int i = 0; i < opers.Count; i++)
                {
                    cmd.CommandText = opers[i];
                    cmd.ExecuteNonQuery();
                }
                sql = "DELETE FROM DRIVERS_HAVE WHERE QUANTITY=0 and DRIVER_ID=";
                sql += worker.id;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM TASKS WHERE TASK_ID="; sql += worker.choodesTaskId;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM TASKS_GOODS WHERE TASK_ID="; sql += worker.choodesTaskId;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();


                int minutes = 0;
                if (DateTime.Parse(et.Text).Hour > DateTime.Parse(st.Text).Hour)
                {
                    minutes = (DateTime.Parse(et.Text).Hour - DateTime.Parse(st.Text).Hour) * 60;
                    if (DateTime.Parse(et.Text).Minute > DateTime.Parse(st.Text).Hour)
                    {
                        minutes += (DateTime.Parse(et.Text).Minute - DateTime.Parse(st.Text).Minute);
                    }
                    else
                    {
                        minutes += (DateTime.Parse(et.Text).Minute + 60 - DateTime.Parse(st.Text).Minute);
                    }
                }
                if (DateTime.Parse(et.Text).Hour < DateTime.Parse(st.Text).Hour)
                {
                    minutes = (DateTime.Parse(et.Text).Hour + 24 - DateTime.Parse(st.Text).Hour) * 60;
                    if (DateTime.Parse(et.Text).Minute > DateTime.Parse(st.Text).Hour)
                    {
                        minutes += (DateTime.Parse(et.Text).Minute - DateTime.Parse(st.Text).Minute);
                    }
                    else
                    {
                        minutes += (DateTime.Parse(et.Text).Minute + 60 - DateTime.Parse(st.Text).Minute);
                    }
                }
                sql = "INSERT INTO REPORTS(TASK_ID,SUMTIME,LENG,NOTES) VALUES(";
                sql += worker.choodesTaskId; sql += ",";
                sql += minutes; sql += ",";
                sql += length; sql += ",'";
                if (hints.Text=="" || hints.Text==null)
                { 
                    sql += " ";
                }
                else
                {
                    sql += hints.Text;
                }
                sql += "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                if((60 - length/(minutes/60))<10)
                {
                    MessageBox.Show("Анализатор маршрута: данный маршрут оптимален");
                }
                else
                {
                    MessageBox.Show("Анализатор маршрута: данный маршрут не оптимален");
                }
                
                this.Close();
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
