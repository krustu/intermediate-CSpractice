
using System;
using System.ComponentModel;
class Program
{
    static void Main()
    {
        List<Robot> robots = new List<Robot>
        {
            new Robot(new WheeledMovement(), new LaserWeapon()),
            new Robot(new LeggedMovement(), new MeleeWeapon()),
            new Robot(new WheeledMovement(), new MeleeWeapon())

        };
        foreach (Robot robot in robots)
        {
            robot.Act();

        }


        Console.WriteLine("hi");
        Console.ReadKey();
    }
}
public interface IMovement
{
    void Move();
}
public interface IWeapon
{

    void Attack();
}
public class Robot
{
    private IMovement? _movement;
    private IWeapon? _weapon;
    public Robot(IMovement? movement, IWeapon? weaponq)
    {
        _movement = movement;
        _weapon = weaponq;
    }
    public void Act()
    {

        _movement?.Move();
        _weapon?.Attack();
    }


}

public class WheeledMovement : IMovement
{
    public void Move()
    {
        Console.WriteLine("Driving");
    }
}
public class LeggedMovement : IMovement
{
    public void Move()
    {
        Console.WriteLine("Walking");
    }
}
public class LaserWeapon : IWeapon
{

    public void Attack()
    {
        Console.WriteLine("Bum! Bum!");
    }
}
public class MeleeWeapon : IWeapon
{

    public void Attack()
    {
        Console.WriteLine("CHAH!");
    }
}
