namespace Pippel.Tyche.Bet.Data.Repositories

open Pippel.Data
open Pippel.Tyche.Bet.Data.Models

[<Interface>]
type ITeamRepository =
    inherit IRepository<TeamDao>
