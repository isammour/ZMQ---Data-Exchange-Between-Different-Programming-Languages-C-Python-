using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmq_Sockets
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var requestSocket = new RequestSocket("tcp://127.0.0.1:5555"))
            {
                var person = new Person
                {
                    Name = nameTextBox.Text,
                    Age = Int32.Parse(ageTextBox.Text)
                };

                var serializedPerson = JsonConvert.SerializeObject(person);
                requestSocket.SendFrame(serializedPerson);
            }
        }
    }
}
