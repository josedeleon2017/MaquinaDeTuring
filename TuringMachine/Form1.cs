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
        int PointerPosition = 0;
        List<char> Input = new List<char>();
        bool Stop = false;
        int CountTransitions = 0;
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
        {
            Step();
        }

        void Step()
        {
            char current_char = Input[PointerPosition];
            string ActionResult = tm.MakeTransition(current_char);

            char char_to_write = ActionResult[0];
            Input[PointerPosition] = char_to_write;

            char move = ActionResult[1];
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
                CountTransitions++;
            }
            if (CountTransitions % 25 == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Desea para la ejecución?", "text", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Stop = true;
                }

            }
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Agregar validaciones
            //Si todos los caracteres de la cinta pertenecen al alfabeto importar si no, no
            Input.Add('_');
            for (int i = 0; i < txtInput.Text.Length; i++)
            {
                Input.Add(txtInput.Text[i]);
            }
            Input.Add('_');
            btnDoStep.Enabled = true;
            btnDoExecution.Enabled = true;
            RefreshData();
            txtInput.Enabled = false;
            btnLoadInput.Enabled = false;
        }

        public void RefreshData()
        {
            lblCounter.Text = Convert.ToString(CountTransitions);
            if (PointerPosition == 0)
            {
                lblActualPosition.Text = Convert.ToString(Input[PointerPosition]);
                string right_chain_initial = "";
                for (int i = PointerPosition + 1; i < Input.Count; i++)
                {
                    right_chain_initial += Convert.ToString(Input[i]);
                }
                lblRightPart.Text = right_chain_initial;
            }
            lblActualPosition.Text = Convert.ToString(Input[PointerPosition]);
            string left_chain = "";
            for (int i = 0; i < PointerPosition; i++)
            {
                left_chain += Convert.ToString(Input[i]);
            }
            lbl_LeftPart.Text = left_chain;
            string right_chain = "";
            for (int i = PointerPosition+1; i < Input.Count; i++)
            {
                right_chain += Convert.ToString(Input[i]);
            }
            lblRightPart.Text = right_chain;

            lblState.Text = Convert.ToString(tm.CurrentState);
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
            txtInput.Text = "";
            txtInput.Enabled = true;
            btnLoadInput.Enabled = true;
            btnDoStep.Enabled = false;
            btnDoExecution.Enabled = false;
            btnRestart.Enabled = false;
            lbl_LeftPart.Text = "_";
            lblActualPosition.Text = "_";
            lblRightPart.Text = "_";
            lblCurrentTransition.Text = "_";
            lblState.Text = "_";
            Input = new List<char>();
            PointerPosition = 0;
            tm.CurrentState = tm.InitialState;
            tm.CurrentTransition = null;
        }

        private void btnDoExecution_Click(object sender, EventArgs e)
        {
            btnDoStep.Enabled = false;
            while (Stop!=true)
            {   
                Step();
                Refresh();
                Thread.Sleep(500);
            }
            Stop = false;
            return;
        }
    }
}
