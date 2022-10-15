using UnityEngine;
using UnityEngine.EventSystems;     // �����ǋL

// Sprite �� EventSystems �̃��\�b�h���g���ē�����
// ����L���@http://negi-lab.blog.jp/SpriteControlByEventSystem
public class SpriteControlByEventSystem : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    // �N���b�N
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicked");
    }

    // �h���b�O
    public void OnDrag(PointerEventData eventData)
    {
        // �}�E�X�̈ʒu�ɓ�����
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}