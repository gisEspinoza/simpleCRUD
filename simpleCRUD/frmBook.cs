﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    public partial class frmBook : Form
    {
        private string action = "";
        public frmBook()
        {
            InitializeComponent();
        }
      

        private void Form1_Load(object sender, EventArgs e)
        {
            //deja un tab 
            tabs.TabPages.Remove(tabForm);

            //carga los datos en el datagridView
            //deshabilita controles
            fillDataGridView();
            controlsDisable();

        }

        //utilizado para mostrar los registros en el datagridview
        public void fillDataGridView()
        {
            //instancia de la clase libro| Book
            Book book = new Book();

            clearDataGridView();

            dtgBooks.Columns.Add("bookId", "BOOK ID");
            dtgBooks.Columns.Add("title", "TITLE");
            dtgBooks.Columns.Add("subtitle", "SUBTITLE");
            dtgBooks.Columns.Add("isbn", "ISBN");
            dtgBooks.Columns.Add("publishedDate", "PUBLISHED DATE");

            //llamado al medoto getBooks() de la clase Book
            MySqlDataReader dataReader = book.getAllBooks();

            //leer el resultado y mostrarlo en el datagridview
            while(dataReader.Read())
            {
                dtgBooks.Rows.Add(
                        dataReader.GetValue(0),
                        dataReader.GetValue(1),
                        dataReader.GetValue(2),
                        dataReader.GetValue(3),
                        dataReader.GetValue(4)
                       );
            }
        }

        public void clearDataGridView()
        {
            dtgBooks.Columns.Clear();
            dtgBooks.Rows.Clear();
        }
        //deshabilita los controles de formulario
        public void controlsDisable()
        {
            txtId.Enabled = false;
            txtTitle.Enabled = false;
            txtSubTitle.Enabled = false;
            txtISBN.Enabled = false;
            dtPublishedDate.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        //habilitar los controles de formulario
        public void controlsEnable()
        {
            txtId.Enabled = false;
            txtTitle.Enabled = true;
            txtSubTitle.Enabled = true;
            txtISBN.Enabled = true;
            dtPublishedDate.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        //limpiar el contenido de los controles
        public void clearControls()
        {
            txtId.Text = "";
            txtTitle.Text = "";
            txtSubTitle.Text = "";
            txtISBN.Text = "";
            dtPublishedDate.Text = "";
        }

          
       
        private void dtgBooks_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            tabs.TabPages.Remove(tabData);//ocultar el tab de el datagridview
            tabs.TabPages.Add(tabForm); //mostrar el formulario para los datos
            tabs.TabPages[0].Text = "EDIT BOOK";

            action = "edit";
            controlsEnable();

            txtId.Visible = true;
            txtId.ReadOnly = true;
            lblId.Visible = true;

            //cargar datos en controles
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //mediante este boton se programara para guardar y editar
        }

      

        private void btnExit_Click(object sender, EventArgs e)
        {
            //codigo del boton salir
            string mensaje = "¿Está seguró que desea salir?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void lNew_Click(object sender, EventArgs e)
        {
            tabs.TabPages.Add(tabForm);//mostrar el formulario
            tabs.TabPages.Remove(tabData); //ocultar el  tab del dataagridview
            tabs.TabPages[0].Text = "NEW BOOK"; //agregar texto al tab

            txtId.Visible = false;
            lblId.Visible = false;
            txtTitle.Focus(); //enviar enfoque al titulo
            action = "new";
            controlsEnable();
            clearControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguró que desea cancelar?";
            if (MetroFramework.MetroMessageBox.Show(this, mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearControls();
                controlsDisable();


                tabs.TabPages.Remove(tabForm);
                tabs.TabPages.Add(tabData);
                tabs.TabPages[0].Text = "BOOK LIST";
            }
        }

        private void tabForm_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }

}
