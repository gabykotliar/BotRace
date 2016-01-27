namespace BotRace.Game.Implementation.FSharp
open BotRace.Game
open _Maze
open _Cell

type RecursiveBacktrackingMazeGenerator() =
    
    let Directions = [| Direction.N; Direction.E; Direction.S; Direction.W |] 
    let rand = new System.Random()
    let Swap (a: _[]) x y = 
        let tmp = a.[x]
        a.[x] <- a.[y]
        a.[y] <- tmp
    let Shuffle a = 
        Array.iteri (fun i _ -> Swap a i (rand.Next(i, Array.length a))) a
        a

    let rec CarvePassageFrom (pos : _Position.T) (maze : _Maze.T)  = 
        Directions
        |> Shuffle 
        |> Array.iter
            (fun direction ->
                let target = pos |> _Position.At direction
                match 
                    target |> Exists maze
                    &&
                    (maze |> CellAt target) |> IsClosed with
                        | true ->
                            _Maze.Carve maze pos direction 
                            (maze |> CarvePassageFrom target) |> ignore
                        | false -> ())
        maze
    
    member this.Create size = 
        (this :> BotRace.Game.MazeGenerator).Create size

    interface BotRace.Game.MazeGenerator  with
        member this.Create size =
            size
            |> _Maze.Create 
            |> CarvePassageFrom (0, 0) 
            |> Implementation.FSharp.Maze
            :> BotRace.Game.Maze

