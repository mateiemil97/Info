using AutoMapper;
using Entities;
using Models.CategoryModel;
using Models.HistoryModels;
using Models.LocationModels;
using Models.PriceModels;
using Models.ToolboothModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controllers
{
    public class MapperClass: Profile
    {
        public MapperClass()
        {
            CreateMap<Location, GetLocationModel>();
            CreateMap<Toolbooth, GetToolboothModel>();
            CreateMap<Category, GetCategoryModel>();
            CreateMap<Price, GetPriceModel>();
            CreateMap<CreateHistoryModel,History>();
        }
    }
}
