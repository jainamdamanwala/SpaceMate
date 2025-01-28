# Space-Mate - Functionalities Overview

---
## Watch the Gameplay video on Youtube  
<a href = "https://youtu.be/BYlRjYLgxuo"><img src="https://img.shields.io/static/v1?message=Youtube&logo=youtube&label=&color=FF0000&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="youtube logo"  /></a> 
[![Gameplay Video](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222029.png)](https://youtu.be/BYlRjYLgxuo)

![Gameplay Screenshot](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222148.png)

<div>
    <img src="https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222239.png" width = 49%/>
    <img src="https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222253.png" width =49%/>
    <img src="https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222559.png" width = 49%/>
    <img src="https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222652.png" width =49%/>
    <img src="https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222705.png" width = 49%/>
    <img src="https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222813.png" width =49%/>
</div>


## PLAYERMOVEMENT
- Handles player movement, including running, jumping, and crouching.
- Supports animations for idle, running, crouching, and crouch-walking states.
- Implements a dissolve effect during spawning.
- Allows interaction with lifts and speed boosts via collisions.

## SaveSystem
- Provides functionality to save and load player data using binary serialization.
- Stores player health, coins, diamonds, and other progress data persistently.

## AudioManager
- Manages all audio in the game, including background music and sound effects.
- Implements a singleton pattern for consistent audio management across scenes.
- Supports volume and pitch variation for a dynamic audio experience.

## Sound
- Defines the properties of individual sounds, including volume, pitch, looping, and audio clip.
- Integrates with the `AudioManager` for playback.

## Follow_player
- Implements a simple camera follow system.
- Adjusts the camera position based on the player's position and a configurable offset.


## Bullet
- Handles the behavior of player bullets.
- Moves in a straight line at a set speed and destroys itself upon collision with non-player objects.

## CharacterButtonController
- Manages character movement using joystick input and button controls.
- Implements running and jumping mechanics.
- Features a dissolve effect for character appearance.

## CharacterController2D
- Provides detailed control for 2D character movement, including jumping, crouching, and flipping directions.
- Ensures smooth movement transitions and allows for air control.
- Handles interactions with the ground and ceilings using physics checks.

## CharacterMove
- Controls character movement with joystick input.
- Includes animations for idle and running states.
- Implements jumping mechanics and flips character orientation based on movement direction.

## Gun
- Handles gun mechanics, including shooting, reloading, and ammo management.
- Integrates joystick input for directional shooting.
- Includes interactions with power-ups like fast shooting and ammo crates.

## JoyButton
- Detects and tracks button press states for user input.
- Provides functionality for interactions like jumping or shooting.

## JoyStickAim
- Implements aiming mechanics based on joystick input.
- Adjusts the character's aim and rotation dynamically.
- Ensures smooth return to default aim position when joystick is idle.

## PlayerCheckpoint
- Manages player respawn at checkpoints.
- Handles game state transitions for player death and buying additional lives.
- Updates the player's position to the last saved checkpoint.

## PlayerData
- Stores player-specific data such as coins and diamonds.
- Supports data serialization for saving and loading player progress.

## PlayerHealth
- Tracks and manages player health, lives, and resources (coins and diamonds).
- Updates UI elements like health bars and counters.
- Handles interactions with enemies, bullets, and collectible items.

## BossBullet
- Handles the behavior of the boss's bullets.
- Tracks and moves towards the player's position.
- Creates an impact effect upon collision and destroys itself.

## BossHealth
- Manages the health of a boss enemy.
- Takes damage from player bullets and triggers a death effect when health reaches zero.
- Displays the level completion UI upon the boss's defeat.

## BossPatrol
- Implements patrolling behavior for a boss character.
- Alternates movement direction upon reaching edges or obstacles.
- Uses raycasts to detect the ground and prevent falling.

## BossShoot
- Handles the shooting mechanics of the boss.
- Continuously fires bullets at a fixed rate from a specified fire point.
![Boss](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222925.png)

## EnemyBullet
- Manages the behavior of bullets fired by regular enemies.
- Moves in a specified direction and destroys itself upon collision with the player or other objects.

## EnemyHealth
- Manages the health of standard enemies.
- Handles damage from player bullets and triggers a death effect upon destruction.

## Patrol
- Implements a basic patrolling system for enemies.
- Changes direction upon encountering obstacles or edges.
- Plays a running animation while patrolling.

## Range
- Detects targets within a specified radius using a circular scan.
- Rotates to face the detected target.
- Provides visual feedback for the scan radius in the Unity Editor.

## Turret
- Implements a turret system that fires bullets at regular intervals.
- Shoots a single bullet from a defined fire point and destroys the bullet after a set duration.

## Turret2
- Extends the turret functionality by firing bullets from two fire points simultaneously.
- Shoots at regular intervals and destroys bullets after a set duration.


## PurchaseButton
- Handles button functionality for in-app purchases.
- Supports various purchase types including removing ads and buying different quantities of diamonds.
- Triggers the appropriate purchase method in the `IAPManager` when a button is clicked.

## RestorePurchases
- Allows users to restore previous purchases (e.g., on a new device or after reinstalling the game).
- Supports platforms like iOS and macOS and integrates with the `IAPManager`.

## Menu
- Manages the main menu and store menu of the game.
- Displays the player's current diamond and coin counts.
- Includes functionality to load player data, save progress, and navigate between the main menu and store.
- Supports starting a new game, exiting the application, and accessing the store menu.

![Main Menu Screenshot](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222029.png))


## HealthKit
- Provides a health kit that restores the player's health when collected.
- The object is destroyed upon collision with the player.

## IAPManager
- Manages in-app purchases for the game.
- Supports buying consumable items like diamonds in various quantities and a non-consumable item to remove ads.
- Includes functionality to initialize purchasing, process purchases, and restore past purchases on supported platforms.
![IAP Manager Screenshot](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222112.png))

## LevelComplete
- Triggers the display of the "Level Complete" UI when the player reaches a specific area.
![Level Complete](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222813.png)

## LevelComplete2
- Handles saving player progress and triggers the level completion process.
- Utilizes a save system to store player health and progress and manages level transitions.

## Lift
- Implements a moving platform (lift) that oscillates between two predefined positions at a specified speed.

## AmmoCrate
- Adds ammunition to the player's inventory when collected.
- Plays a sound effect and destroys the crate upon interaction with the player.

## CheckPoint
- Saves the player's current position as a checkpoint for respawning after death.

## Coin
- Handles coin collection, plays a sound effect, and destroys the coin upon player interaction.

## GameManager
- Manages global game states, including player lives, checkpoint positions, level counters, and resources (coins and diamonds).
- Ensures persistent data between scenes using the singleton pattern.

## GameMenu
- Provides a game menu system with the following functionalities:
  - Pause and resume the game.
  - Display game-over and level-complete menus.
  - Save player progress.
  - Navigate to the main menu or exit the game.
  - Tracks and updates the player's current level.
![Pause Menu](https://github.com/jainamdamanwala/SpaceMate/blob/main/Screenshots/Screenshot%202025-01-27%20222204.png)

---
