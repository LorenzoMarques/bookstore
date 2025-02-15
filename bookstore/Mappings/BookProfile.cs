using AutoMapper;
using bookstore.Dtos.Book;
using bookstore.Dtos.Category;
using bookstore.Dtos.User;
using bookstore.Models;

namespace bookstore.Mappings
{
    public class BookProfile: Profile
    {
        public BookProfile() {
            CreateMap<UpdateBookDto, Book>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.BookCategories, opt => opt.MapFrom(src => src.BookCategories));

            CreateMap<BookCategory, CategoryDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Category.Name));
        }
    }
}
