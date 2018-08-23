using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Proyecto1Arqui
{
	public partial class Form1 : Form
	{
		ArrayList listaPalabras = new ArrayList();
		public Form1()
		{
			InitializeComponent();
			leerTexto();
		}

		public void leerTexto() {
			String linea = null;
			using(StreamReader leer = new StreamReader(@"C:\Users\USER\Documents\TEC\Arqui\pruebaPrograDocx.docx"))
			{
				while(!leer.EndOfStream){
					linea = leer.ReadLine();
					descomponerLinea(linea);
				}
				label1.Text = listaPalabras.Count.ToString();
			}
			
		}

		public void descomponerLinea(String linea) {
			ArrayList palabra = new ArrayList();
			Char[] palabraArray;
			String resultado;
			Boolean palGuardada = false;
			var chars = linea.ToCharArray();
			foreach (char letra in chars) {
				if (letra.Equals(' '))
				{
					palabraArray = new char[palabra.Count];
					palabra.CopyTo(palabraArray);
					resultado = string.Join(null, palabraArray);
					listaPalabras.Add(resultado);
					palabra = new ArrayList();
					palGuardada = true;
				}
				else {
					palabra.Add(letra);
					palGuardada = false;
				}
			}
			if (palGuardada == false) {
				palabraArray = new char[palabra.Count];
				palabra.CopyTo(palabraArray);
				resultado = string.Join(null, palabraArray);
				listaPalabras.Add(resultado);
				palabra = new ArrayList();	
			}
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		
	}
}
