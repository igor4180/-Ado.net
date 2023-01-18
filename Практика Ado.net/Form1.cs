﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Практика_Ado.net
{
	public partial class Form1 : Form
	{
		SqlDataAdapter adapterCategory = null;
		SqlDataAdapter adapterGoods = null;
		SqlConnection connection = new SqlConnection();
		SqlCommand command = new SqlCommand();
		SqlDataReader reader = null;
		DataSet dataSetGoods = new DataSet();
		DataSet dataSetCategory = new DataSet();


		public Form1()
		{
			InitializeComponent();
		}

		private void tabPage1_Click(object sender, EventArgs e)
		{
			
		}

		private void подключитсяКБдToolStripMenuItem_Click(object sender, EventArgs e)
		{
			connection.ConnectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;
			try
			{
				adapterCategory = new SqlDataAdapter("select * from Category", connection.ConnectionString);
				adapterCategory.Fill(dataSetCategory);
				dataGridView1.DataSource = dataSetCategory.Tables[0];
				adapterGoods = new SqlDataAdapter("select * from Goods", connection.ConnectionString);
				adapterGoods.Fill(dataSetGoods);
				dataGridView2.DataSource = dataSetGoods.Tables[0];
				ts_status.Text = "Connection to bd success";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				ts_status.Text = "Connection to bd close";
			}
		}

		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabPage1)
			{
				int lastid = 1;
				if (dataGridView1.Rows.Count > 0)
				{
				 lastid = (int)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value;

				}
				AddCategory ac = new AddCategory(lastid);
				if (ac.ShowDialog() ==	DialogResult.OK)
				{

				}
			}
			else if (tabControl1.SelectedTab == tabPage2)
			{

			}
		}
	}
}
