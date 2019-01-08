using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ASCIICopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           var list = GetEmojiList();
            DisplayEmojiList(list);
        }

        private void DisplayEmojiList(List<Category> list)
        {
            foreach (Category c in list)
            {
                Label lbl_cat = new Label() { Text=c.category };
                lbl_cat.AutoSize = false;
                lbl_cat.Width = this.ClientSize.Width -30;
                lbl_cat.Font = new Font(FontFamily.GenericMonospace, 20f);
                lbl_cat.TextAlign = ContentAlignment.MiddleCenter;
                lbl_cat.Margin = new Padding(0, 20, 0, 20);
                flowLayoutPanel1.SetFlowBreak(lbl_cat,true);
                flowLayoutPanel1.Controls.Add(lbl_cat);

                DisplayASCIIItems(c);
            }
        }

        private void DisplayASCIIItems(Category c)
        {
            foreach (Item item in c.items)
            {
                Button btn_ascii = new Button();
                btn_ascii.Text = item.art + Environment.NewLine + item.name;
                btn_ascii.Font = new Font(FontFamily.GenericMonospace, 14);
                btn_ascii.Padding = new Padding(5);
                btn_ascii.Width = flowLayoutPanel1.ClientSize.Width / 2 -10;
                btn_ascii.Height = 80;
                btn_ascii.Click += ASCII_click;
                flowLayoutPanel1.Controls.Add(btn_ascii);
            }

            Label empty = new Label() { Text=" "};
            flowLayoutPanel1.SetFlowBreak(empty,true);
        }

        private void ASCII_click(object sender, EventArgs e)
        {
            Button clickedBtn =(Button) sender;
            string[] infos = clickedBtn.Text.Split('\n');
            Clipboard.SetText(infos[0]);

            MessageBox.Show(clickedBtn.Text + " has copied to clipboard");
        }

        private List<Category> GetEmojiList()
        {
            string jsonContent = File.ReadAllText("smiley_content.json");

            JavaScriptSerializer converter = new JavaScriptSerializer();
            return converter.Deserialize<List<Category>>(jsonContent);
        }
    }
}
