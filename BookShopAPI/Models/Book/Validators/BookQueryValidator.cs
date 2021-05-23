using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopAPI.Constants;
using BookShopAPI.Models.BookShop;
using FluentValidation;

namespace BookShopAPI.Models.Book.Validators
{
    public class BookQueryValidator : AbstractValidator<BookQuery>
    {
        private readonly int[] _pageSizeTaken = new[] {10, 50, 100};
        public BookQueryValidator()
        {
            RuleFor(p => p.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(p => p.PageSize).Custom((value, contex) =>
            {
                if (!_pageSizeTaken.Contains(value))
                {
                    contex.AddFailure(ValidatorMessage.PageSize + $"[{string.Join(",", _pageSizeTaken)}]");
                }
            });
        }
    }
}
