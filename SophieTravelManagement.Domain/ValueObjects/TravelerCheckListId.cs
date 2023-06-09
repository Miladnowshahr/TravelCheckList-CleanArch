﻿using SophieTravelManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SophieTravelManagement.Domain.ValueObjects
{
    public record TravelerCheckListId
    {
        public Guid Value { get; }

        public TravelerCheckListId(Guid value)
        {
            if (value == Guid.Empty)
                throw new TravelerCheckListIdException();
            Value = value ;
        }

        public static implicit operator Guid(TravelerCheckListId id) => id.Value;

        public static implicit operator TravelerCheckListId(Guid id) => new(id);
    
    }
}

//6280237086276025-850-3667260