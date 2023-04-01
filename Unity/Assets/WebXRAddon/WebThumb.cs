using Zinnia.Action;
using WebXR;

public class WebThumb : BooleanAction
{
    public WebXRController controller;
    
    void Update()
    {
        Receive(controller.GetButton(WebXRController.ButtonTypes.Thumbstick));
    }
}
