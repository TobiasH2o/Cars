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

        public Vehicle()
        {
            List<WeaponSlot> Weapons = new List<WeaponSlot>() {
            new WeaponSlot(3,3,2,2)
            };
            For = new Section(
                LeftA: new Tuple<int, int>(8, 2),
                RightA: new Tuple<int, int>(8, 2),
                LeftW: new Tuple<int, int, double>(3, 1, 0.15),
                RightW: new Tuple<int, int, double>(3, 1, 0.15),
                EndA: new Tuple<int, int>(2, 18));
            Mid = new Section(
                LeftA: new Tuple<int, int>(10, 2),
                RightA: new Tuple<int, int>(10, 2));
            Rear = new Section(
                LeftA: new Tuple<int, int>(10, 2),
                RightA: new Tuple<int, int>(10, 1),
                LeftW: new Tuple<int, int, double>(3, 2, 0.15),
                RightW: new Tuple<int, int, double>(3, 2, 0.15),
                EndA: new Tuple<int, int>(1, 12));
            Height = Math.Max(For.EndA.Height, Rear.EndA.Height);
            Width = For.Width + Mid.Width + Rear.Width;
        }
    }
}