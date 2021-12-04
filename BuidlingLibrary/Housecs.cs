using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuidlingLibrary
{
    class Housecs
    {
        internal Housecs()
        {

        }
        private Guid id = Guid.NewGuid();
        private int floor;
        private decimal heigth;
        private int entrance;
        private int flat;

        public Guid Get_id()
        {
            return id;
        }
        public void setfloor(int a)
        {
            floor = a;
        }
        public int Getfloor()
        {
            return floor;
        }
        public void Setheigth(decimal a)
        {
            heigth = a;
        }
        public decimal Gethigth()
        {
            return heigth;
        }
        public void set_flats(int number)
        {
            flat = number;
        }
        public int get_flat()
        {
            return flat;
        }
        public void set_entrance(int number)
        {
            entrance = number;
        }
        public int get_entrance()
        {
            return entrance;
        }
        public double get_heigh_of_floor()
        {
            return (double)heigth / floor;
        }
        public int get_count_of_flat_on_floor()
        {
            return flat / floor;
        }
        public int get_count_of_flat_on_entrance()
        {
            return flat / entrance;
        }
    }
}
