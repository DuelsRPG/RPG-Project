using System;
using System.Collections.Generic;
using System.Linq;

namespace Gladiators
{
    class Program
    {

        List<ClassOfCharaster>  classOfCharastersList;  //Список классов для персонажа
        List<Wepon>             weponsList;             //Список оружия  для персонажа
        List<Equipment>         equipmentsList;         //Список брони   для персонажа

        Player player;
        public static void Main(string[] args)
        {
            Program game = new Program();
            game.startGame();
        }

        void startGame()
        {
            //Инициализация
            initGame();

            //Выбор персонажа
            chooseCharaster();



        }

        //В этой функции мы инициализируем все переменные, которые нам понадобятся
        //в ходе программирования
        void initGame()
        {
            player = new Player();

            classOfCharastersList = new List<ClassOfCharaster>()
            {
                //(Наименование класса, отступ, здоровье, урон )
                new ClassOfCharaster("Воин".PadRight(10),60,20),
                new ClassOfCharaster("Разбойник".PadRight(10),80,10),
                new ClassOfCharaster("Танк".PadRight(10),100,7)
            };
            weponsList = new List<Wepon>()
            {
                //(Наименование, отступ, урон, принадлежность к классу)
                new Wepon("Секира войны".PadRight(17),5,classOfCharastersList[0]),
                new Wepon("Клинок ярости".PadRight(17),8,classOfCharastersList[1]),
                new Wepon("Молот света".PadRight(17),3,classOfCharastersList[2])
            };
            equipmentsList = new List<Equipment>()
            {
                //(Наименование, отступ, здоровье, броня, уклонение, принадлежность к классу)
                new Equipment("Демоническая броня".PadRight(20), 20, 2,0, classOfCharastersList[0]),
                new Equipment("Плащ ночи".PadRight(20),10, 0, 5 , classOfCharastersList[1]),
                new Equipment("Броня света".PadRight(20), 30, 7,0,classOfCharastersList[2])
            };
        }

        //В этой функции мы к классу Player даём Оружие, Снаряжение и Класс
        void chooseCharaster()
        {
            Console.WriteLine("Здравствуйте, введите своё имя: "); player.setName(Console.ReadLine());
            Console.WriteLine($"Привет, {player.getName()}, в этой игре вы сможете ощутить роль гладиатора. ");

            int num = 1;
            Console.WriteLine("Выберите персонажа: ");
            foreach (ClassOfCharaster classOfCharaster in classOfCharastersList) { 
                Console.WriteLine($"{num})\t{classOfCharaster.getName()}-\tHP = {classOfCharaster.getHealth()};\tDMG = {classOfCharaster.getDamage()}.");
                num++;
            }
            player.initClassOfChataster(classOfCharastersList[Convert.ToInt32(Console.ReadLine()) - 1]);

            num = 1;
            Console.WriteLine("Выберите начальное оружие: ");
            foreach (Wepon wepon in weponsList)
            {
                Console.WriteLine($"{num})\t{wepon.getName()} -\tDMG = {wepon.getDamage()};\t CLASS = {wepon.getClassOfCharaster().getName()}.");
                num++;
            }
            player.initWepon(weponsList[Convert.ToInt32(Console.ReadLine()) - 1]);

            num = 1;
            Console.WriteLine("Выберите начальный доспех: ");
            foreach (Equipment equipment in equipmentsList)
            {
                Console.WriteLine($"{num})\t{equipment.getName()} -\tHP = {equipment.getHealth()};\t ARMOR = {equipment.getArmor()};\tDODGE = { equipment.getDodge()}%\t CLASS = {equipment.getClassOfCharaster().getName()}.");
                num++;
            }
            player.initEquipment(equipmentsList[Convert.ToInt32(Console.ReadLine()) - 1]);
        }

        //Функция в которой происходит бой
        void Fight()
        {

        }
        //Функция магазина
        void Shop()
        {

        }

        /*


        void allGame()
        {
            
            
            getResult(player.getHealth, enemy.getHealth);


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
            

            Console.WriteLine(player.getHealth() + " ед. Здоровья");
            Console.WriteLine(player.getDamage() + " ед. Урона");
            Console.WriteLine(player.getArmor() + " ед. Брони");
            Console.ReadLine();
            //Это только первый бой, дальше будут массивы
            Console.WriteLine($"Ваш первый противник - Дункан Холь");
            Console.ReadLine();
            Console.WriteLine("БОЙ!!!");
            FightAction();
        }

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
                            getResult(player.getHealth(), enemy.getHealth());

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
                            getResult(player.getHealth(), enemy.getHealth());

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
                            getResult(player.getHealth(), enemy.getHealth());

                            break;

                        case 1:
                            UserDefence();
                            Console.WriteLine("Вы заблокировали атаку противника");
                            getResult(player.getHealth(), enemy.getHealth());

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
                            getResult(player.getHealth(), enemy.getHealth());

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
                            getResult(player.getHealth(), enemy.getHealth());

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
                            getResult(player.getHealth(), enemy.getHealth());
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
                            getResult(player.getHealth(), enemy.getHealth());
                            break;

                        default:
                            goto case 1;
                    }
                    break;
            }
        }

        void FightAction()
        {
            while ((enemy.getHealth() > 0) && (player.getHealth() > 0))
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
                

                Actions();
            }
            CheckStats();
        }

        void CheckStats()
        {
            if (player.getHealth() <= 0 && enemy.getHealth() >= 0)
            {
                Console.WriteLine("Вы проиграли");
            }
            else if (player.getHealth() > 0 && enemy.getHealth() <= 0)
            {
                Console.WriteLine("Вы Выйграли");
            }
        }
        
        */
    }
}
