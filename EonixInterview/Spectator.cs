using System;

namespace EonixInterview
{
    public class Spectator : IObserver
    {
        public string spectatorName { get; }

        public Spectator(string spectatorName)
        {
            if (spectatorName == null)
            {
                throw new ArgumentNullException(nameof(spectatorName));
            }
            this.spectatorName = spectatorName;
        }

        #region Pattern Observer

        public void Update(Monkey monkey, Trick trick)
        {
            if(monkey == null)
            {
                throw new ArgumentNullException(nameof(monkey));
            }

            if (trick == null)
            {
                throw new ArgumentNullException(nameof(trick));
            }

            switch ((int)trick.trickType)
            {
                case 0:
                    Console.WriteLine($"spectateur applaudit pendant le tour {trick.trickType} '{trick.trickName}' du {monkey.Name}"); break;
                case 1:
                    Console.WriteLine($"spectateur siffle pendant le tour {trick.trickType} '{trick.trickName}' du {monkey.Name}"); break;
            }
        }

        #endregion
    }
}