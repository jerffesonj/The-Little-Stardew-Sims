# The Little Stardew Sims

Game made for a task interview at Blue Gravity Studios

<p align="center">
  <img src="https://user-images.githubusercontent.com/59349985/227663040-05f1f29e-7851-4d13-8444-211f08cb903c.png" width="35%" height="35%">
</p>

<p align="center">
  Gameplay Screenshot
</p>

<p align="center">
  <img src="https://user-images.githubusercontent.com/59349985/227663042-a40c4d97-2f91-40c0-811c-97575f40c653.png" width="35%" height="35%">
</p>
<p align="center">
 Inventory Screenshot
</p>

# How to Play

The game is easy to play: use the W, A, S, and D keys to move the character and left-click the mouse to interact with the shopkeepers. You can buy and sell items, equip and unequip them, and collect gold to purchase items. Once an item is equipped, you cannot sell it; you need to unequip it first.

# What and How was done

To create the game, I looked for art with a character whose clothes could be separated from the character sprite. I found two free art pieces from Kenney's pack that matched the style I wanted. Next, I built the scenario tile pallet and imported TMPro.

I coded the cloth change and inventory using scriptable objects, which allowed me to create different types of clothes. I used the reference of the scriptable objects in the inventory on the canvas.

I imported a UI that matched the medieval art style and created different shopkeepers to sell various items. I added feedback to the player for buying, selling, and equipping/unequipping items.

Towards the end, I created animations for the player and canvas objects and optimized the code. Once everything was working as planned, I added sounds and tested the game in a build.

The Windows build is a .zip file located at /Build/

I also made a build for WebGL to easily be played on your browser.

# Game Links

Links: 

Github: https://jerffesonj.github.io/The-Little-Stardew-Sims/

Itch.io: https://jerffesonj.itch.io/the-little-stardew-sims
