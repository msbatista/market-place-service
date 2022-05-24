using FluentValidation;
using Infrastructure.DataAccess.Configuration;
using WebApi.Models;

namespace WebApi.Modules.FluentValidators;

/// <summary>
/// Catalog item model validator.
/// </summary>
public class CatalogItemModelValidator : AbstractValidator<CatalogItemModel>
{
    /// <summary>
    /// Initializes an instance of CatalogItemModelValidator.
    /// </summary>
    public CatalogItemModelValidator()
    {
        RuleFor(catalogItem => catalogItem.CatalogTypeId).NotEmpty();
        RuleFor(catalogItem => catalogItem.CatalogBrandId).NotEmpty();
        RuleFor(catalogItem => catalogItem.AvailableStock).GreaterThanOrEqualTo(0);
        RuleFor(catalogItem => catalogItem.MaxStockThreshold).GreaterThan(0);
        RuleFor(catalogItem => catalogItem.Name).NotEmpty().MaximumLength(DbLimits.TINY_TEXT);
        RuleFor(catalogItem => catalogItem.Description).MaximumLength(DbLimits.MEDIUM_TEXT);
        RuleFor(catalogItem => catalogItem.Currency).MaximumLength(DbLimits.TINIER_TEXT);
        RuleFor(catalogItem => catalogItem.PictureName).MaximumLength(DbLimits.TINY_TEXT);
        RuleFor(catalogItem => catalogItem.PictureUri).MaximumLength(DbLimits.TINY_TEXT);
    }
}
