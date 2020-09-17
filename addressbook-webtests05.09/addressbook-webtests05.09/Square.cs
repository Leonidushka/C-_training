﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_webtests05._09
{
    class Square : Figure
    {
        private int size;
        private bool colored = false;

        public Square(int size)
        {
            this.size = size;
        }

        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

       
    }
}
