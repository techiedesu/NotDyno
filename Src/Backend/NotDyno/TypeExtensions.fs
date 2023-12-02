module NotDyno.TypeExtensions

open System
open System.Threading.Tasks

let inline (^) f x = f x

let inline retry (maxCount: int) (delayMs: int)
    ([<InlineIfLambda>] action: Exception option -> #Task)
    ([<InlineIfLambda>] failedRetriesAction: Exception -> #Task) = task {
    let rec inline retry attemptsLeft exn = task {
        try
            do! action exn
        with e ->
            if attemptsLeft < 1 then
                do! failedRetriesAction e
            else
                do! Task.Delay(delayMs + 1)
                do! retry (attemptsLeft - 1) (Some e)
    }

    do! retry (maxCount - 1) None
}
