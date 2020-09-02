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
    public class wareHouse
    {
        public string whID { get; set; }
    }
    public class taskObject
    {
        public string reqId { get; set; }
        public string goodId { get; set; }
    }
    public class reqTask
    {
        public string shopID { get; set; }
        public string reqID { get; set; }
    }
    public class reqGoods
    {
        public string goodID { get; set; }
        public string quan { get; set; }
    }
    public class wareGoods
    {
        public string goodID { get; set; }
        public string quan { get; set; }
    }
    public partial class Manager : Window
    {
        public static Human worker;
        public Manager()
        {
            InitializeComponent();
        }
        public Manager(Human h)
        {
            InitializeComponent();
            addGiT.IsEnabled = false;
            wareHouse buff;
            buff = new wareHouse();
            buff.whID = "ID Склада";
            warList.Items.Add(buff);
            worker = h;

            string sql = "Select wh_id from warehouses";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            buff = new wareHouse();
                            int idWH = reader1.GetOrdinal("wh_id");
                            buff.whID = reader1.GetInt32(idWH).ToString();
                            warList.Items.Add(buff);
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
            reqTask buff_t;
            buff_t = new reqTask();
            buff_t.reqID = "ID Запроса ";
            buff_t.shopID = "ID Магазина";
            sql = "Select order_id,shop_id from orders";
            reqList.Items.Add(buff_t);
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            buff_t = new reqTask();
                            int idOR = reader1.GetOrdinal("order_id");
                            int idSH = reader1.GetOrdinal("shop_id");
                            buff_t.reqID = reader1.GetInt32(idOR).ToString() + " ";
                            buff_t.shopID = reader1.GetInt32(idSH).ToString();
                            reqList.Items.Add(buff_t);
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
        }
        public bool checkWH(string gi,string qn,string whID)
        {
            string sql = "Select * from wh_goods where good_id=";
            sql += gi;
            sql += " and ";
            sql += "AVAILABLE_QUANTITY>=";
            sql += qn;
            sql += " and ";
            sql += "wh_id=";
            sql += whID;
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        sc.Close();
                        return true;
                    }
                    else
                    {
                        sc.Close();
                        return false;
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
            return false;
        }
        public bool checkREQ()
        {
            string sql = "Select wh_id,good_id,AVAILABLE_QUANTITY from wh_goods where wh_id=";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        sc.Close();
                        return true;
                    }
                    else
                    {
                        sc.Close();
                        return false;
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
            return false;
        }
        private void whSel(object sender, RoutedEventArgs e)
        {
            wareHouse p = new wareHouse();
                p =(wareHouse)warList.SelectedItem;
            if (p.whID == "ID Склада")
            {
                return;
            }
            warehouseGoods.Items.Clear();
            string sql = "Select wh_id,good_id,AVAILABLE_QUANTITY from wh_goods where wh_id=";
            sql += p.whID;
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            wareGoods buff = new wareGoods();
            buff.goodID = "ID Товара ";
            buff.quan = "Количество ";
            warehouseGoods.Items.Add(buff);
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            buff = new wareGoods();
                            int idGood = reader1.GetOrdinal("good_id");
                            int quant = reader1.GetOrdinal("AVAILABLE_QUANTITY");
                            buff.goodID = reader1.GetInt32(idGood).ToString() + " ";
                            buff.quan = reader1.GetInt32(quant).ToString();
                            warehouseGoods.Items.Add(buff);
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
        }
        private void reqSel(object sender, RoutedEventArgs e)
        {
            reqTask p = new reqTask();
                p= (reqTask)reqList.SelectedItem;
            if(p.reqID == "ID Запроса ")
            {
                return;
            }
            req_goods.Items.Clear();
            string sql = "Select good_id,quantity from order_list where order_id=";
            for (int i =0;i< p.reqID.Length-1;i++)
            {
                sql += p.reqID[i];
            }
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            reqGoods buff = new reqGoods();
            buff.goodID = "ID Товара ";
            buff.quan = "Количество";
            req_goods.Items.Add(buff);
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader1 = cmd.ExecuteReader())
                {
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            buff = new reqGoods();
                            int idGood = reader1.GetOrdinal("good_id");
                            int quant = reader1.GetOrdinal("quantity");
                            buff.goodID = reader1.GetInt32(idGood).ToString() + " ";
                            buff.quan = reader1.GetInt32(quant).ToString();
                            req_goods.Items.Add(buff);
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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int iter = 0;
            for (int i = 0; i < warList.Items.Count; i++)
            {
                if (sourceWH.Text == ((wareHouse)warList.Items[i]).whID)
                {
                    iter++;
                }
            }
            if (iter == 0)
            {
                MessageBox.Show("Скалада с данным ID не существует");
                return;
            }
            if(sourceWH.Text == null || sourceWH.Text == "")
            {
                return;
            }
            addGiT.IsEnabled = true;
            sourceWH.IsEnabled = false;
            fixer.IsEnabled = false;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ready_quest.Items.Add(new taskObject());
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int access_quantity = 0;
            if(ready_quest.Items.IsEmpty)
            {
                MessageBox.Show("Невозможно создать пустую задачу");
                return;
            }
            bool isExist = false;
            string sql;
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            string[] quants = new string[ready_quest.Items.Count];
            string[] shopsIdentificators = new string[ready_quest.Items.Count];
            string wareHouseId = sourceWH.Text;
            taskObject tO;
            int taskId = (((((DateTime.Now.Year * 100 + DateTime.Now.Month) * 100 + DateTime.Now.Day) * 100 + DateTime.Now.Hour) * 100 + DateTime.Now.Minute) * 100 + DateTime.Now.Second);
            //
            reqTask rT;
            for (int i = 0; i < ready_quest.Items.Count; i++)
            {
                tO = ready_quest.Items[i] as taskObject;
                if (tO.goodId == null || tO.goodId == "")
                {
                    MessageBox.Show("Поле id товара пусто в строке " + i+1);
                    return;
                }
                if (tO.reqId == null || tO.reqId == "")
                {
                    MessageBox.Show("Поле id запроса пусто в строке " + i+1);
                    return;
                }
                if (Int32.Parse(tO.goodId) <= 0)
                {
                    MessageBox.Show("ID товара должно быть больше нуля. Строка " + i + 1);
                    return;
                }
                if (Int32.Parse(tO.reqId) <= 0)
                {
                    MessageBox.Show("ID запроса должно быть больше нуля. Строка " + i + 1);
                    return;
                }
                for (int j = 0;j<reqList.Items.Count;j++)
                {
                    rT = reqList.Items[j] as reqTask;
                    if((rT.reqID).GetHashCode() == (tO.reqId + " ").GetHashCode())
                    {
                        isExist = true;
                        shopsIdentificators[i] = rT.shopID;
                    }
                }
                if(!isExist)
                {
                    MessageBox.Show("Строка " + (i+1) + ". Введённое ID не существует");
                    return;
                }
                isExist = false;
                sql = "SELECT QUANTITY FROM ORDER_LIST WHERE ORDER_ID = ";
                sql += tO.reqId;
                sql += " AND GOOD_ID = ";
                sql += tO.goodId;
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
                                int qID = reader.GetOrdinal("QUANTITY");
                                quants[i] = reader.GetInt32(qID).ToString();
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
            }
            //
            for (int i = 0; i < ready_quest.Items.Count; i++)
            {
                tO = ready_quest.Items[i] as taskObject;
                sc.Open();
                sql = "SELECT QUANTITY FROM ORDER_LIST WHERE ORDER_ID = ";
                sql += tO.reqId;
                sql += " AND GOOD_ID = ";
                sql += tO.goodId;
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    using (DbDataReader reader2 = cmd.ExecuteReader())
                    {
                        if (!reader2.HasRows)
                        {
                            MessageBox.Show("Строка " + (i + 1) + ". Запроса на этот товар не существует");
                            sc.Close();
                            return;
                        }
                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
                
                //
            }

            ////
            for (int i = 0; i < ready_quest.Items.Count; i++)
            {
                tO = ready_quest.Items[i] as taskObject;
                sc.Open();
                sql = "SELECT * FROM WH_GOODS WHERE WH_ID = ";
                sql += sourceWH.Text;
                sql += " AND GOOD_ID = ";
                sql += tO.goodId;
                sql += " AND AVAILABLE_QUANTITY >= ";
                sql += quants[i];
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    using (DbDataReader reader1 = cmd.ExecuteReader())
                    {
                        if (!reader1.HasRows)
                        {
                            MessageBox.Show("Товар с ID: " + tO.goodId + " и ID запроса: " + tO.reqId + " не может быть добавлен в задачу из-за нехватки на складе");
                            sc.Close();
                            continue;
                        }
                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
                sc.Open();

                tO = ready_quest.Items[i] as taskObject;
                sql = "UPDATE WH_GOODS SET AVAILABLE_QUANTITY = AVAILABLE_QUANTITY-" + quants[i] + " ";
                sql += ",RESERVED_QUANTITY=RESERVED_QUANTITY+" + quants[i];
                sql += " WHERE WH_ID="  + sourceWH.Text;
                sql += " AND GOOD_ID= " + tO.goodId;
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteReader();
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
                tO = ready_quest.Items[i] as taskObject;
                sql = "INSERT INTO TASKS_GOODS(TASK_ID,SHOP_ID,GOOD_ID,QUANTITY) VALUES( ";
                sql += taskId.ToString();
                sql += ",";
                sql += shopsIdentificators[i];
                sql += ",";
                sql += tO.goodId.ToString();
                sql += ",";
                sql += quants[i];
                sql += ")";
                sc.Open();
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
                tO = ready_quest.Items[i] as taskObject;
                sql = "DELETE FROM ORDER_LIST WHERE ORDER_ID = ";
                sql += tO.reqId.ToString();
                sql += " AND GOOD_ID = ";
                sql += tO.goodId.ToString();
                sc.Open();
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
                access_quantity++;
            }
            if (access_quantity > 0)
            {
                sql = "INSERT INTO TASKS(TASK_ID,WH_ID) VALUES( ";
                sql += taskId.ToString();
                sql += ",";
                sql += wareHouseId;
                sql += ")";
                sc.Open();
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
            }
            reqTask buff;
            for(int i = 1;i < reqList.Items.Count;i++)
            {
                buff = reqList.Items[i] as reqTask;
                sc.Open();
                sql = "SELECT * FROM ORDER_LIST WHERE ORDER_ID=";
                sql += buff.reqID;
                cmd.Connection = sc;
                cmd.CommandText = sql;
                try
                {
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            sc.Close();
                            sc.Open();
                            sql = "DELETE FROM ORDERS WHERE ORDER_ID=";
                            sql += buff.reqID;
                            cmd.Connection = sc;
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                    sc.Close();
                    return;
                }
                finally
                {
                    sc.Close();
                }
            }
            Manager man = new Manager(worker);
            man.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if(ready_quest.Items.IsEmpty)
            {
                return;
            }
            ready_quest.Items.RemoveAt(ready_quest.Items.Count - 1);
        }
    }
}
