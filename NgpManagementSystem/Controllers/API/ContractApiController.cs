using AutoMapper;
using Microsoft.Ajax.Utilities;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{
    public class ContractApiController : ApiController
    {

        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }


        //get data for YEAR
        [HttpGet]
        [Route("api/yeargetdata/get")]
        public IHttpActionResult GetYEARrData()
        {
            var year = Db.NgpYears.ToList().Select(Mapper.Map<NgpYear, YearDTO>);
            return Ok(year.OrderByDescending(x => x.Id));
        }


        //CREATE/SAVING METHODS CONTRACT
        [HttpPost]
        [Route("api/contract/post")]
        public IHttpActionResult SaveContract(ContractDTO contractDTO)
        {
            if (ModelState.IsValid)
            {
                var contract = Mapper.Map<ContractDTO, ngp_contract>(contractDTO);
                var sess_id = (int)HttpContext.Current.Session["LoginID"];
                if (contractDTO.contractID == 0)
                {

                    contract.moa = contractDTO.moa;
                    contract.contractorName = contractDTO.contractorName;
                    contract.location_municipality = contractDTO.location_municipality;
                    contract.location_barangay = contractDTO.location_barangay;
                    contract.area = contractDTO.area;
                    contract.commodity = contractDTO.commodity;
                    contract.commodity_type = contractDTO.commodity_type;
                    contract.survival_rate = contractDTO.survival_rate;
                    contract.project_name = contractDTO.project_name;
                    contract.contract_cost = contractDTO.contract_cost;
                    contract.site_code = contractDTO.site_code;
                    contract.year_established = contractDTO.year_established;
                    contract.num_seedlings_planted = contractDTO.num_seedlings_planted;
                    contract.num_seedlings_produced = contractDTO.num_seedlings_produced;
                    contract.num_seedlings_survived = contractDTO.num_seedlings_survived;
                    contract.num_seedlings_replanted = contractDTO.num_seedlings_replanted;
                    contract.num_seedlings_survived_year1 = contractDTO.num_seedlings_survived_year1;
                    contract.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
                    contract.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving role depend in UserId login
                    contract.UserName = Db.NgpUsers.FirstOrDefault(o=>o.Id== sess_id)?.UserName; //saving username depend in login
                    contract.Name= Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving username depend in login



                    //contract.contractorName = Db.ngp_contractor.SingleOrDefault(x => x.contractorID == contractDTO.contractID).contractor_name;

                    Db.ngp_contract.Add(contract);
                       
                }
                Db.NgpLogsContracts.Add(new NgpLogsContract()
                {

                    Date = DateTime.Now,
                    Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                    UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                    LogMessage = "Added a Contract " + "Contractor Name: " + contractDTO.contractorName,
                    UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                    RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.NgpRole.RoleName,

                });

            }

            Db.SaveChanges();

            return Ok();

        }

        //get data for contractor
        [HttpGet]
        [Route("api/contractorgetdata/get")]
        public IHttpActionResult GetContractorData()
        {
            var contractor = Db.ngp_contractor.ToList().Select(Mapper.Map<ngp_contractor, ContractorDTO>);
            return Ok(contractor.OrderByDescending(x=>x.contractorID));
        }
    }
}
