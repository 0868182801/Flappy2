using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float powerBird;     // Tất cả file code đều dùng đc và hiển thị công khai trên unity
    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]    // Làm private hiện lên trên unnity nhưng không public (không thể sử dụng ở file code khác)
    private AudioSource audio;
    [SerializeField]
    private AudioClip flyClip, pingClip, diedClip;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update()
    {
        BirdMove();
    }

    void BirdMove() {
        if(Input.GetMouseButtonDown(0)) {   // Input.GetKeyDown(KeyCode.Space)
        // MouseButtonDown: khi nhấn chỉ thực hiện 1 lần kể cả nhấn giữ | MouseButton: nhấn giữ sẽ thực hiện liên tục
            myBody.linearVelocity = new Vector2(myBody.linearVelocity.x, powerBird);    // velocity: vận tốc
            audio.PlayOneShot(flyClip); 
        }

         // Thêm hoạt ảnh khi không nhấn nhảy lên đầu bird sẽ cúi xuống
        if(myBody.linearVelocity.y > 0){   // Khi nhấp chuột
            float angel = 0;    // angel: góc xoay để chim cuối xuống
            angel = Mathf.Lerp(0, 45, myBody.linearVelocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel); // trả về góc xoay
        } else if(myBody.linearVelocity.y < 0){    // Khi nhả chuột
            float angel = 0;
            angel = Mathf.Lerp(0, -45, -myBody.linearVelocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        } else if(myBody.linearVelocity.y == 0){    
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
