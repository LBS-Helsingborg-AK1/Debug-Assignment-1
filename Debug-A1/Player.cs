using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Player
{
    public Vector2 position;
    Vector2 speed;

    public string name;
    public int hp;
    public int str;

    public void Update(ConsoleKeyInfo keyPressed)
    {
        speed = new Vector2();

        if (keyPressed.Key == ConsoleKey.W)
        {
            speed.y = 1;
        }
        else if (keyPressed.Key == ConsoleKey.S)
        {
            speed.y = -1;
        }

        if (keyPressed.Key == ConsoleKey.A)
        {
            speed.x = -1;
        }
        else if (keyPressed.Key == ConsoleKey.D)
        {
            speed.x = 1;
        }
    }

    /// <summary>
    /// This method will first confirm that the movement the player wants to do
    /// is correct and legitimate. If it is a wall it's walking into or something
    /// so that we can prevent the player from phasing in and out of the level
    /// </summary>
    /// <param name="map">The map to check against</param>
    public void ApplyMovement(byte[] map)
    {
        int width = map[0];

        // In order for us to get the cell in the array we have to know the width of one row (how many columns).

        int playerIndex = Convert.ToInt32(position.x) + (Convert.ToInt32(position.y) * width) + 1;
        int wantedIndex = Convert.ToInt32(position.x + speed.x) + (Convert.ToInt32(position.y + speed.y) * width) + 1;

        OverdrawMap();
        position.x = position.x + speed.x;
        position.y = position.y + speed.y;
    }

    private void OverdrawMap()
    {
        position.SetConsole();
        Console.Write(" ");
    }

    public void Draw()
    {
        position.SetConsole();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("P");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}
