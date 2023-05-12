using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            if (contractorDTO.contractorID == 0)
            {

                contractor.contractor_name = contractorDTO.contractor_name;
                contractor.address_municipality = contractorDTO.address_municipality;
                contractor.address_barangay = contractorDTO.address_barangay;
                contractor.contractor_type = contractorDTO.contractor_type; 
                Db.ngp_contractor.Add(contractor);
            }


            Db.SaveChanges();

            return Ok();
        }


        //GET DATA ONLY FOR EDIT CONTRACTOR with ID
        [HttpGet]
        [Route("api/contractor/geteditcontractor/{id}")]
        public IHttpActionResult GetEditContractor(int id)
        {
            var editcontractor = Db.ngp_contractor.SingleOrDefault(c => c.contractorID == id);
            return Ok(Mapper.Map<ngp_contractor, ContractorDTO>(editcontractor));
        }



        //EDIT METHOD FOR  SAVING  EDIT CONTRACTOR


        [HttpPost]
        [Route("api/savingeditcontractor/postcontractor/{id}")]
        public IHttpActionResult EditContractorSave(ContractorDTO contractorDTO)
        {


            if (ModelState.IsValid)
            {
                var contractor = Db.ngp_contractor.Single(c => c.contractorID == contractorDTO.contractorID);

                contractor.contractorID = contractorDTO.contractorID;
                contractor.address_municipality = contractorDTO.address_municipality;
                contractor.address_barangay = contractorDTO.address_barangay;
                contractor.contractor_name = contractorDTO.contractor_name;
                contractor.contractor_type = contractorDTO.contractor_type;

            }

            Db.SaveChanges();


            return Ok();

        }
    }
}
