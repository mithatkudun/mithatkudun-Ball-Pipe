using UnityEngine;

public class BallControll : MonoBehaviour
{   

    Touch touch;
    public float power = 15f;
    public GameObject ball;
    public GameObject trajectoryDot;
    public float rotateSpeedX = 5f;
    public float rotateSpeedY = 5f;
    public float forceFactor;
    public int numberOfDots;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 initPos;
    public Rigidbody rb;
    private Vector3 forceAtPlayer;
    private GameObject[] trajectoryDots;

    private void Start()
    {
        initPos = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
        trajectoryDots = new GameObject[numberOfDots];
        SpawnTrajectoryDots();
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.5f;
    }

    private void Update()
    {
        if (rb.IsSleeping() == true)
        {
            UserInput();            
        }

    }        
    public void UserInput()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            startPos = gameObject.transform.position;
            TrajectoryDotsActiveState(true);
        }

        if (Input.GetMouseButton(0))
        { 
            var mousePos = Input.mousePosition;
            mousePos.z = 40;         
            endPos = Camera.main.ScreenToWorldPoint(mousePos) + new Vector3(0, 0, -40);
            endPos.y *= rotateSpeedY;
            endPos.x *= rotateSpeedX;
            forceAtPlayer = endPos - startPos;

            CalculateDotsPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector3 forceAtPlayer = startPos - endPos;
            Vector3 clampedForce = Vector3.ClampMagnitude(forceAtPlayer, forceFactor) * power;
            rb.AddForce(clampedForce, ForceMode.Impulse);
            TrajectoryDotsActiveState(false);
        }
    }
    private void SpawnTrajectoryDots()
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            trajectoryDots[i] = Instantiate(trajectoryDot, gameObject.transform);
            (trajectoryDots[i] as GameObject).transform.parent = gameObject.transform;
        }
    }

    private void TrajectoryDotsActiveState(bool activeState)
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            trajectoryDots[i].SetActive(activeState);
        }
    }

    private void CalculateDotsPosition()
    {
        for (int i = 0; i < numberOfDots; i++)
        {
            trajectoryDots[i].transform.position = CalculatePosition(i * 0.1f);
        }
    }

    private Vector3 CalculatePosition(float elapsedTime)
    {
        return gameObject.transform.position + new Vector3(-forceAtPlayer.x * forceFactor,-forceAtPlayer.y * forceFactor, 0) * elapsedTime + 0.5f * Physics.gravity * elapsedTime * elapsedTime;
    }

}