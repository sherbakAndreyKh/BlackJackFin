﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DAL.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAll();
        void Save();
    }
}
