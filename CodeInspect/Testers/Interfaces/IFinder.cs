﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodeInspect.Testers.Interfaces
{
    interface IFinder<out T>
    {
        IEnumerable<T> GetItems();
    }
}
