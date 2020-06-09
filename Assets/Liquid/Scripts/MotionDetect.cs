// Motion detect component for Simple Liquid Shadergraph
// Aniruddha Hardikar 2020 https://github.com/aniruddhahar?tab=repositories


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionDetect : MonoBehaviour
{
    // The material using the Liquid Shadergraph
    public Material targetMat;

    // Sensitivity to motion, and Rate of decay of motion.
    // Higher sensitivity will means quicker reaction, Higher decay means the liquid will come to rest quicker.
    public float sensitivity = 1f, decayRate = 0.2f;   

    // Position and Rotation deltas
    Vector3 lastPos, speedVec;
    Quaternion lastRot, rotVec;

    public float maxAmplitude = 10; // Maximum amplitude the liquid movement is capped at
    float amp = 0, movementDelta = 0; // Amplitude to be fed into the shader, and the factor by which it grows

    // Start is called before the first frame update
    void Start()
    {
        // We set the position and rotation initial values at start
        lastPos = transform.position;
        lastRot = transform.rotation;
        
        // Inital amplitude is 0;
        amp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Get Rotation delta since last frame
        rotVec = new Quaternion(
            lastRot.x - transform.rotation.x, 
            lastRot.y - transform.rotation.y,
            lastRot.z - transform.rotation.z, 
            lastRot.w - transform.rotation.w);

        // Get Location delta since Last frame.
        speedVec = (lastPos - transform.position);
        
        // Calculate Movement delta
        movementDelta = speedVec.magnitude + (Mathf.Abs(rotVec.x) + Mathf.Abs(rotVec.y) + Mathf.Abs(rotVec.z))/4;
        
        // Add to amplitude based on the amount of movement since last frame
        amp += movementDelta * Time.deltaTime * sensitivity;

        // subtract from Amplitude based in decayrate exponentially;
        amp -= decayRate * decayRate * Time.deltaTime;

        // Clamp Amplitude between 0 and maxAmplitude
        amp = Mathf.Clamp(amp, 0, maxAmplitude);
        
        // If a target material is assigned, feed in the amp variable to the hidden amplitude property in the shadergraph
        if (targetMat) targetMat.SetFloat("_Amp", amp);
        
        // Set new values for lastPos and lastRot to be used in next frame
        lastPos = transform.position;
        lastRot = transform.rotation;
        

    }
}
