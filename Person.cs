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
        protected string typeClassOfCharaster;
        protected int index;
        protected int blockProcent;

        public Specifications() { }
        public Specifications(double damage, double dodge, double health, double armor, string name, string typeClassOfCharaster, int index, int blockProcent)
        {
            this.damage = damage;
            this.dodge = dodge;
            this.health = health;
            this.armor = armor;
            this.name = name;
            this.typeClassOfCharaster = typeClassOfCharaster;
            this.index = index;
            this.blockProcent = blockProcent;
        }
        public Specifications(double damage, double health, double armor, int blockProcent)
        {
            this.damage = damage;
            this.health = health;
            this.armor = armor;
            this.blockProcent = blockProcent;
        }
        //Геттеры
        public double getDamage() { return damage; }
        public double getDodge() { return dodge; }
        public double getHealth() { return health; }
        public double getArmor() { return armor; }
        public string getName() { return name; }
        public string getTypeClassOfCharaster() { return typeClassOfCharaster; }
        public int getIndex() { return index; }
        public int getBlockProcent() { return blockProcent; }

        //Сеттеры
        public void setDamage(double a) { damage = Math.Abs(a); }
        public void setDodge(double a) { dodge = Math.Abs(a); }
        public void setHealth(double a) { health = a; }
        public void setArmor(double a) { armor = a; }
        public void setName(string a) { name = a; }
        public void setTypeClassOfCharaster(string a) { typeClassOfCharaster = a; }
        public void setIndex(int a) { index = a; }
        public void setBlockProcent(int a) { blockProcent = a; }

        //Что может наш класс
        public double kick(Specifications enemy)
        {
            if (!block()) { enemy.health -= damage; return damage; } else return 0;
        }
        public bool block()
        {
            Random r = new Random();
            int nowProcent = r.Next(1, 101);
            return (blockProcent > nowProcent) ? true : false;
        }
    }

    class Enemy : Specifications
    {

    }
    class User : Specifications
    {
        public User(double damage, double health, double armor, int blockProcent)
        {
            this.damage = damage;
            this.health = health;
            this.armor = armor;
            this.blockProcent = blockProcent;
        }
    }

    class Warrior : Specifications
    {
        public static double WarHealth(double a)
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
    }
    class Wepon
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public string Class { get; set; }
        public int Index { get; set; }
    }

    class Equipment
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public double Arrmor { get; set; }
        public string Class { get; set; }
        public int Dodge { get; set; }
        public int Index { get; set; }
    }
}
