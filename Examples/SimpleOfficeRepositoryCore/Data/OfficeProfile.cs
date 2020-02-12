using AutoMapper;
using RESTWebService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleOfficeRepositoryCore.Data
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<OfficeProfile, OfficeModel>();
        }
    }
}
