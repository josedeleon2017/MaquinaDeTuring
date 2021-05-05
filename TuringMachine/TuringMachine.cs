using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TuringMachine
    {
        
        public int States { get; set; }
        public int InitialState { get; set; }
        public List<string> Alphabet { get; set; }
        public List<string> Transitions { get; set; }

        public int CurrentState { get; set; }
        public string CurrentTransition { get; set; }

        /*Realiza la busqueda en la lista de transciciones*/
        public string MakeTransition(char consumed_char)
        {
            for (int i = 0; i < Transitions.Count; i++)
            {
                string[] transition = Transitions[i].Split(',');
                char consumed_match = Convert.ToChar(transition[1]);
                int state_match = Convert.ToInt32(transition[0]);

                /*Si se encuentra una transición consumiendo el caracter actual que salga del estado actual se realiza la transición*/
                if (consumed_char == consumed_match && state_match == CurrentState)
                {
                    /*Valida que el siguiente estado si pertenezca al conjunto de estados*/
                    if (Convert.ToInt32(transition[2]) > this.States) return "La transición se hace a un estado inexistente";

                    CurrentState = Convert.ToInt32(transition[2]);
                    CurrentTransition = Transitions[i];
                    return transition[3] + transition[4];
                }
            }
            /*Devuelve esto cuando no encuentra transciciones validas*/
            return "No se encontraron transiciones";
        }
    }
}
