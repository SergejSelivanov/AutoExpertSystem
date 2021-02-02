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
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        string Parameter;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public void ft_check_complex_rules_1(string Parameter, string Value, string Atr, string Val)
        {
            string par;
            string res;
            string connStr;
            string sqlAsk;
            string Atr1;
            string Val1;


            par = null;
            res = null;
            Atr1 = null;
            Val1 = null;

            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            SqlDataReader sqlReader = null;
            sqlAsk = "SELECT Parameter, Value FROM Answ WHERE Value = @Value AND Parameter = @Parameter";
            SqlCommand command9 = new SqlCommand(sqlAsk, sqlConnection);
            SqlParameter nameParam2 = new SqlParameter("@Value", Val);
            SqlParameter nameParam3 = new SqlParameter("@Parameter", Atr);
            command9.Parameters.Add(nameParam2);
            command9.Parameters.Add(nameParam3);
            sqlReader = command9.ExecuteReader();
            while (sqlReader.Read())
            {
                Atr1 = Convert.ToString(sqlReader[0]);
                Val1 = Convert.ToString(sqlReader[1]);

            }
            //Console.WriteLine(Atr1);
            //Console.WriteLine(Val1);
            sqlReader.Close();
            if (Atr1 == null && Val1 == null)
                return;
            //Console.WriteLine(Atr1);
            //Console.WriteLine(Val1);

            sqlAsk = "SELECT Then_Atr, Then_Value FROM RulesComplex WHERE IF2_Value = @Value AND IF2_Atr = @Parameter AND IF1_Value = @Value1 AND IF1_Atr = @Parameter1";
            SqlCommand command10 = new SqlCommand(sqlAsk, sqlConnection);

            SqlParameter nameParam4 = new SqlParameter("@Value1", Val1);
            SqlParameter nameParam5 = new SqlParameter("@Parameter1", Atr1);
            SqlParameter nameParam6 = new SqlParameter("@Value", Value);
            SqlParameter nameParam7 = new SqlParameter("@Parameter", Parameter);
            command10.Parameters.Add(nameParam4);
            command10.Parameters.Add(nameParam5);
            command10.Parameters.Add(nameParam6);
            command10.Parameters.Add(nameParam7);
            sqlReader = command10.ExecuteReader();
            while (sqlReader.Read())
            {
                par = Convert.ToString(sqlReader[0]);
                res = Convert.ToString(sqlReader[1]);
            }
            //Console.WriteLine(par);
            //Console.WriteLine(res);
            sqlReader.Close();
            if (par == null && res == null)
                return;
            sqlAsk = "UPDATE ParamsRes SET Results = @Results WHERE Parameter = @Atr";
            SqlCommand command13 = new SqlCommand(sqlAsk, sqlConnection);
            command13.Parameters.AddWithValue("Results", res);
            command13.Parameters.AddWithValue("Atr", par);
            command13.ExecuteNonQuery();
        }

        public void ft_check_complex_rules(string Parameter, string Value)
        {
            string connStr;
            string sqlAsk;
            string Atr;
            string Val; 

            Atr = null;
            Val = null;

            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            Console.WriteLine(Parameter);
            Console.WriteLine(Value);
            sqlAsk = "SELECT IF1_Atr, IF1_Value FROM RulesComplex WHERE IF2_Value = @Value AND IF2_Atr = @Parameter";
            SqlCommand command8 = new SqlCommand(sqlAsk, sqlConnection);
            SqlDataReader sqlReader = null;
            SqlParameter nameParam = new SqlParameter("@Value", Value);
            SqlParameter nameParam1 = new SqlParameter("@Parameter", Parameter);
            command8.Parameters.Add(nameParam);
            command8.Parameters.Add(nameParam1);
            sqlReader = command8.ExecuteReader();
            while (sqlReader.Read())
            {
                Atr = Convert.ToString(sqlReader[0]);
                Val = Convert.ToString(sqlReader[1]);
                ft_check_complex_rules_1(Parameter, Value, Atr, Val);
                //Console.WriteLine(Atr);
                //Console.WriteLine(Val);
            }
            sqlReader.Close();
            if (Atr == null && Val == null)
                return;
        }

        public void ft_check_rules(string Parameter, string Value)
        {
            string connStr;
            string sqlAsk;
            string Atr;
            string Val;

            Atr = null;
            Val = null;
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            sqlAsk = "SELECT Then_Atr, Then_Value FROM RulesSimple WHERE IF_Value = @Value AND IF_Atr = @Parameter";
            SqlCommand command15 = new SqlCommand(sqlAsk, sqlConnection);
            SqlDataReader sqlReader = null;
            SqlParameter nameParam = new SqlParameter("@Value", Value);
            SqlParameter nameParam1 = new SqlParameter("@Parameter", Parameter);
            command15.Parameters.Add(nameParam);
            command15.Parameters.Add(nameParam1);
            sqlReader = command15.ExecuteReader();
            while (sqlReader.Read())
            {
                Atr = Convert.ToString(sqlReader[0]);
                Val = Convert.ToString(sqlReader[1]);
            }
            sqlReader.Close();

            ft_check_complex_rules(Parameter, Value);

            if (Atr == null || Val == null)
                return;
            sqlAsk = "UPDATE ParamsRes SET Results = @Results WHERE Parameter = @Atr";
            SqlCommand command22 = new SqlCommand(sqlAsk, sqlConnection);
            command22.Parameters.AddWithValue("Results", Val);
            command22.Parameters.AddWithValue("Atr", Atr);
            command22.ExecuteNonQuery();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string connStr;
            string sqlAsk;
            string Val;

            Val = "Ничего";
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            
            sqlAsk = "UPDATE ParamsRes SET Results = @Results";
            SqlCommand command30 = new SqlCommand(sqlAsk, sqlConnection);
            command30.Parameters.AddWithValue("Results", Val);
            command30.ExecuteNonQuery();

            sqlAsk = "SELECT Question, Parameter FROM Quest WHERE id = 1";
            SqlCommand command44 = new SqlCommand(sqlAsk, sqlConnection);
            SqlDataReader sqlReader = null;
            sqlReader = command44.ExecuteReader();
            while(sqlReader.Read())
            {
                label3.Text = Convert.ToString(sqlReader[0]);
                Parameter = Convert.ToString(sqlReader[1]);
            }
            sqlReader.Close();
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr;
            string sqlAsk;
            int number;

            number = 0;
            connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\seliv\source\repos\ExpertSystem\ExpertSystem\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            sqlAsk = "INSERT INTO [Answ] (Parameter, Value)VALUES(@Parameter,@Value)"; //записываем в таблицу ответов
            SqlCommand command66 = new SqlCommand(sqlAsk, sqlConnection);
            command66.Parameters.AddWithValue("Parameter", Parameter);
            command66.Parameters.AddWithValue("Value", textBox1.Text);
            command66.ExecuteNonQuery(); //конец
            ft_check_rules(Parameter, textBox1.Text);  //Выполняем простые правила
            sqlAsk = "SELECT IF_Par, IF_Val, NextQuest FROM QuestRules"; //подбираем следующий вопрос
            SqlCommand command32 = new SqlCommand(sqlAsk, sqlConnection);
            SqlDataReader sqlReader = null;
            sqlReader = command32.ExecuteReader();
            while (sqlReader.Read())
            {
                if (Convert.ToString(sqlReader[0]) == Parameter && Convert.ToString(sqlReader[1]) == textBox1.Text)
                    number = Convert.ToInt32(sqlReader[2]);
            }
            sqlReader.Close();
            if (number == -1) //почистить таблицу
            {
                sqlAsk = "TRUNCATE TABLE Answ";
                SqlCommand command3 = new SqlCommand(sqlAsk, sqlConnection);
                command3.ExecuteNonQuery();
                Form2 fr1 = new Form2();
                fr1.Show();
                Hide();
            }
            else
            {
                sqlAsk = $"SELECT Question, Parameter FROM Quest WHERE id = {number}";
                SqlCommand command2 = new SqlCommand(sqlAsk, sqlConnection);
                sqlReader = command2.ExecuteReader();
                while (sqlReader.Read())
                {
                    label3.Text = Convert.ToString(sqlReader[0]);
                    Parameter = Convert.ToString(sqlReader[1]);
                }
            }
            textBox1.Clear();
            sqlReader.Close();
            sqlConnection.Close();
        }
    }
}
