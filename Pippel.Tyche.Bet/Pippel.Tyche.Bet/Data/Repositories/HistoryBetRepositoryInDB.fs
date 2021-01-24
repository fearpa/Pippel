namespace Pippel.Tyche.Bet.Data.Repositories

open Pippel.Data.EntityFrameworkCore
open Pippel.Tyche.Bet
open Pippel.Tyche.Bet.Data.Models
    
type HistoryBetRepositoryInDB(context: Context) =
     inherit Repository<HistoryBetDao>(context)
     interface IHistoryBetRepository
