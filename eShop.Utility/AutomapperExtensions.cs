using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Utility
{
    public static class AutomapperExtensions
    {

        public static TDestination MapObject<TSource, TDestination>(TSource value)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TSource, TDestination>(); });
            IMapper mapper = config.CreateMapper();
            return mapper.Map<TSource, TDestination>(value);
        }
    }
}
