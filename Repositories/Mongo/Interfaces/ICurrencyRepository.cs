﻿using MongoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mongo.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> Get();
    }
}
