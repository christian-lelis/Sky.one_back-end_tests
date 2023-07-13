using System.Windows.Forms;
using System;
using System.Data.SqlTypes;
using MySql.Data.MySqlClient;

namespace teste_5
{
    public partial class Form2 : Form
    {

        private TextBox nome;
        private TextBox priSemestre;
        private TextBox secSemestre;
        private Label labelNomeError;
        private Label labelPriError;
        private Label labelSecError;
        private Label labelStatusRes;
        public Form2()
        {
            InitializeComponent();
            AddControles();
        }

        private void AddControles()
        {
            int height = 120;
            Label labelNome = new Label();
            labelNome.Text = "Nome do Aluno:";
            labelNome.Location = new System.Drawing.Point(100, 30);
            labelNome.Size = new System.Drawing.Size(50, 15);
            this.Controls.Add(labelNome);

            nome = new TextBox();
            nome.Location = new System.Drawing.Point(100, 50);
            nome.Size = new System.Drawing.Size(240, 20);
            this.Controls.Add(nome);

            Label labelPri = new Label();
            labelPri.Text = "Nota do 1° semestre:";
            labelPri.Location = new System.Drawing.Point(100, 100);
            labelPri.Size = new System.Drawing.Size(100, 15);
            this.Controls.Add(labelPri);

            priSemestre = new TextBox();
            priSemestre.Location = new System.Drawing.Point(100, height);
            priSemestre.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(priSemestre);

            Label labelSec = new Label();
            labelSec.Text = "Nota do 2° semestre:";
            labelSec.Location = new System.Drawing.Point(240, 100);
            labelSec.Size = new System.Drawing.Size(100, 15);
            this.Controls.Add(labelSec);

            secSemestre = new TextBox();
            secSemestre.Location = new System.Drawing.Point(240, height);
            secSemestre.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(secSemestre);

            Button btnEnviar = new Button();
            btnEnviar.Location = new System.Drawing.Point(100, 170);
            btnEnviar.Size = new System.Drawing.Size(100, 23);
            btnEnviar.Text = "Enviar";
            btnEnviar.Click += Btn_enviar;
            this.Controls.Add(btnEnviar);

            Button btnLimpar = new Button();
            btnLimpar.Location = new System.Drawing.Point(240, 170);
            btnLimpar.Size = new System.Drawing.Size(100, 23);
            btnLimpar.Text = "Limpar campos";
            btnLimpar.Click += Btn_limpar;
            this.Controls.Add(btnLimpar);

            Label labelStatus = new Label();
            labelStatus.Text = "Status do aluno:";
            labelStatus.Location = new System.Drawing.Point(100, 200);
            labelStatus.Size = new System.Drawing.Size(100, 15);
            this.Controls.Add(labelStatus);

            labelStatusRes = new Label();
            labelStatusRes.Text = "Nota não enviada.";
            labelStatusRes.Location = new System.Drawing.Point(200, 200);
            labelStatusRes.Size = new System.Drawing.Size(110, 15);
            labelStatusRes.ForeColor = System.Drawing.Color.Gray;
            this.Controls.Add(labelStatusRes);
        }
        private void Btn_enviar(object sender, EventArgs e)
        {
            if (nome.Text == "" || priSemestre.Text == "" || secSemestre.Text == "")
            {
                if (nome.Text == "")
                {
                    labelNomeError = new Label();
                    labelNomeError.Text = "Campo Obrigatório.";
                    labelNomeError.Location = new System.Drawing.Point(100, 75);
                    labelNomeError.Size = new System.Drawing.Size(150, 35);
                    labelNomeError.ForeColor = Color.Red;
                    this.Controls.Add(labelNomeError);
                    return;
                }
                if (priSemestre.Text == "")
                {
                    labelPriError = new Label();
                    labelPriError.Text = "Campo Obrigatório.";
                    labelPriError.Location = new System.Drawing.Point(100, 145);
                    labelPriError.Size = new System.Drawing.Size(120, 35);
                    labelPriError.ForeColor = Color.Red;
                    this.Controls.Add(labelPriError);
                    return;
                }
                if (secSemestre.Text == "")
                {
                    labelSecError = new Label();
                    labelSecError.Text = "Campo Obrigatório.";
                    labelSecError.Location = new System.Drawing.Point(240, 145);
                    labelSecError.Size = new System.Drawing.Size(120, 35);
                    labelSecError.ForeColor = Color.Red;
                    this.Controls.Add(labelSecError);
                    return;
                }
            }
            decimal pri = Convert.ToDecimal(priSemestre.Text);
            decimal sec = Convert.ToDecimal(secSemestre.Text);
            decimal media = (pri + sec) / 2;
            if (media > Convert.ToDecimal(6.5))
            {
                labelStatusRes.ForeColor = Color.Green;
                labelStatusRes.Text = "Aprovado!";
            }
            else
            {
                labelStatusRes.ForeColor = Color.Red;
                labelStatusRes.Text = "Reporvado!";
            }
            using (MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=alunos;Uid=root;"))
            {
                conexao.Open();
                String sql = "insert into quadro_notas (ano,nome,nota_1_semestre,nota_2_semestre) values (2022,@nome,@pri,@sec)";
                using (MySqlCommand comando = new MySqlCommand(sql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", nome.Text);
                    comando.Parameters.AddWithValue("@pri", pri);
                    comando.Parameters.AddWithValue("@sec", sec);
                    comando.ExecuteNonQuery();
                }
            }
        }
        private void Btn_limpar(object sender, EventArgs e)
        {
            nome.Text = "";
            priSemestre.Text = "";
            secSemestre.Text = "";
            if (labelNomeError != null)
            {
                labelNomeError.Text = "";
            }
            if (labelPriError != null)
            {
                labelPriError.Text = "";
            }
            if (labelSecError != null)
            {
                labelSecError.Text = "";
            }
            labelStatusRes.Text = "Nota não enviada.";
            labelStatusRes.ForeColor = Color.Gray;
        }
    }
}

