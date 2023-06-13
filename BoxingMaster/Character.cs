using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BoxingMaster
{
    internal class Character
    {
        public int reactionSpeed, strength, health, attackSpeed, x, xD, maxH;
        public string name;
        Random randGen = new Random();

        public Character(string _name, int _rs, int _s, int _h, int _as) 
        {
            reactionSpeed = _rs;
            strength = _s;
            health = _h;
            attackSpeed = _as;
            name = _name;
            x = 180;
            xD = 1;
            maxH = _h;
        }

        public void Move(bool attack)
        {
            if (attack)
            {
                x += (18 + 3 * attackSpeed) * xD;
                if(x > 355 - 18 - 3 * attackSpeed || x < 5 + 18 + 3 * attackSpeed) { xD *= -1; }
            }
            else
            {
                x += 3 * xD;
                if (x > 340 || x < 20) { xD *= -1; }
            }
        }

        public int Attack(int a, int d, int eRS)
        {
            //hit type 0 = miss, 1 = hit, 2 = perfect
            int hitType = 0;
            int dif = Math.Abs(a - d);


            if (dif < 50 + 10 * eRS)
            {
                hitType = 0;
            }
            else if(dif < 100 + 20 * eRS)
            {
                int i = randGen.Next(1, 5);
                if(i < strength + 1) { hitType = 1; }
                else { hitType = 2; }
                
            }
            else { hitType = 2; }

            return hitType;
        }
    }
}
