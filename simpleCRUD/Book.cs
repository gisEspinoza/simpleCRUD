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

        //instancias a la clase Crud
        private Crud crud = new Crud();

        //metodo para retornar los registros de la tabla Book
        public MySqlDataReader getAllBooks()
        {
            string query = "SELECT bookId,title,subtitle,ISBN,publishedDate FROM book";

            //llamado al metodo select de la clase Crud
            return crud.select(query);
        }
    }
}
