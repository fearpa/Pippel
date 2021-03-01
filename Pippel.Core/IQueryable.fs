namespace Pippel.Core

open System
open System.Linq
open System.Linq.Dynamic.Core

module IQueryable =

    type IQueryable with

        member this.Select(select: string, [<ParamArray>] args: obj []) =
            DynamicQueryableExtensions.Select(this, select, args)

        member this.Where(where: string, [<ParamArray>] args: obj []) =
            DynamicQueryableExtensions.Where(this, where, args)

        member this.OrderBy(orderBy: string, [<ParamArray>] args: obj []) =
            DynamicQueryableExtensions.OrderBy(this, orderBy, args)

        member this.GroupBy(groupBy: string, [<ParamArray>] args: obj []) =
            DynamicQueryableExtensions.GroupBy(this, groupBy, args)
