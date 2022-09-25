# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Added missing function `SDL_LoadWAV`.
- Added missing function `SDL_GameControllerAddMappingsFromFile`.
### Fixed
- Fix const types in Audio.cs.
- Fix return type of `SDL_GetSystemRAM`.
- Fix types in `SDL_KeyboardEvent` struct.
- Fix `SDL_JoyAxisEvent` struct.
- Fix `SDL_PeepEvents` signature, where `events` parameter was not an array.

## [0.1.1] - 2022-09-25
### Fixed
- Fixed an issue with licensing when creating a package. 

## [0.1.0] - 2022-09-25
### Added
- Bindings for SDL2
- Bindings for SDL2 Mixer
- Bindings for SDL2 Image
- Bindings for SDL2 Ttf

[Unreleased]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.1.1...HEAD
[0.1.1]: https://github.com/MisterIcy/SDLTooSharp/compare/v0.1.0...v0.1.1
[0.1.0]: https://github.com/MisterIcy/SDLTooSharp/releases/tag/v0.1.0