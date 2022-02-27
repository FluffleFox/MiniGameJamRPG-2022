using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool drag = false;
    Rigidbody2D rb2d;

    public void OnPointerDown(PointerEventData eventData)
    {
        drag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        drag = false;
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (drag)
        {
            Vector3 dir = Camera.main.ScreenPointToRay(Input.mousePosition).direction;
            dir = (dir / dir.z) * 100.0f;
            Vector3 point = Camera.main.transform.position + dir;
            Vector2 towardMouse = point - transform.position;
            Debug.DrawLine(transform.position, point, Color.white);
            Debug.DrawLine(transform.position, transform.position+(Vector3)towardMouse, Color.red);
            rb2d.AddForce(SmallNormalize(towardMouse) * 1000.0f * Time.deltaTime, ForceMode2D.Force);
        }
    }

    Vector2 SmallNormalize(Vector2 vec)
    {
        if (vec.magnitude > 100.0f) return vec.normalized*100.0f;
        else return vec;
    }
}
