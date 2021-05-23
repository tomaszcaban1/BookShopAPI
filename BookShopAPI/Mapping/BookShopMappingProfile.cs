using AutoMapper;
using BookShopAPI.Entities;
using BookShopAPI.Models.Book;
using BookShopAPI.Models.BookShop;

namespace BookShopAPI.Mapping
{
    public class BookShopMappingProfile : Profile
    {
        public BookShopMappingProfile()
        {
            BookShopMapping();
            BookMapping();
        }

        private void BookMapping()
        {
            CreateMap<Book, BookDto>();

            CreateMap<CreateBookDto, Book>();
        }

        private void BookShopMapping()
        {
            CreateMap<BookShop, BookShopDto>()
                .ForMember(m => m.ContactEmail, c => c.MapFrom(s => s.Contact.ContactEmail))
                .ForMember(m => m.ContactNumber1, c => c.MapFrom(s => s.Contact.ContactNumber1))
                .ForMember(m => m.ContactNumber2, c => c.MapFrom(s => s.Contact.ContactNumber2))
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.StreetNumber, c => c.MapFrom(s => s.Address.StreetNumber))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<CreateBookShopDto, BookShop>()
                .ForMember(m => m.Contact, c => c.MapFrom(dto => new Contact()
                {
                    ContactEmail = dto.ContactEmail,
                    ContactNumber1 = dto.ContactNumber1,
                    ContactNumber2 = dto.ContactNumber2
                }))
                .ForMember(m => m.Address, c => c.MapFrom(dto => new Address()
                {
                    City = dto.City,
                    Street = dto.Street,
                    StreetNumber = dto.StreetNumber,
                    PostalCode = dto.PostalCode
                }));
        }
    }
}
