using System;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 0;
            int areas = 0;

            for (; ; )
            {
                StartScreen();
                int menuChoice = int.Parse(Console.ReadLine());
                if (menuChoice == 1)
                {
                    level = Difficulty();
                    Console.WriteLine($"Attack is: {level}");
                    int alive = 0;
                    while (alive != 3)
                    {
                        alive = RandomEvent(ref level, ref areas);
                        if (alive == 3)
                        {
                            Console.WriteLine($"You fall to your knees.\n" +
                                              $"While looking up at the sunset everything fades to black.\n" +
                                              $"You made it to {areas} areas.");
                        }
                    }
                }
                else if (menuChoice == 2)
                {
                    Console.WriteLine("Not available yet.");
                }
                else if (menuChoice == 3)
                {
                    Console.WriteLine("Not available yet.");
                }
                else if (menuChoice == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Number. Please try again.");
                }
            }
        }

        public static void StartScreen()
        {
            // achievements like most areas seen, dragon and necromancer kills
            // option = clear achievements 
            Console.WriteLine($"----------------------------------\n" +
                              $"|              Title             |\n" +
                              $"|--------------------------------|\n" +
                              $"|        Press 1 to start        |\n" +
                              $"|      Press 2 for options       |\n" +
                              $"|  Press 3 to view achievements  |\n" +
                              $"|         Press 0 to exit        |\n" +
                              $"----------------------------------" );
        }

        public static int Difficulty ()
        {
            // more strength = more difficulty
            for (; ; )
            {
                int level;
                Console.WriteLine($"----------------------------------\n" +
                                  $"|           Difficulty            |\n" +
                                  $"|---------------------------------|\n" +
                                  $"|        10 starting levels       |\n" +
                                  $"|         7 starting levels       |\n" +
                                  $"|         5 starting levels       |\n" +
                                  $"-----------------------------------");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 10)
                {
                    level = 10;
                    return level;
                }
                else if (choice == 7)
                {
                    level = 7;
                    return level;                   
                }
                else if (choice == 5)
                {
                    level = 5;
                    return level;
                }
                else
                {
                    Console.WriteLine("Invalid difficulty. Please try again.");
                }
            }
        }

        public static int RandomEvent(ref int level, ref int areas)
        {
            // add more as needed
            // make rare areas like battlefield and areas that require other completed areas to unlock
            // ex. fairy realm requires forest secret found
            Random rand = new Random();
            int number = rand.Next(6);
            switch(number)
            {
                case 1:
                    int alive = EventOne(ref level);
                    areas++;
                    return alive;
                case 2:
                    alive = EventTwo(ref level);
                    areas++;
                    return alive;
                case 3:
                    alive = EventThree(ref level);
                    areas++;
                    return alive;
                case 4:
                    alive = EventFour(ref level);
                    areas++;
                    return alive;
                case 5:
                    alive = EventFive(ref level);
                    areas++;
                    return alive;
            }
            int life = 0;
            return life;
        }

        public static int EventOne(ref int level)
        {
            // basic area
            for (; ; )
            {
                Console.WriteLine($"You see a forest ahead, there are two paths.\n" +
                                      $"-----------------------------------\n" +
                                      $"|              Paths              |\n" +
                                      $"|---------------------------------|\n" +
                                      $"|     1 =  Long and safe path     |\n" +
                                      $"|  2 = Short but dangerous path   |\n" +
                                      $"-----------------------------------");
                int path = int.Parse(Console.ReadLine());
                if (path == 1)
                {
                    Console.WriteLine($"Along the path you find a wandering trader.\n" +
                                      $"You have no money so you keep walking.");
                    Random rand = new Random();
                    int number = rand.Next(10);
                    if (number > 5)
                    {
                        Console.WriteLine("As you walk past the forest a monster jumps out.");
                        int monsterStrength = Monster(level);
                        if (monsterStrength > 20)
                        {
                            Console.WriteLine($"A hobgoblin jumps out!");
                            int killMon = DefeatMonster(monsterStrength, ref level);                      
                            return killMon;
                        }
                        else
                        {
                            Console.WriteLine($"A goblin jumps out!");
                            int killMon = DefeatMonster(monsterStrength, ref level);                            
                            return killMon;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You arrive at the next area.");
                        return 0;
                    }
                }
                else if (path == 2)
                {
                    Console.WriteLine("A group of 3 bandits attack you.");
                    int count = 0;
                    while (count < 3)
                    {
                        int bandit = Monster(level);

                        int killMon = DefeatMonster(bandit, ref level);
                        if (killMon == 3)
                        {
                            return killMon;
                        }
                        count++;
                    }
                    Console.WriteLine("After getting past the bandits you reach the next area.");
                    return 0;
                }
                else
                {
                    Console.WriteLine("Invalid number. Please try again.");
                }
            }
        }

        public static int EventTwo(ref int level)
        {
            // rare dragon
            int alive = 0;
            for (; ; )
            {
                Console.WriteLine($"You see something shiny in the ocean.\n" +
                                  $"Dive in the ocean to get it?\n" +
                                          $"-----------------------------------\n" +
                                          $"|               Dive              |\n" +
                                          $"|---------------------------------|\n" +
                                          $"|             1 =  Yes            |\n" +
                                          $"|              2 = No             |\n" +
                                          $"-----------------------------------");
                int dive = int.Parse(Console.ReadLine());
                if (dive == 1)
                {
                    Random rand = new Random();
                    int treasure = rand.Next(50);
                    if (treasure > 40)
                    {
                        Console.WriteLine($"It was a treasure chest!\n" +
                                          $"Inside the chest you find a silver sword.\n" +
                                          $"-Gain 2 levels-");
                        level += 2;
                    }
                    else if (treasure < 10)
                    {
                        Console.WriteLine($"It was a treasure chest!\n" +
                                          $"It is too heavy and you start drowning while trying to get it out.\n" +
                                          $"You give up on the treasure.\n" +
                                          $"-Lose 1 level-");
                        level--;
                    }
                    else if (treasure == 10)
                    {
                        Console.WriteLine("What you saw was the shiny scales of a Dragon");
                        int monsterStrength = 30;
                        alive = DefeatMonster(monsterStrength, ref level);
                        if (alive == 1)
                        {
                            Console.WriteLine($"-Gain 2 levels-\n" +
                                $"The world will remember your achievement.\n" +
                                $"The nearby towns hold a festival in your honour for the next 3 days.");
                            level += 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("What you saw was the shiny scales of a Kelpie");
                        int monsterStrength = Monster(level);
                        alive = DefeatMonster(monsterStrength, ref level);
                    }
                    return alive;
                }
                else if (dive == 2)
                {
                    Console.WriteLine("You aren't tempted by the shiny treasure and move on.");
                    return alive;
                }
                else
                {
                    Console.WriteLine("Invalid number. Try again.");
                }
            }
        }

        public static int EventThree(ref int level)
        {
            // necromancer
            int alive = 0;
            for (; ; )
            {
                Console.WriteLine($"You arrive at a empty village.\n" +
                                  $"Investigate?\n" +
                                          $"-----------------------------------\n" +
                                          $"|            Investigate          |\n" +
                                          $"|---------------------------------|\n" +
                                          $"|             1 =  Yes            |\n" +
                                          $"|              2 = No             |\n" +
                                          $"-----------------------------------");
                int investigate = int.Parse(Console.ReadLine());
                if (investigate == 1)
                {
                    for (; ; )
                    {
                        Console.WriteLine($"Theres a old church in the middle of the village.\n" +
                                  $"You hear strange noises from a locked house.\n" +
                                          $"-----------------------------------\n" +
                                          $"|            Investigate          |\n" +
                                          $"|---------------------------------|\n" +
                                          $"|            1 =  church          |\n" +
                                          $"|             2 = house           |\n" +
                                          $"-----------------------------------");
                        int location = int.Parse(Console.ReadLine());
                        if (location == 1)
                        {
                            Console.WriteLine($"While looking around the church you find a trapdoor.\n" +
                                  $"The basement is full of skeletons.");
                            Random rand = new Random();
                            int chance = rand.Next(50);
                            if (chance < 45)
                            {
                                Console.WriteLine("Four skeletons get up and attack you.");
                                int count = 0;
                                while (count < 4)
                                {
                                    int skeleton = Monster(level);

                                    int killMon = DefeatMonster(skeleton, ref level);
                                    if (killMon == 3)
                                    {
                                        return killMon;
                                    }
                                    count++;
                                }
                            }
                            else
                            {
                                int monsterStrength = 20;
                                Console.WriteLine($"In the corner a necromancer is experementing on a villager.");
                                alive = DefeatMonster(monsterStrength, ref level);
                                if (alive == 1)
                                {
                                    Console.WriteLine($"The villager thanks you and explains what happened.\n" +
                                        $"People started going missing and anyone who tried to leave the vilage were never seen again.\n" +
                                        $"All the others were turned into monsters.");
                                }
                            }
                            return alive;
                        }
                        else if (location == 2)
                        {
                            Console.WriteLine("Two zombies get up and attack you.");
                            int count = 0;
                            while (count < 2)
                            {
                                int zombies = Monster(level);

                                int killMon = DefeatMonster(zombies, ref level);
                                if (killMon == 3)
                                {
                                    return killMon;
                                }
                                count++;
                            }
                            return alive;
                        }
                        else
                        {
                            Console.WriteLine("Invalid number. Try again.");
                        }
                    }
                }
                else if (investigate == 2)
                {
                    Console.WriteLine("You move to the next area.");
                    return alive;
                }
                else
                {
                    Console.WriteLine("Invalid number. Try again.");
                }
            }
        }

        public static int EventFour(ref int level)
        {
            // duel / training
            int alive = 0;
            for (; ; )
            {
                Console.WriteLine($"A warrior asks you for a duel.\n" +
                                  $"Fight?\n" +
                                          $"-----------------------------------\n" +
                                          $"|               Fight             |\n" +
                                          $"|---------------------------------|\n" +
                                          $"|             1 =  Yes            |\n" +
                                          $"|              2 = No             |\n" +
                                          $"-----------------------------------");
                int fight = int.Parse(Console.ReadLine());
                if (fight == 1)
                {
                    int warrior = 10;
                    Console.WriteLine($"The fight begins.");
                    alive = DefeatMonster(warrior, ref level);
                    if (alive == 1)
                    {
                        Console.WriteLine($"The warrior thanks you for the fight and leaves.");
                    }
                    else if (alive == 2)
                    {
                        Console.WriteLine($"The warrior trains you for the next few days\n" +
                            $"-Gain 6 levels-");
                        level += 6;
                    }
                    return alive;
                }
                else if (fight == 2)
                {
                    Console.WriteLine($"You refuse as there is no reason to fight.\n" +
                        $"The warrior calls you a coward as you leave.");
                    return alive;
                }
                else
                {
                    Console.WriteLine("Invalid nummber. Try again.");
                }
            }
        }

        public static int EventFive(ref int level)
        {
            int alive = 0;
            // dungeon labrynth randomized
            for (; ; )
            {
                Console.WriteLine($"Adventurers are lined up to enter a dungeon.\n" +
                                  $"Enter dungeon?\n" +
                                          $"-----------------------------------\n" +
                                          $"|               Enter             |\n" +
                                          $"|---------------------------------|\n" +
                                          $"|             1 =  Yes            |\n" +
                                          $"|              2 = No             |\n" +
                                          $"-----------------------------------");
                int enter = int.Parse(Console.ReadLine());
                if (enter == 1)
                {
                    Console.WriteLine("You enter the dungeon.");
                    for (; ; )
                    {
                        Console.WriteLine($"There are three paths to take.\n" +
                                              $"-----------------------------------\n" +
                                              $"|                 Go              |\n" +
                                              $"|---------------------------------|\n" +
                                              $"|              1 = Left           |\n" +
                                              $"|             2 = Right           |\n" +
                                              $"|            3 = Forward          |\n" +
                                              $"-----------------------------------");
                        int direction = int.Parse(Console.ReadLine());

                        if (direction > 0 && direction <= 3)
                        {
                            for (; ; )
                            {
                                Random rand = new Random();
                                int chance = rand.Next(60);
                                if (chance < 7)
                                {
                                    Console.WriteLine($"There is a portal to exti the dungeon.\n" +
                                              $"-----------------------------------\n" +
                                              $"|                Exit             |\n" +
                                              $"|---------------------------------|\n" +
                                              $"|              1 = Yes            |\n" +
                                              $"|              2 = No             |\n" +
                                              $"-----------------------------------");
                                    int exit = int.Parse(Console.ReadLine());
                                    if (exit == 1)
                                    {
                                        Console.WriteLine($"You exit the dungeon.\n");
                                        return alive;
                                    }
                                }
                                else if (chance < 12)
                                {
                                    Console.WriteLine("You encounter four vampire bats.");
                                    int battle = 0;
                                    while (battle < 4)
                                    {
                                        int monsterStrength = Monster(level);
                                        alive = DefeatMonster(monsterStrength, ref level);
                                        if (alive == 3)
                                        {
                                            return alive;
                                        }
                                        battle++;
                                    }
                                    Console.WriteLine($"You enter the next room.\n");
                                }
                                else if (chance < 21)
                                {
                                    for (; ; )
                                    {
                                        Console.WriteLine($"There is a trap.\n" +
                                            $"Disarm or dodge the trap.\n" +
                                                 $"-----------------------------------\n" +
                                                 $"|                                 |\n" +
                                                 $"|---------------------------------|\n" +
                                                 $"|            1 = Disarm           |\n" +
                                                 $"|            2 = Dodge            |\n" +
                                                 $"-----------------------------------");
                                        int option = int.Parse(Console.ReadLine());
                                        if (option == 1)
                                        {
                                            int disarmResult = rand.Next(20);
                                            if (disarmResult < 15)
                                            {
                                                Console.WriteLine($"Failed to disarm\n" +
                                                    $"-Lose 1 level\n");
                                                level--;
                                                if (level == 0)
                                                {
                                                    return 3;
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Successfully disarmed the trap.\n" +
                                                    $"-Gain 1 level-\n");
                                                level++;
                                                break;
                                            }
                                        }
                                        else if (option == 2)
                                        {
                                            int dodgeResult = rand.Next(20);
                                            if (dodgeResult < 5)
                                            {
                                                Console.WriteLine($"Failed to dodge\n" +
                                                    $"-Lose 1 level\n");
                                                level--;
                                                if (level == 0)
                                                {
                                                    return 3;
                                                }
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Successfully dodged the trap.\n" +
                                                    $"-Gain 1 level-\n");
                                                level++;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid number. Try again.");
                                        }
                                    }
                                }
                                else if (chance < 30)
                                {
                                    Console.WriteLine("You encounter a slime.");
                                    int monsterStrength = Monster(level);
                                    alive = DefeatMonster(monsterStrength, ref level);
                                    if (alive == 3)
                                    {
                                        return alive;
                                    }
                                }
                                else if (chance < 40)
                                {
                                    for (; ; )
                                    {
                                        Console.WriteLine($"There is a treasure chest.\n" +
                                                  $"-----------------------------------\n" +
                                                  $"|                Open             |\n" +
                                                  $"|---------------------------------|\n" +
                                                  $"|              1 = Yes            |\n" +
                                                  $"|              2 = No             |\n" +
                                                  $"-----------------------------------");
                                        int open = int.Parse(Console.ReadLine());
                                        if (open == 1)
                                        {
                                            int chest = rand.Next(20);
                                            if (chest < 10)
                                            {
                                                Console.WriteLine($"The chest had a few cobwebs in it.\n");
                                                break;
                                            }
                                            else if (chest < 15)
                                            {
                                                Console.WriteLine($"The chest had a magic book in it.\n" +
                                                    $"-Gain 3 levels-\n");
                                                level += 3;
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"The chest was a trap.\n" +
                                                    $"-Lose 2 levels-\n");
                                                level -= 2;
                                                if (level <= 0)
                                                {
                                                    return 3;
                                                }
                                                break;
                                            }
                                        }
                                        else if (open == 2)
                                        {
                                            Console.WriteLine($"Leaving the chest behind you move to the next room.\n");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid number. Try again.");
                                        }
                                    }
                                }
                                else if (chance < 43)
                                {
                                    Console.WriteLine("A minotaur charges at you.");
                                    int monsterStrength = 50;
                                    alive = DefeatMonster(monsterStrength, ref level);
                                    if (alive == 3)
                                    {
                                        return alive;
                                    }
                                    if (alive == 1)
                                    {
                                        Console.WriteLine($"You defeated the minotaur and cleared the dungeon.\n");
                                        return alive;
                                    }
                                }
                                else if (chance < 47)
                                {
                                    Console.WriteLine("Cultists are trying to summon a demon");
                                    int cultist = 0;
                                    while (cultist < 4)
                                    {
                                        cultist++;
                                        int monsterStrength = Monster(level);
                                        alive = DefeatMonster(monsterStrength, ref level);
                                        if (alive == 3)
                                        {
                                            return alive;
                                        }
                                    }
                                    Console.WriteLine($"The remaining cultists flee.\n");
                                }
                                else if (chance <= 50)
                                {
                                    Console.WriteLine($"The room is empty. You enter the next area.\n");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid nummber. Try again.");
                        }
                    }
                }
                else if (enter == 2)
                {
                    Console.WriteLine($"You have no interest in the dungeon and keep walking.");
                    return alive;
                }
                else
                {
                    Console.WriteLine("Invalid nummber. Try again.");
                }
            }
        }

        public static int Monster(int level)
        {
            int number = level * 2;
            Random rand = new Random();
            int monsterStrength = rand.Next(number);
            return monsterStrength;
        }

        public static int DefeatMonster (int monsterStrength, ref int level)
        {
            if(level == 0)
            {
                return 3;
            }

            if (level >= monsterStrength)
            {
                Console.WriteLine($"The monsters level is {monsterStrength}. Your level is {level}");
                Console.WriteLine($"You defeat the monster!\n" +
                                  $"-Gain 1 level-\n" +
                                  $"");
                level++;
                return 1;
            }
            else
            {

                Console.WriteLine($"The monsters level is {monsterStrength}. Your level is {level}");
                Console.WriteLine($"The monster is too strong. You take damage while escaping.\n" +
                                                  $"-Lose 2 levels-\n" +
                                                  $"");
                level -= 2;   
                if (level < 1)
                {
                    return 3;
                }
                return 2;
            }
        }
    }
}
