# CSCI 265 phase 3 previous files updates

## Section 3

## Project/product name: Gambling Simulator

## Contact person and email

The following person has been designated the main contact person for questions from the reader:

-  Josiah Bowden, [josiahbowden4@gmail.com](mailto:josiahbowden4@gmail.com)

## Changes to the Design Document
1. Clarified UIX Module’s Responsibilities:

Expanded on the UIX module’s interaction with each game. I specified that it will need custom display logic and data for each supported game (Blackjack, Slots, Craps). This ensures the UIX module can adapt its interface based on the game being played.

2. Refined Core Modules and Logic Details:

Enhanced descriptions for each core module, especially the Game Control module, to include specific data handling and logic. For example, I detailed how the Game Control module handles game state (active data, player balance, etc.) and player interactions (validating commands).
Clarified the role of each game module (Blackjack, Craps, Slots) under the Running Module, indicating how they interact with the core system and ensure smooth operation of game mechanics.

3. Strengthened Data Design:

Improved the discussion of how data is handled, especially for the UIX module, which needs to handle different data types depending on the game being played. I mentioned potential challenges and how to manage dynamic data for future expansion.
Emphasized that the data design will need to evolve if additional features (like cosmetics) are added, outlining how player data will be stored and accessed.


## Changes to team Charter  
Removed Hugh from team Charter document.