using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DentistDatabase
{
    public partial class 建牙 : Form
    {
        public 建牙()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqlText = "EXECUTE 建牙 @患者代码='" + 查询.PatientID + "', @种植牙位='" + textBox1.Text + "'";
            OleDbConnection conn = new OleDbConnection(DBInfo.ConnectString);
            OleDbCommand cmd = new OleDbCommand();
            OleDbTransaction trans = null;

            try
            {
                conn.Open();

                trans = conn.BeginTransaction();

                cmd.Connection = conn;
                cmd.Transaction = trans;
                cmd.CommandText = sqlText;

                int result = cmd.ExecuteNonQuery();  //更新都用这个语句。

                trans.Commit();

                MessageBox.Show("添加成功");

                this.Close();
                主界面 main = new 主界面();
                main.Show();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
                // throw new ApplicationException("执行SQL语句异常:" + ex.Message + "(" + sqlText + ")");
            }
            finally
            {
                conn.Close();
            }
        }

        private void 建牙_Load(object sender, EventArgs e)
        {

        }
    }
}
