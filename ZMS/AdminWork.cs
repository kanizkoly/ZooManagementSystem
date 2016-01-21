using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZMS
{
    public partial class AdminWork : Form
    {
        public AdminWork()
        {
            InitializeComponent();
            ShowAnimal();
            ShowTreatment();
            ShowFood();
            ShowSupply();
            AutoCompleteAnimalSerial();
        }

        DataTable animal;
        DataTable treatment;
        DataTable food;
        DataTable supply;
        string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ZMS_DB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        string AnimalGender;

        private void AnimalTextFildClear()
        {
            textBoxAnimalSerial.Text = "";
            textBoxAnimalName.Text = "";
            textBoxAnimalAge.Text = "";
            radioButtonAnimalFemale.Checked = false;
            radioButtonAnimalMale.Checked = false;
            textBoxAnimalSource.Text = "";
            textBoxAnimalShedNo.Text = "";
            dateTimePickerAnimal.Text = "";

            textBoxTreatmentSerial.Text = "";
            textBoxTreatmentNo.Text = "";
            textBoxTreatmentName.Text = "";
            textBoxTreatmentShadNo.Text = "";
            textBoxTreatmentDisease.Text = "";
            textBoxTreatmentMedicine.Text = "";

            textBoxFoodAnimalSerial.Text = "";
            textBoxFoodAnimalName.Text = "";
            textBoxFoodName.Text = "";
            textBoxFoodQuantity.Text = "";
            textBoxFoodPrice.Text = "";    
        }

        private void AutoCompleteAnimalSerial()
        {
            //auto completes Employee name in check out page.
            textBoxTreatmentSerial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxTreatmentSerial.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection1 = new AutoCompleteStringCollection();

            textBoxFoodAnimalSerial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxFoodAnimalSerial.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection collection2 = new AutoCompleteStringCollection();

            SqlConnection connection = new SqlConnection(connectionString);
            string commandString = "SELECT aserial FROM animal";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    string value = myReader["aserial"].ToString();
                    collection1.Add(value);
                    collection2.Add(value);
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBoxTreatmentSerial.AutoCompleteCustomSource = collection1;
            textBoxFoodAnimalSerial.AutoCompleteCustomSource = collection2;
            NameShadeShow();
        }

        private void NameShadeShow()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string commandString = "SELECT aname, ashedno FROM animal WHERE aserial='" + textBoxTreatmentSerial.Text + "'OR aserial='" + textBoxFoodAnimalSerial.Text + "'";
            SqlCommand command = new SqlCommand(commandString, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = command.ExecuteReader();
                while (myReader.Read())
                {
                    string name = myReader["aname"].ToString();
                    string shedno = myReader["ashedno"].ToString();
                    textBoxTreatmentName.Text = name;
                    textBoxTreatmentShadNo.Text = shedno;
                    textBoxFoodAnimalName.Text = name;
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowAnimal()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "SELECT aserial AS 'Serial',aname AS 'Name',aage AS 'Age',agender AS 'Gender',asource AS 'Source',ashedno AS 'Shed No.',adate AS 'Arrival Date' FROM animal";
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                animal = new DataTable();
                dataAdapter.Fill(animal);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = animal;
                dataGridViewAnimal.DataSource = bsource;
                dataAdapter.Update(animal);
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAnimal()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "INSERT INTO animal(aserial,aname,aage,agender,asource,ashedno,adate) VALUES('" + textBoxAnimalSerial.Text + "','" + textBoxAnimalName.Text + "','" + textBoxAnimalAge.Text + "','" + AnimalGender + "','" + textBoxAnimalSource.Text + "','" + textBoxAnimalShedNo.Text + "','" + dateTimePickerAnimal.Text + "')";
                SqlCommand InsertCommand = new SqlCommand(commandString, connection);
                InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Animal successfully added to the database.", "Congratulations");
                AnimalTextFildClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                AnimalTextFildClear();
            }
        }

        private void DeleteAnimal()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "DELETE FROM animal WHERE aserial='" + textBoxAnimalSerial.Text + "'";
                SqlCommand InsertCommand = new SqlCommand(commandString, connection);
                InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Animal successfully deleted from database.", "Congratulations");
                AnimalTextFildClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                AnimalTextFildClear();
            }
        }

        private void UpdateAnimal()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "UPDATE animal SET aname='" + textBoxAnimalName.Text + "',aage='" + textBoxAnimalAge.Text + "',agender='" + AnimalGender + "',asource='" + textBoxAnimalSource.Text + "',ashedno='" + textBoxAnimalShedNo.Text + "',adate='" + dateTimePickerAnimal.Text + "' WHERE aserial='" + textBoxAnimalSerial.Text + "'";
                SqlCommand InsertCommand = new SqlCommand(commandString, connection);
                InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Animal successfully updated into the database.", "Congratulations");
                AnimalTextFildClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                AnimalTextFildClear();
            }
        }

        private void ShowTreatment()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "SELECT treatment.tid AS 'Treatment Id',treatment.tdate AS 'Date',treatment.tserial AS 'Animal Serial',animal.ashedno AS 'Shed No',animal.aname AS 'Name',animal.aage AS 'Age',treatment.tdisease AS 'Disease',treatment.tmedicine AS 'Medicine' FROM treatment INNER JOIN animal ON treatment.tserial=animal.aserial";
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                treatment = new DataTable();
                dataAdapter.Fill(treatment);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = treatment;
                dataGridViewTreatment.DataSource = bsource;
                dataAdapter.Update(treatment);
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TreatmentInsert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "INSERT INTO treatment(tid,tdate,tserial,tdisease,tmedicine) VALUES('" + textBoxTreatmentNo.Text + "','" + textBoxTreatmentDate.Text + "','" + textBoxTreatmentSerial.Text + "','" + textBoxTreatmentDisease.Text + "','" + textBoxTreatmentMedicine.Text + "')";
                SqlCommand InsertCommand = new SqlCommand(commandString, connection);
                InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Treatment successfully added to the database.", "Congratulations");
                AnimalTextFildClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                AnimalTextFildClear();
            }
        }


        private void ShowFood()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "SELECT food.fid AS 'Food Id',animal.aserial AS 'Animal Serial',animal.ashedno AS 'Animal ShedNo',animal.aname AS 'Animal_Name', food.fname AS 'Food_Name',food.fquantity AS 'Food Quantity',food.fprice AS 'Food Price',food.fdate AS 'Feeding Date' FROM food INNER JOIN animal ON animal.aserial=food.fserial";
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                food = new DataTable();
                dataAdapter.Fill(food);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = food;
                dataGridViewFood.DataSource = bsource;
                dataAdapter.Update(food);
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FoodInsert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "INSERT INTO food(fname,fquantity,fprice,fdate,fserial) VALUES('" + textBoxFoodName.Text + "','" + textBoxFoodQuantity.Text + "','" + TimePickerFoodPurchase.Text + "','" + textBoxFoodPrice.Text + "','" + textBoxFoodAnimalSerial.Text + "')";
                SqlCommand InsertCommand = new SqlCommand(commandString, connection);
                InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Food successfully added to the database.", "Congratulations");
                AnimalTextFildClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                AnimalTextFildClear();
            }
        }

        //
        //test
        private void ShowSupply()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "SELECT oid AS 'Order_No',odate AS 'Order Date',sname AS 'Supplier_Name',saddress AS 'Supplier Address',sphone AS 'Supplier Phone',fname AS 'Food_Item',fquantity AS 'Food Quantity',fprice AS 'Food Price' FROM supply";
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                supply = new DataTable();
                dataAdapter.Fill(supply);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = supply;
                dataGridViewSupply.DataSource = bsource;
                dataAdapter.Update(supply);
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SupplyInsert()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string commandString = "INSERT INTO supply(oid,odate,sname,saddress,sphone,fname,fquantity,fprice) VALUES('" + textBoxOrderNo.Text + "','" + DateTimeOrderDate.Text + "','" + textBoxSupplyName.Text + "','" + textBoxSupplyAddress.Text + "','" + textBoxSupplyPhone.Text + "','" + comboBoxFoodItem.Text + "','" + numericQuantity.Text + "','" + textBoxPrice.Text + "')";
                SqlCommand InsertCommand = new SqlCommand(commandString, connection);
                InsertCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Supply successfully added to the database.", "Congratulations");
                AnimalTextFildClear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                AnimalTextFildClear();
            }
        }

        //test
        //

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out?", "Warning",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Hide();
                Coverpage go = new Coverpage();
                go.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void labelSource_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out?", "Warning",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Hide();
                Coverpage go = new Coverpage();
                go.ShowDialog();
            }
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question,
          MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button7Log_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out?", "Warning",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                       MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Hide();
                Coverpage go = new Coverpage();
                go.ShowDialog();
            }
        }

        private void button6Ex_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question,
         MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void labelFID_Click(object sender, EventArgs e)
        {

        }

        private void labelMedicine_Click(object sender, EventArgs e)
        {

        }

        private void panelFoodSupply_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBoxOrderInfo_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAddAnimal_Click(object sender, EventArgs e)
        {
            AddAnimal();
            ShowAnimal();
            AnimalTextFildClear();
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            AnimalGender = "Female";
        }

        private void radioButtonAnimalMale_CheckedChanged(object sender, EventArgs e)
        {
            AnimalGender = "Male";
        }

        private void buttonUpdateAnimal_Click(object sender, EventArgs e)
        {
            UpdateAnimal();
            ShowAnimal();
            AnimalTextFildClear();
        }

        private void buttonDeleteAnimal_Click(object sender, EventArgs e)
        {
            DeleteAnimal();
            ShowAnimal();
            AnimalTextFildClear();
        }

        private void dataGridViewAnimal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewAnimal.Rows[e.RowIndex];

                    textBoxAnimalSerial.Text = row.Cells["Serial"].Value.ToString();
                    textBoxAnimalName.Text = row.Cells["Name"].Value.ToString();
                    textBoxAnimalAge.Text = row.Cells["Age"].Value.ToString();
                    AnimalGender = row.Cells["Gender"].Value.ToString();
                    textBoxAnimalSource.Text = row.Cells["Source"].Value.ToString();
                    textBoxAnimalShedNo.Text = row.Cells["Shed No."].Value.ToString();
                    dateTimePickerAnimal.Text = row.Cells["Arrival Date"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxSerialNo_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(animal);
            DV.RowFilter = string.Format("Serial LIKE '{0}%'", textBoxSerialNo.Text);
            dataGridViewAnimal.DataSource = DV;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(animal);
            DV.RowFilter = string.Format("Name LIKE '{0}%'", textBoxName.Text);
            dataGridViewAnimal.DataSource = DV;
        }

        private void textBoxTreatmentSerial_Enter(object sender, EventArgs e)
        {
            //NameShadeShow();
        }

        private void textBoxTreatmentSerial_TextChanged(object sender, EventArgs e)
        {
            NameShadeShow();
        }

        private void buttonTreatmentInsert_Click(object sender, EventArgs e)
        {
            TreatmentInsert();
            ShowTreatment();
            AnimalTextFildClear();
            
        }

        private void textBoxTreatmentNameSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(treatment);
            DV.RowFilter = string.Format("Name LIKE '{0}%'", textBoxTreatmentNameSearch.Text);
            dataGridViewTreatment.DataSource = DV;
        }

        private void textBoxTreatmentDiseaseSearch_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(treatment);
            DV.RowFilter = string.Format("Disease LIKE '{0}%'", textBoxTreatmentDiseaseSearch.Text);
            dataGridViewTreatment.DataSource = DV;
        }

        private void buttonFoodLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out?", "Warning",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question,
           MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Hide();
                Coverpage go = new Coverpage();
                go.ShowDialog();
            }
        }

        private void buttonFoodExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBoxFoodAnimalSerial_TextChanged(object sender, EventArgs e)
        {
            NameShadeShow();
        }

        private void buttonFoodInsert_Click(object sender, EventArgs e)
        {
            FoodInsert();
            ShowFood();
            AnimalTextFildClear();
        }

        private void textBoxFoodSearchName_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(food);
            DV.RowFilter = string.Format("Animal_Name LIKE '{0}%'", textBoxFoodSearchName.Text);
            dataGridViewFood.DataSource = DV;
        }

        private void textBoxFoodSearchItem_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(food);
            DV.RowFilter = string.Format("Food_Name LIKE '{0}%'", textBoxFoodSearchItem.Text);
            dataGridViewFood.DataSource = DV;
        }

        private void buttonSupplyExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Warning",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonSupplyInsert_Click(object sender, EventArgs e)
        {
            SupplyInsert();
            ShowSupply();
            AnimalTextFildClear();
        }

        private void textBoxSearchOrder_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(supply);
            DV.RowFilter =  string.Format("Order_No LIKE '{0}%'", textBoxSearchOrder.Text);
            dataGridViewSupply.DataSource = DV;
        }

        private void textBoxSearchSupply_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(supply);
            DV.RowFilter = string.Format("Supplier_Name LIKE '{0}%'", textBoxSearchSupply.Text);
            dataGridViewSupply.DataSource = DV;
        }

        private void textBoxSearchFood_TextChanged(object sender, EventArgs e)
        {
            DataView DV = new DataView(supply);
            DV.RowFilter = string.Format("Food_Item LIKE '{0}%'", textBoxSearchSupplyFood.Text);
            dataGridViewSupply.DataSource = DV;
        }
    }
}
