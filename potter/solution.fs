module Tests

open Xunit

type Book = First | Second | Third | Fourth

let calculateCartCost books =
    match List.distinct books |> List.length with
    | 4 -> 8. - (8. * 0.2)
    | 3 -> 8. - (8. * 0.1)
    | 2 -> 8. - (8. * 0.05)
    | _ -> 8.

[<Fact>]
let ``should return 8 for a single book`` () =
     Assert.Equal(8., calculateCartCost [Book.First])

[<Fact>]
let ``should return 8 for a multiples of the same book`` () =
     Assert.Equal(8., calculateCartCost [Book.First; Book.First])

[<Fact>]
let ``should return 8 with 5% discount for two unique books`` () =
     Assert.Equal(7.6, calculateCartCost [Book.First; Book.Second])

[<Fact>]
let ``should return 8 with 10% discount for three unique books`` () =
     Assert.Equal(7.2, calculateCartCost [Book.First; Book.Second; Book.Third])

[<Fact>]
let ``should return 8 with 20% discount for four unique books`` () =
     Assert.Equal(6.4, calculateCartCost [Book.First; Book.Second; Book.Third; Book.Fourth])
