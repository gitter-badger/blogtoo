using System;
using System.IO;
using System.Web.Mvc;

namespace BlogToo.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult Resource(string path)
        {
            // Remove the Server HTTP Response Header from being sent
            HttpContext.Response.Headers.Remove("Server");

            // Map to path of file in the default App_Data/Resources folder
            var fullPath = HttpContext.Server.MapPath("~/App_Data/Resources/" + path);

            // If file does not exist send a default 404
            if (String.IsNullOrEmpty(path) || !System.IO.File.Exists(fullPath))
            {
                return Redirect("/Error/404");
            }

            // Get Content-Type from file extension
            var contentType = GetMimeTypeFromExtension(System.IO.Path.GetExtension(fullPath));

            // Create file stream
            var fileStream = new System.IO.FileStream(fullPath, FileMode.Open);

            // Send the file
            Response.ContentType = contentType;
            return new FileStreamResult(fileStream, contentType);
        }

        /// <summary>
        /// Returns a mime type for a given file extension
        /// </summary>
        /// <param name="extension">File Extension</param>
        /// <returns></returns>
        private string GetMimeTypeFromExtension(string extension)
        {
            switch (extension)
            {
                case ".3pg": // Third Generation Partnership Project - Mobile Video
                    return "video/3gpp";
                case ".7z": // 7Zip Archive
                    return "application/x-7z-compressed";
                case ".aac": // Advanced Audio Coding
                    return "audio/aac";
                case ".ac3": // Dolby Digital AC-3 Audio Format
                    return "audio/ac3";
                case ".avi": // Audio Video Interleave
                    return "video/x-msvideo";
                case ".css": // Cascading Style Sheets
                    return "text/css";
                case ".csv": // Comma Separated Values
                    return "text/csv";
                case ".doc": // Word
                    return "application/msword";
                case ".docx": // Word 2007+
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case ".flac": // Free Lossless Audio Codec
                    return "audio/flac";
                case ".flv": // Flash Video
                    return "video/x-flv";
                case ".gif": // Graphics Interchange Format 
                    return "image/gif";
                case ".gtar": // GNU Tape Archive
                    return "application/x-gtar";
                case ".gz": //  GNU Zip
                    return "application/x-gzip";
                case ".ico": // Icon
                    return "image/x-icon";
                case ".jpg": // Joint Photographic Experts Group
                case ".jpeg":
                    return "image/jpeg";
                case ".js": // JavaScript
                    return "application/javascript";
                case ".json": // JavaScript Object Notation
                    return "application/json";
                case ".m4a":
                    return "audio/m4a";
                case ".mov":
                    return "video/quicktime";
                case ".mp2":
                case ".mpg":
                case ".mpeg":
                    return "video/mpeg";
                case ".mp3":
                    return "audio/mpeg";
                case ".mp4a":
                    return "audio/mp4";
                case ".mp4":
                case ".mp4v":
                    return "video/mp4";
                case ".odp":
                    return "application/vnd.oasis.opendocument.presentation";
                case ".ods":
                    return "application/vnd.oasis.opendocument.spreadsheet";
                case ".odt":
                    return "application/vnd.oasis.opendocument.text";
                case ".oga": // Xiph Ogg Audio
                case ".ogg":
                    return "audio/ogg";
                case ".ogv": // Xiph Ogg Video
                    return "video/ogg";
                case ".pdf": // Adobe Portable Document Format
                    return "application/pdf";
                case ".png": // Portable Network Graphics
                    return "image/png";
                case ".ppt": // PowerPoint
                    return "application/vnd.ms-powerpoint";
                case ".pptx": // PowerPoint 2007+
                    return "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                case ".qt": // QuickTime Video
                    return "video/quicktime";
                case ".rtf": // Rich Text File
                    return "application/rtf";
                case ".svg": // Scalable Vector Graphics
                    return "image/svg+xml";
                case ".swf": // Adobe Shockwave Flash
                    return "application/x-shockwave-flash";
                case ".tar": // Tape Archive
                    return "application/x-tar";
                case ".tif": // Tagged Image File Format
                case ".tiff":
                    return "image/tiff";
                case ".torrent": // Torrent
                    return "application/x-bittorrent";
                case ".txt": // Text 
                    return "text/plain";
                case ".vxml": // Voice XML
                    return "application/voicexml+xml";
                case ".wav": // Waveform Audio File Format
                case ".wave":
                    return "audio/wav";
                case ".webm": // Google Web Media Format
                    return "video/webm";
                case ".webp": // Google Wep Photo Format
                    return "image/webp";
                case ".wma": // Windows Media Audio
                    return "audio/x-ms-wma";
                case ".xls": // Excel
                    return "application/vnd.ms-excel";
                case ".xlsx": // Excel 2007+
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                case ".xml": // XML (Extensible Markup Language)
                    return "application/xml";
                case ".zip": // Zip Archive
                    return "application/zip";
                default: // The default type for unknown data files
                    return "application/octet-stream"; 
            }
        }
    }
}