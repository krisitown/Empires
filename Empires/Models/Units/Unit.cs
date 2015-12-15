using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.Models.Interfaces;

namespace Empires.Models
{
    public abstract class Unit : IUnit
    {
        private int health;
        private int attackDamage;

        protected Unit(int hp, int ad)
        {
            this.Health = hp;
            this.AttackDamage = ad;
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health cannot drop below 0");
                }
                this.health = value;
            }
        }

        public int AttackDamage
        {
            get
            {
                return this.attackDamage; 
                
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Attack Damage cannot be negative");
                }
                this.attackDamage = value;
            }
        }
    }
}
