﻿module BarcodeTests

open System
open Xunit
open Pippel.Type

let barcodes: obj [] seq =
    seq {
        yield [| "90311017" |] // GTIN-8
        yield [| "012345678905" |] // GTIN-12
        yield [| "9780201379624" |] // GTIN-13
        yield [| "40700719670720" |] // GTIN 14
    }

let wrongValues: obj [] seq =
    seq {
        yield [| null |]
        yield [| "hello" |]
    }

[<Theory>]
[<MemberData("barcodes")>]
let ``given a correct value for a Barcode when a Barcode is created then a Barcode is returned`` (value: string) =
    let barcode = value |> Barcode.create
    Assert.True(true)
    Assert.Equal(value, barcode |> Barcode.value)


[<Theory>]
[<MemberData("wrongValues")>]
let ``given a wrong value for a Barcode when a Barcode is created then an exception is raised`` (value: string) =
    Assert.Throws<ArgumentException>(fun () -> value |> Barcode.create |> ignore)


[<Theory>]
[<MemberData("barcodes")>]
let ``given a correct value for a Barcode when a barcode try to create then an option with the barcode is returned`` (value: string) =
    let barcodeOpt = value |> Barcode.tryCreate
    Assert.True(barcodeOpt.IsSome)
    Assert.Equal(value, barcodeOpt.Value |> Barcode.value)


[<Theory>]
[<MemberData("wrongValues")>]
let ``given a wrong value for a Barcode when a Barcode try to create then an option without value is returned`` (value: string) =
    let barcodeOpt = value |> Barcode.tryCreate
    Assert.True(barcodeOpt.IsNone)
