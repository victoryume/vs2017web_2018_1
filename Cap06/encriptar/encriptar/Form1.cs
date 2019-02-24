using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encriptar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = "123456";
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 20))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] key = deriveBytes.GetBytes(20);

                string encodeSalt = Convert.ToBase64String(salt);
                string encodeKey = Convert.ToBase64String(key);

            }

            string encodeSaltDB = "7RC1NTLhXNNFyzzmSgCOhHqv09M=";
            string encodeKeyDB = "6j7WWvNartSVdI7zswQz++DQoFs=";

            byte[] saltDB = Convert.FromBase64String(encodeSaltDB);
            byte[] keyDB = Convert.FromBase64String(encodeKeyDB);
            
            string password2 = "123456";
            using (var deriveBytes = new Rfc2898DeriveBytes(password2, saltDB))
            {
                byte[] testKey = deriveBytes.GetBytes(20);

                if (testKey.SequenceEqual(keyDB))
                {
                    MessageBox.Show("Password válido");
                }
                else {
                    MessageBox.Show("Password no válido");
                }
            }
        }
    }
}
