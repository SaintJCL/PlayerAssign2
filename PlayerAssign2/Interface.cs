using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IPlayer
    {
        Guid Id { get; }
        string Name { get; set; }

    }
}
