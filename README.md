# <img src="https://i.imgur.com/YxgFdHy.jpg" height="40" alt="Icon" title="Mario Form Game"> Mario Form Game

Mario Form Game is a game based on the world of mario, recreated through the Windows Form App in C#.
This project was conducted in an educational environment.

-------

# Table of Contents.

- [The project](#the-project)
  - [What is it ?](#user-content-what-is-it)
  - [Why pick that game ?](#user-content-why-pick-that-game)
  - [What can be added ?](#user-content-what-can-be-added)
- [The difficulties encountered](#the-difficulties-encountered)
  - [How was this handled?](#user-content-how-was-this-handled)
- [The features](#the-features)
  - [The keys](#user-content-the-keys)

-------

# The project.

## What is it

This project is a school project completed in approximately 2 weeks, with the aim of making an arcade game (platformer, space invader, pong...).
Your goal is to collect every coins to complete the stage.

## Why pick that game

Loving mario games, I chose to create a platformer in this universe.

## What can be added

I wanted to create several levels in order to be able to add a level selection menu in the home screen, but due to lack of time I did not have time to realize it.
In order to simplify the code, I have to group the code necessary for the basic functioning of the game into classes.

-------

# The difficulties encountered

The main difficulties encountered are at the beginning of the project. The first steps in Windows Form App are quite complex but remain properly documented on the internet.
The realization of collisions also posed a problem for me because we have to manage more things than on Unity for example. They have been significantly improved compared to the beginning of the project but remain sometimes imperfect.
Find correct sprites to create maps with corresponding themes is also hard.

## How was this handled

I solved my problems by doing long searches on the internet, comparing how things are done by many people and also by reading forums.

-------

# The features

* Home screen
  * Start game button
  * Help button
    * Keys
  * Quit buttom
  * Sound design (music theme & menu scroll)
  * Keyboard scroll (label highlight)
  
* Game
  * Maps theme
  * Sound design (music theme, collision, coin, game over, game won, jump, death)
  * Pause menu (pause sound & label highlight)
  * Mario (main character)
    * Moves (right, left & jump)
    * Sprite animations (right, left, run right & run left)
    * Collisions
  * Enemies
    * Movements
    * Sprite animations (right & left)
    * Kill Mario if they touch him
  * Killing objects
    * Spike
    * Lava / Void
  * Lives system
  * Coins
  * Question block
    * When broken gives a coin
    * When broken spawns label "+1"
    * When broken changes texture
  * Moving platform
  * Win / lose label 

## The keys

The whole game is playable keyboard only.

* Arrow left
  * Help screen
    * Go back to the menu
  * Game
    * Move left
    
* Arrow up
  * Home screen
    * Navigate through the menus
  * Game
    * Jump
    
* Arrow down
  * Navigate through the menus
  
* Arrow right
  * Game
    * Move right
    
* Escape
  * Home screen
    * Close the menu
  * Game
    * Pause the game
    
* Enter
  * Home screen & game
    * Select the highlighted option in menus
    
* Space
  * Game
    * Restart/next level
    
-------
