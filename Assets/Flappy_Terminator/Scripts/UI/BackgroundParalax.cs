using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))] 
public class BackgroundParalax : MonoBehaviour
{
    [SerializeField] private float _speed = 1;

    private RawImage _image;
    private float _imagePositionX;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;
        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }
}
