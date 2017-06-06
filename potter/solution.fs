module Tests

open Xunit

type Book = First | Second | Third | Fourth | Fifth

let distinctTitleCount books = 
    List.distinct books |> List.length

let calculateCartDiscount books = 
    match distinctTitleCount books with
    | 5 -> 0.75
    | 4 -> 0.8 
    | 3 -> 0.90 
    | 2 -> 0.95
    | _ -> 1.

let round (number:float) = 
    System.Math.Round (number, 2)

let calculateCartCost books =
    books
    |> calculateCartDiscount
    |> (*) (float (List.length books))
    |> (*) 8.
    |> round

[<Fact>]
let ``should return 8 for a single book`` () =
     Assert.Equal(8., calculateCartCost [Book.First])

[<Fact>]
let ``should return 8 for a multiples of the same book`` () =
     Assert.Equal(16., calculateCartCost [Book.First; Book.First])

[<Fact>]
let ``should return 16 with 5% discount for two unique books`` () =
     Assert.Equal(15.2, calculateCartCost [Book.First; Book.Second])

[<Fact>]
let ``should return 24 with 10% discount for three unique books`` () =
     Assert.Equal(21.6, calculateCartCost [Book.First; Book.Second; Book.Third])

[<Fact>]
let ``should return 32 with 20% discount for four unique books`` () =
     Assert.Equal(25.6, calculateCartCost [Book.First; Book.Second; Book.Third; Book.Fourth])

[<Fact>]
let ``should return 40 with 25% discount for four unique books`` () =
     Assert.Equal(30., calculateCartCost [Book.First; Book.Second; Book.Third; Book.Fourth; Book.Fifth])

[<Fact>]
let ``should return 24 with a 5% discount for a multiples of the same book with one unique pair`` () =
     Assert.Equal(22.8, calculateCartCost [Book.First; Book.First; Book.Second])
