using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace DribblyWebAPI.Controllers
{
    public class FileController : ApiController
    {
        private string uploadPath = "D:/RJ/Projects/dribbly-test/www/images/uploads/courts/";

        [Route("api/file/upload")]
        public IHttpActionResult Upload()
        {
            
            string uploadedFilePath = "";

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            try
            {
                string ext = System.IO.Path.GetExtension(files[0].FileName);
                string uploadedFileName;

                do
                {
                    uploadedFileName = DateTime.Now.ToString("yyyyMMddHHmmssfffffff") + ext;
                    uploadedFilePath = uploadPath + uploadedFileName;
                } while (File.Exists(uploadedFilePath));

                
                files[0].SaveAs(uploadedFilePath);

                return Ok(uploadedFileName);

                // int uploadCount = 0;

                //for (int i = 0; i < files.Count; i++)
                //{

                //    System.Web.HttpPostedFile currentFile = files[i];

                //    if (currentFile.ContentLength > 0)
                //    {
                //        uploadedFilePath = uploadPath + Path.GetFileName(currentFile.FileName);
                //        currentFile.SaveAs(uploadedFilePath);
                //        uploadCount++;

                //    }

                //}
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
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
