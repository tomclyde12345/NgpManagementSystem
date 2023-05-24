using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using NgpManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{
    public class ContractorAPIController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        } 
        //CREATE/SAVING METHODS contractor
        [HttpPost
        ]
        [Route("api/contractor/post")
        ]
        public IHttpActionResult SaveContractor(ContractorDTO contractorDTO)
        {
            var contractor = Mapper.Map<ContractorDTO, ngp_contractor>(contractorDTO);

            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if (contractorDTO.contractorID == 0)
            {

                contractor.contractor_name = contractorDTO.contractor_name;
                contractor.address_municipality = contractorDTO.address_municipality;
                contractor.address_barangay = contractorDTO.address_barangay;
                contractor.contractor_type = contractorDTO.contractor_type;
                //for Project
                contractor.location_municipality = contractorDTO.location_municipality;
                contractor.location_barangay = contractorDTO.location_barangay;
                contractor.area = contractorDTO.area;
                contractor.year_form = contractorDTO.year_form;
                contractor.penro = contractorDTO.penro;
                contractor.cenro = contractorDTO.cenro;
                contractor.region = contractorDTO.region;
                //for contract year 1
                contractor.moanumber_year1 = contractorDTO.moanumber_year1;
                contractor.datemoasigned_year1 = contractorDTO.datemoasigned_year1;
                contractor.contractcost_year1 = contractorDTO.contractcost_year1;
                contractor.dateobligated_year1 = contractorDTO.dateobligated_year1;
                contractor.orsno_year1 = contractorDTO.orsno_year1;
                contractor.num_seedlings_produced_year1 = contractorDTO.num_seedlings_produced_year1;
                contractor.commodity_year1 = contractorDTO.commodity_year1;
                contractor.num_seedlings_planted_year1 = contractorDTO.num_seedlings_planted_year1;
                contractor.survivalrate_year1 = contractorDTO.survivalrate_year1;




                contractor.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
                contractor.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving role depend in UserId login
                contractor.UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName; //saving username depend in login
                contractor.Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving username depend in login
                Db.ngp_contractor.Add(contractor);
            }


            Db.NgpLogsContractors.Add(new NgpLogsContractor()
            {

                Date = DateTime.Now,
                Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                LogMessage = "Added a Contractor " + "Name: " + contractorDTO.contractor_name,
                UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.NgpRole.RoleName,


            });

            Db.SaveChanges();

            return Ok();


        }

        //GET in form contractor
        [Route("api/contractorget/get/{id}")]
        [HttpGet]
        public IHttpActionResult GetContractorData(int id)
        {
            var contractor = Db.ngp_contractor.SingleOrDefault(d => d.contractorID == id);
            if (contractor == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ngp_contractor, ContractorDTO>(contractor));
        }


        //Put
        [HttpPut]
        [Route("api/contractorput/updatecontractor/{id}")]
        public IHttpActionResult UpdateDept(int id, ContractorDTO contractorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contractorinDb = Db.ngp_contractor.SingleOrDefault(d => d.contractorID == id);
            if (contractorinDb == null)
            {
                return NotFound();
            }
            Mapper.Map(contractorDTO, contractorinDb);
            contractorinDb.contractorID = id;
            contractorinDb.contractor_name =  contractorDTO.contractor_name;
            contractorinDb.address_barangay = contractorDTO.address_barangay;
            contractorinDb.address_municipality = contractorDTO.address_municipality;


            Db.SaveChanges();
            return Ok();
        }



        [HttpDelete]
        [Route("api/contractordelete/delete/{id}")]
        public IHttpActionResult DeleteContractor(int id)
        {
            var contractorinDb = Db.ngp_contractor.SingleOrDefault(d => d.contractorID == id);
            if (contractorinDb == null)
            {
                return NotFound();
            }
            Db.ngp_contractor.Remove(contractorinDb);
            //_db.LoginActivity.Add(new LoginActivity()
            //{
            //    UserName = User.Identity.GetFullName(),
            //    ActivityMessage = "Deleted A Department",
            //    ActivityDate = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
            //    Email = User.Identity.GetUserName(),

            //});
            Db.SaveChanges();
            return Ok();
        }

    }
}
