using System;
namespace PhoneBookApp.Repositories.Interfaces
{
	public interface IFileService
	{
        public Tuple<int, string> SaveImage(IFormFile ProfilePicture);
        public bool DeleteImage(string ProfilePictureName);
    }
}

