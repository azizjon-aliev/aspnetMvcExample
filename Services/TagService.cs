using BlogAPI.Core.Services;
using BlogAPI.Models.Entities;
using BlogAPI.Repositories;

namespace BlogAPI.Services
{
    public class TagService : BaseService<Tag>
    {
        public TagService(TagRepository repository) : base(repository)
        {
        }
    }
}