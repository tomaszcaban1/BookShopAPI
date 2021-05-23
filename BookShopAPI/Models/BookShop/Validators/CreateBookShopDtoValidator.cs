using System;
using System.Linq;
using BookShopAPI.Constants;
using BookShopAPI.Entities.DbContext;
using FluentValidation;

namespace BookShopAPI.Models.BookShop.Validators
{
    public class CreateBookShopDtoValidator : AbstractValidator<CreateBookShopDto>
    {
        private readonly BookShopDbContext _dbContext;

        public CreateBookShopDtoValidator(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;

            BookShopRules();
        }

        private void BookShopRules()
        {
            RuleFor(s => s.Name)
                .Custom((value, context) =>
                {
                    var isNameBookShopExists = _dbContext.BookShops
                        .Any(s => s.Name.Equals(value));

                    if (isNameBookShopExists)
                        context.AddFailure(ValidatorMessage.NameInUse);
                });
        }
    }
}
