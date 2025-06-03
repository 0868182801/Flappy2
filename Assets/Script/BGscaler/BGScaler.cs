using UnityEngine;
using System.Collections;
// GameObject = background do code đc gán vào đối tg background
public class BGScaler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    // Khi bắt đầu nhấn chạy game 
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer> (); // Gán SpriteRenderer() của GameObject vào biến sr
        Vector3 tempScale = transform.localScale; // lấy thông số scale hiện tại của background ---> 1,1,1 --> 1
        // Vector2: truyền vào 2 đại lượng x và y
        float height = sr.bounds.size.y; // lấy chiều cao của background
        float width = sr.bounds.size.x;

        float phong_chieuCao = Camera.main.orthographicSize * 2f;   // camera size = 5 --> phong_chieuCao = 10
        float phong_chieuNgang = phong_chieuCao * Screen.width/Screen.height;   // Screen.width: kik thước của khung màn hình screen máy đang use

        tempScale.y = phong_chieuCao/height; 
        tempScale.x = phong_chieuNgang/width;

        transform.localScale = tempScale;

    }

}
