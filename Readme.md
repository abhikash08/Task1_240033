GAME IDEA :
This is a 2D platformer game where the main objective is to reach the other end of the cave and landing on the fire on the last platform
collecting treasure boxes and also defeating the red scarfed knight in the way.

The Game consists of 4 scenes : HOME , GAMEPLAY , DEATH , WIN.
All the scripts are inside Asse-> Scripts.
** Initially my thought was to keep the camera stationary like JumpKing type games but it didn't work out even after using cinemachine so I decided the camera would follow the character.

Google drive link of the game :
**DISCLAIMER**
*The platforms sometimes get behind the background and sometimes work fine. I have sorted the layers correctly but still this issue is persisting so please while testing out my game please either restart or die and play again. I will attach photos of my scene view and game view in the google drive that will contain the build of my game

https://drive.google.com/drive/folders/1Qf1NUzpiG53px6mOpDCxdsz3dJOBD65a?usp=sharing



CONTROLS :
A -> Move right
D -> Move left
SPACE -> Jump
LMB -> Attack

MY CONTRIBUTION :
1.Made the sprite for idle state and punching state of enemy using *PixelStudio*(Android Tab).
2.Background image for all the different scenes have been taken from *DeviantArt.com*
3.Background music for all the different scenes have been downloaded from *YouTube.com*
4.Animations created and used are all that were given in the sample apart from Enemy attacking.
5.I also learned to use Gizmos which gives us a visual debugger kind of which aids debugging like isGround detectors etc.
6. CODES Brief Explaination:

-> Collectible.cs 
This script handles the collection of treasure objects in a 2D game. When a player touches the treasure, it:
Awards points (via a CollectibleManager)
OnTriggerEnter2D
Called automatically by Unity when another collider enters this object's trigger zone.
 destroys the treasure object (removing it from the scene)
Destroys if "Player" tag is detected on player.

-> CollectibleManager.cs
Tracks the current score.
Updates a TextMeshPro (TMP) UI element to display the score.
Provides a global access point  for other scripts (like TreasureCollectible) to add points.
public int currentScore -> Stores the player's accumulated score (starts at 0).
public TMP_Text scoreText -> Reference to a TextMeshPro UI element for displaying the score.

-> DeathScreenManager.cs
Contains 2 functions one that restarts the game that is loads the gameplay scene and other that takes back to home screen in case you don't wanna die anymore :).

-> EnemyAttack.cs
Detects when the player enters a radius around the enemy
Deals damage at set intervals (cooldown)
Triggers an attack animation
Visualizes the detection range in the Unity Editor using Gizmos
Checks for players within range using Physics2D.OverlapCircle
If player is found AND cooldown has passed:
Gets the player's PlayerHealth component
Calls TakeDamage() on the player
Triggers the "Attack" animation
Updates lastAttackTime

-> EnemyHealth.cs
Initializes currentHealth to maxHealth when the enemy spawns.
TakeDamage(int damage)
Reduces currentHealth by the damage amount.
Calls Die() if health drops to/below zero which destroys the game object enemy

-> EnemyPatrol.cs
**My enemy initially moved to and fro but after I added attack animations ( I didn't have a spritesheet since I created it separately (Both idle and punching sprites of enemy) ) it stopped moving which I guess happened because I had transformed the sprite in the animator tab.
But now it doesn't work and I didn't have time to make changes so I decided that my enemy will be stationary ;( **

->HealthBar.cs
Health tracking (current/max values)
Damage reception 
Fall death detection ( if it goes beyond a certain y, then death)
Health UI updates ( Health slider)
Death handling (scene reloading)

-> HomeButton.cs
Home button contains instructions , a play button loading gameplay scene and an exit that exits the editor.

-> MovablePlatform.cs
Script for the moving platforms with editable speed and kinematic (rigidbody2d) so that no effect of gravity
 back and forth between two points
Moves at a constant speed
Automatically reverses direction at boundaries

->PlayerAttack.cs
Listens for Left Mouse Click (KeyCode.Mouse0)
Sets attack state
Records attack time
Triggers "Attack" animation
Activates hitbox
Auto-disables hitbox after 0.2s (via Invoke)
(OnTriggerEnter2D())
Checks if collider is on enemyLayer
Calls TakeDamage() on enemy's EnemyHealth component

->PlayerMove.cs
I had to add a flip method as the sprite initially faced left so when i pressed right it went right but faced left and vice versa
for jump i used ground check which means it checks if character is grounded through an empty object placed at the feet and if it is ground
a force will be applied
I also applied a horizontal boost function since my character went too far horizontally after jumping .
Mathf.Lerp() creates smooth acceleration/deceleration
float airControl = isGrounded ? 1f : 0.8f; control restriced while in air as compared to ground
Flip function: Flips the sprite by modifying X scale (preserves original proportions)
              Repositions the attackPoint to match facing direction

-> WinCon.cs
A certain x and y co ordinate if the player lands on then the YouWin scene will load also allowing for a small tolerance range of whatever value we want 0.5 or 1 we can change in the inspector

->YouWinScreenHome.cs
Contains a button takes us back to home on the YouWin screen.
