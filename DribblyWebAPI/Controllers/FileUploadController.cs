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
    public class FileController : ApiController
    {
        //private string uploadPath = "D:/RJ/Projects/dribbly-test/www/images/uploads/courts/";
        private string uploadPath;

        public FileController()
        {
            uploadPath = HttpContext.Current.Server.MapPath("~/" + WebConfigurationManager.AppSettings["imageUploadPath"]);
        }

        [Route("api/file/upload")]
        public IHttpActionResult Upload()
        {
            
            string uploadedFilePath = "";

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            if(files.Count > 0)
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

        [Route("api/file/delete")]
        public IHttpActionResult delete()
        {
            try
            {
                string fileName = System.Web.HttpContext.Current.Request.Params["filename"].ToString();
                File.Delete(uploadPath + fileName);
                return Ok("");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }            
        }

    }
}
