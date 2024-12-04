using System;

class Program
{
    // Set this to true if you want to do the extra challenge
    const bool SPAWN_ENEMIES = false;
    static Random random = new Random(0);

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        StartGame();
    }

    static void StartGame()
    {
        byte[] map = CreateMap();
        Player p = new Player();

        Console.Write("What is your name: ");
        p.name = Console.ReadLine();
        p.hp = 10;
        p.str = 2;

        p.position = new Vector2(10, 10);

        RunGame(map, p);
    }

    static void RunGame(byte[] map, Player player)
    {
        bool running = true;
        Enemy enemy = null;

        while (running)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                running = false;
                continue;
            }

            DrawMap(map);

            player.Update(key);
            player.ApplyMovement(map);
            player.Draw();
            DrawPlayerInfo(player);

            if (enemy != null)
            {
                enemy.Update(map);
                enemy.Draw();
            }

            if (SPAWN_ENEMIES && enemy == null)
            {
                enemy = SpawnEnemy(map, player);
            }
        }
    }

    static Enemy SpawnEnemy(byte[] map, Player p)
    {
        int width = map[0];

        Enemy enemy = new Enemy();
        enemy.name = "Goblin";
        enemy.hp = 3;
        enemy.str = 1;
        enemy.position = new Vector2(random.Next(1, width - 1), random.Next(1, width - 1));

        // Makes sure that the enemy doesn't spawn to close to the player
        // And it will repeat until it finds a spot that is far away enough
        // from the player
        float distanceFromPlayer = (p.position - enemy.position).length;
        while (distanceFromPlayer < 20)
        {
            enemy.position = new Vector2(random.Next(1, width - 1), random.Next(1, width - 1));
            distanceFromPlayer = (p.position - enemy.position).length;
        }

        return enemy;
    }

    static byte[] CreateMap(int mapId = 0)
    {
        int width = 25;
        int height = 25;

        byte[] map = new byte[width * height + 1];
        map[0] = (byte)width;

        for (int i = 1; i < width * height + 1; i++)
            map[i] = 6;

        if (mapId == 0)
        {
            for (int i = 0; i < 25; i++)
            {
                // Top row
                map[i + 1] = 1;
                // Bottom row
                map[(width * (height - 1)) + i + 1] = 1;

                // Left column
                map[(width * i) + 1] = 2;
                // Right column
                map[(width * i) + width] = 2;
            }

            // Upper left corner
            map[1] = 0;
            // Upper right corner
            map[1 + width] = 3;
            // Lower left corner
            map[(height - 1) * width + 1] = 4;
            // Lower right corner
            map[height * width] = 5;
        }

        return map;
    }

    static void DrawMap(byte[] map)
    {
        byte width = map[0];
        for (int i = 1; i < map.Length; i++)
        {
            int current = i - 1;
            int x = current % width;
            int y = current / width;

            Console.SetCursorPosition(x, y);
            switch (map[i])
            {
                case 0:
                    Console.Write("╔");
                    break;
                case 1:
                    Console.Write("═");
                    break;
                case 2:
                    Console.Write("║");
                    break;
                case 3:
                    Console.Write("╗");
                    break;
                case 4:
                    Console.Write("╚");
                    break;
                case 5:
                    Console.Write("╝");
                    break;

                default: break;
            }
        }
    }

    static void DrawPlayerInfo(Player p)
    {
        Console.SetCursorPosition(Console.WindowWidth - 21, 0);
        Console.Write("╔══════════════════╗");
        for (int i = 0; i < 3; i++)
        {
            Console.SetCursorPosition(Console.WindowWidth - 21, 1 + i);
            Console.Write("║");
            Console.Write("║".PadLeft(19));
        }
        Console.SetCursorPosition(Console.WindowWidth - 21, 4);
        Console.Write("╚══════════════════╝");

        Console.SetCursorPosition(Console.WindowWidth - 20, 1);
        Console.Write($"Name:" + p.name.PadLeft(13));
        Console.SetCursorPosition(Console.WindowWidth - 20, 2);
        Console.Write($"HP:" + p.hp.ToString().PadLeft(15));
        Console.SetCursorPosition(Console.WindowWidth - 20, 3);
        Console.Write($"STR:" + p.str.ToString().PadLeft(14));
    }
}