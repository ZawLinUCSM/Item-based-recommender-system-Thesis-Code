using DataObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoughSetTheory
{
    public partial class Form1 : Form
    {
        #region Variables
        TestConnection connectionObj;
        AttributesInfo _attributeInfo;
        DataTable _medicalDataTable;
        DataTable _attributeDataTable;
        StreamReader Tabel = new StreamReader("RoughSetData.txt");
        List<Object> elments_of_Universe = new List<Object>();
        ArrayList infoList = new ArrayList();
        #endregion

        public Form1()
        {
            InitializeComponent();

            // Initialize Objects 
            connectionObj = new TestConnection();
            _medicalDataTable = new DataObject.AttributeDataset.MedicalDataDataTable();
            // Bind table to medical grid view.
            dgvMedicalList.DataSource = _medicalDataTable;

            _attributeDataTable = new DataObject.AttributeDataset.AttributeListDataTable();
            // Bind table to attribute grid view.
            dgvAttributeList.DataSource = _attributeDataTable;
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            bool isConnection = connectionObj.TestDBConnection();
            MessageBox.Show("Connection Success");
        }

        private void btnGetAttribute_Click(object sender, EventArgs e)
        {
            infoList.Add("TH");
            infoList.Add("HU");
            infoList.Add("FU");
            infoList.Add("WL");
            infoList.Add("TI");
            //infoList.Add("DB");

            Prepare_Data_Table();
            // Generate RoughSet
            GenerateRoughSet();
        }

        private void GenerateRoughSet()
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

            // Find Indispen Objects from RoughSet Object.
            #region Indispensable Lists

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
                        this.dataGridView2.Rows[0].Cells[1].Value += Indispen[i].ToString();
                        this.dataGridView2.Rows[2].Cells[1].Value += Indispen[i].ToString();

                    }
                    else
                    {

                        this.dataGridView2.Rows[0].Cells[1].Value += Indispen[i].ToString() + ",";
                        this.dataGridView2.Rows[2].Cells[1].Value += Indispen[i].ToString() + ",";

                    }

                }
            }

            #endregion

            // Find Dispen Objects from RoughSet Object.
            #region Dispensable Lists
            List<object> Dispen = RouObj.Dispensable();
            if (Dispen.Count == 0)

                this.dataGridView2.Rows[1].Cells[1].Value = "---";

            else
            {
                for (int i = 0; i < Dispen.Count; i++)
                {
                    if (i == Dispen.Count - 1)
                        this.dataGridView2.Rows[1].Cells[1].Value += Dispen[i].ToString();
                    else
                        this.dataGridView2.Rows[1].Cells[1].Value += Dispen[i].ToString() + ",";

                }
            }

            #endregion

            // Find Reduct Objects from RoughSet Object.
            #region Reducts Lists
            List<object> Reducts = RouObj.Reducts();
            if (Reducts.Count == 0)

                this.dataGridView2.Rows[3].Cells[1].Value = "---";

            else
            {
                for (int i = 0; i < Reducts.Count; i++)
                {
                    if (i == Reducts.Count - 1)
                        this.dataGridView2.Rows[3].Cells[1].Value += Reducts[i].ToString();
                    else
                        this.dataGridView2.Rows[3].Cells[1].Value += Reducts[i].ToString() + ",";

                }
            }

            #endregion

            // Find Indcernibility Objects from RoughSet Object.
            #region Indecernibility Lists
            List<List<object>> Indecirnibility = RouObj.Indecernibility();
            for (int i = 0; i < Indecirnibility.Count; i++)
            {
                this.dataGridView2.Rows[4].Cells[1].Value += "{";
                for (int j = 0; j < Indecirnibility[i].Count; j++)
                {

                    if (j == Indecirnibility[i].Count - 1)
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

            #endregion

        }    
        private void Prepare_Data_Table()
        {
            try
            {

                int index = 0;               
                while (Tabel.EndOfStream != true)
                {
                    string row = Tabel.ReadLine();
                    string[] Values = row.Split(new char[] { '\t' });
                    List<Attribute> attr_values = new List<Attribute>();
                    for (int i = 0; i < Values.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(Values [i]))
                        {
                            //Attribute x = new Attribute((char)(97 + i), (int.Parse(Values[i])));
                            Attribute x = new Attribute(infoList[i], (int.Parse(Values[i])));
                            attr_values.Add(x);
                        }
                       
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
        private void btnRetrieveMedicalData_Click(object sender, EventArgs e)
        {
            AttributesInfo.RetrieveMedicalList(_medicalDataTable);
        }

        #region Old
        private void GenerateAttributes()
        {
            // Generate Diabetes
            GenerateDiabetes();

            // Generate Thrist
            GenerateThrits();

            // Generate Hunger
            GenerateHunger();

            // Generate FrequentUrination
            GenerateFrequentUrination();

            // Generate WeightLoss
            GenerateWeightLosss();

            // Generate Tiredness
            GenerateTiredNess();
        }

        private void GenerateTiredNess()
        {
            throw new NotImplementedException();
        }

        private void GenerateWeightLosss()
        {
            throw new NotImplementedException();
        }

        private void GenerateFrequentUrination()
        {
            throw new NotImplementedException();
        }

        private void GenerateHunger()
        {
            throw new NotImplementedException();
        }

        private void GenerateThrits()
        {
            throw new NotImplementedException();
        }

        private void GenerateDiabetes()
        {

        }
        #endregion
    }
}
