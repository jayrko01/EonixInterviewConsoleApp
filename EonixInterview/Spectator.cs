using System;

namespace EonixInterview
{
    public class Spectator : IObserver
    {
        private readonly ILogger logger;

        public string spectatorName { get; }

        public Spectator(string spectatorName, ILogger logger)
        {
            if (spectatorName == null)
            {
                throw new ArgumentNullException(nameof(spectatorName));
            }
            this.spectatorName = spectatorName;
            this.logger = logger;
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
                    logger.LogMessage($"Spectateur applaudit pendant le tour {trick.trickType} '{trick.trickName}' du {monkey.Name}"); break;
                case 1:
                    logger.LogMessage($"spectateur siffle pendant le tour {trick.trickType} '{trick.trickName}' du {monkey.Name}"); break;
            }
        }

        #endregion
    }
}