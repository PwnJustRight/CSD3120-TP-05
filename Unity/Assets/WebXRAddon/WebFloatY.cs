using Zinnia.Action;
using WebXR;
using UnityEngine;

public class WebFloatY : FloatAction
{
    public WebXRController controller;
    private float yAxis;
       
    void Update()
    {
        var vec2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        yAxis = vec2.y;
        Receive(yAxis);
    }
}
