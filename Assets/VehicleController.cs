using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class VehicleController : MonoBehaviour
{
    public float desired_acceleration;
    public float impulse;
    public float turnrate;
    public CheckpointController target;
    public float starttime;
    public TextMeshProUGUI timelbl;
    public TextMeshProUGUI laplbl; 
    int lap = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration*5, 0, 0);
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / 200;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }
        timelbl.text = string.Format("Current time: {0:F2} seconds", (Time.time - starttime));
    }
    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
    }

    public void CompleteLap()
    {   
        lap++;
        laplbl.text = "Lap: " + lap;
    }
}
