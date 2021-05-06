using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class Form1 : Form
    {
        TuringMachine tm = new TuringMachine();
        List<char> Input = new List<char>();
        int PointerPosition = 0;  
        int CountTransitions = 0;
        int CountTransitionsWith0 = 1;
        bool Stop = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnDoStep_Click(object sender, EventArgs e)
        {   //Realiza una transición de la MT  
            Step();
        }

        
        void Step()
        {
            char current_char = Input[PointerPosition];
            //Obtiene la acción a realizar sobre la UI
            string ActionResult = tm.MakeTransition(current_char);
            
            //Muestra el mensaje de error, si hubo un error al realizar la transición en la MT
            if (ActionResult.Length > 2)
            {
                Stop = true;
                DialogResult result = MessageBox.Show($"{ActionResult}", "Error");
                btnDoStep.Enabled = false;
                btnDoExecution.Enabled = false;
                btnRestart.Enabled = true;
                return;
            }

            //Escribe en el puntero del cabezal el caracter definido por la transición
            char char_to_write = ActionResult[0];
            Input[PointerPosition] = char_to_write;

            //Agrega un "_" al final de la cinta si es que esta fue modificada
            if (Input[Input.Count-1] != '_') Input.Add('_');
            
            //Realiza la acción del movimiento sobre la cinta
            char move = ActionResult[1];
            move = (move.ToString().ToLower().ToCharArray()[0]);
            if (move == 'd')
            {
                PointerPosition++;
                CountTransitions++;
            }
            if (move == 'i')
            {
                PointerPosition--;
                CountTransitions++;
            }
            if (move == 'p')
            {
                //Si se llega a un estado final, la acción que se realiza es la de parar (halting)
                RefreshData();
                DialogResult result = MessageBox.Show("Se ha detenido la ejecución", "Estado de ejecución");
                btnDoStep.Enabled = false;
                btnDoExecution.Enabled = false;
                btnRestart.Enabled = true;
                Stop = true;
                return;
            }
            if(move == '0')
            {
               //Si se hace una transición sin movimiento únicamente se aumenta la cantidad de transiciones realizadas
               CountTransitions++;
                CountTransitionsWith0++;
            }
            //Cada 150 transiciones realizadas consulta si se desea continuar con la ejecución automática
            if (CountTransitions % 100 == 0)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea detener la ejecución automática?", "Estado de ejecución", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Stop = true;
                }
            }
            //Cada 10 transiciones sin movimiento consulta si se desea continuar con la ejecución automática
            if (CountTransitionsWith0 % 10 == 0)
            {
                DialogResult dialogResult = MessageBox.Show($"Se han realizado {CountTransitionsWith0} transiciones <sin movimiento>\n¿Desea detener la ejecución automática?", "Estado de ejecución", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Stop = true;
                }
            }
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Valida que la entrada no sea vacía
            if(txtInput.Text == "")
            {
                DialogResult result = MessageBox.Show("Debe ingresar una cadena de entrada", "Error");
                return;
            }
            //Valida que la entrada no contenga espacios en blanco
            if (txtInput.Text.Contains(" "))
            {
                DialogResult result = MessageBox.Show("La cadena de entrada no puede contener espacios en blanco", "Error");
                return;
            }
            //Valida que la entrada no contenga espacios "_"
            if (txtInput.Text.Contains("_"))
            {
                DialogResult result = MessageBox.Show("La cadena de entrada no puede contener '_'", "Error");
                return;
            }
            //Valida que todos los caracteres de la entrada pertenezcan al alfabeto
            for (int i = 0; i < txtInput.Text.Length; i++)
            {
                if (!tm.Alphabet.Contains(Convert.ToString(txtInput.Text[i])))
                {
                    txtInput.Text = "";
                    DialogResult result = MessageBox.Show("La cadena de entrada contiene carácteres que no pertenecen al alfabeto", "Error");
                    return;
                }
            }

            //Ajusta al formato predeterminado la cadena de entrada
            Input.Add('_');
            for (int i = 0; i < txtInput.Text.Length; i++)
            {
                Input.Add(txtInput.Text[i]);
            }
            Input.Add('_');

            //Habilita los botones a usar y deshabilita los inncesarios
            btnDoStep.Enabled = true;
            btnDoExecution.Enabled = true;
            RefreshData();
            txtInput.Enabled = false;
            btnLoadInput.Enabled = false;
        }

        public void RefreshData()
        {
            //Actualiza la cantidad de transiciones realizadas
            lblCounter.Text = Convert.ToString(CountTransitions);

            //Si el puntero se encuentra en la primera posición se distribuye la cinta de la siguiente forma
            if (PointerPosition == 0)
            {
                //Coloca el caracter del puntero en el cabeza de lectura/escritura
                lblActualPosition.Text = Convert.ToString(Input[PointerPosition]);
                //La parte de la entrada restante se coloca del lado derecho (la parte aún sin leer)
                string right_chain_initial = "";
                for (int i = PointerPosition + 1; i < Input.Count; i++)
                {
                    right_chain_initial += Convert.ToString(Input[i]);
                }
                lblRightPart.Text = right_chain_initial;
            }
            //Coloca el caracter del puntero en el cabeza de lectura/escritura
            lblActualPosition.Text = Convert.ToString(Input[PointerPosition]);
            //Coloca del lado izquierdo la cadena anterior al puntero (la parte ya leída)
            string left_chain = "";
            for (int i = 0; i < PointerPosition; i++)
            {
                left_chain += Convert.ToString(Input[i]);
            }
            lbl_LeftPart.Text = left_chain;
            //Coloca del lado derecho la cadena posterior al puntero (la parte aún sin leer)
            string right_chain = "";
            for (int i = PointerPosition+1; i < Input.Count; i++)
            {
                right_chain += Convert.ToString(Input[i]);
            }
            lblRightPart.Text = right_chain;

            //Actualiza el estado actual
            lblState.Text = Convert.ToString(tm.CurrentState);
            
            //Si se esta incializando la MT la transición inicial es null, de lo contrario si tendra una transición realizada
            if (tm.CurrentTransition == null)
            {
                lblCurrentTransition.Text = "-";
            }
            else
            {
                lblCurrentTransition.Text = tm.CurrentTransition;
            }
        }

        private void lblActualPosition_Click(object sender, EventArgs e)
        {

        }

        private void lbl_LeftPart_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivo de texto con MT | *.txt";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName; // get name of file
                lblMachineName.Text = dialog.FileName.Split('\\')[dialog.FileName.Split('\\').Length-1];
                var ArchivoMT = File.ReadAllLines(path);
                try
                {
                    tm.States = Convert.ToInt32(ArchivoMT[0]);
                    tm.InitialState = Convert.ToInt32(ArchivoMT[1]);
                    tm.CurrentState = tm.InitialState;
                    tm.Alphabet = new List<string>();
                    foreach (char c in ArchivoMT[2])
                    {
                        tm.Alphabet.Add(Convert.ToString(c));
                    }
                    if (ArchivoMT.Length < 4) throw new Exception(); //Comprueba que el archivo de MT tenga al menos una transición
                    tm.Transitions = new List<string>();
                    for (int i = 3; i < ArchivoMT.Length; i++)
                    {
                        tm.Transitions.Add(ArchivoMT[i]);
                    }
                    DialogResult result = MessageBox.Show("Archivo cargado exitosamente!!!","Resultado archivo");
                    btnLoadInput.Enabled = true;
                    txtInput.Enabled = true;
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Ha ocurrido un error, compruebe el formato del archivo","Error");
                }
                
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            //Borra los labels utilizados previamente
            txtInput.Text = "";
            lbl_LeftPart.Text = "_";
            lblActualPosition.Text = "_";
            lblRightPart.Text = "_";
            lblCurrentTransition.Text = "_";
            lblState.Text = "_";
            lblCounter.Text = "_";

            //Habilita y deshabilita los componentes utilizados en los pasos anteriores
            txtInput.Enabled = true;
            btnLoadInput.Enabled = true;
            btnDoStep.Enabled = false;
            btnDoExecution.Enabled = false;
            btnRestart.Enabled = false;

            //Vuelve a incializar las variables utilizadas en este ámbito
            Input = new List<char>();
            PointerPosition = 0;
            CountTransitions = 0;
            CountTransitionsWith0 = 1;
            tm.CurrentState = tm.InitialState;
            tm.CurrentTransition = null;
        }

        private void btnDoExecution_Click(object sender, EventArgs e)
        {
            //Realiza un paso con delay de 500ms mientras no se detenga la ejecución
            btnDoStep.Enabled = false;
            while (Stop!=true)
            {   
                Step();
                Refresh();
                Thread.Sleep(500);
            }
            Stop = false;
            btnRestart.Enabled = true;
            btnDoExecution.Enabled = false;
            return;
        }
    }
}
