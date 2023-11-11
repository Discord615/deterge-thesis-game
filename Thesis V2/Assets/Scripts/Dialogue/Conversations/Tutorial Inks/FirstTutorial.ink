INCLUDE tutorialExternalFunction.ink

-> main

=== main ===
Welcome to the tutorial of the game. You can use press Enter to continue to the dialogue.

Now you can use the arrow keys or WASD to select a choice and press enter to choose it.
+ [Sounds cool]
    -> Continuation
+ [Good to know]
    -> Continuation
+ [Okay]
    -> Continuation

=== Continuation ===
Now we can move onto movement. You can use the arrow keys or WASD to move your character. Try walking towards the NPC.
~ startQuest("goToPoint")
-> END