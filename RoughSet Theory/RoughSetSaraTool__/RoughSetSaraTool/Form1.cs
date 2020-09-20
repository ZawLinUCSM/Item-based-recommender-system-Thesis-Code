using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RoughSetSaraTool
{
    //Coding By Sara El-Sayed El-Metwally @ Friday, April 05, 2013 9:00 pm
    // Assistant Lecturer , Faculty of Computers & Information Sciences, Mansoura University ,Eygpt.
    // Email: sarah_almetwally4@yahoo.com 
    public partial class Form1 : Form
    {
        StreamReader Tabel = new StreamReader("Tabel.txt");
        List<Object> elments_of_Universe = new List<Object>();
        private void Prepare_Data_Table()
        {
            try
            {
                
                int index = 0;
                while (Tabel.EndOfStream != true)
                {
                    string row = Tabel.ReadLine();
                    string[] Values = row.Split(new char[] { ',' });
                    List<Attribute> attr_values = new List<Attribute>();
                    for (int i = 0; i < Values.Length; i++)
                    {
                        Attribute x = new Attribute((char)(97 + i), (int.Parse(Values[i])));
                        attr_values.Add(x);
                    }
                    index++;
                    Object xx = new Object(index, attr_values);
                    elments_of_Universe.Add(xx);
                }

            }

            finally
            {
                Tabel.Close();

            }
        
        
        
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.ColumnCount = elments_of_Universe[0].__Attribute_Values.Count + 1;
            for (int i = 0; i < this.dataGridView1.ColumnCount; i++)
            {
                this.dataGridView1.Columns[i].Width = 25;//18 for positive values

            }
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.RowCount = elments_of_Universe.Count+1;
            DataGridViewCellStyle CellStyle1 = new DataGridViewCellStyle();
            CellStyle1.BackColor = Color.LightGreen;
            for (int j = 1; j < this.dataGridView1.RowCount; j++)
            {

                this.dataGridView1.Rows[j].Cells[0].Value = elments_of_Universe[j - 1].__Name;
                this.dataGridView1.Rows[j].Cells[0].Style = CellStyle1;
                
            }
            DataGridViewCellStyle CellStyle2 = new DataGridViewCellStyle();
            CellStyle2.BackColor = Color.LightPink;
            for (int i = 1; i < this.dataGridView1.ColumnCount; i++)
            {
                this.dataGridView1.Rows[0].Cells[i].Value = elments_of_Universe[0].__Attribute_Values[i - 1].Name;
                this.dataGridView1.Rows[0].Cells[i].Style = CellStyle2;
                
            }
            for (int j = 1; j < this.dataGridView1.RowCount; j++)
            {
                for (int i = 1; i < this.dataGridView1.ColumnCount; i++)
                {

                    this.dataGridView1.Rows[j].Cells[i].Value = elments_of_Universe[j-1].__Attribute_Values[i - 1].value;

                }

            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.ColumnCount = 2;
            this.dataGridView2.Columns[0].Width = 130;
            this.dataGridView2.Columns[1].Width = 170;
            this.dataGridView2.RowCount = 6;
            this.dataGridView2.Rows[0].Cells[0].Value = "Indicernibility(Attributes)";
            this.dataGridView2.Rows[0].Cells[0].Value = "Indispensable Attributes";
            this.dataGridView2.Rows[1].Cells[0].Value = "Dispensable Attributes";
            this.dataGridView2.Rows[2].Cells[0].Value = "Core";
            this.dataGridView2.Rows[3].Cells[0].Value = "Reducts";
            this.dataGridView2.Rows[4].Cells[0].Value = "IND(Attributes)";
            this.dataGridView2.Rows[5].Cells[0].Value = "IND(Attributes-{a})";
            RoughSet RouObj = new RoughSet(elments_of_Universe);
            List<object> Indispen = RouObj.Indispensable();
            if (Indispen.Count == 0)
            { 
                this.dataGridView2.Rows[0].Cells[1].Value = "---";
                this.dataGridView2.Rows[2].Cells[1].Value = "---";
            
            }
            else
            {
                for (int i = 0; i < Indispen.Count; i++)
                {
                    if (i == Indispen.Count - 1)
                    {

                        this.dataGridView2.Rows[0].Cells[1].Value += Indispen[i].ToString() ;
                        this.dataGridView2.Rows[2].Cells[1].Value += Indispen[i].ToString() ;
                    
                    }
                    else
                    {

                        this.dataGridView2.Rows[0].Cells[1].Value += Indispen[i].ToString() + ",";
                        this.dataGridView2.Rows[2].Cells[1].Value += Indispen[i].ToString() + ",";
                    
                    
                    }
                    
                }
            }
            List<object> Dispen = RouObj.Dispensable();
            if (Dispen.Count == 0)
           
                this.dataGridView2.Rows[1].Cells[1].Value = "---";
                           
            else
            {
                for (int i = 0; i < Dispen.Count; i++)
                {
                    if (i == Dispen.Count- 1)
                    this.dataGridView2.Rows[1].Cells[1].Value += Dispen[i].ToString() ;
                    else
                    this.dataGridView2.Rows[1].Cells[1].Value += Dispen[i].ToString() + ",";

                }
            }
            
            List<object> Reducts = RouObj.Reducts();
            if (Reducts.Count == 0)

                this.dataGridView2.Rows[3].Cells[1].Value = "---";


            else
            {
                for (int i = 0; i < Reducts.Count; i++)
                {
                    if(i==Reducts.Count-1)
                    this.dataGridView2.Rows[3].Cells[1].Value += Reducts[i].ToString() ;
                    else
                    this.dataGridView2.Rows[3].Cells[1].Value += Reducts[i].ToString() + ",";


                }
            }

            List<List<object>> Indecirnibility = RouObj.Indecernibility();
            for (int i = 0;i< Indecirnibility.Count; i++)
            {
                this.dataGridView2.Rows[4].Cells[1].Value += "{";
                for (int j = 0; j < Indecirnibility[i].Count; j++)
                {

                    if(j==Indecirnibility[i].Count-1)
                    this.dataGridView2.Rows[4].Cells[1].Value += Indecirnibility[i][j].ToString();
                    else
                    this.dataGridView2.Rows[4].Cells[1].Value += Indecirnibility[i][j].ToString() + ",";
                
                }

                this.dataGridView2.Rows[4].Cells[1].Value += "},";
            
            
            }
            List<List<object>> Indecirnibility_a = RouObj.Indecernibility("a");
            for (int i = 0; i < Indecirnibility_a.Count; i++)
            {
                this.dataGridView2.Rows[5].Cells[1].Value += "{";
                for (int j = 0; j < Indecirnibility_a[i].Count; j++)
                {

                    if (j == Indecirnibility_a[i].Count - 1)
                        this.dataGridView2.Rows[5].Cells[1].Value += Indecirnibility_a[i][j].ToString();
                    else
                        this.dataGridView2.Rows[5].Cells[1].Value += Indecirnibility_a[i][j].ToString() + ",";

                }

                this.dataGridView2.Rows[5].Cells[1].Value += "},";


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Prepare_Data_Table();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
