using System;
using System.Collections.Generic;

namespace EonixInterview
{
    public class Trainer
    {
        public Trainer(string name, Monkey monkey)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (monkey == null)
            {
                throw new ArgumentNullException(nameof(monkey));
            }

            this.Name = name;
            this.Monkey = monkey;
        }

        public string Name { get; }
        public Monkey Monkey { get; }
    }
}