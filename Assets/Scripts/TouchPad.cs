using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IEndDragHandler
{
    public float Vertical;
    public float Horizontal;

    public bool IsPress;
    public bool IsMove;

    bool SecondTouch;
    int IndexTouch;

    public static TouchPad instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void FixedUpdate()
    {
        if (IsPress) {
            if (Input.touchCount > 0)
            {
                IndexTouch = Input.touchCount - 1;
                Touch t = Input.GetTouch(IndexTouch);

                Vector2 Moving = t.deltaPosition * Time.deltaTime;

                if (t.phase == TouchPhase.Stationary || t.phase == TouchPhase.Ended || t.phase == TouchPhase.Canceled)
                {
                    IsMove = false;
                }

                if (t.phase == TouchPhase.Moved)
                {
                    IsMove = true;
                }

                if (IsMove)
                {
                    if (Moving.magnitude != 0)
                    {
                        Horizontal = Moving.x;
                        Vertical = Moving.y;
                    }
                }
                else
                {
                    Horizontal = 0;
                    Vertical = 0;
                }
            }
            else
            {
                Horizontal = 0;
                Vertical = 0;
            }
        }
        else
        {
            IsMove = false;
            Horizontal = 0;
            Vertical = 0;
        }
    }

    public void OnDrag (PointerEventData data)
    {
        if (data.pointerEnter.gameObject == this.gameObject)
        {
            IsPress = true;
        }


    }
    public void OnEndDrag(PointerEventData data)
    {
        if (data.pointerEnter.gameObject == this.gameObject)
        {
            IsPress = false;
        }
    }


    public void OnPointerDown(PointerEventData data)
    {
        if (data.pointerEnter.gameObject == this.gameObject)
        {
            IsPress = true;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (data.pointerEnter.gameObject == this.gameObject)
        {
            IsPress = false;
        }
    }
}
