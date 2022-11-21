# Rounds Mod Template

This is the main template I use for making mods for rounds. 
If you have never made a mod before then it should be used after reading through [Willuwontu's Modding Tutorial](https://docs.google.com/document/d/1zu_89HeFC4aU9xI1MGXTkW1rDLnVCVfoQa5YiNpaWD8/edit)

Note that this template contains none of the required dependencies and those must be added to remove the errors found in the class files. (Will's tutorial explains how to add the needed ones)

Any class that extends the CardBase method will be automaticly built. If for some reason you need a card to not be built, overwirte ShouldBuild() to return false.


To add art to cards, replace the assets file with a custom one. Follow [this tutorial](https://docs.google.com/document/d/1w2Qk_n83e3-eAVKZVlYzrT8myphqZspp2VwV7S_DvuA/edit) for how to make art in unity. Prefabs should be in the form of C_CARD_NAME
(Note: the asset bundle should be named "assets")


To create harmony patches see [this documentaion](https://harmony.pardeike.net/articles/intro.html)


### Suggested Libraries 

The following is a list of extra libraries that may aid in the project you are making:
- [WillsWackyManagers](https://rounds.thunderstore.io/package/willuwontu/WillsWackyManagers/) Primarily used for curses.
- [Classes Manager Reborn](https://rounds.thunderstore.io/package/Root/Classes_Manager_Reborn/) Used for the creation of custom classes.
- [ModsPlus](https://rounds.thunderstore.io/package/willis81808/ModsPlus/) Various helpfull metiods for handling custom things.
- [RarityLib](https://rounds.thunderstore.io/package/Root/RarityLib/) Used for creating/using custom rarities. Adds Legendary by default.
- [CardThemeLib](https://rounds.thunderstore.io/package/Root/CardThemeLib/) Used for creating/using custom card themes. (the border and background colour of the cards)
- [ItemShops](https://rounds.thunderstore.io/package/willuwontu/ItemShops/) A utillity for creating really cool shops inside the game.




<br>
<br>
<br>
<br>
<br>
<sup><sub><sub>Note: A discord server exists to aid in modding and playing modded games, it can be joined here https://discord.gg/zUtsjXWeWk</sub></sup></sup>
