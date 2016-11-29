# VRGame
Jacob
(I'm not really familiar with git so you'll have to excuse me if there are a lot of unnessesary files)

This folder is the entire Unity project used to test the VR framework
In order to use it, you will need:
>Unity
>An HTC Vive install
>Steam
>SteamVR
>SteamVR plugin for unity
>Virtual Reality Toolkit (Search on google VRTK) for unity
>some c# editing environment (like Visual Studio)

the items in the main assets folder are all the assets I created for the project, the rest are freeware found on unity's asset store
Take a look at all of the scripts in this folder and read their comments to guide you through the project

there are 3 main scenes:
>TestScene - this was the first scene used to test the VR headset. It uses a KB+M movement scheme and should probably just be discarded. 
  it's very primative
>VRscene1 - this map was used to create the controller functions, it has both implementations of the script and can be used to compare them
  You can pick up the sword and the gun on the table and use the gun to fire at the targets.
>MazeGame - this scene puts everything together. The user navigates the maze and brings the cube to the end. Press the use button to change
between a flat box and a cube. There are 3 holes in the walls: Purple - user can teleport through   Blue - cube   Green - Flat box

I encourage you to look at the VRTK scripts to understand how they work, they are very well put together
