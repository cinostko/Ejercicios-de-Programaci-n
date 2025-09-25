using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_3
{
    class Player
    {
        private int health;
        private int damage;

        public Player(int health, int damage)
        {
            this.health = Math.Min(health, 100);
            this.damage = Math.Min(damage, 100);
        }

        public void ReceiveDamage(int dmg)
        {
            health -= dmg;
            if (health < 0) health = 0;
        }

        public int GetDamage() => damage;

        public bool IsAlive() => health > 0;

        public int GetHealth() => health;
    }

    class Enemy
    {
        protected int health;
        protected int damage;

        public Enemy(int health, int damage)
        {
            this.health = Math.Min(health, 100);
            this.damage = Math.Min(damage, 100);
        }

        public void ReceiveDamage(int dmg)
        {
            health -= dmg;
            if (health < 0) health = 0;
        }

        public virtual int GetDamage() => damage;

        public bool IsAlive() => health > 0;

        public int GetHealth() => health;

        public virtual string GetTypeName() => "Enemy";
    }

    class MeleeEnemy : Enemy
    {
        public MeleeEnemy(int health, int damage) : base(health, damage) { }

        public override string GetTypeName() => "Melee";
    }

    class RangedEnemy : Enemy
    {
        private int bullets;

        public RangedEnemy(int health, int damage, int bullets) : base(health, damage)
        {
            this.bullets = bullets;
        }

        public override int GetDamage()
        {
            if (bullets > 0)
            {
                bullets--;
                return damage;
            }
            return 0;
        }

        public bool HasBullets() => bullets > 0;

        public override string GetTypeName() => "Ranged";
    }

    class Game
    {
        private Player player;
        private List<Enemy> enemies;

        public Game(Player player, List<Enemy> enemies)
        {
            this.player = player;
            this.enemies = enemies;
        }

        public void Start()
        {
            int turn = 1;

            while (player.IsAlive() && enemies.Exists(e => e.IsAlive()))
            {
                Console.WriteLine($"\n--- Turn {turn} ---");
                ShowStatus();

                
                Console.WriteLine("elige un enemigo para atacar :3:");
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].IsAlive())
                        Console.WriteLine($"{i + 1}: {enemies[i].GetTypeName()} (HP: {enemies[i].GetHealth()})");
                }

                int choice;
                while (true)
                {
                    Console.Write("ingresa el numero del enemigoo: ");
                    if (int.TryParse(Console.ReadLine(), out choice) &&
                        choice >= 1 && choice <= enemies.Count &&
                        enemies[choice - 1].IsAlive())
                    {
                        break;
                    }
                    Console.WriteLine("invalido, intenta otra vez.");
                }

                enemies[choice - 1].ReceiveDamage(player.GetDamage());
                Console.WriteLine($"has atacado al enemigo :) {choice} por {player.GetDamage()} daño!");

               
                foreach (var enemy in enemies)
                {
                    if (enemy.IsAlive())
                    {
                        int dmg = enemy.GetDamage();
                        player.ReceiveDamage(dmg);
                        Console.WriteLine($"{enemy.GetTypeName()} el enemigo te ataca {dmg} daño!");
                        break; 
                    }
                }

                turn++;
            }

            Console.WriteLine(player.IsAlive() ? "\nGnasteeeeeee!" : "\nperdiste uu");
        }

        private void ShowStatus()
        {
            Console.WriteLine($"player HP: {player.GetHealth()}");
            for (int i = 0; i < enemies.Count; i++)
            {
                string status = enemies[i].IsAlive() ? $"HP: {enemies[i].GetHealth()}" : "muerto";
                Console.WriteLine($"Enemy {i + 1} ({enemies[i].GetTypeName()}): {status}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Player player = new Player(100, 30);
            List<Enemy> enemies = new List<Enemy>
        {
            new MeleeEnemy(50, 10),
            new RangedEnemy(40, 15, 3)
        };

            Game game = new Game(player, enemies);
            game.Start();
        }
    }

}
