namespace Pippel.Tyche.Bet.Domain.Actions.Queries

open Pippel.Tyche.Bet.Data.Models.Queries
open Pippel.Type

[<Interface>]
type IFindOnPlayingMatchesByGroupMatchAction =

    abstract AsyncExecute: Uuid -> Async<OnPlayingMatchViewDao seq>
