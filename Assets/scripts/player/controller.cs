using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class controller : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] float Speed;
    [Header("UI")]
    [SerializeField] Text time_text;
    [SerializeField] GameObject lose;
    [SerializeField] GameObject win;
    [HideInInspector]
    private Rigidbody rb;
    int time = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(timer());
    }
    private void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal") / 10 * Speed;
        float ver = Input.GetAxis("Vertical") / 10 * Speed;

        rb.AddForce(new Vector3(ver, 0, -hor), ForceMode.VelocityChange);
    }
    IEnumerator timer() {
        yield return new WaitForSeconds(1);
        time++;
        time_text.text = "TIME: "+ time.ToString()+" S";
        StartCoroutine(timer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
            lose.SetActive(true);

        if (other.tag == "Finish")
        {
            SaveS.Load();
            StaticValues.time.Add(time);
            SaveS.Save();
            win.SetActive(true);
        }
    }
}