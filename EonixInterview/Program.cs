using System;

namespace EonixInterview
{
    class Program
    {
        static void Main()
        {
            Spectator spectator = new Spectator("Nicolas");
        
            Monkey monkey1 = new Monkey("Singe 1");
            Trainer trainer1 = new Trainer("Dresseur1", monkey1);

            Monkey monkey2 = new Monkey("Singe 2");
            Trainer trainer2 = new Trainer("Dresseur2", monkey2);

            trainer1.Monkey.Attach(spectator);
            trainer2.Monkey.Attach(spectator);

            trainer1.Monkey.LearnTrick(new Trick("Marcher sur les mains", TrickType.Acrobatie));
            trainer1.Monkey.LearnTrick(new Trick("Rouler par terre", TrickType.Acrobatie));
            trainer1.Monkey.LearnTrick(new Trick("frapper dans les mains", TrickType.Acrobatie));
            trainer1.Monkey.LearnTrick(new Trick("Jouer de la guitare", TrickType.Musique));
            trainer1.Monkey.LearnTrick(new Trick("Jouer de l'harmonica", TrickType.Musique));

            trainer2.Monkey.LearnTrick(new Trick("Tourner sur sa tête", TrickType.Acrobatie));
            trainer2.Monkey.LearnTrick(new Trick("Courir vite", TrickType.Acrobatie));
            trainer2.Monkey.LearnTrick(new Trick("Faire du cheval", TrickType.Acrobatie));
            trainer2.Monkey.LearnTrick(new Trick("Jouer du triangle", TrickType.Musique));
            trainer2.Monkey.LearnTrick(new Trick("Chanter", TrickType.Musique));

            Console.WriteLine($"===================       {trainer1.Monkey.Name} will start the show !  ================================");

            foreach (var trick in trainer1.Monkey.GetAllTricks())
            {
                trainer1.Monkey.PerformTrick(trick);
            }
            Console.WriteLine($"====================      {trainer1.Monkey.Name} end the show !        ===============================");
            Console.WriteLine();
            Console.WriteLine($"====================      {trainer2.Monkey.Name} will start the show ! ===============================");

            foreach (var trick in trainer2.Monkey.GetAllTricks())
            {
                trainer2.Monkey.PerformTrick(trick);
            }

            Console.WriteLine($"====================      {trainer2.Monkey.Name} end the show !        ===============================");

        }
    }
}
