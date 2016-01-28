namespace BotRace.Game.Implementation.FSharp
open BotRace.Game

    module _Movement =
        type T = Direction*int

        let Create d s : T =
            if (d = Direction.All)then
                raise (new System.ComponentModel.InvalidEnumArgumentException("direction", Direction.All |> int, typedefof<Direction>))
            d,s

        let Direction = function (d, _) -> d

        let Speed = function (_, s) -> s

type Movement(m : _Movement.T) =
   
    let mutable movement = m

    new (d : Direction) = Movement(_Movement.Create d 1)

    member this.Speed 
        with get()      = 
            movement |> _Movement.Speed
        and set(value)  = 
            movement <- match movement with (d, _) -> d, value

    member this.Direction 
        with get()      = 
            movement |> _Movement.Direction
        and set(value)  = 
            movement <- match movement with (_, s) -> value, s


