# AR_FinalProject
## Project: Collaborative Navigation 

This project explores the use of Augmented Reality in a Collaborative Navigation task. A collaborative navigation task involves at least two parties communicating with one another, one playing the leader's role and the other as the follower. The leader's role is to instruct the follower to navigate an environment (i.e, a building) to find target objects. The follower's role is to follow instructions and travel through the space as instructed. 

This project involves two applications, one for the leader and one for the follower, that will communicate with each other. Currently, I am planning to use Photon Voice as a means of communication, but if this does not work a phone call will be used as a substitute. The leader application will be a VR desktop application that will stream the video from the follower's camera. This will allow them to know the location of the followers and direct them to the targets. The follower application will be deployed on the HoloLens 2, and the video of the follower's first point of view will be sent to the leader. We can tell that they have found a target by having them scan the QR code of the target. 

What has been done: 
- I have tried to implement voice networking but found out that to be able to use it on a HoloLens 2 I needed to use a special addon SDK to support the ARM64 build. This comes with a subscription cost so I contacted the Photon company to help out. Still waiting for an answer but this is not a big concern since we can use phone calls as a substitute.
- I have successfully set up a Unity project on the HoloLens 2. This took quite some time for me as this is my first time working with the HoloLens and I encountered a lot of errors when trying to compile just a simple project and deploy it to the Hololens2 via USB. I spent quite some time debugging this issue. This will be crucial as it will allow me to work on streaming the live video to the Unity desktop Application.
- I also created a Unity desktop application to communicate with applications deployed in the HoloLens2. I have set up Photon Networking for it but I will have to connect the HoloLens to it somehow.

Next Steps:
- Implement Video Streaming
- Add QR code scanning for Follower Application
- Implement Voice Network (if receive an alternate solution from Photon people)
   




