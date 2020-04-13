using System;
using System.Collections.Generic;

namespace EonixInterview
{
    public class Monkey
    {
        private List<IObserver> _observers = new List<IObserver>();
        

        public Monkey(string monkeyName)
        {
            if(monkeyName == null)
            {
                throw new ArgumentNullException(nameof(monkeyName));
            }

            listTricks = new List<Trick>();
            this.Name = monkeyName;
        }

        public IList<Trick> listTricks { get; }
        public string Name { get; }

        #region method

        public void LearnTrick(Trick trick)
        {
            if (!this.listTricks.Contains(trick))
            {
                this.listTricks.Add(trick);
            }
        }

        public IList<Trick> GetAllTricks()
        {
            return listTricks;
        }

        #endregion


        #region Pattern Observer
        public void Attach(IObserver spectator)
        {
            _observers.Add(spectator);
        }

        public void Detach(IObserver spectator)
        {
            _observers.Remove(spectator);

        }
        

        public void PerformTrick(Trick trick)
        {
            foreach (var spectator in _observers)
            {
                spectator.Update(this, trick);
            }
        }

        #endregion

    }
}