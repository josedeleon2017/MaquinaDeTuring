using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class Form1 : Form
    {
        TuringMachine tm = new TuringMachine();
        int PointerPosition = 0;
        List<char> Input = new List<char>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tm.States = 2;
            tm.InitialState = '1';
            tm.Alphabet = new List<string>() { "1", "0" };
            tm.Transitions = new List<string>() { "1,_,2,_,d", "2,1,2,0,d", "2,0,2,1,d", "2,_,2,_,p" };
            tm.CurrentState = tm.InitialState;
            tm.CurrentTransition = "---";
        }

        private void btnDoStep_Click(object sender, EventArgs e)
        {
            char current_char = Input[PointerPosition];
            string ActionResult = tm.MakeTransition(current_char);

            char char_to_write = ActionResult[0];
            Input[PointerPosition] = char_to_write;

            char move = ActionResult[1];
            if (move == 'd')
            {
                PointerPosition++;
            }
            if (move == 'i')
            {
                PointerPosition--;
            }
            if (move == 'p')
            {
                DialogResult result = MessageBox.Show("Se ha detenido la ejecución", "Estado de ejecución");
            }
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Input.Add('_');
            for (int i = 0; i < txtInput.Text.Length; i++)
            {
                Input.Add(txtInput.Text[i]);
            }
            Input.Add('_');
            RefreshData();
        }

        public void RefreshData()
        {
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
            lblCurrentTransition.Text = tm.CurrentTransition;
        }

        private void lblActualPosition_Click(object sender, EventArgs e)
        {

        }

        private void lbl_LeftPart_Click(object sender, EventArgs e)
        {

        }
    }
}
