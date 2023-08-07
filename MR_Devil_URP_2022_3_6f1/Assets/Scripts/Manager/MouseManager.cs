using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : Singleton<MouseManager>
{
    [SerializeField]
    private bool isClick;

    private float xRotate, yRotate;

    [SerializeField]
    private Vector3 originPos, swipePos, dragPos;

    private Vector3 swipeOriginPos;
    private Vector3 swipeCurrPos;

    private bool isSwipe;

    private void Update()
    {
        MouseRaycast();
    }

    // Mouse Raycast (UI ¼±ÅÃ ¾ÈµÊ)
    private void MouseRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f) && !EventSystem.current.IsPointerOverGameObject())
            MouseButton(hit, 0);
    }

    // Mouse Button Left = 0, Right = 1, Wheel = 2, else = 3 ~ 6
    private void MouseButton(RaycastHit hit, int mouseButton)
    {
        if (Input.GetMouseButtonDown(mouseButton))
        {
            if (hit.collider.gameObject)
            {

            }
        }
    }

    // Touch
    private void Touch()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {

        }
    }

    #region MouseWheel

    private void MouseWheel(RaycastHit hit)
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll == 0)
            return;

        bool isZoomIn = scroll >= 0.1f ? true : false;
        float fov = isZoomIn ? 20f : 60f;

        if (fov == Camera.main.GetComponent<Camera>().fieldOfView)
            return;

        Vector3 point = hit.point;
        point.z = point.z > -360 ? point.z + 360 : point.z;
        point.z *= 0.5f;

        Vector3 pos = isZoomIn ? new Vector3(point.x, Camera.main.transform.position.y, point.z) : Camera.main.transform.position;
        Zoom(pos, fov);
    }

    // X = 0, Up = 1, Down = 2
    private int MouseWheel()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (wheelInput > 0)
            return 1;
        else if (wheelInput < 0)
            return 2;

        return 0;
    }

    #endregion

    #region Drag

    private void Drag()
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(2))
        {
            isClick = false;

            originPos = Vector2.zero;
            swipePos = Vector2.zero;
            dragPos = Vector2.zero;

            return;
        }

        Vector2 dist = Vector2.zero;

        if (!isClick)
        {
            isClick = true;

            originPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            swipePos = Input.mousePosition;
            dist = swipePos - originPos;

            if (CheckSwipe(originPos, swipePos, 1.5f))
            {
                if (dist.x == 0)
                    return;

                Rotate(300f);
            }
        }

        if (Input.GetMouseButton(2))
        {
            dragPos = Input.mousePosition;
            dist = dragPos - originPos;

            if (CheckSwipe(originPos, dragPos, 1.5f))
            {
                if (dist.x == 0)
                    return;

                Move(originPos, dragPos, 50f, Singleton.Instance.camera.GetComponent<Camera>().fieldOfView / 12f);
            }
        }
    }

    private bool CheckDrag(Vector2 originPos, Vector2 currPos, float swipeDist)
    {
        Vector2 dist = currPos - originPos;

        return dist.magnitude > swipeDist ? true : false;
    }

    #endregion

    #region Swipe

    private void Swipe()
    {
        if (Input.touchCount == 0)
            return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 dist;

            if (touch.phase == TouchPhase.Began)
                swipeOriginPos = Input.mousePosition;

            if (touch.phase == TouchPhase.Moved)
            {
                swipeCurrPos = Input.mousePosition;
                dist = swipeCurrPos - swipeOriginPos;

                if (CheckSwipe(swipeOriginPos, swipeCurrPos, 1.5f))
                {
                    isSwipe = true;

                    if (dist.x > 0)
                    {
                        //¿ÞÂÊ
                    }
                    else
                    {
                        //¿À¸¥ÂÊ
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                swipeOriginPos = Vector2.zero;
                swipeCurrPos = Vector2.zero;
                isSwipe = false;
            }
        }
    }

    private bool CheckSwipe(Vector2 originPos, Vector2 currPos, float swipeDist)
    {
        if (isSwipe)
            return false;

        bool check;
        Vector2 dist = currPos - originPos;
        return check = dist.magnitude > swipeDist ? true : false;
    }

    #endregion

    private void RotateCamera(GameObject obj, int resolution, float speed)
    {
        float value = resolution * 0.5f;
        float leftValue = value - 300f;
        float rightValue = value + 300f;

        int flag = Input.mousePosition.x < leftValue ? 1 : -1;

        if (Input.mousePosition.x < leftValue || rightValue < Input.mousePosition.x)
            Camera.main.transform.RotateAround(obj.transform.position, transform.up, Time.deltaTime * flag * speed);
    }

    private void Zoom(Vector3 pos, float fov)
    {
        Camera.main.GetComponent<Camera>().fieldOfView = fov;
        Camera.main.transform.position = pos;
    }

    private int GetFlag(float currValue, float originValue, float swipeDist)
    {
        int flag = 0;

        if (currValue < originValue - swipeDist)
            flag = -1;

        if (currValue > originValue + swipeDist)
            flag = 1;

        return flag;
    }

    private void Rotate(float speed)
    {
        float xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
        xRotate += xRotateMove;
        xRotate = Mathf.Clamp(xRotate, -205, -25);

        float yRotateMove = -Input.GetAxis("Mouse X") * Time.deltaTime * speed / 2;
        yRotate += yRotateMove;

        //Singleton.Instance.gunwoo.transform.localRotation = Quaternion.AngleAxis(xRotate, Vector3.right) * Quaternion.AngleAxis(yRotate + 180, Vector3.up);
    }

    private void Move(Vector3 originPos, Vector3 currPos, float swipeDist, float speed)
    {
        float x = Time.deltaTime * GetFlag(currPos.x, originPos.x, swipeDist) * -speed;
        float y = Time.deltaTime * GetFlag(currPos.y, originPos.y, swipeDist) * -speed;

        //Singleton.Instance.gunwoo.GetComponent<Rigidbody>().MovePosition(Singleton.Instance.gunwoo.GetComponent<Rigidbody>().position + new Vector3(x, 0f, y));
    }
}