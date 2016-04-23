using UnityEngine;
using System.Collections;

public class gyro : MonoBehaviour
{
    private Vector2 velocity = new Vector2(0.0f, 0.0f);
#if UNITY_EDITOR
    private Vector3 rot;
#endif

    // Use this for initialization
    void Start()
    {
        // debug mode
        for (int i = 0; i < 100; ++i)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.position = Random.onUnitSphere * 10f;
            go.transform.rotation = Random.rotation;
        }
#if UNITY_EDITOR
        rot = transform.rotation.eulerAngles;
#else
        Input.gyro.enabled = true;
#endif
    }
    void ModSpeed(Vector2 a)
    {
        velocity += a;
    }
    void ModAngle()
    {
#if UNITY_EDITOR
        float spd = Time.deltaTime * 100.0f;
        rot += new Vector3(-spd * Input.GetAxis("Mouse Y"), spd * Input.GetAxis("Mouse X"), 0.0f);
        transform.rotation = Quaternion.Euler(rot);
#else
        transform.rotation = Quaternion.AngleAxis(90.0f,Vector3.right)*Input.gyro.attitude*Quaternion.AngleAxis(180.0f,Vector3.forward);
#endif
    }
    void Slower()
    {
        if (velocity.magnitude < 0.5)
        {
            velocity.x = 0.0f;
            velocity.y = 0.0f;
        }
        else
        {
            velocity *= 0.9f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ModAngle();
        ModSpeed(new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")));
        //transform.Translate(velocity.x * Vector3.forward * Time.deltaTime + velocity.y * Vector3.right * Time.deltaTime);
        //Slower();
    }
}
