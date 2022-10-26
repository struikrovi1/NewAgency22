namespace NewAgency.Helper
{
    public static class ImageHelper
    {
        
        public static string UploadImage(IFormFile Image, IWebHostEnvironment _env)
        {
            var path = "/uploads/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }
            return path;
        }

        public static void DeleteImage(string photoName)
        {

        }
    }
}
