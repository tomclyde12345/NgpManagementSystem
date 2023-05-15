using AutoMapper;
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
                Db.ngp_contractor.Add(contractor);
            }


            Db.NgpLogsContractors.Add(new NgpLogsContractor()
            {

                Date = DateTime.Now,
                Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                LogMessage = "Added a Contractor " + "Name: " + contractorDTO.contractor_name,
                UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,


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

    }
}
