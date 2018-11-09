---
layout: default
title: Island Warfare
tagline: VR Capstone Group from Team 4-Fun at UW CSE
---

## Project Description

Our project is an Magic Leap AR "Island Colonization" video game where the player attempts to take over floating islands by defeating enemies. The player can switch between a high-level overview of the world where they distribute units to different floating islands and a low-level view where they actually walk onto the island and watch the battle themselves.

___

## Team Bio
- **Anny Kong**
    - I am a senior at UW majoring in computer science. While I am a big fan of VR/AR as well as great games, it's super exiciting to make a game with AR technologies.
- **Charles Mihran**
    - I am a senior in computer science at UW Settle, but I'm initially from the Bay Area in California. I grew up loving playing video games ranging from Halo to Pokemon and have been interested in game development for a while. I've made some games on my own but am excited to work on a team to creating a game in AR. When I was younger I loved games from the "Command and Conquer" series and am excited to make a strategy game of our own.
- **Xiuxing Lao**
    - I am a senior student in Computer Science at the University of Washington. I always believe that great story can be told in AR.
- **Yuyang Ge**
    - I am a senior studying computer science at UW Seattle. I am also minor in Music and Math, concentrated in biopsychology. I have developed games in the past for iOS system but this is the first time I get the oppotunity to development a game in AR. I believe that VR/AR will be an integral part of the furture, and I am very excited to be working with a team to make a strategy game of our own.

___

## PRD Link
[PRDv2](https://docs.google.com/document/d/1tK8rWAsgP0X3kz5zsiT1drsX3x8JszOWKTgnmHstGJ0/edit?usp=sharing)

___

## Hype/Demo video
Coming soon

___

## Weekly Blog Posts
### Week 6
**Introduction**:

We deployed and tested spawning units using RTS engine, raycasting, and zoom in/out of overview to close up to first person view. According to our milestone we should have smooth transaction of zoom in and out, and we should be looking into the RTS engine. And after week 6, we have accomplished our milestones and in addition we have figured out raycasting and highlight selecting island. Although we have not combined the three parts mentioned above, but each individual part can be build and run on magic leap. 

**Progress**: 

We figured out one of our critical feature smooth zooming in and out of three islands (1 main island and 2 smaller islands). There are three camera position of zooming in/out: overview, close up, and first person. For each islands the user has the option of any of the three positions mentioned above, but the restriction is that zooming in needs to follow the order respectively. I.e. the user cannot zoom in to first person view without zooming into close up view first. But the user can zoom out from whichever position he chooses. This is one of the critical features of our game because we want to give the user complete experience of our game. One of the chanllenge is the structure of the code that manages the three different views. Since we did different views and islands seperately, it caused a lot of redundancy. Fixing the structure of the code can also make combining with raycasting easier. 

**Plan for next week per person**:
- Anny Kong: 
- Charles Mihran:
- Xiuxing Lao:
- Yuyang Ge: combine zooming with units and raycasting. 

### Week 5
#### RTS Battle
**Introduction**: 

We deployed and tested both our chosen RTS engine as well as our initial design of the combined scene. RTS works quite well as all soldiers look good and have good animations but we need to figure out to dynamically spwan them and to help them travel between islands. The design also goes well as we combined two scenes and rendered a bit to have our inital layout finished. And we figured out the zoom in/out, highlight outline, and display control ray on the combined scene. But we need to work further on the interaction between control ray and islands.

**Progress**: 

We studied the documentation of RTS and deployed it to the Magic Leap to see who it works. Given a path and a number of soldiers to release at the start, there will be various soldiers with good actions fighting with enemies and destroying the castle:

![Week 5 RTS Action](week5/week5_good_action.png)

![Week 5 Castle Destruction](week5/week5_destroy_castle.png)

We finished initial island design with assets. We made some modifications to the original design, i.e. making lands to floating islands, adjusting their scales and rotations. Then we combined two scenes and built the combined scene and deployed it to the magic leap successfully. For now, we have a home island and 4 enemy islands around it:

![Week 5 Islands Initial Design 1](week5/week5_Islands_Initial_Design1.png)

![Week 5 Islands Initial Design 2](week5/week5_Islands_Initial_Design2.png)

Then, we made the outline of a single island possible. Once enabled, 1 out of 5 islands could be highlighted in yellow. The entire island could be shown as selected to make the interaction between ray and island happen. When the island is selected, it's outline is being highlighted as shown below:

![Week 5 Island_Outline 1](week5/week5_outline1.png)

![Week 5 Island Outline 2](week5/week5_outline2.png)

![Week 5 Island Highlight](week5/week5_red_outline.png)

We also display the controller in our view and users can see a ray coming out of the controller clearly. So it helps with the island selection:

![Week 5 Controller Visualization 1](week5/week5_Controller_visualization.png)

**Plan for next week**: 

1. For RTS, we plan to clone/Spawn soldiers at specified position/positions
	- get the soldier GameObject
	- create a public field under GameObject
	- attach soldier to the field under some GameObject
	-  i.e. When OnButtonDown, 
	```
	    // spawn new soldier
	   GameObject newObject = Instantiate(cloneObject);             
	   // at some position of the island             
	   newObject.transform.parent = GameObject.Find("GameObject1").transform;
	```

2. For controller, when the ray cast has a hit/makes a selection, hightlight the target island.
- VirtualPointer.cs  — for highlight/not
- Use Raycast() to check and RaycastHit[] to store hit. 
- Go through transform hierarchy to get GameObject to hightlight


### Week 4
#### Island Rendering and RTS Research
**Introduction**: This week we've focused primarily on figuring out how we want to render islands in the magic leap AR space, as well as learning the basics of the RTS engine we'll be using. As islands are the main part of the game we wanted to make sure that they will look good and that the movement around them feels fluid. We've been able to place the islands in the 3D space around the player and are looking more into the modification of the islands. 

**Progress**: We finished the design for smaller islands (where the units will be placed and fights). First, we brought the assets package for design of the islands, but it included many demos, materials, and textures which we could choose from. Eventually we settle on a very simple design of the islands with big open space which the fights could take place. One of the struggles we faced was that all the materials were all in one level of hierarchy which made scale and move the entire island very difficult. We asked for help and eventually figure out how to create new objects to included different materials for different levels of hierarchy. Another struggle is that we could not figure out where to place the camera. It took us some experiments to know that the rotation of the initial position of the camera should be 0 and we should only change the y-axis of the camera position. Below is the screen shot of the islands in perspective to x, y, and z axis. 

![Week 4 Screenshot](week4/week4screenshot.jpg)

After setting up the scene of our game, the next thing that we do was to figure out how to connect the Magic Leap controller to our current scene, so that player could have some simple interactions with the island. With the help of faculty, we sucessfully achieved one of the key feature of the game, "Zoom in and Zoom out" of the island. That means that when the player click the bumper on the controller, the island can either gradually move away from the player or approach the player until he is in the middle of this island. However, current "Zoom in and Zoom out" can only be applied to just one island, so the "Zoom in and Zoom out" still need further improvement in the future.

![week4_Zoom_In/Out](week4/week4_Zoom_in_out.png)

**Plan for next week**: Next week we plan to dive more into the "RTS" aspect of things. We want to experiment with adding units in some form to the islands. We'll try to implement some of the character models we plan to purchase and see if we can get them walking around. We also want to become a lot more familiar with how our chosen RTS engine will work. If we can understand the engine well then that will enable us to implement more complexity and more interesting gameplay. 

___

### Week 3
#### Website, PRD, and Gameplay Plans
We created our website and set up the inital draft of our PRD, or the project requirements document. We've laid out weekly milestones and member responsibilies that will hopefully help us stay on track while we get started on developing our game. We've also laid out our plans for gameplay to have a more concrete understanding on how we want the game to be played. We've decided that each island will have their own battle happening that the player must manage. Each battle will consist of the player attempting to take over the island by destroying all the enemies on it. We also want to have some basic base-building in our game, such as having buildings that generate resources for the player and buildings that let the player spend resources to create units. Taking over the island will include destroying the enemy player's units and buildings. After an island is conquered, we're envisioning some way for the player to transfer units to new islands to aid in the conquering of the new islands. We've also decided on a general aesthetic theme for the game. Instead of a space theme we've gone with a more fantasy style. We've found assets that include stuff like knights, monsters, and medieval buildings in a low-poly style to keep our assets consistent.

___

### Week 2
#### Project decided
We decided on a project! Initially we wanted to have some sort of space RTS in VR, but decided that it wasn't novel enough given that games like Lazer Bait already exist. After trying out the Magic Leap, we became excited at the idea of making an AR game. We liked our "planet colonization" game idea but decided to switch the planets into islands to make the game aesthetic more unique. We also decided that part of the novel gameplay of our game will be how the player interacts with the island. The play will see floating islands around them and have the option to zoom-in to them and get a larger field of the battlefield, walking over everything to get a better view. They can then zoom-out to get a larger view of all the islands. 

___

### Week 1
#### Hello world! 
We've met our group, set up some collaborationt tools and are brainstorming possible ideas for our project. More updates to follow through these blog posts as we continue to make more progress.