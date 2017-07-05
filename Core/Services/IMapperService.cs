using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface IMapperService
    {
        T Map<T, I>(I input);
    }
}
