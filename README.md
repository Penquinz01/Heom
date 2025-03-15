Game Documentation
1. Game Overview

Game Title: Heom

Genre: Puzzle-Platformer with Action Elements

Platform: PC

Target Audience: Players who enjoy challenging puzzles and dynamic platforming experiences

Development Team:

Coding and Mechanics: Janbaas
Level Design: Anthony
Art: Hani
2. Gameplay Mechanics

Core Mechanic: Pressing the Shift key changes the background color, affecting the visibility and interaction of objects and enemies.

Object and Enemy Interaction: Objects and enemies matching the background color become invisible and are disabled, creating dynamic puzzle scenarios.

Player Abilities:

Movement: Running and jumping
Interactions: Navigating levels and solving puzzles using the color-changing mechanic
Enemies:

Knight: Engages in close combat with melee attacks
Archer: Attacks from a distance using arrows
3. Level Design

Progression: Levels increase in complexity, introducing new challenges that require strategic use of the color-changing mechanic.

Puzzles: Designed to leverage the color-changing mechanic and enemy interactions, requiring players to think critically to progress.

4. User Interface (UI)

HUD Elements: Displays such as health bars, score, and current background color indicator.

Menus: Main menu, settings, and pause screens with intuitive navigation.

5. Art and Audio

Visual Style: A minimalist aesthetic with a focus on contrasting colors to emphasize the color-changing mechanic.

Sound Design: Subtle background music and sound effects that enhance the immersive experience without distracting from gameplay.

6. Technical Specifications

Engine: Unity

Platform Requirements: Compatible with standard PC hardware; specific requirements to be determined based on final optimization.

7. Development Timeline

Development Duration: Completed within a 24-hour game jam.

Milestones:

Conceptualization: Idea brainstorming and mechanic planning
Development: Coding mechanics, designing levels, and creating art assets
Testing: Playtesting and debugging
Finalization: Polishing and preparing for submission

Default Controls for "Heom"
•	Movement:
o	W: Move Forward
o	A: Move Left
o	S: Move Backward
o	D: Move Right
•	Jump:
o	Spacebar: Initiate Jump
•	Attack:
o	E: Perform Attack
o	Left Mouse Button (LMB): Perform Attack
•	Color Change Mechanic:
o	Left Shift: Change Background Color
o	Q: Change Background Color

Code Overview:
GameManager
The GameManager is responsible for managing the game's state, including the currently selected color and the objects associated with each color.
Key Components
·	ColorSelected Enum: Represents the currently selected color (Red, Green, Blue).
·	Color Variables: Stores the color values for Red, Green, and Blue.
·	Object Lists: Lists to keep track of objects for each color (redObjects, greenObjects, blueObjects).
·	CinemachineImpulseSource: Used for camera shake effects.
Key Methods
·	Awake(): Initializes the GameManager and sets up the input controls.
·	Start(): Enables the input controls and sets the initial color to Red.
·	OnSwitch(): Handles the color switch input and updates the selected color.
·	SetRed(), SetGreen(), SetBlue(): Methods to update the game state based on the selected color.
·	RegisterRed(), RegisterGreen(), RegisterBlue(): Methods to add objects to the respective color lists.
·	RemoveRed(), RemoveGreen(), RemoveBlue(): Methods to remove objects from the respective color lists.
·	GetColor(): Returns the color value based on the selected color.
·	CameraShake(): Triggers a camera shake effect.
Arrow
The Arrow class represents the arrows shot by the Archer enemy.
Key Components
·	Velocity: Speed of the arrow.
·	DestroyTime: Time after which the arrow is destroyed.
·	Rigidbody2D: Used for physics calculations.
Key Methods
·	Start(): Initializes the arrow's velocity and sets the destroy time.
·	Update(): Checks if the arrow should be destroyed based on the elapsed time.
·	OnCollisionEnter2D(): Handles collisions with other objects. If the arrow hits the player, it triggers the player's hurt state and destroys the arrow.
Color Objects (RedObjects, GreenObjects, BlueObjects)
These classes represent the objects associated with each color.
Key Components
·	SpriteRenderer: Used to render the object's sprite.
Key Methods
·	Initialize(): Initializes the object.
·	Remove(): Removes the object from the game.
·	Start(): Called once before the first execution of Update.
Player Controls
The player can switch between different colors using the input controls. Each color activates or deactivates the respective objects in the game.
Color Switching
·	Red: Activates red objects and deactivates green and blue objects.
·	Green: Activates green objects and deactivates red and blue objects.
·	Blue: Activates blue objects and deactivates red and green objects.
Enemies
Normal (Melee Type)
The Normal enemy is a melee type that engages the player in close combat.
Archer (Ranged Type)
The Archer enemy shoots arrows at the player from a distance.
Key Methods for Enemies
·	Attack(): The method used by both enemy types to attack the player. For Normal enemies, this would be a melee attack. For Archer enemies, this involves shooting an arrow.

