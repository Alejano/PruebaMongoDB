using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoDB
{
    public partial class EliminadMDB : Form
    {
        public static String clientesx = "";
        
        public static string IDC = "";
        public EliminadMDB()
        {
            InitializeComponent();
        }

        private void EliminadMDB_Load(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://prueba:qwerty@ds113046.mlab.com:13046/mongoprueba");
            var db = client.GetDatabase("mongoprueba");
            var clientes = db.GetCollection<BsonDocument>("Cliente");
            var filter = Builders<BsonDocument>.Filter.Eq("_id",IDC);

            clientes.AsQueryable<BsonDocument>().ToList().ForEach(song =>
           clientesx = (clientesx + Convert.ToString(song["_id"]) + " " + Convert.ToString(song["Nombre"]) + " " + Convert.ToString(song["Edad"]) + "\r\n")

           );

            textBox1.Text = clientesx;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Form1 f1 = new Form1();
            f1.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDC = textBox2.Text;
           

            MessageBox.Show("Preparando carga");

            MongoClient client = new MongoClient("mongodb://prueba:qwerty@ds113046.mlab.com:13046/mongoprueba");
            var db = client.GetDatabase("mongoprueba");
            var clientes = db.GetCollection<BsonDocument>("Cliente");

            //deleting single record
             clientes.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Nombre", IDC));

            MessageBox.Show("cargando");


            clientesx = "";
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
