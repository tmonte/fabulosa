namespace Fabulosa


type BoundingRect = {
    Top: int
    Right: int
    Bottom: int
    Left: int
    Width: int
    Height: int
}

module BoundingRect =
    open System
    open Fable.Import.Browser
    
    let OfClientRectType (rect: ClientRect) =
        {
            Top = Convert.ToInt32(rect.top)
            Right = Convert.ToInt32(rect.right)
            Bottom = Convert.ToInt32(rect.bottom)
            Left = Convert.ToInt32(rect.left)
            Width = Convert.ToInt32(rect.width)
            Height = Convert.ToInt32(rect.height)
        }
            