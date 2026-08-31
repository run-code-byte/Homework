using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace day07.Book
{
    public partial class BookAdd : Form
    {
        public BookAdd()
        {
            InitializeComponent();
            ucBook1.SendData += AddBook;
        }

        private void AddBook(BookInfo book)
        {
            List<BookInfo> books=new List<BookInfo>();
            string JsonStr = "";
            if (File.Exists("./book.json"))
            {
                JsonStr = File.ReadAllText("./book.json");
                books=JsonSerializer.Deserialize<List<BookInfo>>(JsonStr);
            }
            books.Add(book);
            JsonStr = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true,
                AllowTrailingCommas=true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText("./book.json", JsonStr);
            MessageBox.Show("图书新增成功");
            this.Close();
        }
    }
}
