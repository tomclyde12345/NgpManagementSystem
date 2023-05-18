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
            Mapper.CreateMap<ngp_sched, SchedDTO>().ReverseMap();
            Mapper.CreateMap<NgpYear, YearDTO>().ReverseMap();
            Mapper.CreateMap<NgpLogsUserAccount, LogsAccountDTO>().ReverseMap();
            Mapper.CreateMap<NgpLogsContractor, LogsContractorDTO>().ReverseMap();
            Mapper.CreateMap<NgpLogsContract, LogsContractDTO>().ReverseMap();
            Mapper.CreateMap<NgpLogsPayment, LogsPaymentDTO>().ReverseMap();
            Mapper.CreateMap<NgpLogsProject, LogsProjectDTO>().ReverseMap();
            Mapper.CreateMap<NgpLogsSched, LogsSchedDTO>().ReverseMap();
            Mapper.CreateMap<NgpMaintenanceMode, MaintenanceModeDto>().ReverseMap();
        }
    }
}