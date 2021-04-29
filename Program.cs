using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiators
{
    class Program
    {
        List<User> personList;
        List<Equipment> equipments;
        List<Wepon> wepons;

        User player;

        double ModyficateArmDmg(double a)
        {
            a = 100 * ((0.06 * a) / (1 + 0.06 * a));
            return a;
        }
        void getResult(double UH, double EH)
        {
            Console.WriteLine("У вас - " + UH + " ед. Здоровья");
            Console.WriteLine("У врага - " + EH + " ед. Здоровья");
        }
        void initLists()
        {
            personList = new List<User>()
            {
                new User(20,60,2,5),
                new User(10,80,7,15),
                new User(7,100,10,30)
                //new User{Index = 2, health = 80, Damage = 10, Armor = 7,  typeClassOfCharaster = "Воин" , Dodge = 10},
                //new User{Index = 3, health = 100, Damage = 7, Armor = 10,  typeClassOfCharaster = "Танк" , Dodge = 0}
            };
            equipments = new List<Equipment>()
            {
                new Equipment{Index = 1,Name ="Демоническая броня", Health = 20, Arrmor = 2, Class = "Воин"},
                new Equipment{Index = 2,Name ="Плащ ночи", Health = 10, Dodge = 5 , Class = "Разбойник"},
                new Equipment{Index = 3,Name ="Демоническая броня", Health = 30, Arrmor = 7,Class = "Танк"}
            };
            wepons = new List<Wepon>()
            {
                new Wepon{Index = 1, Damage = 5, Name= "Секира войны", Class = "Воин"},
                new Wepon{Index = 2, Damage = 8, Name = "Клинок ярости", Class = "Разбойник" },
                new Wepon{Index = 3, Damage = 3, Name= "Молот света", Class = "Танк"}
            };
        }

        void chooseCharaster()
        {
            Console.WriteLine("Выберите персонажа: ");
            foreach (var charaster in personList)
            {
                switch (charaster.getTypeClassOfCharaster())
                {
                    case "Воин":
                        charaster.setHealth(Warrior.WarHealth(charaster.getHealth()));

                        break;

                    case "Разбойник":
                        charaster.setHealth(Rouge.RogHealth(charaster.getHealth()));

                        break;
                    case "Танк":
                        charaster.setArmor(Tank.TankArrmor(charaster.getArmor()));

                        break;
                }
                Console.WriteLine($"{charaster.getIndex()}. {charaster.getName()} {charaster.getHealth()} HP {charaster.getDamage()} DMG {charaster.getTypeClassOfCharaster()}");
            }
            player = personList[Convert.ToInt32(Console.ReadLine()) - 1];
        }

        void chooseStartInventory()
        {

        }

        void allGame()
        {
            Random random = new Random();
            Console.WriteLine("Здравствуйте, введите своё имя: ");
            string UserName = Console.ReadLine();
            Console.WriteLine($"Привет, {UserName}, в этой игре вы сможете ощутить роль гладиатора. ");

            //Инициализация листов
            initLists();

            //Выбор персонажа
            chooseCharaster();

            Enemy enemy = new Enemy();
            enemy.getHealth() = 75;
            enemy.Damage = 10;
            enemy.Armor = 3;
            enemy.Dodge = 10;

            Console.WriteLine("Выберите оружие: ");
            foreach (var wepon in wepons)
            {
                Console.WriteLine($"{wepon.Index}. {wepon.Damage} DMG {wepon.Class}");
            }
            Wepon UserWepon = wepons[Convert.ToInt32(Console.ReadLine()) - 1];
            player.mainWepon = UserWepon;
            //temp
            player.kick(enemy);
            enemy.kick(player);
            //endtemp
            Console.WriteLine("Выберите доспех: ");

            foreach (var equipment in equipments)
            {
                Console.WriteLine($"{equipment.Index}. {equipment.Name} {equipment.Health} HP, {equipment.Arrmor} Брони, шанс уворота { equipment.Dodge}%");
            }

            var UserEquipment = equipments[Convert.ToInt32(Console.ReadLine()) - 1];

            switch (player.typeClassOfCharaster)
            {
                case "Разбойник":
                    switch (UserWepon.Class)
                    {
                        case "Воин":
                            player.Damage += UserWepon.Damage * 0.75;
                            break;
                        case "Танк":
                            player.Damage += UserWepon.Damage * 0;
                            player.Dodge *= 0.1;
                            break;
                        case "Разбойник":
                            player.Damage += UserWepon.Damage * 1.25;
                            break;
                    }
                    switch (UserEquipment.Class)
                    {
                        case "Воин":
                            player.Damage *= 0.8;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge *= 0.25;
                            break;
                        case "Танк":
                            player.Damage *= 0.5;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge = 0;
                            break;
                        case "Разбойник":
                            player.Damage *= 1.1;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge *= 1 - UserEquipment.Dodge;
                            break;
                    }
                    break;
                case "Воин":
                    switch (UserWepon.Class)
                    {
                        case "Воин":
                            player.Damage += UserWepon.Damage * 1.25;
                            break;
                        case "Танк":
                            player.Damage += UserWepon.Damage * 0.9;
                            break;
                        case "Разбойник":
                            player.Damage += UserWepon.Damage * 0.7;
                            break;
                    }
                    switch (UserEquipment.Class)
                    {
                        case "Воин":
                            player.Damage *= 0.8;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge *= 0.25;
                            break;
                        case "Танк":
                            player.Damage *= 0.9;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge = 0;
                            break;
                        case "Разбойник":
                            player.getHealth *= 0.85;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge *= 1 - UserEquipment.Dodge;
                            break;
                    }
                    break;
                case "Танк":
                    switch (UserWepon.Class)
                    {
                        case "Воин":
                            player.Damage += UserWepon.Damage;
                            break;
                        case "Танк":
                            player.Damage += UserWepon.Damage * 1.3;
                            break;
                        case "Разбойник":
                            player.Damage += UserWepon.Damage * 0.8;
                            break;
                    }
                    switch (UserEquipment.Class)
                    {
                        case "Воин":
                            player.Damage *= 1;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge *= 1;
                            break;
                        case "Танк":
                            player.getHealth += UserEquipment.Health * 1.25;
                            player.Armor += UserEquipment.Arrmor * 1.2;
                            player.Dodge = 0;
                            break;
                        case "Разбойник":
                            player.Damage *= 0.85;
                            player.getHealth += UserEquipment.Health;
                            player.Armor += UserEquipment.Arrmor;
                            player.Dodge *= 1 - UserEquipment.Dodge;
                            break;
                    }
                    break;
            }



            getResult(player.getHealth, enemy.getHealth);

            void CheckStats()
            {
                if (player.getHealth <= 0 && enemy.getHealth >= 0)
                {
                    Console.WriteLine("Вы проиграли");
                }
                else if (player.getHealth > 0 && enemy.getHealth <= 0)
                {
                    Console.WriteLine("Вы Выйграли");
                }
            }

            bool UserDodge(double ud)
            {
                bool Dodge = false;
                int UDodgeChanse = random.Next(0, 100);
                if (UDodgeChanse <= ud && UDodgeChanse != 0)
                {
                    Dodge = true;
                }

                return Dodge;
            }


            bool EnemyDodge(double ed)
            {
                bool Dodge = false;
                int EDodgeChanse = random.Next(0, 100);
                if (EDodgeChanse <= ed)
                {
                    Dodge = true;
                }

                return Dodge;
            }


            #region НЕГУЖНОЕ ГОВНИЦО

            void UserAtack()
            {
                enemy.getHealth -= (player.Damage - (int)Math.Round(player.Damage * (ModyficateArmDmg(enemy.Armor) / 100)));
            }

            void EnemyAtack()
            {
                player.getHealth -= (enemy.Damage - (int)Math.Round(player.Damage * (ModyficateArmDmg(player.Armor) / 100)));
            }

            void EnemyDefence()
            {

                enemy.getHealth -= 0;

            }

            void UserDefence()
            {

                player.getHealth -= 0;

            }

            void BothDefence()
            {
                Console.WriteLine("Вы оба решили блокировать атаку");
            }
            #endregion
            void FightAction()
            {
                while ((enemy.getHealth > 0) && (player.getHealth > 0))
                {
                    char UserAction = '0';
                    try
                    {
                        UserAction = Convert.ToChar(Console.ReadLine());
                    }
                    catch
                    {
                        UserAction = '\0';
                    }

                    int EnemyAction = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                    int value = random.Next(1, 11);
                    //Не советую трогать, просто поверьте, оно работает
                    void Actions()
                    {

                        switch (UserAction)
                        {
                            case '1':
                                switch ((int)(EnemyAction % ((int)(value % 3) + 0.1)))
                                {
                                    case 0:
                                        EnemyDefence();
                                        Console.WriteLine("Противник заблокировал ваш удар");
                                        getResult(player.getHealth, enemy.getHealth);

                                        break;
                                    case 1:
                                        Console.WriteLine("Вы оба нанесли атаку");
                                        if (UserDodge(player.Dodge))
                                        {
                                            Console.WriteLine("Вы увернулись от удара.");
                                        }
                                        else
                                        {
                                            EnemyAtack();
                                        }

                                        if (EnemyDodge(enemy.Dodge))
                                        {
                                            Console.WriteLine("Противник увернулся от вашей атаки.");
                                        }
                                        else
                                        {
                                            UserAtack();
                                        }
                                        getResult(player.getHealth, enemy.getHealth);

                                        break;
                                    default:
                                        goto case 1;


                                }
                                break;
                            case '2':
                                switch ((int)(EnemyAction % ((int)(value % 2) + 0.1)))
                                {
                                    case 0:
                                        BothDefence();
                                        getResult(player.getHealth, enemy.getHealth);

                                        break;

                                    case 1:
                                        UserDefence();
                                        Console.WriteLine("Вы заблокировали атаку противника");
                                        getResult(player.getHealth, enemy.getHealth);

                                        break;
                                    default:
                                        goto case 1;
                                }
                                break;
                            case '\0':
                                Console.WriteLine("Вы пропустили ход.");
                                switch ((int)(EnemyAction % ((int)(value % 2) + 0.1)))
                                {
                                    case 0:
                                        Console.WriteLine("Противник решил показать вам, какой у него красивый щит");
                                        getResult(player.getHealth, enemy.getHealth);

                                        break;
                                    case 1:

                                        Console.WriteLine("Противник воспользовался шансом и нанёс вам удар");
                                        if (UserDodge(player.Dodge))
                                        {
                                            Console.WriteLine("Вы увернулись от удара.");
                                        }
                                        else
                                        {
                                            EnemyAtack();
                                        }
                                        getResult(player.getHealth, enemy.getHealth);

                                        break;
                                    default:
                                        goto case 1;
                                }
                                break;
                            default:
                                Console.WriteLine("Вы пропустили ход.");
                                switch ((int)(EnemyAction % ((int)(value % 2) + 0.1)))
                                {
                                    case 0:
                                        Console.WriteLine("Противник тоже решил пропустить ход");
                                        getResult(player.getHealth, enemy.getHealth);
                                        break;
                                    case 1:
                                        Console.WriteLine("Противник воспользовался шансом и нанёс вам удар");
                                        if (UserDodge(player.Dodge))
                                        {
                                            Console.WriteLine("Вы увернулись от удара.");
                                        }
                                        else
                                        {
                                            EnemyAtack();
                                        }
                                        getResult(player.getHealth, enemy.getHealth);
                                        break;

                                    default:
                                        goto case 1;
                                }
                                break;
                        }
                    }

                    Actions();
                }
                CheckStats();
            }

            Console.WriteLine(player.getHealth + " ед. Здоровья");
            Console.WriteLine(player.Damage + " ед. Урона");
            Console.WriteLine(player.Armor + " ед. Брони");
            Console.ReadLine();
            //Это только первый бой, дальше будут массивы
            Console.WriteLine($"Ваш первый противник - Дункан Холь");
            Console.ReadLine();
            Console.WriteLine("БОЙ!!!");
            FightAction();
        }

        static void Main(string[] args)
        {
            Program game = new Program();
            game.allGame();
        }

    }
}
