using System;

namespace ConsoleApp
{
    public class Weapon
    {
        private readonly int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage <= 0 || bullets <= 0) throw new ArgumentOutOfRangeException();
            _damage = damage;
            _bullets = bullets;
        }

        public void Fire(Player player)
        {
            if (player.IsPlayerAlive() && _bullets > 0)
            {
                player.Hit(_damage);
                _bullets -= 1;
            }
        }
    }

    public class Player
    {
        private int _health;

        public Player(int health)
        {
            if (health <= 0) throw new ArgumentOutOfRangeException();
            _health = health;
        }

        public void Hit(int damage)
        {
            _health -= damage;
        }

        public bool IsPlayerAlive()
        {
            return _health > 0;
        }

    }

    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}