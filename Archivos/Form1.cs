using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileStream mArchivoEscritor = new FileStream("datos.dat", FileMode.Append, FileAccess.Write);
            using (BinaryWriter Escritor = new BinaryWriter(mArchivoEscritor))
            {
                string nombre = tbName.Text;
                int edad = int.Parse(tbAge.Text);
                int nota = int.Parse(tbGrade.Text);
                char genero = char.Parse(tbGender.Text);

                Escritor.Write(nombre.Length);
                Escritor.Write(nombre.ToCharArray());
                Escritor.Write(edad);
                Escritor.Write(nota);
                Escritor.Write(genero);
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            FileStream mArchivoLector = new FileStream("datos.dat", FileMode.Open, FileAccess.Read);
            using (BinaryReader Lector = new BinaryReader(mArchivoLector))
            {
                while (mArchivoLector.Position != mArchivoLector.Length)
                {
                    int length = Lector.ReadInt32();
                    char[] nombreArreglo = Lector.ReadChars(length);
                    string nombre = new string(nombreArreglo);
                    int edad = Lector.ReadInt32();
                    int nota = Lector.ReadInt32();
                    char genero = Lector.ReadChar();

                    lbDatos.Items.Add($"Nombre: {nombre}");
                    lbDatos.Items.Add($"Edad: {edad}");
                    lbDatos.Items.Add($"Nota: {nota}");
                    lbDatos.Items.Add($"Genero: {genero}");
                }
            }
        }
    }
}
