# Fable.ReactNative.ImagePicker

Fable bindings for [react-native-image-picker](https://github.com/react-native-image-picker/react-native-image-picker).

## Install
Add npm module:

`yarn add react-native-image-picker`

Install Pod

`cd ios && pod install`

Add NuGet package

```dotnet add package Fable.ReactNative.ImagePicker```

or add `Fable.ReactNative.ImagePicker` to your paket.dependencies

## Sample

This package provides bindings as well as the helper functions `showImagePicker`, `launchCamera` and `launchImageLibrary` which lets you call the `react-native-image-picker` equivalents with a list of props in the familiar `Fable.React` way. The functions has the following signature.

```fsharp
seq<ImagePickerProps> -> (PickerResponse -> unit) -> unit
```

Provide a list of properties along with a callback function containing the response. See `ImagePickerProps` and `PickerResponse` in `Fable.ReactNative.ImagePicker.fs` and the `react-native-image-picker` documentation for further details.

```fsharp
open Fable.ReactNative.ImagePicker

// open camera/library modal
showImagePicker [
    Title "Select image"
    MediaType MediaType.Photo
] (fun response ->
    if not response.didCancel then
        // do something with base-64 image
        response.data
)

// open camera directly
launchCamera [] (fun response ->
    // do something with response
)

// open library directly
launchImageLibrary [] (fun response ->
    // do something with response
)

```