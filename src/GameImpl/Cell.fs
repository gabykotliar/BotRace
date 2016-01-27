namespace BotRace.Game.Implementation.FSharp
open BotRace.Game

    module internal _Cell =
        open System.Collections.Specialized
        type T = BitVector32

        let Create() =
            new T(Direction.All |> int)

        let HasWal (cell : T) direction = 
            cell.[direction |> int]

        let Carve direction (cell : T) =
            let newData = cell.Data  &&& (~~~(direction |> int))
            new T(newData)

        let IsClosed (cell : T) =
            cell.Data = (Direction.All |> int)

        let ToJson (cell : T) = 
             cell.Data.ToString("X")

type private _intf = BotRace.Game.Cell

type Cell(v : _Cell.T) =  
    let mutable c = v
    new() = Cell(_Cell.Create())

    member private this._toIntf = this :> BotRace.Game.Cell
    member this.HasWall direction = this._toIntf.HasWall direction
    member this.Carve direction = this._toIntf.Carve direction
    member this.IsClosed() = this._toIntf.IsClosed()
    member this.ToJson() = _Cell.ToJson c

    interface BotRace.Game.Cell with
        member this.HasWall direction = direction |> _Cell.HasWal c
        member this.Carve direction = 
            c <- (c |> _Cell.Carve  direction)
            this._toIntf
        member this.IsClosed() = _Cell.IsClosed c

