namespace BotRace.Game.Implementation.FSharp
open System
open BotRace.Game

    module internal _Maze =
        open _Cell
        open _Position

        type T = _Cell.T [][]

        let Create size =  
            Array.init size 
                (fun i -> 
                    Array.init size
                        (fun i ->_Cell.Create()))

        let CellAt position (maze : T) =
            maze.[position |> Row].[position |> Column]

        let Height maze = 
            Array.length maze

        let Width (maze : T) = 
            Array.length maze.[0]

//        let ToJson (maze : T) = 
//            let grid = new System.Text.StringBuilder()
//            maze.Grid 
//                |> Array2D.iter 
//                    (fun cell -> 
//                        (cell |> ToJson |> grid.Append) |> ignore)
//            grid.ToString()

        let ToJson (maze : T) = 
            maze 
                |> Array.map 
                    (fun row -> 
                        row 
                        |> Array.map (fun cell -> 
                                        cell |> ToJson )
                        |> String.Concat)
                |> String.Concat

        let Home maze : _Position.T = 0,0
        let Exit maze : _Position.T = Height maze, Width maze

        let private Update (m: T)  (p: _Position.T) c = 
            m.[p |> Row].[p |> Column] <- c

        let Carve m from direction = 
            let ``to`` = from |> At direction
            m 
            |> CellAt from
            |> Carve direction
            |> Update m from
            m
            |> CellAt ``to``
            |> Carve (direction.Oposite())
            |> Update m ``to``

        let Exists maze position = 
            let size = Array.length maze
            let col = position |> Column
            let row = position |> Row
            0 <= col && col < size && 0 <= row && row < size

 
type Maze (data : _Maze.T) =
    let maze = data
    new (size : int) = new Maze(_Maze.Create(size))

    static member ClosedGrid (size : int) =
        new Maze(size)

    member this.Carve (from : Position) direction = 
        _Maze.Carve maze (from.Row, from.Column) direction

    interface BotRace.Game.Maze with
        member this.get_Width()  = _Maze.Width maze
        member this.get_Height() = _Maze.Height maze
        member this.CellAt position = 
            maze
            |> _Maze.CellAt (position.Row, position.Column)
            |> Implementation.FSharp.Cell
            :> Cell
        member this.Home = 
            maze 
            |> _Maze.Home
            |> Implementation.FSharp.Position
            :> Position
        member this.Exit = 
            maze
            |> _Maze.Exit
            |> BotRace.Game.Implementation.FSharp.Position
            :> BotRace.Game.Position
        member this.ToJson() = maze |> _Maze.ToJson
