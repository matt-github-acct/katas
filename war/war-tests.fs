module war_tests

open NUnit.Framework
open Swensen.Unquote
open war

[<Test>]
let ``the highest rank wins the cards in the round`` () = 
    let result = playRound((Spade, Value 2), (Spade, Value 3))

    test <@ result = 2 @>

[<Test>]
let ``queens are higher rank than jack`` () = 
    let result = playRound((Spade, Jack), (Spade, Queen))

    test <@ result = 2 @>

[<Test>]
let ``kings are higher rank than queens`` () = 
    let result = playRound((Spade, King), (Spade, Queen))

    test <@ result = 1 @>

[<Test>]
let ``aces are higher rank than kings`` () = 
    let result = playRound((Spade, King), (Spade, Ace))

    test <@ result = 2 @>

[<Test>]
let ``if the ranks are equal, clubs beat spades`` () = 
    let result = playRound((Club, Value 3), (Spade, Value 3))

    test <@ result = 1 @>

[<Test>]
let ``if the ranks are equal, diamonds beat clubs`` () = 
    let result = playRound((Club, Value 3), (Diamond, Value 3))

    test <@ result = 2 @>

[<Test>]
let ``if the ranks are equal, hearts beat diamonds`` () = 
    let result = playRound((Heart, Value 3), (Diamond, Value 3))

    test <@ result = 1 @>

[<Test>]
let ``the player loses when they run out of cards`` () = 
    ([(Spade, Value 2)], [(Spade, Value 3)])
    |> playGame
    |> fun x -> test <@ x = 2 @>

    ([(Spade, Value 3)], [(Spade, Value 2)])
    |> playGame
    |> fun x -> test <@ x = 1 @>


    ([(Spade, Value 2); (Spade, Value 5); (Spade, Value 5)], [(Spade, Value 1); (Spade, Value 6); (Spade, Value 7)])
    |> playGame
    |> fun x -> test <@ x = 2 @>