# Snake_with_AWS_MySQL

![alt text](https://github.com/artemis94/Snake_with_AWS_MySQL/blob/master/Images/snake.png?raw=true)

The project's goal is to showcase my programming skills and knowledge of technologies. The game is a lot of fun. 

### Translated version  
A translated version of the program can be downloaded from [here](https://l.messenger.com/l.php?u=https%3A%2F%2Fdrive.google.com%2Fdrive%2Ffolders%2F1dmvo1OqT62EedFhI4Ud3czsW4XZpxpOR%3Fusp%3Dsharing&h=AT083Co_tOg4BBQp5gVmQwT_uDaG9rQFqItWmdvlr6FpDWzi7B4zqHBLmsAfzp_H63-znAvxG9EjfK9c9rX3R9c6MMtO2Z_VEEC43ZISp0vI91v2Tv4-qFmlTWU5tW7ZbXNHSbsE41YXf4Ba9qSU1A)

## Features
- Amazon Web Services RDS MySQL Cloud Database
- Registration
- Login
- The Game
- Viewing previous plays
- Ranked List
- Admin control

## System Requirements
- Windows operating system.
- .NETFramework 4.7.2

# Usage

### Registration
Before using the program you have to register. You must choose a user name and an e-mail address that arent already present in the database.

### Login 
Using your username and password with whitch you registered you can log in to the program. After a successful login you are taken to the programs menu.

### Forgotten Password
The user has to give their registered e-mail address to which they will recieve the code with whitch they can set a new password for their account.

### Menu
In the upper right corner you will find the logout button. 
There are 4 menu points to cshoose from:
- New Game
- My Previous games
- Ranked List
- Settings

### The Game
The Game starts when any key is pressed on the keyboard. The game can be ended at any point by pressing te "esc" key. The main goal of the game is to feed the snake, who I named Henry, grow him and gain points by doing so. 

Currently there are 4 game modes to choose from:
- Mushrooms! <img src="https://github.com/artemis94/Snake_with_AWS_MySQL/blob/master/Images/mushroom.png" alt="alt text" height="25"> (Gombák!): Each time Henry eats, his speed increases and poisonous mushrooms appear on the field, which have to be avoided othervise the player loses points. 
- Sweeping Sibilant (SzáguldóSziszegő): Each time Henry eats his speed increases at a really high rate. It' easy to loose control.
- Accelerating (Gyorsuló): Each time Henry eats, his speed increases at a lower rate. For those who would like an easyer challange.
- Constant (Állandó): Henry's speed is constant. For those who would like a casual game.

The game mode can be chaned in the settings. 
At the end of each game, you have a chance to save your game, after that you are returned to the menu.


![alt text](https://github.com/artemis94/Snake_with_AWS_MySQL/blob/master/Images/game.png?raw=true)


### Previous games
In this window the player can view the results of all their past games.

### Ranked List
In this window the player can compare their results with the results of other players. 

### Settings
Here the player can change the game mode, change their password or change their personal data.

### User Management
This menu option only appears for users with admin or moderator rank. There is only one admin account. The admin can promote users to the rank of moderator or downmote them. In this window the users personal data can be edited, their ranks and their active or inactive status.

# Known Issues
During playing the game, if any key is held down the game stops until that key is released. That is due to the way Windows handles keypresses and cannot be resolved from whithin the program.

# Future plans
- Separating the different game modes into different classes.
- Adding more game modes.
- Adding a two player mode.
