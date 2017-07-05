using AutoMapper;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class MapperService : IMapperService
    {
        public MapperService()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<dynamic, InputModel<OrderIntentSlotType>>();
            });
        }

        public T Map<T, I>(I input)
        {
            return Mapper.Map<T>(input);
        }
    }
}
