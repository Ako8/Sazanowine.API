using Sazanowine.Application.Features.Wines.Commands.CreateWine;
using Sazanowine.Application.Features.Wines.Commands.UpdateWine;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Wines.Dto;

public static class WineMappers
{
    public static Wine Map(this CreateWineCommand command)
    {
        var newWine = new Wine()
        {
            Name = command.Name,
            Price = command.Price,
            StockQuantity = command.StockQuantity,
            Description = command.Description,
            ImageUrl = command.ImageUrl,
            ForSale = command.ForSale,
            VintageYear = command.VintageYear,
            DiscountedPrice = command.DiscountedPrice,
            IsDiscounted = command.IsDiscounted
        };

        return newWine;
    }

    public static Wine Map(this UpdateWineCommand command, Wine wine)
    {
        wine.Name = command.Name;
        wine.Price = command.Price;
        wine.StockQuantity = command.StockQuantity;
        wine.ForSale = command.ForSale;
        wine.Description = command.Description;
        wine.ImageUrl = command.ImageUrl;
        wine.VintageYear = command.VintageYear;
        wine.DiscountedPrice = command.DiscountedPrice;
        wine.IsDiscounted = command.IsDiscounted;

        return wine;
    }
}
