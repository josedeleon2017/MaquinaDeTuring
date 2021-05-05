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



        public string MakeTransition(char consumed_char)
        {
            for (int i = 0; i < Transitions.Count; i++)
            {
                string[] transition = Transitions[i].Split(',');
                char consumed_match = Convert.ToChar(transition[1]);
                int state_match = Convert.ToInt32(transition[0]);
                if (consumed_char == consumed_match && state_match == CurrentState)
                {
                    CurrentState = Convert.ToInt32(transition[2]);
                    CurrentTransition = Transitions[i];
                    return transition[3] + transition[4];
                }
            }
            return "";
        }
    }
}
