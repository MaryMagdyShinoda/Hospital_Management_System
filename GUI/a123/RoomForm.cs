﻿/*
 * Created by SharpDevelop.
 * User: kyrellos
 * Date: 12/29/2021
 * Time: 9:27 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a123
{
	/// <summary>
	/// Description of Form5.
	/// </summary>
	public partial class RoomForm : Form
	{
		static string cs = @"Data Source=DESKTOP-L15KNA0;Initial Catalog=Hospital;Integrated Security=True";
		SqlConnection con = new SqlConnection();
		public RoomForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public DataTable LoadRoomTable()
		{
			SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L15KNA0;Initial Catalog=Hospital;Integrated Security=True");
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Room";
			con.Open();
			SqlCommand cmd = new SqlCommand(query, con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);
			con.Close();
			return dt;
		}

		void Label4Click(object sender, EventArgs e)
		{
			Application.Exit();			
		}
		void btn_PATIENT(object sender, EventArgs e)
		{
			PatientForm pf = new PatientForm();
			pf.Show();
			this.Close();
		}
		
		void btn_DOCTOR(object sender, EventArgs e)
		{
			DoctorForm df = new DoctorForm();
			df.Show();
			this.Close();
		}
		
		
		void btn_NURSE(object sender, EventArgs e)
		{
			NurseForm nf = new NurseForm();
			nf.Show();
			this.Close();
		}
		
		void btn_DEPT(object sender, EventArgs e)
		{
			DepartmentForm depf = new DepartmentForm();
			depf.Show();
			this.Close();
		}
		
		void btn_Menu(object sender, EventArgs e)
		{
			Menu mef = new Menu();
			mef.Show();
			this.Close();
		}
		void btn_Medicine(object sender, EventArgs e)
		{
			MedicineForm mf = new MedicineForm();
			mf.Show();
			this.Close();
		}
		
		void Button14Click(object sender, EventArgs e)
		{
			
		}
		
		void Button15Click(object sender, EventArgs e)
		{
			
		}
		
		void Button16Click(object sender, EventArgs e)
		{
			
		}
		
		void Button17Click(object sender, EventArgs e)
		{
			dataGridView1.DataSource = LoadRoomTable();
		}
		void btn_Main_Menu(object sender, EventArgs e)
		{
			MainForm m = new MainForm();
			m.Show();
			this.Close();
		}

        private void button12_Click(object sender, EventArgs e)
        {
			SqlConnection con = new SqlConnection(cs);
			con.Open();
			if (con.State == System.Data.ConnectionState.Open)
			{
				string query = "INSERT INTO Room (  roomType ,roomPrice,patientId ) VALUES ( '" + textBox_Type.Text + "','" + textBox_Price.Text + "','"+fk.Text.ToString()+"')";
				SqlCommand cmd = new SqlCommand(query, con);
				cmd.ExecuteNonQuery();
				if (textBox_Type.Text == "")
				{
					MessageBox.Show("Invalid Name ");
				}
				if (textBox_Price.Text == "")
				{
					MessageBox.Show("Invalid Name ");
				}
				if (fk.Text == "")
				{
					MessageBox.Show("Invalid Name ");
				}
				con.Close();

				textBox_Type.Text = "";
				textBox_Price.Text = "";
				fk.Text = "";

				MessageBox.Show("Room Added Successfully");
				dataGridView1.DataSource = LoadRoomTable();
			}
		}

        private void button11_Click(object sender, EventArgs e)
        {
			SqlConnection con = new SqlConnection(cs);
			DataTable dt = new DataTable();
			string query = "SELECT * FROM Room WHERE roomType LIKE'%" + textBox_Search.Text + "%'";
			con.Open();
			SqlCommand cmd = new SqlCommand(query, con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);
			con.Close();
			dataGridView1.DataSource = dt;
		}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
			textBox_Type.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
			textBox_Price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
		}
    }
}
