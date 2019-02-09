# rogue-template v0.01
A Roguelike Template Project and Library for Unity

# What is this?
Rogue Template is a WIP framework for developing roguelike games in Unity.  The goal of this project is that it should provide most of the common functionality that a roguelike would need, so that a developer can instead focus their time on the parts of their game that make it unique.

# What are the current features?
Currently the project is in a pre-alpha state and undergoing active development, so it's not yet useful for much.
**Please note that at this point much of the design/implementation is subject to change**
* A skill system where skills/spells can be defined as a simple list of visuals and gameplay effects.
* Base class for actors (player, creatures) in the game.
* A demo scene in which a character sprite moves around a simple room.

# What are the planned features?
* Basic character/monster actions - moving, attacking, picking up items.
* A simple targeting controller to handle picking skill targets.
* Basic UI for things like player stats, inventory, equipment, etc.
* Clean separation between game data and rendering/visuals - where possible the game data will be entirely agnostic to how the game is being displayed, so you should be able to write your own rendering logic if you want to make the game 3D or ASCII-based instead of using 2D sprites, for example.
* A simple dungeon generation framework with some common dungeon algorithms.
* Implementations of common algorithms - field of view, pathfinding, etc., with the ability to add your own alternatives where possible.
* Save/Load functionality for the included types with support for adding more.

# What are NOT planned features?
* A fully playable game - the included sample will only serve to demo features of the library.
* A large library of content - in general any content (items, creatures, skills, etc.) will be included only as necessary to provide enough of an example for you to understand the framework. 
* A completely codeless editor - while a goal of this project is to greatly *reduce* the amount of code needed to create a roguelike, it is unlikely that it will ever reach the point where no new code is necessary.
* Multiplayer - this is out of the scope of this project currently.
* Fringe/minor features - the goal of this project is to handle the 'typical' case roguelike as easily as possible, and in some cases that may mean design decisions that make some non-standard features more difficult to implement.
