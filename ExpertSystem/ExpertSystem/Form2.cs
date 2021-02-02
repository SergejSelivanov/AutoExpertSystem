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

namespace ExpertSystem
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string mark;
            string kuzov;
            string Korobka;
            string dvigatel;
            string privod;
            string probeg;
            string strana;
            string connStr;
            string sqlAsk;

            mark = null;
            kuzov = null;
            Korobka = null;
            dvigatel = null;
            privod = null;
            probeg = null;
            strana = null;

            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            sqlAsk = "SELECT Parameter, Results FROM ParamsRes";
            SqlCommand command21 = new SqlCommand(sqlAsk, sqlConnection);
            SqlDataReader sqlReader = null;
            sqlReader = command21.ExecuteReader();
            while (sqlReader.Read())
            {
                if (Convert.ToString(sqlReader[0]) == "Марка")
                    mark = Convert.ToString(sqlReader[1]);
                if (Convert.ToString(sqlReader[0]) == "Кузов")
                    kuzov = Convert.ToString(sqlReader[1]);
                if (Convert.ToString(sqlReader[0]) == "Коробка")
                    Korobka = Convert.ToString(sqlReader[1]);
                if (Convert.ToString(sqlReader[0]) == "Двигатель")
                    dvigatel = Convert.ToString(sqlReader[1]);
                if (Convert.ToString(sqlReader[0]) == "Привод")
                    privod = Convert.ToString(sqlReader[1]);
                if (Convert.ToString(sqlReader[0]) == "Пробег")
                    probeg = Convert.ToString(sqlReader[1]);
                if (Convert.ToString(sqlReader[0]) == "Страна")
                    strana = Convert.ToString(sqlReader[1]);
            }
            sqlReader.Close();
            sqlAsk = "SELECT Link FROM Objects WHERE Mark=@mark AND Kuzov=@kuzov AND Korobka=@Korobka AND Dvigatel=@dvigatel AND Privod=@privod AND Probeg=@probeg AND Strana=@strana";
            SqlCommand command0 = new SqlCommand(sqlAsk, sqlConnection);
            SqlParameter nameParam = new SqlParameter("@mark", mark);
            SqlParameter nameParam1 = new SqlParameter("@kuzov", kuzov);
            SqlParameter nameParam2 = new SqlParameter("@Korobka", Korobka);
            SqlParameter nameParam3 = new SqlParameter("@dvigatel", dvigatel);
            SqlParameter nameParam4 = new SqlParameter("@privod", privod);
            SqlParameter nameParam5 = new SqlParameter("@probeg", probeg);
            SqlParameter nameParam6 = new SqlParameter("@strana", strana);
            command0.Parameters.Add(nameParam);
            command0.Parameters.Add(nameParam1);
            command0.Parameters.Add(nameParam2);
            command0.Parameters.Add(nameParam3);
            command0.Parameters.Add(nameParam4);
            command0.Parameters.Add(nameParam5);
            command0.Parameters.Add(nameParam6);
            sqlReader = command0.ExecuteReader();
            while (sqlReader.Read())
            {
                linkLabel1.Text = Convert.ToString(sqlReader[0]);
            }
            sqlReader.Close();

            /*if (privod == "Полный" && probeg == "Больше" && strana == "Россия")                                    //русские
                linkLabel1.Text = "https://auto.ru/cars/used/sale/vaz/2121/1100263920-1ffcd957/";
            if (privod == "Передний" && probeg == "Больше" && strana == "Россия")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/vaz/2115/1101801606-f98122f2/";
            if (Korobka == "Автомат" && probeg == "Меньше" && strana == "Россия" && kuzov == "Седан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/vaz/vesta/1101824251-96814715/";
            if (Korobka == "Автомат" && probeg == "Меньше" && strana == "Россия" && kuzov == "Джип")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/vaz/xray/1101550948-5ea6fc7f/";
            if (Korobka == "Механика" && probeg == "Меньше" && strana == "Россия" && kuzov == "Джип")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/vaz/xray/1101561990-5cb18841/";
            if (Korobka == "Механика" && probeg == "Меньше" && strana == "Россия" && kuzov == "Седан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/vaz/vesta/1101718684-376254ec/";

            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Седан" && mark == "БМВМерседес")           //Люкс немец
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bmw/5er/1084927544-1d5bc5e9/";
            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Джип" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/mercedes/g_klasse/1101467410-1e616573/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bmw/m3/1101786330-c0c51e1c/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bmw/x5/1086836006-d9a2fea2/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bmw/3er/1095901074-5a1453dd/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bmw/x5/1092804822-2921299e/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Седан" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/mercedes/c_klasse/1101440377-9b8edb36/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Джип" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/mercedes/glk_klasse/1101593389-00b2e0fa/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/mercedes/e_klasse/1097317888-03c0bfd2/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/new/group/mercedes/glc_klasse/21558978/21565419/1101574693-2bd732a5/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/mercedes/s_klasse_amg/1101193272-2affa4f7/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "БМВМерседес")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/mercedes/g_klasse_amg/1101664266-cbf244b6/";

            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Седан" && mark == "Фольсваген")           //обычный немец
                linkLabel1.Text = "https://auto.ru/cars/used/sale/volkswagen/polo/1101808137-39755c96/";
            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Джип" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/tiguan/20692012/22247778/1101537365-f460d1b0/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/jetta/21717755/22201815/1101860228-c270d627/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/tiguan/20692012/20887652/1101860367-293eb7e3/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/jetta/21717755/22201815/1101860228-c270d627/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/tiguan/20692012/20887652/1101860367-293eb7e3/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Седан" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/volkswagen/polo/1101741922-9d9bdab1/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Германия" && kuzov == "Джип" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/volkswagen/touareg/1101617747-f62c8f0e/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/passat/21674604/22570011/1101597902-2188e4de/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/touareg/21307095/21307309/1101743442-ab4cf392/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Седан" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/passat/21674604/22570011/1101597902-2188e4de/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Германия" && kuzov == "Джип" && mark == "Фольсваген")
                linkLabel1.Text = "https://auto.ru/cars/new/group/volkswagen/touareg/21307095/21307309/1101743442-ab4cf392/";

            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Седан" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/peugeot/406/1101815544-7c829d39/";
            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Джип" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/peugeot/3008/1101759003-afdb1cb3/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/peugeot/408/1101132923-d8a24c6c/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/peugeot/3008/1101759003-afdb1cb3/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bugatti/chiron/1101749448-64a74701/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/citroen/c_crosser/1092492646-64000f99/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Седан" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/citroen/c4/1101702411-a2d6e1ad/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Джип" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/new/group/citroen/c3_aircross/21200842/21200938/1101798709-e751e39f/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/citroen/c4/1101439496-fe5c1deb/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/new/group/citroen/c5_aircross/21465409/21589132/1101798697-fa6de5b8/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/bugatti/chiron/1101749448-64a74701/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "ПежоСитроенБугатти")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/citroen/c_crosser/1101827182-77909e09/";
            if (dvigatel == "Электрический")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/tesla/model_3/1101475532-5084acaf/?from=searchline";

            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Седан" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/logan/21335454/21335688/1098533866-49584c0f/";
            if (Korobka == "Механика" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Джип" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/arkana/21593373/21593474/1101171871-f2fe4917/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/renault/talisman/1101832494-ba2fa709/";
            if (Korobka == "Механика" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/renault/duster/1101581050-1201b7a8/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/renault/talisman/1101832494-ba2fa709/";
            if (Korobka == "Механика" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/duster/20627751/21502219/1101808685-d2c69fd7/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Седан" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/logan/21335453/21335688/1101614333-f36bf966/";
            if (Korobka == "Автомат" && dvigatel == "Средний" && strana == "Франция" && kuzov == "Джип" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/kaptur/22179143/22493156/1101691321-090cf2fc/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/logan/21454467/21454719/1101298021-782c346b/";
            if (Korobka == "Автомат" && dvigatel == "Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/renault/koleos/1101813387-d43b282f/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Седан" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/renault/logan/21454467/21454719/1101298021-782c346b/";
            if (Korobka == "Автомат" && dvigatel == "Супер Сильный" && strana == "Франция" && kuzov == "Джип" && mark == "Логан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/renault/koleos/1101813387-d43b282f/";


            if (Korobka == "Механика" && mark == "Любая" && kuzov == "Седан")
                linkLabel1.Text = "https://auto.ru/cars/new/group/hyundai/solaris/21796130/21800621/1101821468-153d9e34/";
            if (Korobka == "Механика" && mark == "Любая" && kuzov == "Джип")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/chevrolet/niva/1101415121-f72570cf/";
            if (Korobka == "Автомат" && mark == "Любая" && kuzov == "Седан")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/lexus/is/1101769817-a81b2f25/";
            if (Korobka == "Автомат" && mark == "Любая" && kuzov == "Джип")
                linkLabel1.Text = "https://auto.ru/cars/used/sale/nissan/pathfinder/1101789207-91a8c7f1/";*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr;
            string sqlAsk;
            string Val;

            Val = "Ничего";
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();

            sqlAsk = "UPDATE ParamsRes SET Results = @Results";
            SqlCommand command99 = new SqlCommand(sqlAsk, sqlConnection);
            command99.Parameters.AddWithValue("Results", Val);
            command99.ExecuteNonQuery();
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}
