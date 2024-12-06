# SmartPlanMR

## Setup and Building the App

This section explains how to set up and run the Unity project with the MR app.
First, Unity 2022.3.23f1 must be installed. The easiest way to do this is via the https://unity.com/releases/editor/archive. To do this, simply select "2022" -> "LTS (Default)" and search for 2022.3.23f1 in the list. Afterwards you can open Unity on your laptop and should have the right version installed if you click on "Installs".

After you have installed the right Unity version, you can click on "Projects" and then on "Add". Now a folder selector should open. Here you have to choose the previous cloned git folder and double click on it.

Now you can just click on "Open" on the right bottom corner. After you clicked on that, Unity should open itself and load the project. This can take a while, just wait until its finished and the project has opened. After it has opened, select on the left bottom in the "Project" tab the folder "Scenes" and then double click von "SampleScene".

Now you have opened the right Scene. After thats done you need to set up a few things to be able to build the project. Firstly select "Edit" in the upper left corner and then "Project Settings" in the drop down menu. In the project settings, choose "Player" on the left hand side and the select the android logo.

Now when you have selected the android logo, search in the big window in the middle for "Publishing Settings". Inside of the Publishing Settings you need to click on "Keystore Manager.." and create a new keystore. Simply follow the given instructions in Unity to do that.
After you have created the keystore, close the Project Settings window and click on the top left corner on "File" and then on "Build Settings".

Inside the build settings, you need to click in the left list on "Android" and then on "Switch Platform". This again can take a while. Just wait until its finished. After its finished, make sure that your Meta Quest 3 is connected to your PC and click on "Default Device" on the right side. Here you should now be able to select your Meta Quest 3 device. After selecting the Meta Quest 3, just click on "Build and run" on the bottom left corner and Unity is building the MR app directly on to your Meta Quest.
