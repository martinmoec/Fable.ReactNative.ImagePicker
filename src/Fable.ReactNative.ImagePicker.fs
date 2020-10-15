module Fable.ReactNative.ImagePicker

open Fable.Core
open Fable.Core.JsInterop

type PickerResponse = {
    ``customButton``    : string
    ``didCancel``       : bool
    ``error``           : string
    ``data``            : string
    ``uri``             : string
    ``origURL``         : string option
    ``isVertical``      : bool
    ``width``           : float
    ``height``          : float
    ``fileSize``        : float
    ``type``            : string option
    ``fileName``        : string option
    ``path``            : string option
    ``latitude``        : float
    ``longitude``       : float
    ``timestamp``       : string option
    ``originalRotation``: float option
}

type IRNImagePicker =
    abstract member ``showImagePicker``     : obj -> (PickerResponse -> unit) -> unit
    abstract member ``launchCamera``        : obj -> (PickerResponse -> unit) -> unit
    abstract member ``launchImageLibrary``  : obj -> (PickerResponse -> unit) -> unit

type Globals =

    [<Import("default", "react-native-image-picker")>]
    static member RNImagePicker with get() : IRNImagePicker = jsNative and set(v:IRNImagePicker) = jsNative

type CustomButtonProps =
    | Name  of string
    | Title of string

[<StringEnum>]
type MediaType =
    | Photo
    | Video
    | Mixed

[<StringEnum>]
type CameraType =
    | Front
    | Back

type StorageProps =
    | SkipBackup        of bool
    | Path              of string
    | CameraRoll        of bool
    | WaitUntilSaved    of bool
    | PrivateDirectory  of bool

type PermissionDeniedProps =
    | Title         of string
    | Text          of string
    | ReTryTitle    of string
    | OkTitle       of string

[<StringEnum>]
type VideoQuality =
    | Low
    | Medium
    | High


type ImagePickerProps =
    | Title                 of string
    | CancelButtonTitle     of string
    | TakePhotoButtonTitle  of string
    | ChooseFromLibraryButtonTitle of string
    | ChooseWhichLibraryTitle of string
    | CameraType of CameraType
    | MediaType of MediaType
    | Quality   of float
    | MaxWidth  of float
    | MaxHeight of float
    | VideoQuality of VideoQuality
    | DurationLimit of float
    | Rotation      of float
    | AllowsEditing of bool
    | NoData        of bool
    | TintColor     of obj
    
    static member CustomButtons (x : seq<seq<CustomButtonProps>>) =
        !!("customButtons", x |> Seq.map(keyValueList CaseRules.LowerFirst))
    
    static member PermissionDenied (x : seq<PermissionDeniedProps>) =
        !!("permissionDenied", keyValueList CaseRules.LowerFirst x)
    static member StorageOptions (x : seq<StorageProps>) = 
        !!("storageOptions", keyValueList CaseRules.LowerFirst x)

let showImagePicker (props : seq<ImagePickerProps>) =
    Globals.RNImagePicker.showImagePicker (keyValueList CaseRules.LowerFirst props)

let launchCamera (props :seq<ImagePickerProps>) =
    Globals.RNImagePicker.launchCamera (keyValueList CaseRules.LowerFirst props)

let launchImageLibrary (props :seq<ImagePickerProps>) =
    Globals.RNImagePicker.launchImageLibrary (keyValueList CaseRules.LowerFirst props)