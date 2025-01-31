using API.Entities;

namespace API.Extensions;
public static class ProductExtensions
{
    public static IQueryable<Product> Sort(this IQueryable<Product> query, string? orderBy)
    {
        query = orderBy switch
        {
            "price" => query.OrderBy(x => x.Price),
            "priceDesc" => query.OrderByDescending(x => x.Price),
            _ => query.OrderBy(x => x.Name),
        };
        return query;
    }

    public static IQueryable<Product> Search(this IQueryable<Product> query, string? SearchTerm)
    {
        if (string.IsNullOrWhiteSpace(SearchTerm))
            return query;

        var lowerCaseSearchTerm = SearchTerm.Trim().ToLower();

        return query.Where(x => x.Name.ToLower().Contains(lowerCaseSearchTerm));
    }

    public static IQueryable<Product> Filter (this IQueryable<Product> query, string? brands, string? type) {
        var brandList = new List<string>();
        var typeList = new List<string>();

        if(!string.IsNullOrWhiteSpace(brands)) {
            brandList.AddRange([.. brands.ToLower().Split(",")]);
        }

        if(!string.IsNullOrEmpty(type)) {
            typeList.AddRange([.. type.ToLower().Split(",")]);
        }
        query = query.Where(x => brandList.Count == 0 || brandList.Contains(x.Brand.ToLower()));
        query = query.Where(x => typeList.Count == 0 || typeList.Contains(x.Type.ToLower()));
        return query;
    }
}
