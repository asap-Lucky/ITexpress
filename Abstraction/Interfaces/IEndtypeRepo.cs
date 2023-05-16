﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Interfaces
{
    public interface IEndtypeRepo
    {
        void AddEndtype(IEndType endtype);

        IEndType GetEndtype(int id);

        List<IEndType> GetAllEndTypes();
    }
}
