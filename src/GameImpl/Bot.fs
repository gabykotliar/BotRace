namespace BotRace.Game.Implementation.FSharp
open BotRace.Game

type Bot(uri : string) =
    let u = uri

    interface BotRace.Game.Bot with
        member this.GetMoveRequest() = Direction.W |> Movement
        member this.SetCell cell = raise (new System.NotImplementedException())
        member this.InvalidMoveResponse() = raise (new System.NotImplementedException())

