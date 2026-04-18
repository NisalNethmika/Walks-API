using WebApp1.Models.Domain;

namespace WebApp1.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
