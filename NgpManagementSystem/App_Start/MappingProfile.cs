using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<NgpUser, AccountDTO>().ReverseMap();
            Mapper.CreateMap<NgpRole, RoleDTO>().ReverseMap();
            Mapper.CreateMap<ngp_contractor, ContractorDTO>().ReverseMap();
            Mapper.CreateMap<NgpMunicipality, MunicipalityDTO>().ReverseMap();
            Mapper.CreateMap<NgpBarangay, BarangayDTO>().ReverseMap();
            Mapper.CreateMap<ngp_projects, ProjectDTO>().ReverseMap();
            Mapper.CreateMap<ngp_contract, ContractDTO>().ReverseMap();
            Mapper.CreateMap<ngp_payment, PaymentDTO>().ReverseMap();
        }
    }
}