using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smooth : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startRocketPosition, endRocektPosition;
    private float flyTime;
    private float fligDuration = 0.1f;

    public GameObject OverPanel;

    public int health = 1;

    public GameObject effect;

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            OverPanel.SetActive(true);
            Destroy(gameObject);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.y < startTouchPosition.y) && transform.position.y > -3.5f)
                StartCoroutine(Fly("up"));

            if ((endTouchPosition.y > startTouchPosition.y) && transform.position.y < 3.5f)
                StartCoroutine(Fly("down"));
        }

    }

    private IEnumerator Fly(string whereToFly)
    {
        switch (whereToFly)
        {
            case "up":
                flyTime = 0f;
                startRocketPosition = transform.position;
                endRocektPosition = new Vector3
                    (startRocketPosition.x , transform.position.y - 3.5f, transform.position.z);
        
                while(flyTime < fligDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startRocketPosition, endRocektPosition, flyTime / fligDuration);
                    yield return null;
                }
                break;

            case "down":
                flyTime = 0f;
                startRocketPosition = transform.position;
                endRocektPosition = new Vector3
                   (startRocketPosition.x , transform.position.y + 3.5f, transform.position.z);

                while(flyTime < fligDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp
                        (startRocketPosition, endRocektPosition, flyTime / fligDuration);
                    yield return null;
                }
                break;
        }
    }
}
