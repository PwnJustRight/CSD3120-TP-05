using Zinnia.Action;
using WebXR;

public class WebGrip : BooleanAction
{
    public WebXRController controller;
    void Update()
    {
        Receive(controller.GetButton(WebXRController.ButtonTypes.Grip));
    }
}
