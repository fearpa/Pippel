module QueryRepositoryTests

open System.Linq
open Pippel.Data.Test.DemoData
open Pippel.Core
open Pippel.Data
open Pippel.Data.EntityFrameworkCore
open Pippel.Data.Test
open Xunit

[<Fact>]
let ``given several items that exist when they are queried and filtered by any criteria then a paged result is returned with the items that meet the criteria``
    ()
    =
    async {
        let products = createProducts ()
        let context = createContextWithData (products)

        let supplier = "Bavaria"

        let productsFilteredBefore =
            products.Where(fun x -> x.Supplier = supplier)

        let repository =
            Repository<Product>(context) :> IRepository<Product>

        let! page =
            repository.AsyncFindWithPagination<Product>
                (DynamicQueryObject(
                    { DynamicQueryParam.Select = None
                      Where = Some("Supplier = @0", [| supplier |])
                      GroupBy = None
                      OrderBy = None }
                ))
                0
                products.Length

        Assert.Equal(productsFilteredBefore.Count(), page.Items.Count())
        Assert.Equal(productsFilteredBefore.Count(), page.PageCount)

        for productFilteredAfter in page.Items do
            Assert.True(productsFilteredBefore.Contains(productFilteredAfter))
    }
