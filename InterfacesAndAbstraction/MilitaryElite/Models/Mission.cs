using MilitaryElite.Contracts;
using MilitaryElite.Exceptions;
using System;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;

            ParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        private void ParseState(string stateString)
        {
            State state;

            bool parsed = Enum.TryParse<State>(stateString, out state);

            if (!parsed)
            {
                throw new InvalidStateException();
            }

            this.State = state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
