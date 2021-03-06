using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;
using System.Windows.Forms; // hereda de acá

/* CLASE 6: WINDOWS FORMS 
 * Los formularios son objetos.
 * Partial class: clase creada en dos archivos. La clase es la unión de los dos. Divide físicamente a la clase en mas de un carchivos
 * Eventos: Siempre se disparan, pero solo pasa algo si se escucha, si alguien lo recibe.
 * Ciclo de vida del formulario
 * MessageBox
 */

namespace WindowsFormsApp1
{
    public partial class frmPrincipal : Form
    {
        //bool PaintMostrado = false;
        //bool ActivedMostrado = false;

        public frmPrincipal()
        {
            InitializeComponent();
            // PaintMostrado = false;
            //ActivedMostrado = false;
        }


        //btnMostrar: Muestra MessageBox
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bla", "titulo", MessageBoxButtons.YesNoCancel,
              MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // Cancelar devuelve el btn por defecto.
                this.btnAceptar.Text = DialogResult.Yes.ToString();
            }
            else
            {
                this.btnAceptar.Text = "No";
            }
        }
        
        // se carga el formuario
        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Load");
        }

        // se pinta el formulario
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //if (!PaintMostrado)
            //{
            //  MessageBox.Show("Paint");
            //  PaintMostrado = true;
            //}
        }

        // se activa el formulario
        private void Form1_Activated(object sender, EventArgs e)
        {
            //if (!ActivedMostrado)
            //{
            //  MessageBox.Show("Actived");
            //  ActivedMostrado = true;
            //}
        }

        // se llama a cerrar el form. Existe y no se borró nada. Todavía se puede 
        // cancelar el cierre del form. Pasada esta instancia no hay vuelta atrás.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("FormClosing", "Va a Cerrar el Formulario",
            //  MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
            //  MessageBoxDefaultButton.Button2) == DialogResult.No)
            //    e.Cancel = true;
        }

        // se cierra el form.
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("FormClosed");
        }

        // mostrar forms
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            //intefases de multiples documentos IsMdiContainer
            this.IsMdiContainer = true;

            //Creamos la instancia del formulario2
            frmPantalla2.frmPantalla2 formulario2 = new frmPantalla2.frmPantalla2();
            frmPantalla2.frmPantalla2 formulario3 = new frmPantalla2.frmPantalla2();

            //owner
            //formulario.show(frmOwner)
            //si ciero el formulario se cierra el owner también. y cuando se crea se crean los dos.             
            FrmOwner.Form1 frmOwner = new FrmOwner.Form1();
            frmOwner.Show();
            formulario3.Show(frmOwner);

            // le digo al formulario2 que está dentro de un formulario mdi padre y le digo que es "this"
            formulario2.MdiParent = this;

            //formulario2.ShowDialog();
            formulario2.Show();
            this.btnMostrar.Text = formulario2.atributoString;
        }

        // Crea un formulario nuevo
        private void btnCrearFrm_Click(object sender, EventArgs e)
        {
            frmPantalla2.frmPantalla2 frmNuevo = new frmPantalla2.frmPantalla2();
            this.IsMdiContainer = true;
            frmNuevo.MdiParent = this;
            frmNuevo.Show();
        }

        // Ordena los formularios contenidos dentro del mdi
        private void btnOrdenarFrms_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
    }
}
