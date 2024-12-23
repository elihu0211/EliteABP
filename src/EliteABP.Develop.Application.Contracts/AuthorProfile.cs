using AutoMapper;
using EliteABP.Develop.Authors;
using EliteABP.Develop.Dtos.Author;

namespace EliteABP.Develop;
public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // 將用於創建方法的輸入 DTO, 映射到 Author 實體
        CreateMap<CreateAuthorDto, Author>();
        //.Ignore(author => author.Id); // 忽略 Id 屬性

        // 當應用方法返回值類型是基礎 DTO 時, 將 Author 實體映射到基礎 DTO
        CreateMap<Author, AuthorDto>();
    }
}