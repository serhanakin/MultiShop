using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
        {
            new ApiResource("ResourceCatalog") {
                Scopes = { "CatalogFullPermission", "CatalogReadPermission" }
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes = { "DiscountFullPermission" }
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = { "OrderFullPermission" }
            }
        };

    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full access to Catalog API"),
            new ApiScope("DiscountFullPermission", "Full access to Discount API"),
            new ApiScope("OrderFullPermission", "Full access to Order API"),
            new ApiScope("CatalogReadPermission", "Read only access to Catalog API"),
        };
}
