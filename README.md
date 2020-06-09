# URP-LiquidShadergraph
## Procedural Shader graph for interactive liquids in Unity URP
### This is a shadergraph to 'fake' interactive liquid simulation in Unity's Universal Render Pipeline, made with the goal to bring really cheap, and adjustable interactive liquid behaviour to lightweight rendering applications, especially in VR such as on the Oculus Quest. 

### Demo Video

<a href="http://www.youtube.com/watch?feature=player_embedded&v=_Q3YGZFRv6s" target="_blank"><img src="http://img.youtube.com/vi/_Q3YGZFRv6s/0.jpg" alt="Oculus Quest Liquids!" width="240" height="180" border="10" /></a>

The shadergraph uses no vertex manipulation, or compute shader magic. Instead the shadergraph utilises the Voronoi noise node to fake liquid surface ripples and foam. The liquid 'top' surface is faked by rendering backfaces with a flat color, and applying alpha clipping above an overall fill value. Animated bubbles and foam are then blended in. Several parameters are adjustable:
1. Interaction: Whether the shader responds to object movement, which is detected via a provided script (MotionDetect.cs)
2. Liquid and Foam/bubble colors, with foam sensitivity and fading
3. Ripple frequency, amplitude and movement speed
4. Bubble density and vertical speed

## Instructions
1. Open the project in a recent version of Unity. Unity 2019.3.14f1 and URP 7.3.1 were used to create the shadergraph.
2. Find the sample scene under Assets/Liquid/Scenes/Samplescene.unity and open it
3. Press play to enter play mode, and try moving/rotation around the objects in the scene view
4. Explore the various parameters on the shader and the motion detection script to customize

## Important Notes
1. When using for VR, use multi-pass rendering instead of multiview. the shader tends to break on multiview (tested on Oculus)
2. Feel free to customize the shadergraph as you need to, if you find it too expensive on mobile GPUs
3. Fill Levels are essentially offsets from object pivots, so Level 0 will put the liquid surface at where the pivot is.
4. A basic motion detection script is provided (MotionDetect.cs), however it is advised to customize it or write your own based on your exact requirements.
5. The demo video is recorded on an Oculus Quest running in android mode, using Unity's new XR Interaction Toolkit. However, the provided project and shadergraph does not have any VR/XR dependencies and as such does not include a VR camera rig.
