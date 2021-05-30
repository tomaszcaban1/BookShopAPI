using System;
using System.Linq;
using BookShopAPI.Constants;
using FluentValidation;

namespace BookShopAPI.Models.Book.Validators
{
    public class BookQueryValidator : AbstractValidator<BookQuery>
    {
        private readonly int[] _pageSizeTaken = new[] { 10, 50, 100 };
        private readonly string[] _columnSortTaken = {
            nameof(BookDto.Author)
            , nameof(BookDto.Description)
            , nameof(BookDto.Price)
            , nameof(BookDto.Title)
        };

        public BookQueryValidator()
        {
            RuleFor(p => p.PageNumber).GreaterThanOrEqualTo(1);

            RuleFor(p => p.PageSize)
                .Must(value => _pageSizeTaken.Contains(value))
                .WithMessage(ValidatorMessage.PageSize + $"[{string.Join(",", _pageSizeTaken)}]");

            RuleFor(p => p.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || _columnSortTaken.Contains(value))
                .WithMessage(ValidatorMessage.SortBy + $"[{string.Join(",", _columnSortTaken)}]");
        }
    }
}
