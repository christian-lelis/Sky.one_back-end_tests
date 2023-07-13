using System;
using System.Windows.Forms;

namespace teste_4
{
    public partial class Form1 : Form
    {

        private TextBox textBox;
        private TextBox textBox1;
        public Form1()
        {
            InitializeComponent();
            AdicionarControles();
        }

        private void AdicionarControles()
        {
            int height = 90;
            Label label = new Label();
            label.Text = "Login";
            label.Location = new System.Drawing.Point(50, 70);
            label.Size = new System.Drawing.Size(50, 15);

            this.Controls.Add(label);

            textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(50, height);
            textBox.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(textBox);

            Label label1 = new Label();
            label1.Text = "Senha";
            label1.Location = new System.Drawing.Point(160, 70);
            label1.Size = new System.Drawing.Size(50, 15);
            this.Controls.Add(label1);

            textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(160, height);
            textBox1.Size = new System.Drawing.Size(100, 20);
            textBox1.UseSystemPasswordChar = true;
            this.Controls.Add(textBox1);

            Button button = new Button();
            button.Location = new System.Drawing.Point(270, height);
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Entrar";
            button.Click += Button_Click;
            this.Controls.Add(button);
        }
        Label label2 = new Label();

        private void Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox.Text == "")
            {
                label2.Text = "O Login é obrigatório.";
                label2.Location = new System.Drawing.Point(48, 120);
                label2.Size = new System.Drawing.Size(130, 25);
                label2.ForeColor = System.Drawing.Color.Red;
                this.Controls.Add(label2);
            }
            else
            {
                label2.Text = "";
                MessageBox.Show("Me contrata pf 😭");
            }
        }
    }
}
