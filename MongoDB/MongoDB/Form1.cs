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
    public partial class Form1 : Form
    {
        public static String nombre = "";
        public static String edad = "";
        public static String clientesx = "";
        //public static string[,] cliente =new string[100,3];

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MongoClient client = new MongoClient("mongodb://prueba:qwerty@ds113046.mlab.com:13046/mongoprueba");
            var db = client.GetDatabase("mongoprueba");
            var clientes = db.GetCollection<BsonDocument>("Cliente");
            /*
                        var filter = Builders<BsonDocument>.Filter.Gte("Edad", 22);
                        var sort = Builders<BsonDocument>.Sort.Ascending("Alejandro");

                        clientes.Find(filter).Sort(sort).ForEachAsync(song =>
                        clientesx = (clientesx+Convert.ToString(song["_id"])+" "+ Convert.ToString(song["Nombre"])+" "+Convert.ToString(song["Edad"])+"\r\n")

                        //MessageBox.Show("Los datos son " + song["Nombre"] + "  " + song["Edad"])
                        );

              */

            clientes.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            clientesx = (clientesx + Convert.ToString(song["_id"]) + " " + Convert.ToString(song["Nombre"]) + " " + Convert.ToString(song["Edad"]) + "\r\n")

            );





            //textBox3.Text = Datos;
            MessageBox.Show(":C");
            textBox3.Text = clientesx;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BsonDocument clientenuevo = new BsonDocument
                  {
                    { "Nombre" , textBox1.Text },
                    { "Edad" , textBox2.Text },
                  };
            BsonDocument DatosCliente = clientenuevo;

            MongoClient client = new MongoClient("mongodb://prueba:qwerty@ds113046.mlab.com:13046/mongoprueba");
            var db = client.GetDatabase("mongoprueba");
            var clientes = db.GetCollection<BsonDocument>("Cliente");
            clientes.InsertOne(DatosCliente);
        }
    }
}


