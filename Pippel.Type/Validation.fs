﻿namespace Pippel.Type

open System.Text.RegularExpressions

module Validation =

    let ifTrueThen x =
        function
        | true -> Some x
        | false -> None

    let (|Null|_|) value = value |> isNull |> ifTrueThen Null

    let (|WhiteSpaces|_|) (value: string) =
        value.Trim() = "" |> ifTrueThen WhiteSpaces

    let (|NotMatches|_|) pattern value =
        Regex.IsMatch(value, pattern)
        |> not
        |> ifTrueThen NotMatches

    let (|NotRange|_|) lower upper value =
        (value >= lower && value <= upper)
        |> not
        |> ifTrueThen NotRange

    let (|Less|_|) limit value = value < limit |> ifTrueThen Less
