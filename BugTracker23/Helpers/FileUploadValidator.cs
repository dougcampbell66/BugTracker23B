﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;

namespace BugTracker23.Helpers
{
    public class FileUploadValidator
    {
        public static bool IsWebFriendlyFile(HttpPostedFileBase file)
        {
        if (file == null)
        {
            return false;
        }

        if (file.ContentLength > 2 * 1024 * 1024 || file.ContentLength < 1024)
        {
            return false;
        }

        try
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var AllowableExtensions = WebConfigurationManager.AppSettings["AllowableExtensions"].Split(',');
            return AllowableExtensions.Contains(fileExtension);
        }
        catch
        {
            return false;
        }
    }
}
}