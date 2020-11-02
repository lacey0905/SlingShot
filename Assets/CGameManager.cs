using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{

    public LineRenderer lineLeft;
    public LineRenderer lineRight;

    public Ball ball;

    private void Update()
    {

        Vector3 ballPos = ball.GetPos();

        if (ballPos.y < -4f)
        {
            lineLeft.SetPosition(0, new Vector3(-2.5f, -4f, 0f));
            lineLeft.SetPosition(1, new Vector3(ballPos.x, ballPos.y, 0f));
            lineRight.SetPosition(0, new Vector3(2.5f, -4f, 0f));
            lineRight.SetPosition(1, new Vector3(ballPos.x, ballPos.y, 0f));
        }
        else
        {
            lineLeft.SetPosition(0, new Vector3(-2.5f, -4f, 0f));
            lineLeft.SetPosition(1, new Vector3(0f, -4f, 0f));
            lineRight.SetPosition(0, new Vector3(2.5f, -4f, 0f));
            lineRight.SetPosition(1, new Vector3(0f, -4f, 0f));
        }


        if (Input.GetMouseButtonDown(0))
        {

            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null && hit.collider.tag == "Ball")
            {
                target = hit.collider.gameObject;
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (target != null)
            {
                target.transform.position = pos;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (target != null)
            {
                ball.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power, ForceMode2D.Impulse);
            }
        }

    }

    GameObject target;
    public float power;
    

}
