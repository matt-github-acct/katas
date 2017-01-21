
using System.Collections.Generic;
using System.Linq;

public enum Book
{
    First,
    Second,
    Third,
    Fourth,
    Fifth
}

public class Cart
{
    public static readonly Dictionary<int, decimal> DiscountMap = new Dictionary<int, decimal>
        {
            { 5, .25m },
            { 4, .2m },
            { 3, .1m },
            { 2, .05m },
            { 1, 0m },
            { 0, 0m },
        };

    public IEnumerable<Book> Books { get; private set; }

    public const decimal TwoSetsOfFourDiscount = (8 * 4 * .2m * 2);

    public decimal Calculate() => (Books.Count() * 8) - this.CalculateDiscount();

    public Cart(IEnumerable<Book> books)
    {
        Books = books;
    }
}

static class CartExtensions
{
    public static decimal CalculateDiscount(this Cart cart)
    {
        if (cart.HasTwoSetsOfFour())
        {
            return Cart.TwoSetsOfFourDiscount + cart.RemoveTwoSetsOfFour().CalculateDiscount();
        }

        var distinct = cart.Books.Distinct();

        var discount = (8 * distinct.Count() * Cart.DiscountMap[distinct.Count()]);

        var remaining = cart.RemoveBooks(distinct);

        return remaining.Books.Any() ? discount + CalculateDiscount(remaining) : discount;
    }

    public static bool HasSetOfFour(this Cart cart) => cart.Books.Distinct().Count() > 3;

    public static bool HasTwoSetsOfFour(this Cart cart)
        => cart.HasSetOfFour() && cart.RemoveOneSetOfFour().HasSetOfFour();

    public static Cart RemoveTwoSetsOfFour(this Cart cart)
        => cart.RemoveOneSetOfFour().RemoveOneSetOfFour();

    public static Cart RemoveOneSetOfFour(this Cart cart) => cart.RemoveOneSetOf(4);

    public static Cart RemoveOneSetOf(this Cart cart, int setLength)
        => cart.RemoveBooks(cart.Books.Distinct().Take(setLength));

    public static Cart RemoveBooks(this Cart cart, IEnumerable<Book> booksToRemove)
    {
        var cleaned = cart.Books.ToList();

        foreach (var book in booksToRemove)
        {
            cleaned.Remove(book);
        }

        return new Cart(cleaned);
    }
}
