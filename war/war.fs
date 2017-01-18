module war

type Suit =
    | Spade
    | Club
    | Diamond
    | Heart

type Rank =
    | Value of int
    | Jack
    | Queen
    | King
    | Ace

type Card = Suit * Rank

let playRound (card1:Card,card2:Card) =
    failwith "not implemented: winning card"

let playGame (hand1:Card list, hand2:Card list) =
    failwith "not implemented: game winner"
