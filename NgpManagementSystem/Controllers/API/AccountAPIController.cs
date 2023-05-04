﻿using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using Scrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{

    public class AccountAPIController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        //get data for user
        [HttpGet]
        [Route("api/accountdata/get")]
        public IHttpActionResult GetAccountdata()
        {
            var usergetdata = Db.NgpUsers.ToList().Select(Mapper.Map<NgpUser, AccountDTO>);
            return Ok(usergetdata);
        }




        //get data for role
        [HttpGet]
        [Route("api/roledata/get")]
        public IHttpActionResult GetRoleData()
        {
            var role = Db.NgpRoles.ToList().Select(Mapper.Map<NgpRole, RoleDTO>);
            return Ok(role);
        }

        //GET DATA ONLY FOR EDIT ACCOUNT with ID
        [HttpGet]
        [Route("api/editaccount/geteditaccount/{id}")]
        public IHttpActionResult GetDataEditAccount(int id)
        {
            var editaccount = Db.NgpUsers.SingleOrDefault(c => c.Id == id);
            return Ok(Mapper.Map<NgpUser, AccountDTO>(editaccount));
        }



        //SAVEVING ACCOUNT CREATION WITH INCLUDE PROFILE IMAGE

        [HttpPost]
        [Route("api/addaccount/post")]

        public async Task<string> PostImage()
        {

            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/SampleImg/");
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);
                ScryptEncoder encoder = new ScryptEncoder();
                NgpUser user = new NgpUser();

                if (user.Id == 0)
                {
                    user.Name = provider.FormData["Name"];
                    user.Email = provider.FormData["Email"];
                    user.UserName = provider.FormData["UserName"];
                    user.Password = encoder.Encode(provider.FormData["Password"]);
                    user.RoleID = Convert.ToInt32(provider.FormData["RoleID"]);

                }


                foreach (var file in provider.FileData)
                {
                    foreach (var key in provider.FormData.AllKeys)
                    {
                        foreach (var val in provider.FormData.GetValues(key))
                        {
                            if (key == "FileName")
                            {
                                var name = file.Headers
                                .ContentDisposition
                                .FileName;

                                // remove double quotes from string.
                                var dateNew = Convert.ToString(DateTime.Now.Ticks) + "-";
                                name = name.Trim('"');

                                var localFileName = file.LocalFileName;
                                var filePath = Path.Combine(root, dateNew + name);

                                File.Move(localFileName, filePath);



                                if (name == null || name.Length == 0)
                                {
                                    user.FilePath = "/DefaultImage/city-hall.png";
                                }
                                else
                                {
                                    user.FilePath = "/SampleImg/" + dateNew + name;
                                }
                                user.FileName = name;
                                user.Id = user.Id;

                                Db.NgpUsers.Add(user);
                                Db.SaveChanges();


                            }
                        }
                    }
                }


            }
            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            return "File uploaded!";
        }




        //EDIT METHOD FOR  SAVING  EDIT ACCOUNT

        [HttpPost]
        [Route("api/savingeditaccount/post/{id}")]
        public IHttpActionResult EditAccount(AccountDTO editaccountDTO)
        {


            if (ModelState.IsValid)
            {
                var accountdt = Db.NgpUsers.Single(c => c.Id == editaccountDTO.Id);

                accountdt.Id = editaccountDTO.Id;
                accountdt.Name = editaccountDTO.Name;
                accountdt.UserName = editaccountDTO.UserName;
                accountdt.Email = editaccountDTO.Email;
                accountdt.RoleID = editaccountDTO.RoleID;


            }

            Db.SaveChanges();


            return Ok();

        }

        //DELETE METHOD FOR  DELETE ACCOUNT

        [HttpDelete]
        [Route("api/accountdelete/getaccountdelete/{id}")]
        public IHttpActionResult DeleteAccount(int id)
        {


            var deletedb = Db.NgpUsers.SingleOrDefault(d => d.Id == id);

            if (deletedb == null)
            {
                return NotFound();
            }
            Db.NgpUsers.Remove(deletedb);


            Db.SaveChanges();
            return Ok();
        }

        //QUERY USERS ONLY SHOW PICTURE ONLY BY USERS PICS ID
        [HttpGet]
        [Route("api/account/getpics/{id}")]
        public IHttpActionResult GetPics(int id)
        {
            var account = Db.NgpUsers.OrderByDescending(u => u.Id).FirstOrDefault(u => u.Id == id);
            return Ok(account);
        }


        //CHANGE PROFILE PICTURE SAVING PHOTO

        [HttpPost]
        [Route("api/changephoto")]
        public async Task<string> ChangePhoto()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/SampleImg/");
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);

                NgpUser res = new NgpUser();

                foreach (var file in provider.FileData)
                {
                    foreach (var key in provider.FormData.AllKeys)
                    {
                        foreach (var val in provider.FormData.GetValues(key))

                            if (key == "Id")
                            {
                                var name = file.Headers
                                       .ContentDisposition
                                       .FileName;

                                // remove double quotes from string.
                                name = name.Trim('"');
                                var dateNew = Convert.ToString(DateTime.Now.Ticks) + "-";

                                var localFileName = file.LocalFileName;
                                var filePath = Path.Combine(root, dateNew + name);

                                File.Move(localFileName, filePath);


                                {
                                    res.FilePath = "~/SampleImg/" + dateNew + name;
                                }

                                res.FileName = name;
                                res.Id = Convert.ToInt32(provider.FormData["Id"]);
                                res.Id = res.Id;

                                Db.SaveChanges();

                            };


                    }
                }


            }

            catch (Exception e)
            {
                return $"Error: {e.Message}";
            }

            return "File uploaded!";
        }

        //SAVING RESET PASSWORD

        [HttpPost]
        [Route("api/resetpassword/postresetpassword/{id}")]
        public IHttpActionResult SavingResetPassword(AccountDTO resetpass)
        {

            ScryptEncoder encoder = new ScryptEncoder();
            if (ModelState.IsValid)
            {
                var accountdt = Db.NgpUsers.Single(c => c.Id == resetpass.Id);

                accountdt.Id = resetpass.Id;
                accountdt.Name = resetpass.Name;
                accountdt.UserName = resetpass.UserName;
                accountdt.Email = resetpass.Email;
                accountdt.RoleID = resetpass.RoleID;
                accountdt.Password = encoder.Encode(resetpass.Password);



            }

            Db.SaveChanges();


            return Ok();

        }

    }
}
