namespace Pippel.Tyche.Bet.Domain.Actions.Queries

open Pippel.Data
open Pippel.Tyche.Bet.Data.Models.Queries
open Pippel.Tyche.Bet.Domain.Actions
open Pippel.Tyche.Bet.Domain.Actions.Queries.QueriesObjects
open Pippel.Type

type FindOnPlayingMatchesByPoolAction
    (
        repository: IQueryRepository<OnPlayingMatchViewDao>,
        findGroupBetByKeyAction: IFindPoolByKeyAction
    ) =

    interface IFindOnPlayingMatchesByPoolAction with

        member this.AsyncExecute(groupBetID: Uuid) : Async<OnPlayingMatchViewDao seq> =
            async {
                let! groupBet = findGroupBetByKeyAction.AsyncExecute { PoolID = groupBetID }

                return!
                    repository.AsyncFind<OnPlayingMatchViewDao>(
                        OnPlayingMatchesByMasterPoolQueryObject(groupBet.MasterPoolID)
                    )
            }
