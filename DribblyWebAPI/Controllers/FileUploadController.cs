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
            string uploadPath = "D:/RJ/Projects/dribbly-test/www/images/uploads/courts/";
            string uploadedFilePath = "";

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

            try
            {
                int uploadCount = 0;

                for (int i = 0; i < files.Count; i++)
                {

                    System.Web.HttpPostedFile currentFile = files[i];

                    if (currentFile.ContentLength > 0)
                    {
                        uploadedFilePath = uploadPath + Path.GetFileName(currentFile.FileName);
                        currentFile.SaveAs(uploadedFilePath);
                        uploadCount++;

                    }

                }

                return uploadedFilePath;
            }
            catch (Exception ex)
            {
                return "Upload failed with error '" + ex.Message + "'";
            }
            
        }
    }
}
