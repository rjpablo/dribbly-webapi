using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;

namespace DribblyWebAPI.Controllers
{
    public class FileUploadController : ApiController
    {
        public string Upload()
        {
            string uploadPath = System.Web.Hosting.HostingEnvironment.MapPath("~/images/uploads/courts");

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            try
            {
                int uploadCount = 0;

                for (int i = 0; i < files.Count; i++)
                {

                    System.Web.HttpPostedFile currentFile = files[i];

                    if (currentFile.ContentLength > 0)
                    {
                        currentFile.SaveAs(uploadPath + Path.GetFileName(currentFile.FileName));
                        uploadCount++;

                    }

                }

                return uploadCount + " files uploaded successfully!";
            }
            catch (Exception ex)
            {
                return "Upload failed with error '" + ex.Message + "'";
            }
            
        }
    }
}
