using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace ImageProcessing.Pages
{
    public class ImageUploadModel : PageModel
    {
        public string CurrentTime { get; set; }
        public IFormFile File { get; set; }

        public void OnGet()
        {
            CurrentTime = $"Current time is {DateTime.Now}";
        }

        public async Task OnPost()
        {
            await RotateImage();
        }

        private async Task RotateImage()
        {
            //Convert image to grayscale

            Stream imageStream = new MemoryStream();
            File.CopyTo(imageStream);
            Bitmap bitmap = new(imageStream);

            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images",  $"{File.FileName}rotated.jpg");

            bitmap.Save(filePath);
        }
    }
}
