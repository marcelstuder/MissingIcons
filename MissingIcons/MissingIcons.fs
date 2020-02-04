// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace MissingIcons

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module App = 
    type Model = 
      { Count : int }

    type Msg = 
        | Increment 

    let initModel = { Count = 0; }

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }, Cmd.none

    let schedulePage () =
        View.ContentPage(
            title = "Schedule", 
            content = View.StackLayout(
                padding = Thickness 20.0,
                verticalOptions = LayoutOptions.Center,
                children = [ 
                    yield View.Label(
                        text = "schedule page",
                        horizontalOptions = LayoutOptions.Center,
                        width=200.0, 
                        horizontalTextAlignment=TextAlignment.Center
                    )
                ]
              )
        )

    let settingsPage () =
        View.ContentPage(
            title = "Settings", 
            icon=Path "settings.png", 
            content = View.StackLayout(
                padding = Thickness 20.0,
                verticalOptions = LayoutOptions.Center,
                children = [ 
                    yield View.Label(
                        text = "settings page",
                        horizontalOptions = LayoutOptions.Center,
                        width=200.0, 
                        horizontalTextAlignment=TextAlignment.Center
                    )
                ]
              )
        )

    let view (model: Model) dispatch =
        let schedule = schedulePage().Icon(Path "schedule.png")  // icon not visible if set like this
        let settings = settingsPage()                            // icon visible if set in contentpage
        View.TabbedPage(
            title="Main page",
            children=[ schedule; settings ]
        )

    // Note, this declaration is needed if you enable LiveUpdate
    let program = Program.mkProgram init update view

type App () as app = 
    inherit Application ()

    let runner = 
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app

