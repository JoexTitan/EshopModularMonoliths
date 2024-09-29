namespace Catalog.Products.Models;

// POCO (Plain Old C# Object) - Anemic Model
// DDD - Domain Rich Model - Entity Rich Model

public class Product : Aggregate<Guid> // every attribute & method is inherited from Aggregate
{
    public string Name { get; private set; } = default!;
    public List<string> Category { get; private set; } = new();
    public string Description { get; private set; } = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal? Price { get; private set; }

    // Create basically acts like a constructor for Product class

    public static Product Create(Guid id, string name, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(id.ToString());
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Product product = new Product
        {
            Id = id,
            Name = name,
            Category = category,
            Description = description,
            ImageFile = imageFile,
            Price = price
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    public void Update(string name, List<string> category, string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;

        if (Price != price)
        {
            Price = price;
            AddDomainEvent(new ProductPriceChangeEvent(this));
        }
    }
}

//public class Product : Entity<Guid>
//{
//    public string Name { get; private set; } = default!;
//    public List<string> Categories { get; private set; } = new();
//    public string Description { get; private set; } = default!;
//    public string ImageFile { get; private set; } = default!;
//    public decimal? Price { get; private set; }

//    // Constructor to ensure necessary fields are initialized properly
//    public Product(string name, List<string> categories, string description, string imageFile, decimal? price)
//    {
//        SetName(name);
//        SetCategories(categories);
//        SetDescription(description);
//        SetImageFile(imageFile);
//        SetPrice(price);
//    }

//    // Behavior: Setting the name with validation
//    public void SetName(string name)
//    {
//        if (string.IsNullOrWhiteSpace(name))
//            throw new ArgumentException("Product name cannot be empty.");
//        Name = name;
//    }

//    // Behavior: Setting categories with validation
//    public void SetCategories(List<string> categories)
//    {
//        if (categories == null || !categories.Any())
//            throw new ArgumentException("Product must belong to at least one category.");
//        Categories = categories;
//    }

//    // Behavior: Setting description
//    public void SetDescription(string description)
//    {
//        if (string.IsNullOrWhiteSpace(description))
//            throw new ArgumentException("Description cannot be empty.");
//        Description = description;
//    }

//    // Behavior: Setting image file path
//    public void SetImageFile(string imageFile)
//    {
//        if (string.IsNullOrWhiteSpace(imageFile))
//            throw new ArgumentException("Image file path cannot be empty.");
//        ImageFile = imageFile;
//    }

//    // Behavior: Setting price
//    public void SetPrice(decimal? price)
//    {
//        if (price <= 0)
//            throw new ArgumentException("Price must be greater than zero.");
//        Price = price;
//    }
//}
