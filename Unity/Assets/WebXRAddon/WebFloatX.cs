using Zinnia.Action;
using WebXR;
using UnityEngine;

public class WebFloatX : FloatAction
{
    public WebXRController controller;
    private float xAxis;
       
    void Update()
    {
        var vec2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        xAxis = vec2.x;
        Receive(xAxis);
    }
}
