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

let suitValue card = 
    match fst card with
    | Spade -> 1
    | Club -> 2
    | Diamond -> 3
    | Heart -> 4

let cardValue card = 
    suitValue card +
    match snd card with
    | Jack -> 11
    | Queen -> 12
    | King -> 13
    | Ace -> 14
    | Value x -> x

let playRound (card1,card2) =
    if (cardValue card1) > (cardValue card2) then 1 else 2

let rec playGame (hand1:Card list, hand2:Card list) =

    
    match (hand1, hand2) with
    | [], _ -> 2
    | _, [] -> 1
    | _ ->
        match playRound (List.head hand1, List.head hand2) with
            | 1 -> 
                playGame (hand1 @ [List.head hand2], List.tail hand2)
            | 2 ->
                playGame (List.tail hand1, hand2 @ [List.head hand1])
    