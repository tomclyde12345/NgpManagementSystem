using AutoMapper;
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
            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/SampleImg/");
            var provider =
                new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content
                    .ReadAsMultipartAsync(provider);
                ScryptEncoder encoder = new ScryptEncoder();
                NgpUser res = new NgpUser();

                if (res.Id == 0)
                {
                    res.Name = provider.FormData["Name"];
                    res.Email = provider.FormData["Email"];
                    res.UserName = provider.FormData["UserName"];
                    res.Password = encoder.Encode(provider.FormData["Password"]);
                    res.RoleID = Convert.ToInt32(provider.FormData["RoleID"]);

                    Db.NgpUsers.Add(res);
                    Db.NgpLogsUserAccounts.Add(new NgpLogsUserAccount()
                    {

                        Date = DateTime.Now,
                        Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                        UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                        LogMessage = "Added a  User Account  " + "Name of user: " + res.Name,
                        UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                        RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID,


                    });

                }

                Db.SaveChanges();

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

                                NgpUpload upload = new NgpUpload();

                                if (name == null || name.Length == 0)
                                {
                                    upload.FilePath = "/DefaultImage/denr.png";
                                }
                                else
                                {
                                    upload.FilePath = "/SampleImg/" + dateNew + name;
                                }
                                upload.FileName = name;
                                upload.AccountId = res.Id;

                                Db.NgpUploads.Add(upload);
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





        //EDIT  PROFILE IMAGE
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

                            if (key == "AccountId")
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
                                NgpUpload upload = new NgpUpload();

                                {
                                    upload.FilePath = "/SampleImg/" + dateNew + name;
                                }

                                upload.FileName = name;
                                upload.AccountId = Convert.ToInt32(provider.FormData["AccountId"]);
                                upload.Id = res.Id;
                                Db.NgpUploads.Add(upload);
                               
                            };
                        Db.SaveChanges();

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

            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if (ModelState.IsValid)
            {
                var accountdt = Db.NgpUsers.Single(c => c.Id == editaccountDTO.Id);

                accountdt.Id = editaccountDTO.Id;
                accountdt.Name = editaccountDTO.Name;
                accountdt.UserName = editaccountDTO.UserName;
                accountdt.Email = editaccountDTO.Email;
                accountdt.RoleID = editaccountDTO.RoleID;

            Db.NgpLogsUserAccounts.Add(new NgpLogsUserAccount()
            {

                Date = DateTime.Now,
                Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                LogMessage = "Edit a  User Account  " + "Name of user: " + accountdt.Name+ "Name of Editor:"+ accountdt.UserName + "Role:" + accountdt.NgpRole.RoleName,
                UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID,
            });

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
            var upload = Db.NgpUploads.OrderByDescending(u => u.Id).FirstOrDefault(u => u.AccountId == id);
            return Ok(upload);
        }

    



        //SAVING RESET PASSWORD

        [HttpPost]
        [Route("api/resetpassword/postresetpassword/{id}")]
        public IHttpActionResult SavingResetPassword(AccountDTO resetpass)
        {
            var sess_id = (int)HttpContext.Current.Session["LoginID"];
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

                Db.NgpLogsUserAccounts.Add(new NgpLogsUserAccount()
                {

                    Date = DateTime.Now,
                    Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                    UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                    LogMessage = "Reset a Password " + "Name of user: " + accountdt.Name + "UserName:" + accountdt.UserName + " Role:" + accountdt.NgpRole.RoleName,
                    UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                    RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID,
                });

            }

            Db.SaveChanges();


            return Ok();

        }


        //CREATE/SAVING METHODS ROLE
        [HttpPost]
        [Route("api/saverole/post")]
        public IHttpActionResult SaveRole(RoleDTO roleDTO)
        {
            var role = Mapper.Map<RoleDTO, NgpRole>(roleDTO);

            if (roleDTO.Id == 0)
            {

                role.RoleName = roleDTO.RoleName;



                Db.NgpRoles.Add(role);
            }


            Db.SaveChanges();

            return Ok();

        }
    }
}
