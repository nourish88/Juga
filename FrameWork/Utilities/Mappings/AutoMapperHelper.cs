using System.Collections.Generic;
using AutoMapper;
namespace Framework.Utilities.Mappings
{
  public  class AutoMapperHelper
    {
        public static List<TDestination> MapListToList<TSource, TDestination>(List<TSource> list)
        {
            Mapper.Initialize(c => { c.CreateMap<TSource, TDestination>(); });

            List<TDestination> result = Mapper.Map<List<TSource>, List<TDestination>>(list);
            return result;
        }
        public static TDestination MapObjectToObject<TSource, TDestination>(TSource source)
        {
           Mapper.Initialize(c => { c.CreateMap<TSource, TDestination>(); });

            TDestination result = Mapper.Map<TSource, TDestination>(source);
            return result;
        }
        }
       
}
