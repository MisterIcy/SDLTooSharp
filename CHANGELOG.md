# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.3.2] - 2023-01-21
### Fixed
- Fixed build & release system

## [0.3.1] - 2023-01-21

### Added
- Added an enumeration for [Display Orientations](SDLTooSharp/Managed/Video/DisplayOrientation.cs).
- Added simple documentation and links to SDL Wiki to most SDL_ functions.

### Changed
- Added a `SdlErrorMsg` property in `SDLException` which contains the actual error reported by SDL.

## [0.3.0] - 2022-12-23

### Added
- Added a [class](SDLTooSharp/Managed/Font/Font.cs) for performing font operations in a more managed way.
- Added classes for [Point2](SDLTooSharp/Managed/Common/Point2.cs) and [Point2F](SDLTooSharp/Managed/Common/Point2.cs).
- Added classes for [Size](SDLTooSharp/Managed/Common/Size.cs) and [SizeF](SDLTooSharp/Managed/Common/Size.cs).

### Fixed
- Fixed `SDL_GameControllerGetAxis` which returned an unsigned value instead of a signed one.
- Fixed `SDL_GetClosestDisplayMode` which had a wrong signature.

## [0.2.0] - 2022-09-25
### Added
- Added missing function `SDL_LoadWAV`.
- Added missing function `SDL_GameControllerAddMappingsFromFile`.
- Added missing function `SDL_JoystickUpdate`.
- Added metal related functions (`metal.h`)
- Added system related functions (`system.h`).
- Added version related function (`version.h`).
- Added missing version functions to SDL_Image, SDL_Mixer and SDL_TTF.

### Fixed
- Fix const types in Audio.cs.
- Fix return type of `SDL_GetSystemRAM`.
- Fix types in `SDL_KeyboardEvent` struct.
- Fix `SDL_JoyAxisEvent` struct.
- Fix `SDL_PeepEvents` signature, where `events` parameter was not an array.
- Fix `SDL_GameControllerGetSensorData` signature, where data was not an array.
- Fix typo in `SDL_HapticCondition`

## [0.1.1] - 2022-09-25
### Fixed
- Fixed an issue with licensing when creating a package. 

## [0.1.0] - 2022-09-25
### Added
- Bindings for SDL2
- Bindings for SDL2 Mixer
- Bindings for SDL2 Image
- Bindings for SDL2 Ttf

[Unreleased]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.3.2...HEAD
[0.3.2]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.3.1...v0.3.2
[0.3.1]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.3.0...v0.3.1
[0.3.0]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.2.0...v0.3.0
[0.2.0]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.1.1...v0.2.0
[0.1.1]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/MisterIcy/SDLTooSharp/releases/tag/v0.1.0