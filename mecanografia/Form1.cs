using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mecanografia
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private string palabraActual;
        private int indiceDeletrasActual;
        private Dictionary<Keys, Button> LetrasAbecedario;
        public Form1()
        {
            InitializeComponent();
            NuevaPalabra();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            LetrasAbecedario = new Dictionary<Keys, Button>()
            {
                {Keys.A, Btn_A },
                {Keys.B, Btn_B },
                {Keys.C, Btn_C },
                {Keys.D, Btn_D },
                {Keys.E, Btn_E },
                {Keys.F, Btn_F },
                {Keys.G, Btn_G },
                {Keys.H, Btn_H },
                {Keys.I, Btn_I },
                {Keys.J, Btn_J },
                {Keys.K, Btn_K },
                {Keys.L, Btn_L },
                {Keys.M, Btn_M },
                {Keys.N, Btn_N },
                {Keys.O, Btn_O },
                {Keys.P, Btn_P },
                {Keys.Q, Btn_Q },
                {Keys.R, Btn_R },
                {Keys.S, Btn_S },
                {Keys.T, Btn_T },
                {Keys.U, Btn_U },
                {Keys.V, Btn_V },
                {Keys.W, Btn_W },
                {Keys.X, Btn_X },
                {Keys.Y, Btn_Y },
                {Keys.Z, Btn_Z }
            };

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                if (LetrasAbecedario.TryGetValue(e.KeyCode, out Button obtenerboton))//si la tecla precionada es encontrada en el diccionario
                {
                    obtenerboton.BackColor = Color.White;// el boton asociado se tornara de blanco
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)//si la letra que preciono esta entre la A a la Z
            {
                if (LetrasAbecedario.TryGetValue(e.KeyCode, out Button obtenerboton))//si la tecla precionada es encontrada en el diccionario
                {
                    obtenerboton.BackColor = Color.Red;// el boton asociado se tornara de color rojo
                }
            }
        }

        private void NuevaPalabra()
        {
            // lista de palabras para probar
            string[] palabras = { "buenos", "dias", "quiero", "hacer", "mecanografia", "programa" };

            // obtener una palabra aleatoria
            palabraActual = palabras[random.Next(palabras.Length)];
            indiceDeletrasActual = 0;

            // Mostrar la palabra en el RichTextBox
            RtbxObtener.Text = palabraActual;

            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnPrueba_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (indiceDeletrasActual < palabraActual.Length)
            {
                // Obtener la letra actual que el usuario debe coincidir
                char letraActual = palabraActual[indiceDeletrasActual];

                // Verificar si la tecla presionada coincide con la letra actual
                if (e.KeyChar == letraActual)
                {
                    // Pintar la letra en verde
                    RtbxObtener.Select(indiceDeletrasActual, 1);
                    RtbxObtener.SelectionColor = Color.Green;

                    // Pasar a la siguiente letra
                    indiceDeletrasActual++;
                    // Si completamos la palabra, generar una nueva
                    if (indiceDeletrasActual == palabraActual.Length)
                    {
                        NuevaPalabra();
                    }
                }
                else
                {
                    // Pintar la letra en rojo si no coincide
                    RtbxObtener.Select(indiceDeletrasActual, 1);
                    RtbxObtener.SelectionColor = Color.Red;
                }

                //e.Handled = true; 
            }
        }
    }
}