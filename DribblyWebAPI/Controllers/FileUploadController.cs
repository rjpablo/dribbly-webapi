using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using System.Web.Configuration;

namespace DribblyWebAPI.Controllers
{
    [RoutePrefix("api/file")]
    public class FileController : ApiController
    {
        //private string uploadPath = "D:/RJ/Projects/dribbly-test/www/images/uploads/courts/";
        private string uploadPath;

        public FileController()
        {
            uploadPath = HttpContext.Current.Server.MapPath("~/" + WebConfigurationManager.AppSettings["imageUploadPath"]);
        }

        [Route("UploadCourtPhoto/{userId}")]
        public IHttpActionResult UploadCourtPhoto(string userId)
        {
            //string userId = "";

            string folderPath = uploadPath + userId + '/';

            string uploadedFilePath = "";

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            if (files.Count > 0)
            {
                try
                {
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string ext = System.IO.Path.GetExtension(files[0].FileName);
                    string uploadedFileName;

                    do
                    {
                        uploadedFileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ext;
                        uploadedFilePath = folderPath + uploadedFileName;
                    } while (File.Exists(uploadedFilePath));

                    files[0].SaveAs(uploadedFilePath);

                    return Ok(uploadedFileName);

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            else
            {
                return BadRequest("No files to upload.");
            }
        }

        [Route("upload")]
        public IHttpActionResult Upload()
        {
            
            string uploadedFilePath = "";

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            if (files.Count > 0)
            {
                try
                {
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string ext = System.IO.Path.GetExtension(files[0].FileName);
                    string uploadedFileName;

                    do
                    {
                        uploadedFileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ext;
                        uploadedFilePath = uploadPath + uploadedFileName;
                    } while (File.Exists(uploadedFilePath));

                    files[0].SaveAs(uploadedFilePath);

                    return Ok(uploadedFileName);

                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                }
            }
            else
            {
                return BadRequest("No files to upload.");
            }                        
        }

        [Route("deleteCourtPhoto/{fileName}/{userId}")]
        public IHttpActionResult delete(string fileName, string userId)
        {
            try
            {
                //string fileName = System.Web.HttpContext.Current.Request.Params["filename"].ToString();
                //string userId = System.Web.HttpContext.Current.Request.Params["userId"].ToString();
                File.Delete(uploadPath + userId + '/' + fileName);
                return Ok("");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }  
        }

    }
}
