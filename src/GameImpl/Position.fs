namespace BotRace.Game.Implementation.FSharp
open BotRace.Game
    
    module internal _Position = 
        open System

        type T = int*int

        let DontMove = function
            | r, c -> r, c
        let MoveNorth = function
            | r,c -> r - 1, c
        let MoveEast = function
            | r,c -> r, (c + 1)
        let MoveSouth = function
            | r, c -> r + 1, c
        let MoveWest = function
            | r, c -> r, (c - 1)

        let At direction = 
            match direction with
                | Direction.N -> MoveNorth
                | Direction.E -> MoveEast
                | Direction.S -> MoveSouth
                | Direction.W -> MoveWest
                | _ -> raise (new InvalidOperationException())


type Position(p : _Position.T) = 
    new(r, c) = new Position((r, c)) 
    member this.Column
        with get() = (this :> BotRace.Game.Position).Column
    member this.Row
        with get() = (this :> BotRace.Game.Position).Row
    member this.At direction = 
        (this :> BotRace.Game.Position).At direction

    interface BotRace.Game.Position with
        member this.get_Column() = snd p
        member this.get_Row() = fst p
        member this.At direction =
            let newPosition = p |> _Position.At direction
            new Position(newPosition) :> BotRace.Game.Position
