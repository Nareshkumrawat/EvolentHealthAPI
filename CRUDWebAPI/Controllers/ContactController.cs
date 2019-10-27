using CRUDWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDWebAPI.Controllers
{
    [RoutePrefix("Api/Contact")]
    public class ContactController : ApiController
    {
        private readonly EvolentHealthDBEntities context;
        public ContactController()
        {
            context = new EvolentHealthDBEntities();
        }

        /// <summary>
        /// EvolentHealthWEBAPI - Add Contact Details in [tbl_ContactDetails] table.
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("InsertContactDetails")]
        public HttpResponseMessage Add(ContactDetails contactDetails)
        {
            try
            {
                context.InsertContactDetails(contactDetails.FirstName, contactDetails.LastName, contactDetails.Email, contactDetails.PhoneNo);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", ResponseMessage = "Contact Created Successfully !", Error = "" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ResponseStatus = "error", ResponseMessage = "Something went wrong !", Error = ex.Message });
            }
        }


        /// <summary>
        /// EvolentHealthWEBAPI - Update Contact Details in [tbl_ContactDetails] table.
        /// </summary>
        /// <param name="contactDetails"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateContactDetails")]
        public HttpResponseMessage Update(ContactDetails contactDetails)
        {
            try
            {                                                         
                ContactDetails objContactDetails = new ContactDetails();
                objContactDetails = context.ContactDetails.Find(contactDetails.ContactId);

                if (objContactDetails != null)
                {
                    context.UpdateContactDetails(contactDetails.ContactId, contactDetails.FirstName, contactDetails.LastName, contactDetails.Email, contactDetails.PhoneNo, contactDetails.StatusMode);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", message = "Contact Update Successfully !", Error = "" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", message = "Contact Id Not Exists !", Error = "" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ResponseStatus = "error", message = "Something went wrong !", Error = ex.Message });
            }
        }

        /// <summary>
        /// EvolentHealthWEBAPI - Delete Contact Details from [tbl_ContactDetails] table using ContactId.
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteContactDetails")]
        public HttpResponseMessage Delete(int? ContactId)
        {
            try
            {
                ContactDetails objContactDetails = new ContactDetails();
                objContactDetails = context.ContactDetails.Find(ContactId);

                if (objContactDetails != null)
                {
                    context.DeleteContactDetail(ContactId);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", ResponseMessage = "Contact Delete Successfully !", Error = "" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", ResponseMessage = "Contact Id Not Exists !", Error = "" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ResponseStatus = "error", ResponseMessage = "Something went wrong !", Error = ex.Message });
            }
        }

        /// <summary>
        /// EvolentHealthWEBAPI - Get All Contact Details from [tbl_ContactDetails] table.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetContactDetails")]
        public HttpResponseMessage GetAllContactDetails()
        {
            try
            {
                var data = context.GetAllContactDetails();

                return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", ResponseData = data.ToList(), ResponseMessage = "All Contact Details Get Successfully !", Error = "" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ResponseStatus = "error", ResponseMessage = "Something went wrong !", Error = ex.Message });
            }
        }

        /// <summary>
        /// EvolentHealthWEBAPI - Get All Contact Details from [tbl_ContactDetails] table using ContactId.
        /// </summary>
        /// <param name="ContactId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetContactDetailsById")]
        public HttpResponseMessage GetContactDetail(int? ContactId)
        {
            try
            {
                ContactDetails objContactDetails = new ContactDetails();
                objContactDetails = context.ContactDetails.Find(ContactId);

                if (objContactDetails != null)
                {
                    var data = context.GetContactDetailsById(ContactId).FirstOrDefault();
                    return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", ResponseData = data, ResponseMessage = "Contact Get Successfully !", Error = "" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Accepted, new { ResponseStatus = "success", ResponseMessage = "Contact Id Not Exists !", Error = "" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { ResponseStatus = "error", ResponseMessage = "Something went wrong !", Error = ex.Message });
            }
        }

    }
}