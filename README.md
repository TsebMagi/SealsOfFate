[![Stories in Ready](https://badge.waffle.io/legitbiz/SealsOfFate.svg?label=ready&title=Ready)](http://waffle.io/legitbiz/SealsOfFate)

# SealsOfFate
A fork of the general SealsOfFate project for personal work, currently focusing on AI development. Like the main project, it is licensed under the MIT license, see LICENSE for details.

###Week 3 Report###
Code progress has been slower than expected over these last three weeks. Getting Unity and Git to interface has been unexpectedly difficult, leading to delays in setting up the project basics. Thus, the majority of the time has been spent doing research and design. In addition to the standard Unity tutorials, I've found a fantastic resource in "Programming Game AI by Example". It has been an excellent and practical guide that directly covers several of my goals.

My initial prototype will include a single melee enemy. This enemy will only be active when the player is in the room, and when activated will charge at the player and attack, pathing aroudn obstacles. Once that initial protoype is finished, a secondary prototype is to implement a ranged enemy that attempts to maintain a minimum range from the player. These enemies will e implemented using a simple state machine with states for asleep, alert, seek, attack, and flee (for the ranged enemy). Pathfinding will be handled by A*.

Fortunately, it seems we've sorted out our issues with git, and have the basic framework needed to start implementing and testing the AI. I anticipate work to go much faster now.
