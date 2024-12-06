# SmartPlanMR

## Setup and Building the App

This section explains how to set up and run the Unity project with the MR app.
First, Unity 2022.3.23f1 must be installed. The easiest way to do this is via the https://unity.com/releases/editor/archive. To do this, simply select "2022" -> "LTS (Default)" and search for 2022.3.23f1 in the list. Afterwards you can open Unity on your laptop and should have the right version installed if you click on "Installs" on the left hand side(\hyperref[fig:b.2]{Fig B.2 right}).

[Prototype.pdf](ReadMeImages/Prototype.pdf)

After you have installed the right Unity version, you can click on "Projects" and then on "Add" (\hyperref[fig:b.3]{Fig B.3 left}). Now a folder selector should open. Here you have to choose the previous cloned git folder and double click on it(\hyperref[fig:b.4]{Fig B.4 right}).

[Prototype copy.pdf](https://github.com/user-attachments/files/18031225/Prototype.copy.pdf)


Now you can just click on "Open" on the right bottom corner (\hyperref[fig:b.4]{Fig B.4 left}). After you clicked on that, Unity should open itself and load the project. This can take a while, just wait until its finished and the project has opened. After it has opened, select on the left bottom in the "Project" tab the folder "Scenes" (Arrow 5) and then double click von "SampleScene" (Arrow 6) (\hyperref[fig:b.4]{Fig B.4 right}).

[Prototype copy 2.pdf](https://github.com/user-attachments/files/18031226/Prototype.copy.2.pdf)


Now you have opened the right Scene. After thats done you need to set up a few things to be able to build the project. Firstly select "Edit" in the upper left corner (Arrow 7) and then "Project Settings" in the drop down menu (Arrow 8) (\hyperref[fig:b.5]{Fig B.5 left}). In the project settings, choose "Player" on the left hand side (Arrow 9) and the select the android logo (Arrow 10) (\hyperref[fig:b.5]{Fig B.5 right}).

[Prototype copy 3.pdf](https://github.com/user-attachments/files/18031227/Prototype.copy.3.pdf)


Now when you have selected the android logo, search in the big window in the middle for "Publishing Settings" (Arrow 11) (\hyperref[fig:b.6]{Fig B.6 left}) Inside of the Publishing Settings you need to click on "Keystore Manager.." and create a new keystore. Simply follow the given instructions in Unity to do that.
After you have created the keystore, close the Project Settings window and click on the top left corner on "File" (Arrow 12) and then on "Build Settings" (Arrow 13) (\hyperref[fig:b.6]{Fig B.6 right}).

[Prototype copy 4.pdf](https://github.com/user-attachments/files/18031228/Prototype.copy.4.pdf)


Inside the build settings, you need to click in the left list on "Android" (Arrow 14) and then on "Switch Platform" (Arrow 15) (\hyperref[fig:b.7]{Fig B.7 left}). This again can take a while. Just wait until its finished. After its finished, make sure that your Meta Quest 3 is connected to your PC and click on "Default Device" on the right side (Arrow 16). Here you should now be able to select your Meta Quest 3 device. After selecting the Meta Quest 3, just click on "Build and run" on the bottom left corner (Arrow 17) and Unity is building the MR app directly on to your Meta Quest (\hyperref[fig:b.7]{Fig B.7 right}).

[Prototype copy 5.pdf](https://github.com/user-attachments/files/18031229/Prototype.copy.5.pdf)
