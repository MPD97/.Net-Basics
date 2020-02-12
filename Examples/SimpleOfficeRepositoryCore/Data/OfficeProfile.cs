using AutoMapper;
using RESTWebService.ViewModels;
using SimpleOfficeRepositoryCore.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOfficeRepositoryCore.Data
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<OfficeModel, Office>();
            CreateMap<Office, OfficeModel>();

        }
    }
}
