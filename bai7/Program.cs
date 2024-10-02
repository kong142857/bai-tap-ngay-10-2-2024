// See https://aka.ms/new-console-template for more information
using System;

// Lớp trừu tượng Product
abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    // Phương thức trừu tượng hiển thị thông tin sản phẩm
    public abstract void DisplayProductInfo();

    // Phương thức trừu tượng để áp dụng giảm giá
    public abstract void ApplyDiscount(decimal percentage);
}

// Giao diện ISellable
interface ISellable
{
    void Sell(int quantity);
    bool IsInStock();
}

// Lớp con MobilePhone kế thừa từ Product và triển khai ISellable
class MobilePhone : Product, ISellable
{
    public string Brand { get; set; }

    // Triển khai phương thức hiển thị thông tin sản phẩm
    public override void DisplayProductInfo()
    {
        Console.WriteLine($"Ten san pham: {Name}");
        Console.WriteLine($"Gia: {Price:C}");
        Console.WriteLine($"Ton kho: {Stock}");
        Console.WriteLine($"Thuong hieu: {Brand}");
    }

    // Triển khai phương thức áp dụng giảm giá
    public override void ApplyDiscount(decimal percentage)
    {
        Price -= Price * (percentage / 100);
        Console.WriteLine($"Gia sau khi giam: {Price:C}");
    }

    // Triển khai phương thức bán sản phẩm
    public void Sell(int quantity)
    {
        if (quantity <= Stock)
        {
            Stock -= quantity;
            Console.WriteLine($"{quantity} đien thoai đa đuoc ban.");
        }
        else
        {
            Console.WriteLine("So luong khong đu.");
        }
    }

    // Kiểm tra tồn kho
    public bool IsInStock()
    {
        return Stock > 0;
    }
}

// Lớp con Laptop kế thừa từ Product và triển khai ISellable
class Laptop : Product, ISellable
{
    public string Processor { get; set; }

    public override void DisplayProductInfo()
    {
        Console.WriteLine($"Ten san pham: {Name}");
        Console.WriteLine($"Gia: {Price:C}");
        Console.WriteLine($"Ton kho: {Stock}");
        Console.WriteLine($"Bo xu ly: {Processor}");
    }

    public override void ApplyDiscount(decimal percentage)
    {
        Price -= Price * (percentage / 100);
        Console.WriteLine($"Gia sau khi giam: {Price:C}");
    }

    public void Sell(int quantity)
    {
        if (quantity <= Stock)
        {
            Stock -= quantity;
            Console.WriteLine($"{quantity} may tinh đa đuoc ban.");
        }
        else
        {
            Console.WriteLine("So luong khong đu.");
        }
    }

    public bool IsInStock()
    {
        return Stock > 0;
    }
}

// Lớp con Accessory kế thừa từ Product và triển khai ISellable
class Accessory : Product, ISellable
{
    public string Type { get; set; }

    public override void DisplayProductInfo()
    {
        Console.WriteLine($"Ten san pham: {Name}");
        Console.WriteLine($"Gia: {Price:C}");
        Console.WriteLine($"Ton kho: {Stock}");
        Console.WriteLine($"Loai phu kien: {Type}");
    }

    public override void ApplyDiscount(decimal percentage)
    {
        Price -= Price * (percentage / 100);
        Console.WriteLine($"Gia sau khi giam: {Price:C}");
    }

    public void Sell(int quantity)
    {
        if (quantity <= Stock)
        {
            Stock -= quantity;
            Console.WriteLine($"{quantity} phu kien đa đuoc ban.");
        }
        else
        {
            Console.WriteLine("So luong khong đu.");
        }
    }

    public bool IsInStock()
    {
        return Stock > 0;
    }
}

// Chương trình chính
class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo đối tượng MobilePhone
        MobilePhone phone = new MobilePhone
        {
            Name = "Samsung s21",
            Price = 50000000,
            Stock = 10,
            Brand = "Samsung"
        };

        // Khởi tạo đối tượng Laptop
        Laptop laptop = new Laptop
        {
            Name = "Dell alienware x18 r2",
            Price = 50000000,
            Stock = 5,
            Processor = "Intel i7"
        };

        // Khởi tạo đối tượng Accessory
        Accessory accessory = new Accessory
        {
            Name = "Op lung",
            Price = 200000,
            Stock = 50,
            Type = "Op đien thoai"
        };

        // Hiển thị thông tin sản phẩm
        Console.WriteLine("Thong tin đien thoai:");
        phone.DisplayProductInfo();
        Console.WriteLine();

        Console.WriteLine("Thong tin may tinh:");
        laptop.DisplayProductInfo();
        Console.WriteLine();

        Console.WriteLine("Thong tin phu kien:");
        accessory.DisplayProductInfo();
        Console.WriteLine();

        // Bán sản phẩm
        phone.Sell(2);
        laptop.Sell(1);
        accessory.Sell(10);

        Console.WriteLine();

        // Áp dụng giảm giá
        phone.ApplyDiscount(10);
        laptop.ApplyDiscount(15);
        accessory.ApplyDiscount(5);

        Console.WriteLine();

        // Kiểm tra tồn kho
        Console.WriteLine($"Đien thoai con trong kho: {phone.IsInStock()}");
        Console.WriteLine($"May tinh con trong kho: {laptop.IsInStock()}");
        Console.WriteLine($"Phu kien con trong kho: {accessory.IsInStock()}");
    }
}

