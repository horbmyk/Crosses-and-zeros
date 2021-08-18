using UnityEngine;
using UnityEngine.UI;

namespace CrossesAndZeros
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image Image;
        [SerializeField] private Sprite Cross;
        [SerializeField] private Sprite Zero;

        public void Select()
        {
            Image.sprite = Cross;
            Debug.Log("Click");
        }
    }
}
