## Description

On Android, when a modal `ContentPage` with transparent background contains overlapping `Grid` elements, a Grid with `InputTransparent="True"` does not fill the available space on first render. Black/transparent gaps appear at the bottom and right edges. After a Hot Reload or any property change, the Grid expands to the correct size.

**iOS works correctly.**

## Steps to Reproduce

1. Create a `ContentPage` with `BackgroundColor="Transparent"`
2. Add overlapping `Grid` elements in the same parent Grid cell
3. Set `InputTransparent="True"` on the second (overlay) Grid
4. Open the page as modal: `await Navigation.PushModalAsync(page, false)`
5. Run on Android

**Result**: The overlay Grid doesn't fill the screen, leaving gaps at bottom and right edges

## Code Sample

```xml
<ContentPage BackgroundColor="Transparent">
    <Grid SafeAreaEdges="None" RowDefinitions="*" ColumnDefinitions="*">
        <!-- Backdrop Layer -->
        <Grid SafeAreaEdges="None" Grid.Row="0" Grid.Column="0">
            <BoxView BackgroundColor="Black" Opacity="0.7" />
        </Grid>
        
        <!-- Overlay Layer with InputTransparent="True" -->
        <Grid SafeAreaEdges="None"
              InputTransparent="True"
              Grid.Row="0" Grid.Column="0"
              BackgroundColor="Aqua"/>
    </Grid>
</ContentPage>
```

Full reproduction: [Link to your repo if you upload it]

## Expected Behavior

Aqua overlay Grid fills entire screen, completely covering the black backdrop.

## Actual Behavior

**Android**: Aqua Grid is smaller, black backdrop visible at bottom and right edges on first render. Hot Reload fixes it.

**iOS**: Works correctly.

## Workaround

Remove `InputTransparent="True"` and use `TapGestureRecognizer` on the Grid instead:

```xml
<Grid SafeAreaEdges="None" Grid.Row="0" Grid.Column="0">
    <Grid.GestureRecognizers>
        <TapGestureRecognizer Command="{Binding CloseCommand}"/>
    </Grid.GestureRecognizers>
    <!-- content -->
</Grid>
```

## Environment

- **.NET MAUI**: [Your version]
- **Android**: API 36 (tested)
- **Device**: Pixel 9a Emulator (tested)
- **OS**: macOS

## Impact

Affects modal overlays, dialogs, badge displays, and any full-screen transparent overlay on Android that uses `InputTransparent` for event pass-through.
