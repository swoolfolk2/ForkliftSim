using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public JoystickManager joystickManager;
    public float rotationSpeed;
    private Vector2 rotation;
    void LateUpdate()
    {
        Rotate();
    }
    public void SetCameraActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    private void Rotate()
    {
        float timeSpeed = rotationSpeed * Time.deltaTime * Mathf.Rad2Deg;
        rotation = new Vector2(joystickManager.GetRs().y * timeSpeed, joystickManager.GetRs().x * timeSpeed);
        transform.Rotate(rotation.x, rotation.y, 0);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
