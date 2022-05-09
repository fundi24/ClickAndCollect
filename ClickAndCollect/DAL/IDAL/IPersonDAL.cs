﻿using ClickAndCollect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickAndCollect.DAL
{
    public interface IPersonDAL
    {
        public bool AccountExists(Person p);
        public Person GetAllFromUser(Person p);
    }
}
