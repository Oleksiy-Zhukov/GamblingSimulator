# CSCI 265 Design (Phase 5 Updated)

## Team name: Section 3

## Project/product name: Gambling Simulator

## Contact person and email

The following person has been designated the main contact person for questions from the reader:

 -  Josiah Bowden, [josiahbowden4@gmail.com](mailto:josiahbowden4@gmail.com)

## Overview

This document outlines the design for Gambling Simulator. The goal is to provide a single-player casino experience, where the player can engage in games such as Blackjack, Craps, and slots. The entire game will run on the player’s machine, allowing them to explore various games at their own pace. The gameplay takes place in a virtual casino environment, and the player controls an avatar that moves around the casino floor, interacts with game tables and machines. 

Key Features and mechanics include:

1) Player information management: current balance, stats.  
2) Visual representation of NPCs: Dealers or other casino staff, though they won’t be interactive.  
3) Game interfaces: Overworld heads-up display(tutorial/help box, balance), and interface for each game where player can bet and play.  
4) Player action detection: Moving, interacting with tables, placing bets, interacting with game buttons.  
5) Game mechanics and logic for each game: Handling card draws in Blackjack, reel spins in Slots, dice rolls in Craps  
6) Sound effects: Card shuffling and dealing, slot machine spins, dice rolls  
7) Menu and interface navigation: Main menu, gameplay screens, options and out of money (game over) screen.

The primary design challenge is to ensure the game mechanics are accurate and engaging, including the development of a fair random number generator (RNG) to handle outcomes for all games. The design will prioritize functionality, focusing on creating a stable and integrated system where all components operate smoothly together.

## Core Design Influence

The design choices for Gambling Simulator were driven by the need to create a robust and seamless system where all components interact smoothly. Several factors shaped our approach:

1) Simplicity and Focus on Functionality: Our primary focus is on ensuring all game components work together efficiently. Rather than building complex visual elements or navigation, we opted for a straightforward interface that allows players to access and play the games without unnecessary distractions. This choice keeps development focused on core mechanics and ensures the system operates reliably.  
2) Modular Game Design: We chose a modular approach for each game (Blackjack, Slots, Craps), meaning each game functions as an independent component. This allows for easier testing, debugging, and integration. Each module shares common elements like the random number generator (RNG) for game outcomes, ensuring consistency across all games.  
3) Player-Centric Interaction: Since the game is single-player, the interaction design is kept simple and user-friendly. Players interact directly with the game interface, placing bets and playing after short navigation in the virtual world. This minimalistic approach ensures that the player can focus on the core casino experience, with minimal learning curve or distractions.  
4) Realistic Game Logic: Ensuring fairness and accuracy in game outcomes was a key factor in our design. The use of a fair RNG ensures all games adhere to standard casino rules, providing players with a realistic and transparent gambling experience.

In summary, our design decisions were influenced by the need for reliability, simplicity, and modular functionality, ensuring that every part of the system operates smoothly and consistently.

## System Context

With our game it will not be multiplayer, so it will just be a game downloaded and installed on the user's computer for them to play. The diagram below shows what it will look like  
![](img/SystemContext.png)

## Architectural Design and Module Descriptions

The structure of Gambling Simulator is built around three core modules, each with distinct responsibilities: the Game Control Module, the Running Module, and the UIX Module. These modules are designed to work together seamlessly, with each handling a specific aspect of the game’s operation. The Game Control Module is responsible for managing the overall game state, player data, and the flow of information between the other two modules. The Running Module contains the game mechanics for each of the casino games (Blackjack, Craps, Slots), overseeing all in-game logic and interactions, while the UIX Module focuses on the user interface, ensuring players can easily interact with the game and see real-time updates. These three modules communicate through well-defined interfaces that ensure smooth data exchange, consistency, and the overall integrity of the system. This modular architecture allows for easier maintenance and future expansion of the game, such as adding new games or features without disrupting the core system.

### Game Control Module
The Game Control Module is central to managing the overall flow of the game. It functions as the intermediary between the player and the game world, coordinating data storage, gameplay events, and communication with both the Running and UIX Modules. The primary responsibility of this module is to track and maintain the current state of the game, including the player’s progress, balance, and any other relevant data that affects gameplay.

A key aspect of this module is the management of the Open World, which encompasses the casino layout and environment. The Open World defines how the player navigates the casino, including the physical layout of the space, the sounds that populate the environment, and the various points of interaction within the casino. For example, as the player moves around the casino, the Game Control Module will handle the interactions between the player and the various game tables, ensuring that the player can move freely, approach a table, and begin playing when they are ready. Additionally, the Open World will handle the visual design of the casino, making sure that the environment feels immersive, with vibrant lighting, sound effects, and realistic 3D models that simulate a real-world casino experience.

Another crucial responsibility of the Game Control Module is to store player data. This includes managing the player's balance, tracking their winnings or losses, and saving progress throughout the gameplay. Player data is encapsulated in a BankAccount class, which handles deposits and withdrawals, ensuring that the player’s balance is always accurate and cannot go negative. This class also stores additional information such as cosmetic items purchased, player preferences, and game history, allowing players to resume their progress in subsequent sessions. This data storage system is fundamental to maintaining the continuity of the player's experience across multiple play sessions.

The Game Control Module is also in charge of validating player commands. As players interact with the game’s interface, this module ensures that their actions are valid according to the rules of the game they are playing. For instance, in Blackjack, the module will ensure that the player cannot attempt actions like splitting cards when the game rules don’t permit it. It checks each input against the current game state and validates that the player’s actions are appropriate for the situation, helping to enforce the game's rules and maintain fairness.

Finally, the Game Control Module is responsible for confirming the end of a game. This could happen either when the player runs out of money or when the player chooses to leave. The module must detect when these conditions are met and communicate the game’s conclusion to the player. It also triggers appropriate transitions, such as displaying the game over screen or asking if the player wants to play again.

### Running Module
The Running Module is the heart of the game’s mechanics. It handles the logic for each of the casino games available in the simulator, including Blackjack, Craps, and Slots. This module is in charge of processing the game rules, generating outcomes, and controlling the non-playable characters (NPCs), such as the Blackjack dealer, the Craps roller, or the slot machine’s automated behavior.

The Blackjack Module within the Running Module is responsible for the card deck, the rules of the game, and player interactions. It controls the dealing of cards, ensuring that the deck is shuffled and dealt properly, and processes actions like hitting, standing, doubling down, or splitting, based on the player’s choices. The module also manages the logic for determining hand values, busts, and game outcomes, ensuring the game runs smoothly and according to standard Blackjack rules.

The Craps Module manages the dice-rolling mechanics of the game. It processes the player’s bet, rolls the dice, and determines the outcome based on the rules of Craps. It tracks the current point, adjusts the player’s balance depending on the results of each roll, and handles the transition between different phases of the game, such as the come-out roll or the point phase. It also manages the player’s interactions with NPCs, such as the shooter, and provides feedback through the UIX Module.

The Slots Module operates the slot machines in the game. This module handles the spinning of the reels, ensuring that each spin generates a fair and random result. It also manages the payout calculations, adjusting the player’s balance based on the outcome of each spin. Like the other game modules, it interacts with the UIX Module to provide real-time feedback to the player, displaying the results of the spin and any winnings.

Throughout the Running Module, each game communicates with the UIX Module, sending updates on game states, player actions, and outcomes. The module ensures that all game mechanics are processed according to the rules, providing a seamless experience where game outcomes are calculated in real-time.

### UIX Module
The UIX Module is the module responsible for managing the user interface and the player’s interaction with the game world. It serves as the bridge between the player and the core game mechanics, ensuring that players can interact with the game in a clear, intuitive, and enjoyable way. The UIX Module adapts to different types of games, offering custom interfaces for each one.

For the casino environment itself, the UIX Module manages the open world interface, displaying the virtual casino, the player’s current location, and all available games the player can interact with. It provides visual feedback on the player’s progress, such as displaying the balance and any in-game information like tutorial tips or help messages. As the player moves around the casino, the UIX Module will update to show which games are available for interaction, providing clear instructions for starting a game or interacting with NPCs.

The UIX Module also handles the custom game interfaces. Each game, such as Blackjack, Craps, and Slots, has its own unique interface elements that need to be displayed to the player. The UIX Module will adapt the interface to each specific game, displaying relevant information like the current hand in Blackjack, the dice roll results in Craps, or the current symbols on the reels in Slots. This module will update dynamically as the game progresses, reflecting changes in the game state in real-time.

Another important role of the UIX Module is to handle user input. Whether the player is placing bets, interacting with game buttons, or navigating the casino, the UIX Module listens for and processes all player inputs. It communicates with the Running Module to send commands based on the player’s actions, such as confirming a bet or selecting an action like "hit" or "stand" in Blackjack. After receiving the player’s input, the UIX Module updates the screen to reflect the new game state, ensuring the player always knows what’s happening in the game.

Finally, the UIX Module must effectively communicate with the Running Module to display the outcomes of game actions. The UIX Module needs to continuously receive data from the Running Module about the current game state, such as card draws, dice rolls, or slot spins, and update the player’s interface accordingly. This ensures that the player’s experience is always in sync with the underlying game mechanics, providing an interactive and immersive experience.

### The Layout  
This is where the physical layout for the casino is, mapping where the tables will be. It also makes sure that the player can’t go through the walls or move through the tables, blocking their movement to ensure they don’t fall through the world.

### The Visuals  
We want the player to feel like they really are at the casino, this includes making it look as authentic as possible. We plan to have bright lights surrounding the slot machines, a classic looking carpet floor, and tables with dealers that seem inviting to the player. There will also be posters/murals on the walls with slogans encouraging gambling. This isn’t going to be our primary focus, as functional gameplay is first priority.

### The Sounds  
In the casino we want to have the authentic sounds one would find at a real casino. This includes loud dings of slot machines, and people talking/cheering for others wins. There will also be some music playing to make the game feel more atmospheric, and we don’t want to have a quiet and eerie feeling in the casino, we want it to be fun and feel exciting.  

### Validating Commands  
 While the UIX module will handle the user inputs, this module will make sure the inputs they are doing have a valid command. An example would be if they are in blackjack and try to split when they aren’t allowed to, the game doesn’t let them split even though they pressed the button for it.  

### The Input  
When a player presses a button on their keyboard we want to accept their input accurately. It will then take their input and send it to the game control module. We will have the keyboard mapped, with some of the ideas for different keys commands being:

* WASD movement  
* E to interact  
* Esc for the pase menu  
* Mouse Movement to move camera

We might let customization of keybinds but that is undecided. It then sends the resulting keystrokes or mouse clicks to the running module, which then confirms the command and makes sure the player's request is valid. After the game control module gets the request, validates it, then sends it to the running module to have the game do the request made. After the game makes the request it will send it back to the game control, and then goes back to the UIX module with its output.

### Output  
After the game responds to the input, and the game control receives that result it then sends an output to the UIX module. This can include different visuals appearing on screen, such as a “YOU WIN\!\!” graphic if they win a hand or a “Try Again” if they lose. We also want to make sure that the sounds that go with it make sense, like a victory bell for a win or a sad trumpet sound for a loss. We also want to make sure that the rest of the HUD is accurate, like showing the correct buttons for interacting and moving around, and making sure that the balance being shown to the player is accurate. 


### Game Specific UIX
We will now go over some specific needs for each game, including both the inputs and outputs.


### Overview of the Modules  
It is important for the modules to function and communicate properly. The UIX handles the direct player inputs and the direct player output. Ensure that the player can’t change or impact the game logic or anything else that they aren’t supposed to touch. The UIX sends it to the game control module, which validates the player's command. The control module also handles the other logic surrounding the game, like where the player is in the casino, and the player's balance. It sends these requests made by the user to the running module, which is where the actual games run. This stores the rules for the games and the actual code and assets that run the game, ensuring bets and other things of the like. Below is a simple diagram showing how the modules connect.  
![](img/DataMovementDiagram.PNG)  
Module for the game running

## Data Design

In this section we go over how we will be storing data. For our game there is two main branches for what data we are storing, the players data and the games data.

### Players Data  
For the player we will be storing a two main aspects in their user profile, these include:

* The players username/id  
* The players in game balance
* The player’s purchased cosmetics

The username/id will be something they choose themselves, being able to call themselves whatever they choose. It may be tied to an email address, but the final decision on that is yet to be made. With the user having a profile, it makes it possible to store/save what they currently have in the balance across multiple sessions. Storing their balance is important because we don’t want to short out players while not giving them things for free. One of our secondary features we hope to implement is a store to buy cosmetics, and with the players profiles being saved it makes it possible for them to keep their cosmetics tied to their account. This could also lead to some fun end game stuff, like giving the player the option to sell their cosmetics to keep playing without going bankrupt. For that to happen we need to implement the store first. The players data will be stored in the game control module, and we will encourage players to not keep sensitive data in their profile as currently with the game not needing any personal data to play we won’t be over tight on security. We plan to store the players data even past when they close the game, we want to implement this by having save states that will store the players current game to their local device. This will make the player's ability to gamble feel like there is a bit more of a risk, as they wouldn’t just be able to restart and pretend like it never happened. 

### Game Data  
For the games we don’t play to store the data of previous play for blackjack or slots, while craps will store a few of the previous game for bets and to show the player what was just rolled. How that data will be stored is yet to be decided but it will likely be saved in a local file in the craps game folder. For the other games not storing data keeps the files needed smaller, and it's not needed to keep previous games as they have no impact on the game that is currently being played. 

## Game State and Flow of Play

For this section we lay out the current flow of the game. In the current version of Gambling Simulator, players can immerse themselves into a 3D casino currently featuring three unique games: Blackjack, Slots, and Dice(Craps). The game features a persistent balance which flows across all games, ensuring a continuous thrill until the balance reaches zero, allowing for strategic decisions as users can try to shift their luck from one game to another. 

The expected flow of events is listed below, with some steps bypassed if a player's balance hits zero, marking the end of their casino adventure.

### Flow of Events

The expected sequence of gameplay is structured as follows:

1. Game Start:  
    Players enter the casino with their initial balance.  
2. Game Selection:  
    Players will explore the casino, and can choose from Blackjack, Slots, or Craps to start their gambling experience.  
3. Gameplay Actions: 
   * Blackjack: Players engage in classic gameplay, trying to beat the dealer with strategic moves such as hitting, standing, or utilizing side bets.  
   * Slots: Players spin the reels, hoping for winning combinations that can significantly boost their balance.  
     1. Game starts with loading player balance into the craps module/main function.  
     2. The Player will select their initial bets and amounts for each bet, and at least one of either Pass /Don’t pass bets.  
     3. Flags will be set based on player bets  
     4. The player will initiate a dice roll sequence  
     5. The results of the dice roll will be interpreted. If the roll didn’t result in a round ending condition, the player will be able to make additional bets and roll again. If the round ends, the player will be paid out if they win.  
     6. Rounds may be played until the player runs out of money or the player chooses to quit.  
     7. The craps module will update the player’s balance upon exit.  
   * Craps: Players roll the dice, placing bets on various outcomes and experiencing the thrill of chance.  
4. Balance Update:  
    After each game, the persistent balance updates based on the outcomes, either increasing or decreasing the player's funds.  
5. Game Continuation:  
   Players can switch between games at any time, utilizing their luck and balance strategically to maximize their wins.

### Endgame Condition

At any stage the game may conclude when a player's balance reaches zero. Players must gamble wisely to keep the excitement alive and avoid going bankrupt.

![](img/FlowOFPlay-General.png)

### BlackJack Flow of Play

BlackJack will have a fairly straightforward flow of play, each hand having to go through the various possibilities and responding to the player's inputs. The stages are:

1. Game Start: player places their initial bet  
2. Deals 2 starting cards  
3. Deal 2 cards to the dealer, on face up the other face down  
   1. If the face up is an ace, give the player the option for an insurance bet  
4. Offer the player their available options  
   1. If they have two of the same card, offer them to split their hand  
   2. If their cards have a value equaling 9-11, offer them to double  
   3. Offer them to hit, gaining another card, busting if the value goes over 21  
   4. Let them stand, moving onto the next phase  
   5. Make sure if player has multiple hands from splitting that all of their hands are finished  
5. Dealer then play, hitting until their cards value at least 17,   
   1. If the dealer bust, players with still valid hands win  
   2. If the player has a higher value of cards, they win at a ratio of 3:2, example if you bet $10 you win $15  
   3. If the dealer has a higher value the player loses  
   4. If the dealer and player have the same value, its a push and the player gets their bet back  
6. End of the game

![](img/FlowOfPlay-BlackJack.png)

### Craps Flow of Play

1. Roll Phase  
- Player places a bet.   
- Player rolls two dice (come out roll)   
- If the result is 7 or 11, the player wins if a pass line bet was made. Otherwise player loses  
- If the result was 2,3, or 12, and a don’t pass bet was made, the player wins.   
- Any other value becomes a point. 

2. Point phase   
* Player continues rolling the dice

  *  If the player rolls the Point number again: player wins, round ends. 

  *  If the player rolls a 7 before hitting the Point, player loses, round ends. 

3. End of Round  
* The player either wins or loses, collects winnings or loses bets   
* Game resets for the next round. 


![](img/FlowOfPlay-Craps.png)

### Slots Flow of Play

1. Betting phase  
   * Player decides how many lines they wish to bet on  
   * Player decides how much they would like to bet on each line  
   * Player decides how many rolls they would like with these settings (multi roll)  
2. Pull the lever  
   * Lever initiates the slot rng and game takes over  
   * If the player would like they are able to stop the roll early  
3. Winnings  
   * Winnings are determined by the lines \* payout.  
4. Updates  
   * The amount paid is updated as you pay it  
   * The amount won is updated as you win it

![](img/FlowOfPlay-Slots.png)

## Transition to physical design

We will be implementing our game using the unity game engine. Unity gives us the possibility to learn how to code in an already established game engine to help further our skills, while also giving us free assets to use since we lack in our artistic skills. Unity uses C\# to code its games, so our game will also be coded in C\# as well. 