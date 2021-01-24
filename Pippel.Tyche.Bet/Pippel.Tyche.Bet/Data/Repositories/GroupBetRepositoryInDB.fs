namespace Pippel.Tyche.Bet.Data.Repositories

open Pippel.Data.EntityFrameworkCore
open Pippel.Tyche.Bet
open Pippel.Tyche.Bet.Data.Models
    
type GroupBetRepositoryInDB(context: Context) =
     inherit Repository<GroupBetDao>(context)
     interface IGroupBetRepository
