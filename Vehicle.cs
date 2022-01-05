using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class Vehicle
    {
        private Section For;
        private Section Mid;
        private Section Rear;

        public Vehicle()
        {
            For = new Section(
                LeftA: new Tuple<int, int>(2, 8),
                RightA: new Tuple<int, int>(2, 8),
                LeftW: new Tuple<int, int, double>(2, 3, 0.15),
                RightW: new Tuple<int, int, double>(2, 3, 0.15),
                EndA: new Tuple<int, int>(12, 2));
            Mid = new Section(
                LeftA: new Tuple<int, int>(2, 6),
                RightA: new Tuple<int, int>(2, 6));
            Rear = new Section(
                LeftA: new Tuple<int, int>(2, 8),
                RightA: new Tuple<int, int>(2, 8),
                LeftW: new Tuple<int, int, double>(2, 3, 0.15),
                RightW: new Tuple<int, int, double>(2, 3, 0.15),
                EndA: new Tuple<int, int>(12, 1));
        }
    }
}