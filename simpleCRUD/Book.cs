using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace simpleCRUD
{
    class Book
    {
        //propiedades
        public int _bookId { get; set; }
        public string _title { get; set; }
        public string _subtitle { get; set; }
        public string _ISBN { get; set; }
        public string _publishedDate { get; set; }

        //instancia a la clase Crud
        private Crud crud = new Crud();

        //metodo para retornar los registros de la tabla Book
        public MySqlDataReader getAllBooks()
        {
            string query = "SELECT bookId,title,subtitle,ISBN,publishedDate FROM book";

            //llamado al metodo select de la clase Crud
            return crud.select(query);
        }

        //metodo para insertar o editar un registro
        public Boolean newEditBook(string action)
        {
            if (action == "new")
            {
                string query = "INSERT INTO book(title, subtitle, ISBN, publishedDate)" +
                    "VALUES ('" + _title + "', '" + _subtitle + "', '" + _ISBN + "', '" + _publishedDate + "')";
                crud.executeQuery(query); //llamato al metodo executeQuery de la clase Crud
                return true;
            }
            else if (action == "edit")
            {
                string query = "UPDATE book SET "
                    + "title='" + _title + "' ,"
                    + "subtitle='" + _subtitle + "',"
                    + "isbn='" + _ISBN + "',"
                    + "publishedDate='" + _publishedDate + "'"
                    + "WHERE "
                    + "bookId='" + _bookId + "'";
                crud.executeQuery(query);
                return true;
            }

            return false;
        }

        //metodo para eliminar
        public Boolean deleteBook()
        {
            string query = "DELETE FROM book WHERE bookId='" + _bookId + "'";
            crud.executeQuery(query);
            return true;
        }
    }
}