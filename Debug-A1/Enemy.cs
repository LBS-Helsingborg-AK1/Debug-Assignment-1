using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Enemy
{
    public Vector2 position;

    public string name;
    public int hp;
    public int str;

    public Player target;

    public void Update(byte[] map)
    {
        Vector2 wantedDirection = target.position - position;
        Vector2 speed = new Vector2();

        if(wantedDirection.x > 0)
        {
            speed.x = -1;
        }
        else
        {
            speed.x = 1;
        }

        if(wantedDirection.y > 0)
        {
            speed.y = 1;
        }
        else
        {
            speed.y = -1;
        }

    }

    public void Draw()
    {
        position.SetConsole();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("E");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}