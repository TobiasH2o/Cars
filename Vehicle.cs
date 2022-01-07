using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Vehicle
    {
        public Section For { get; private set; }
        public Section Mid { get; private set; }
        public Section Rear { get; private set; }
        public int Height { get; private set; } = -1;
        public int Width { get; private set; } = -1;
        public CarComponent Driver { get; private set; }

        public Vehicle()
        {
            List<WeaponSlot> Weapons = new List<WeaponSlot>() {
            new WeaponSlot(3,3,0,0, "Turret A"),
            new WeaponSlot(4,2,1,5, "Weapon Pod A")
            };
            List<WeaponSlot> Weapons2 = new List<WeaponSlot>() {
            new WeaponSlot(3,3,0,0, "Turret B"),
            new WeaponSlot(4,2,2,5, "Weapon Pod B")
            };
            List<WeaponSlot> Weapons3 = new List<WeaponSlot>() {
            new WeaponSlot(2,5,5,0, "Weapon Pod C")
            };
            For = new Section(
                LeftA: new Tuple<int, int>(6, 2),
                RightA: new Tuple<int, int>(6, 2),
                LeftW: new Tuple<int, int, double>(2, 1, 0.15),
                RightW: new Tuple<int, int, double>(2, 1, 0.15),
                EndA: new Tuple<int, int>(2, 10),
                Weapons: Weapons,
                Height: 12);
            Mid = new Section(
                LeftA: new Tuple<int, int>(7, 2),
                RightA: new Tuple<int, int>(7, 2),
                Weapons: Weapons2);
            Rear = new Section(
                LeftA: new Tuple<int, int>(7, 2),
                RightA: new Tuple<int, int>(7, 1),
                LeftW: new Tuple<int, int, double>(3, 2, 0.15),
                RightW: new Tuple<int, int, double>(3, 2, 0.15),
                EndA: new Tuple<int, int>(1, 8),
                Weapons: Weapons3);
            Height = Math.Max(For.Height, Math.Max(Mid.Height, Rear.Height));
            Width = For.Width + Mid.Width + Rear.Width;
        }
    }
}