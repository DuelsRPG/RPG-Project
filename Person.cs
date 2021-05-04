using System;
using System.Collections.Generic;
using System.Text;

namespace Gladiators
{
    class Specifications
    {
        //Нормально
        protected double damage;
        protected double dodge;
        protected double health;
        protected double armor;
        protected string name;
        protected int blockProcent;
        protected int blockPenetration;

        //Геттеры
        public double getDamage() { return damage; }
        public double getDodge() { return dodge; }
        public double getHealth() { return health; }
        public double getArmor() { return armor; }
        public string getName() { return name; }
        public int getBlockProcent() { return blockProcent; }
        public int getBlockPenetration() { return blockPenetration; }

        //Сеттеры
        public void setDamage(double a) { damage = Math.Abs(a); }
        public void setDodge(double a) { dodge = Math.Abs(a); }
        public void setHealth(double a) { health = a; }
        public void setArmor(double a) { armor = a; }
        public void setName(string a) { name = a; }
        public void setBlockProcent(int a) { blockProcent = a; }
        public void setBlockPenetration(int a) { blockPenetration = a; }

        //Что может наш класс
        public double kick(Specifications enemy)
        {
            if (!block() || chanceBlockPenetration() || chanceDodge()) { enemy.health -= damage; return damage; } else return 0;
        }
        public bool block()
        {
            Random r = new Random();
            int nowProcent = r.Next(1, 101);
            return (blockProcent > nowProcent) ? true : false;
        }

        public bool chanceDodge()
        {
            Random d = new Random();
            int nowDodgeProcent = d.Next(1, 101);
            return (dodge > nowDodgeProcent) ? true : false;
        }
        public bool chanceBlockPenetration()
        {
            Random cbp = new Random();
            int nowDodgePenetration = cbp.Next(1,101);
            return (blockPenetration > nowDodgePenetration) ? true : false;
        }
    }

    class Player : Specifications
    {
        private Wepon               mainWepon;
        private Equipment           mainEquipment;
        private ClassOfCharaster    mainClass;

        public string className;
        public double health;
        public double damage;
        public double armor;
        public double dodge;
        public int blockProcent;
        public int blockPenetration;
        

        public void initWepon(Wepon a) 
        { 
            mainWepon = a;
            //считаем дать ли баф или дебаф
            // сделать так же проверку на схожесть с дружественным классом
            damage += a.getDamage() * ((a.getClassOfCharaster() == mainClass) ? 1.5 : 0.5);
        }
        public void initEquipment(Equipment a) { 
            mainEquipment = a;
            
            //считаем дать ли баф или дебаф
            // сделать так же проверку на схожесть с дружественным классом
            health += a.getHealth() * ((a.getClassOfCharaster() == mainClass) ? 1.5 : 0.5);
            armor += a.getArmor() * ((a.getClassOfCharaster() == mainClass) ? 1.5 : 0.5);
            dodge = (1-(1-(mainClass.getDodge())/100)*(1-(a.getDodge() * ((a.getClassOfCharaster() == mainClass) ? 1.5 : 0.5))/100))*100;
        }
        public void initClassOfChataster(ClassOfCharaster a) { 
            mainClass = a;

            damage    = a.getDamage();
            health    = a.getHealth();
            className = a.getName();
            dodge = a.getDodge();
           blockProcent = a.getBlockProcent();
    }
        public Player() { }

        public Player(double health, double damage, double armor, double dodge, int blockProcent, int blockPenetration)
        {

        }
        public string getSpecification()
        {
            return $"Вы - {className} у вас: \n\t {damage} DMG  \n\t {health} HP \n\t {armor} Брони \n\t {dodge}% уклониться";
        }

        public bool live()
        {
            return (health<=0) ? false: true;
        }

    }
    
    class ClassOfCharaster
    {
        private double damage;
        private double health;
        private double dodge;
        private string name;
        public int blockProcent;
        public int blockPenetration;

        public ClassOfCharaster(string name, double health, double damage, double dodge, int blockProcent, int blockPenetration)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
            this.dodge = dodge;
            this.blockProcent = blockProcent;
            this.blockPenetration = blockPenetration;
        }

        public void setDamage(double a) { damage = a; }
        public void setHealth (double a) { health = a; }
        public void setDodge(double a) { dodge = a; }
        public void setName(string a) { name = a; }
        public void setBlockProcent(int a) { blockProcent = a; }
        public void setBlockPenetration(int a) { blockPenetration = a; }


        public double getDamage() { return damage; }
        public double getHealth() { return health; }
        public double getDodge() { return dodge; }
        public string getName() { return name; }
        public int getBlockProcent() { return blockProcent; }
        public int getBlockPenetration() { return blockPenetration; }
    }

    class Wepon
    {
        private double damage;
        private string name;
        private ClassOfCharaster classOfCharaster;

        public Wepon(string name, double damage, ClassOfCharaster classOfCharaster)
        {
            this.name = name;
            this.damage = damage;
            this.classOfCharaster = classOfCharaster;
        }

        public void setDamage(double a) { damage = a; }
        public void setName(string a) { name = a; }
        public void setClassOfCharaster(ClassOfCharaster a) { classOfCharaster = a; }

        public double getDamage() { return damage; }
        public string getName() { return name; }
        public ClassOfCharaster getClassOfCharaster() { return classOfCharaster; }

    }
    class Equipment
    {
        private ClassOfCharaster classOfCharaster;
        private double health;
        private double armor;
        private double dodge;
        private string name;

        public Equipment(string name, double health, double armor, double dodge, ClassOfCharaster classOfCharaster)
        {
            this.name = name;
            this.health = health;
            this.armor = armor;
            this.dodge = dodge;
            this.classOfCharaster = classOfCharaster;
        }

        public void setHealth(double a) { health = a; }
        public void setArmor(double a) { armor = a; }
        public void setDodge(double a) { dodge = a; }
        public void setName(string a) { name = a; }
        public void setClassOfCharaster(ClassOfCharaster a) { classOfCharaster = a; }

        public double getHealth() { return health; }
        public double getArmor() { return armor; }
        public double getDodge() { return dodge; }
        public string getName() { return name; }
        public ClassOfCharaster getClassOfCharaster() { return classOfCharaster; }

    }

    //Это будет переделано
    /*class Warrior : Specifications
    {
        public double WarHealth(double a)
        {
            double WarriorHP = a * 1.2;
            return WarriorHP;
        }
    }
    class Rouge : Specifications
    {
        public static double RogHealth(double b)
        {
            double RougeHP = b * 0.8;
            return RougeHP;
        }
    }
    class Tank : Specifications
    {
        public static double TankArrmor(double a)
        {
            double TankArm = a * 1.5;
            return TankArm;
        }
    }*/


}
