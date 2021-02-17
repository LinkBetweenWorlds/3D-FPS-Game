using UnityEngine;
public class TracerBlink : MonoBehaviour
{
    public float maxDistance = 4.0f;
    public GameObject canvas;
    public KeyCode Boost;
    Vector3 destination;
    Animator anim;
    private float timer = 0;
    private float BlinkTimer = 15;
    public bool BlinkReady = false;
    private void Start()
    {
        if (canvas != null)
        {
            anim = canvas.GetComponentInChildren<Animator>();
            anim.enabled = false;
        }
        timer = 0;
        BlinkTimer = 15;
        BlinkReady = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= BlinkTimer && BlinkReady == false)
        {
            BlinkReady = true;
        }
        else 
        {
            timer += Time.deltaTime;
        }
        if (BlinkReady)
        {
            if (Input.GetKeyDown(Boost))
            {
                BlinkReady = false;
                timer = 0;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    destination = hit.point;
                }
                else
                {
                    destination = transform.
                   position + transform.forward * maxDistance;
                }
            }
            if (Input.GetKeyDown(Boost) && transform.position != destination)
            {
                destination.y += 0.5f;
                transform.parent.position = destination;
                if (anim != null)
                    anim.enabled = true;
            }
            if (anim == null)
            {
                return;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                anim.Rebind();
                anim.enabled = false;
            }
        }
    }
}