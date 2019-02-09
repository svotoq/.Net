using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNo_9
{
    public delegate void OneHit();
    public delegate void ThreeHit();
    public delegate void msg(string message);
    class Boss
    {
        public event msg Attacked;
        private string Name { get; set; }
        private int HP { get; set; }
        private bool Agressive { get; set; }
        private int Damage { get; set; }
        private int Level { get; set; }
        private string type;
        private string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value == "Petya" || value == "ROBOT")
                {
                    type = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        public Boss(string Name, string Type)
        {
            this.Name = Name;
            this.Type = Type;
            HP = 100;
            Agressive = false;
            Level = 1;
            Damage = 30;
        }
        public static void Help(Boss boss)
        {
            if(boss.type == "Petya")
            {
                Console.WriteLine("\nСПРАВКА!!");
                Console.WriteLine("================================");
                Console.WriteLine("Это Петя, а Петю бить нельзя:>");
                Console.WriteLine("================================\n");
            }
            if(boss.type == "ROBOT")
            {
                Console.WriteLine("\nСПРАВКА!!");
                Console.WriteLine("================================");
                Console.WriteLine("Босс типа \"ROBOT\"" +
                    $"\nИмя: {boss.Name}" +
                    "\nСпособность: Повышение сопротивления к урону" +
                    "\nУровень 2: <70HP, Сопротивление: 50%" +
                    "\nУровень 3: <28HP, Сопротивление: 75%\n");
                Console.WriteLine("================================\n");
            }
        }
        public void Atack()
        {
            Attacked?.Invoke("Удар!");
            if (type == "Petya")
            {
                Console.WriteLine("Хммм.... Ошибочка! Вызовите справку!");
                return;
            }
            if (HP < 0)
            {
                Console.WriteLine("Вы пинаете мертвую тушку!");
            }
            else
            {
                if (!Agressive)
                {
                    TurnOn();
                }
                switch (Level)
                {
                    case 2: Damage = 21; break;
                    case 3: Damage = 8; break;
                }
                HP -= Damage;
                Console.WriteLine($"Урон {Damage}HP");
                if (HP == 70 || HP == 28)
                {
                    Upgrade();
                }
            }
        }
        private void Upgrade()
        {
            Level++;
            Console.WriteLine("ВНИМАНИЕ!");
            Console.WriteLine($"Босс {Name} перешел на уровень {Level}!");
            Console.WriteLine($"Сопротивление урону {Level * 25}%");
        }
        private void TurnOn()
        {
            Agressive = true;
            Console.WriteLine($"Внимание! Вы заагрили Босса \"{Name}\"!");
        }
        public static void Status(Boss boss)
        {
            Console.WriteLine($"====={boss.Name}=====");
            if (boss.HP < 0)
            {
                Console.WriteLine("Мертв");
            }
            else
            {
                Console.WriteLine($"HP:{boss.HP}");
                Console.WriteLine($"HP:{boss.Level}");
            }
            Console.WriteLine($"===============");
        }
    }
}