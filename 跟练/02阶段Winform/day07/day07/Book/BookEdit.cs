using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using day07;

namespace day07.Book
{
    public partial class BookEdit : Form
    {
        //保存要编辑的图书Id
        private string _editBookId;
        //原始图书对象
        private BookInfo _originBook;

        /// <summary>
        /// 无参构造（备用）
        /// </summary>
        public BookEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 传入图书Id进行编辑
        /// </summary>
        /// <param name="id">图书编号</param>
        public BookEdit(string id)
        {
            InitializeComponent();
            _editBookId = id;

            //1.读取json，根据id找到图书
            LoadBookById();

            //2.给用户控件回填旧数据
            if (_originBook != null)
            {
                ucBook1.SetBookInfo(_originBook);
            }

            //3.绑定保存事件，接收用户修改完成后的数据
            ucBook1.SendData += EditBookSave;
        }

        /// <summary>
        /// 根据Id读取json找到目标图书
        /// </summary>
        private void LoadBookById()
        {
            if (!File.Exists("./book.json"))
            {
                MessageBox.Show("图书文件不存在！");
                this.Close();
                return;
            }
            string jsonStr = File.ReadAllText("./book.json");
            List<BookInfo> books = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);

            //查找id匹配的图书
            _originBook = books.Find(b => b.Id == _editBookId);
            if (_originBook == null)
            {
                MessageBox.Show("没有找到该图书数据");
                this.Close();
            }
        }

        /// <summary>
        /// 编辑保存事件，UCBook点击保存触发SendData执行这里
        /// </summary>
        private void EditBookSave(BookInfo modifyBook)
        {
            List<BookInfo> books;
            string jsonStr = File.ReadAllText("./book.json");
            books = JsonSerializer.Deserialize<List<BookInfo>>(jsonStr);

            //找到对应id下标，替换对象
            int targetIndex = books.FindIndex(b => b.Id == _editBookId);
            if (targetIndex < 0)
            {
                MessageBox.Show("找不到图书，保存失败");
                return;
            }

            // 重要：Id不能被修改，保持原来的Id，防止id被篡改
            modifyBook.Id = _editBookId;
            books[targetIndex] = modifyBook;

            //序列化写回文件，和新增保持完全一样的配置
            jsonStr = JsonSerializer.Serialize(books, new JsonSerializerOptions()
            {
                WriteIndented = true,
                AllowTrailingCommas = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
            File.WriteAllText("./book.json", jsonStr);

            MessageBox.Show("图书编辑成功！");
            this.Close();
        }
    }
}
