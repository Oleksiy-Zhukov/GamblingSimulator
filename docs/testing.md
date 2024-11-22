# CSCI 265 User Acceptance Test  (Phase 5)

## Team name: Section 3

## Project/product name: Gambling Simulator

## Contact person and email

The following person has been designated the main contact person for questions from the reader:

 \-  Josiah Bowden, [josiahbowden4@gmail.com](mailto:josiahbowden4@gmail.com)

## Introduction and overview

Our product will be a gambling simulation with multiple casino games for users to try their luck on. Our purpose for the game is to give people the rush and excitement of gambling without the risk of actually losing money. This can either help people who have a gambling addiction overcome said addiction or help make the new generation of casino goers. Some of its core features will include an open 3D environment to simulate how a real casino feels, with the sounds and bright flashing lights to make it feel like you are really there. As well as a few classic casino games, like slot machines, blackjack and craps. This will be targeted to an audience of people above the legal age to gamble. This will be on a desktop platform with a downloaded application.  The game will not arrive with real money transfers at the start, so you can't make real money from it

## Software tools and environment

The program is designed for Windows based PC’s. Testing will take place within the Unity Editor.

# Test Plan

For testing the game we have chosen to split it up into the different section correlating to the different games, so one for craps, blackjack, slots and the open world

## Test process for craps

Testing for the craps section of the game will take place in Unity. The testing process will use scripts to force certain outcomes and player inputs to test the game logic.  
Challenges:  
Since Craps is an existing game, testing must be done to ensure that our product performs like the real-world counterpart. Ensuring accuracy of game logic is difficult in a chance based game such as Craps, as there are almost an infinite number of outcomes.  
Timeline:  
Test Process:  
The test environment will consist of a Windows PC running Unity Editor with our source code. Custom scripts will be created to test various game states. The scripts will simulate certain conditions and check the values produced by our game logic, which will be either correct or incorrect. Each type of bet will be tested for functionality, as well as for interactions with the other bets. Any bugs or issues should be reported in the appropriate location in the GitHub repo, as well as to the team on Discord.  
Test Cases Summary:  
For Craps, most testing will be focused on the game logic. Each type of bet will need to be tested to ensure it behaves correctly.   
Specifically, the bet logic must be tested for win conditions, lose conditions and payouts. The two types of bets, multi-round and single-round, must be tested to ensure that their behavior matches, as well as ensure no conflicts occur. Game logic testing will be performed via script. The scripts will force certain outcomes of the dice to test particular cases, such as winning the round or losing the round, and the result will pass/fail. Testing the game logic ensures that our implementation is accurate to real Craps rules, as described in the requirements.  
The GUI and user interaction portion of the program will be manually tested by ensuring every type of bet is accessible only at the appropriate time.  
Test Case List:

| Pass Line Bet | test1 |
| :---- | :---- |
| Don’t Pass Bet | test2 |
| Come Bet | test3 |
| Don’t come Bet | test4 |
| Field Bet | test5 |
| Free Odds | test6 |
| Place bets | test7 |
| Hardways bets | test8 |
| Proposition Bets | test9 |

## Testing Process For Blackjack

For testing the blackjack portion of the game we want to ensure that our players have an authentic blackjack experience. We plan to achieve this through multiple play tests done over the course of making the game. We plan to enable certain situations by making a developer mode to manually force results from our random elements of the game. This test will take place in the unity environment and will try to replicate an average user experience. We will now go into more details on the blackjack specific part of the testing.

### Challenges

For this section of testing there are multiple different challenges that may arise and it's important we are prepared for when they rear their ugly heads. Some of these potential challenges are:

* Inaccurate displays  
* Wrong inputs  
* Incorrect approaches to the different logics

We have to make sure that we get ahead of any of these challenges to ensure our testing goes well.

### Timeline

With the deadline for the full game to be done by December 6th we are staging the different tests for this game to ramp up for the final deadline. We want to start slow with the basic core gameplay features and move on from there. The timeline may be subject to change but a current plan is:

* November 25th: GameStart Test and EndGame test  
* November 30th: Hit Test and Stand Test  
* December 1st: Dealer Play Test  
* December 3rd: Insurance Test  
* December 4th: Split and Double Test


This timeline doesn’t give a lot of time at the end so dates may be moved up as more of the game gets made. 

### Test Process

For blackjack, most testing will be focussed on the gameplay with ensuring that the logic and options given to the player are accurate. We want to focus our testers on having a good gameplay experience, with game feel and control coming first with graphics as a secondary. The environment will be on a desktop in the Unity engine. For setup it will be the tester having the files and unity engine installed and then running the game. For each test case we are going to be making a “developer mode” in the game to choose the elements that are usually random with a specific result to make testing for specific scenarios easier to make happen. For each test there will be the inputs we want the tester to give and the result that we want to happen. The tester will then give the input and show what the result was to compare and see what changes need to be made. 

### Test Case Summary

For blackjack the different tests fall into a few different categories. The different sections would be tests of the gameplay mechanics, tests of interacting with the database, and tests with the npc actions.

#### Gameplay Tests

For gameplay tests these include the GameStart test, HitTest, StandTest, and EndGame test. While some other tests also include gameplay tests, these are the core gameplay features and making sure they work is vital to having a working blackjack game. These tests working will make the future tests have a better impact on the game.

#### Interacting with Database Test

The tests that interact with the database are the InsuranceTest, SplitTest, and DoubleTest. These interact with the database of the players balance and the data that is currently being used in the game to give the player the valid options of bets that they can make. We want the game to accurately communicate with the database and ensure that the what our game shows as their balance is what they actually have. 

#### NPC Actions

The only test that involves an NPC is the DealerPlay test. We want to make sure that when the dealer is making their play that the npc dealer follows what it is supposed to do and acts in the appropriate way.   

### Test List

Here is a table that gives the names of the tests for blackjack, a brief description and the reason why. A more detailed description of each of these test is given in the appendix. 

| Test Name | Description | Reason/ Goal of test |
| :---- | :---- | :---- |
| GameStart | Player Bets, and cards are dealt | We want to test that the players bet is taken from their balance, and that they are dealt two random cards. This is planned as the first test as it sets up the base of the game |
| HitTest | Player Hits, and gains one card | We want to make sure that when the player hits they receive a card, and it recounts their value. |
| StandTest | Player Stands and dealer play begins | We want to make sure that the player can stand to see if they win this hand or not |
| DealerPlay | Dealer deals cards to themselves until they reach 17 | We want the dealer to follow the proper dealer routine and give the player an good playing experience  |
| InsuranceTest | Gives player the insurance bet when it available | Make sure that when the dealers face up card is an ace that the player is given the option to make an insurance bet, giving the player a more real experience |
| SplitTest | Gives player the split bet when it available | Making sure that when the player gets two of the same card and they have enough balance that they can “split” their hand |
| DoubleTest | Gives player the double bet when it available | Making sure that if the player cards value are between 9-11, and if they have enough balance, that they can double their bet |
| EndGame | The player stops playing Blackjack | When the player chooses or runs out of money the game ends and brings them to the open world.  |

## Test Process For Slots

## Test Process For the Open World

For testing the open world mechanics of the game we are going to limit test by giving testers general instructions on how to “break” the game world and give them some freedom to come up with specific tests themselves. This will be the main way of testing the 3D environment known as “Stress testing”.

### Challenges

There are a few separate challenges that can occur and we want to be well prepared for them. Some such challenges are:

* Multiple simultaneous inputs  
* Visual bugs  
* Incorrect physics handling

Predicting these challenges and testing for them as they become relevant are important for the development of the game

### Timeline

From now until the end of the project the timeline will advance at a static rate, as more features are introduced to the 3D Environment they will be stress tested to make sure they are able to withstand most of what the players will think to do

* November 25th \- Movement stress test / multiple simul input test  
* November 29th \- Jump physics stress test  
* December 2nd \- Change scene stress test  
* December 5th \- Generic stress tests

This timeline will give us opportunities to test things and go into another development phase if need arises.

### Test Process

Within the 3D environment most of our test will be focused around creating smooth movement between the main menu and the different games and portraying information that is necessary for the player. The setup will involve distributing a current or test version of the game to clients who will have unity installed. At that point in time the testers will be able to open up the game within their localised version of unity to get to the start screen and progress into the 3D environment from there. Following this we will let the testers have free reign to come up with extraneous test in order to fulfil the purposes of the stress test.

### Test Case Summary

The test case fall into three separate categories for the 3D environment, which are mathematical, visual, and logical

#### Mathematical

Mathematical test cover any physics bugs when it come to the player moving and jumping around, as well as interaction with different hitboxes around the map

#### Visual

Visual test cases are for thing related to the camera and loading things in correctly such as textures objects as well as any visual bugs such as display of currency issues and others

#### Logical

Logical tests are related to how the unity engine and our code handles multiple different instructions. For example we could have movement shooter movement, where if you press the left button and then press the right button it will start going right as that was the last thing pressed. One other way of doing movement is for if both directions are pressed movement stops completely.

### Test List

| Test Name | Description |
| :---- | :---- |
| Button test | Press each button on the keyboard once to check for any unintended action keys or for unexpected results |
| Movement test | Get the tester to try out different things relating to player movement to stress the movement |
| Multi simul input test | Get the tester to use different action keys at the same time to see what happens. Mainly for QOL feedback |
| Change Scene test | Get the tester to press different action keys while trying to change scenes for bug testing |
| Hitbox test | Get the tester to fun into multiple different game objects to see what happens relating to interaction between player and object hitboxes |
| Flick test | Get the tester to move to different parts of the map and rapidly spin the character around to test for issues relating to the camera |

## Test Process For Game Control Module
### Test Process for Game Control

The Game Control module governs the overall gameplay experience, including game state transitions, player data management, and interaction validation. Testing for this module will focus on ensuring smooth data handling, correct player state updates, and accurate command validation.

### Challenges

Data Integrity: Ensuring balance updates and game state persist correctly across sessions.
Invalid Commands: Testing for rejection of invalid player commands (e.g., incorrect bets in Blackjack).
Concurrency: Handling simultaneous interactions, especially in multiplayer scenarios.
State Transitions: Verifying that transitions between game states (e.g., from game to menu) are seamless.

### Timeline

* November 25th - Test balance update consistency
* November 28th - Validate invalid command rejection
* December 1st - Test state transitions (start, end, pause, resume)
* December 4th - Multi-session state consistency test
* December 6th - Full end-to-end game state stress test

### Test Process

The Game Control module testing will involve simulating real-player scenarios. Testers will interact with the game world, performing various game-related actions, such as making bets, changing game states, and validating correct data updates. They will focus on verifying that commands are validated correctly, player data is maintained across sessions, and that the game state transitions without errors.

### Test Case Summary

Mathematical: Testing balance updates and calculations during gameplay.
Logical: Validating correct command rejection and state transitions.
Visual: Ensuring the UI reflects the correct game state.

### Test List

| Test Name | Description |
| :---- | :---- |
| Balance Update Test | Test if player’s balance updates correctly after each action (e.g., bet, win, loss). |
| Command Validation Test | Ensure invalid commands (e.g., incorrect bets) are rejected. |
| State Transition Test | Verify smooth transitions between game states (start, pause, exit). |
| Multi-session Test | Check that player data remains consistent across multiple game sessions. |

## Test Process For Running Module
### Test Process for Running Module

The Running module handles the core game mechanics, including the individual game modules like Blackjack, Slots, and Craps. Testing will focus on validating the game logic, player interactions, and random outcomes, ensuring fairness and consistency.

### Challenges

Game Logic Accuracy: Ensuring Blackjack, Craps, and Slot outcomes are correct.
Randomization: Verifying the randomness of the outcomes in games like Slots and Craps.
Concurrency: Handling multiple players interacting with the same game mechanic, especially for Blackjack.
State Synchronization: Ensuring consistency between the game logic and the player UI.

### Timeline

* November 26th - Test Blackjack card dealing and player actions
* November 29th - Validate randomization in Craps and Slots outcomes
* December 2nd - Test game synchronization (player actions and UI feedback)
* December 4th - Cross-game mechanic consistency (Blackjack vs. Slots vs. Craps)
* December 6th - Full gameplay scenario testing across all game types

### Test Process
Testers will simulate real gameplay scenarios, focusing on each individual game mechanic. They will validate that the correct outcomes are generated (e.g., Blackjack hands, Craps rolls, Slots spins) and that the game logic is consistent. Tests will also cover concurrency, ensuring the game can handle multiple players without error.

### Test Case Summary

Mathematical: Verifying the correctness of outcomes, such as winning conditions and payouts.
Logical: Testing the flow of actions for each game mechanic (Blackjack player actions, Craps roll sequence, Slots spin results).
Randomization: Ensuring that randomness is correctly implemented in game outcomes.

### Test List

| Test Name | Description |
| :---- | :---- |
| Blackjack Deal Test | Test if cards are dealt correctly, with valid outcomes. |
| Craps Dice Roll Test | Verify that dice rolls in Craps yield expected random outcomes. |
| Slots Spin Test | Ensure that slot machine outcomes are randomized and within expected parameters. |
| Multi-Player Test | Check game synchronization between multiple players interacting with the same mechanic. |

## Test Process For UIX Module
### Test Process for UIX Module

The UIX module governs the user interface, including game menus, player input, and on-screen displays. Testing will focus on ensuring that the UI is responsive, displays information correctly, and handles input from players seamlessly.

### Challenges

Cross-Device Responsiveness: Ensuring the UI works well on different screen sizes (e.g., desktop vs. mobile).
Input Handling: Handling various forms of input, including mouse, keyboard, and touchscreen.
UI Consistency: Ensuring the UI layout is consistent across different game states and actions.
Accessibility: Verifying that all UI elements are accessible and usable for players with varying levels of ability.

### Timeline

* November 27th - Test UI responsiveness on different screen sizes
* November 30th - Input handling test (keyboard, mouse, touchscreen)
* December 3rd - UI consistency across game states (menus, in-game, results screens)
* December 5th - Accessibility testing (focus on button layouts, text size, etc.)
* December 6th - Full cross-platform UI test

### Test Process

The UIX module testing will involve interaction with all UI elements, such as menus, buttons, and information displays. Testers will simulate real-user behavior, clicking through menus, placing bets, and interacting with the UI while ensuring proper input handling and information display. Cross-device testing will be done to ensure the UI is consistent across all supported platforms.

### Test Case Summary

Visual: Checking the visual display of game elements and UI consistency.
Logical: Ensuring buttons, menus, and actions perform as expected when interacted with.
Functional: Testing input handling for various devices (keyboard, mouse, touchscreen).

### Test List

| Test Name | Description |
| :---- | :---- |
| UI Responsiveness Test | Test UI layout and responsiveness across different screen sizes. |
| Input Handling Test | Test all forms of input (mouse, keyboard, touchscreen) to ensure UI reacts appropriately. |
| Button Interaction Test | Verify that all buttons and menu options perform the expected actions. |
| Accessibility Test | Ensure that all UI elements are accessible to users with varying abilities. |

## Appendix: Detailed Test Descriptions