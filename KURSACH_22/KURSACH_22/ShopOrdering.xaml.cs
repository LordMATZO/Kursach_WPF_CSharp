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
    /// Interaction logic for ShopOrdering.xaml
    /// </summary>
    class ReqGood
    {
        public int id { get; set; }
        public int quantity { get; set; }
    }
    class InfGood
    {
        public string gI { get; set; }
        public string gN { get; set; }
        public string cSt { get; set; }
    }
    public partial class ShopOrdering : Window
    {
        static int goodsQuant = 0;
        public void showGoods()
        {
            InfGood buffd = new InfGood();
            buffd.gI = "ID";
            buffd.gN = "Название";
            buffd.cSt = " Цена";
            goods_id.Items.Add(buffd);
            string sql = "Select good_id,good_name,cost from G_Names";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            InfGood buff;
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            goodsQuant++;
                            int idI = reader.GetOrdinal("good_id");
                            int idN = reader.GetOrdinal("good_name");
                            int idCST = reader.GetOrdinal("cost");
                            int idG = reader.GetInt32(idI);
                            string name = reader.GetString(idN);
                            int cst = reader.GetInt32(idCST);
                            buff = new InfGood();
                            buff.gI = idG.ToString();
                            buff.gN = name;
                            buff.cSt = " ";
                            buff.cSt += cst.ToString();
                            goods_id.Items.Add(buff);
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
        static int ReqGoodsNum = 0;
        public static Human worker;
        public ShopOrdering()
        {
            InitializeComponent();
        }
        public ShopOrdering(Human h)
        {
            worker = h;
            InitializeComponent();
            this.showGoods();
        }
        private void Shops_lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ReqGoodsNum == goodsQuant)
            {
                MessageBox.Show("Нельзя заказать большее количество видов товара");
                return;
            }
            ReqGoodsNum++;
            goods_lb.Items.Add(new ReqGood());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ReqGoodsNum == 0)
            {
                MessageBox.Show("Нельзя добавить пустой запрос");
                return;
            }
            
            ReqGood rg;
            ReqGood buff_rg;
            for (int i = 0; i < goods_lb.Items.Count; i++)
            {

                rg = goods_lb.Items[i] as ReqGood;
                if (rg.quantity <= 0)
                {
                    MessageBox.Show("Строка " + ((int)i + 1) + ". Количество должно быть положительным");
                    return;
                }
                if (rg.id <= 0)
                {
                    MessageBox.Show("Строка " + ((int)i + 1) + ". ID товаров должно быть положительным");
                    return;
                }
                if (rg.id > goodsQuant)
                {
                    MessageBox.Show("Строка " + ((int)i + 1) + ". Введено недоступное ID товара");
                    return;
                }
                for (int j = 0; j < goods_lb.Items.Count; j++)
                {
                    buff_rg = goods_lb.Items[j] as ReqGood;
                    if (j == i)
                    {
                        continue;
                    }
                    if (rg.id == buff_rg.id)
                    {
                        MessageBox.Show("ID товаров не должны повторяться");
                        return;
                    }
                }
            }
            ord.IsEnabled = false;
            int order_id = (((((DateTime.Now.Year*100 + DateTime.Now.Month)*100 + DateTime.Now.Day)*100 + DateTime.Now.Hour)*100 + DateTime.Now.Minute)*100+ DateTime.Now.Second);
            string sql = "insert into orders (order_id,shop_id) values(";
            sql += order_id.ToString();
            sql += ",";
            sql += worker.shopId.ToString();
            sql += ")";
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
            sc.Open();
            cmd.Connection = sc;
            cmd.CommandText = sql;
            try
            {
                using (DbDataReader reader = cmd.ExecuteReader())
                {

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
            SqlCommand cmd1 = new SqlCommand();
            SqlConnection sc1 = DBSQLServerUtils.GetDBConnection();
            sc1.Open();
            cmd1.Connection = sc1;
            ReqGood rg_s;
            for (int i = 0; i < goods_lb.Items.Count; i++)
            {
                rg_s = goods_lb.Items[i] as ReqGood;
                sql = "insert into order_list (order_id,good_id,quantity) values(";
                sql += order_id.ToString();
                sql += ",";
                sql += rg_s.id.ToString();
                sql += ",";
                sql += rg_s.quantity.ToString();
                sql += ")";
                cmd1.CommandText = sql;
                try
                {
                    using (DbDataReader reader2 = cmd1.ExecuteReader())
                    {

                    }
                }
                catch (Exception ed)
                {
                    MessageBox.Show(ed + ed.StackTrace);
                }
            }
            goods_lb.Items.Clear();
            ReqGoodsNum = 0;
            sc1.Close();
            Task.Delay(1000);
            ord.IsEnabled = true;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if(goods_lb.Items.IsEmpty)
            {
                return;
            }
            ReqGoodsNum--;
            goods_lb.Items.RemoveAt(goods_lb.Items.Count-1);
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (goodChAim.Text == null || goodChAim.Text == "")
            {
                MessageBox.Show("Поле ID товара, цена которого меняется не должно быть пустым");
                return;
            }
            if (newCost.Text == null || newCost.Text=="")
            {
                MessageBox.Show("Поле значения новой цены не должно быть пустым");
                return;
            }
            if (Int32.Parse(newCost.Text) < 0)
            {
                MessageBox.Show("Цена товара не должна быть отрицательной");
                return;
            }
            if (Int32.Parse(goodChAim.Text) <= 0)
            {
                MessageBox.Show("Недопустимое ID товара");
                return;
            }
            if (Int32.Parse(goodChAim.Text) > goodsQuant )
            {
                MessageBox.Show("Недопустимое ID товара");
                return;
            }
            
            string sql = "UPDATE G_NAMES SET COST="; sql += newCost.Text;
            sql +=" WHERE GOOD_ID="; sql += goodChAim.Text;
            SqlCommand cmd = new SqlCommand();
            SqlConnection sc = DBSQLServerUtils.GetDBConnection();
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
            }
            finally
            {
                sc.Close();
            }
            goods_id.Items.Clear();
            this.showGoods();
            MessageBox.Show("Изменения вступили в силу");
        }
    }
}
