using UnityEngine;
using UnityEngine.EventSystems;     // これを追記

// Sprite を EventSystems のメソッドを使って動かす
// 解説記事　http://negi-lab.blog.jp/SpriteControlByEventSystem
public class SpriteControlByEventSystem : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    // クリック
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Clicked");
    }

    // ドラッグ
    public void OnDrag(PointerEventData eventData)
    {
        // マウスの位置に動かす
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}