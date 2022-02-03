using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;
using System.Collections;

public class Tochmaneger : MonoBehaviour
{
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private AddScore _Add;
    [SerializeField]
    private TimelineStop _stop;
    [SerializeField]
    private MakeBook _book;
    [SerializeField]
    private click_right_effect _effect;

    private Camera camera;
    private PazzleCookMAnager game = new PazzleCookMAnager();
    private List<GameObject> Books = new List<GameObject>();
    private GameObject lastBook;

	private void Start()
	{
        camera = Camera.main;
	}

	void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        if (_stop.StopMorment()||game.GetGameStop())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
		{
            FirstBook();
		}

		if (Input.GetMouseButton(0) && Books.Count > 0)
        {
            Dragging();
		}

		if (Input.GetMouseButtonUp(0))
        {
            DeleteBooks();
		}

        
    }

    void FirstBook()
    {
        GameObject _child;
        RaycastHit2D hit2D = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.5f);
        if (hit2D.collider != null)
        {
            if(hit2D.collider.gameObject.CompareTag("紫ピース") || hit2D.collider.gameObject.CompareTag("緑ピース")
                || hit2D.collider.gameObject.CompareTag("青ピース") || hit2D.collider.gameObject.CompareTag("赤ピース")
                || hit2D.collider.gameObject.CompareTag("黄ピース"))
            {
                var thisBook = hit2D.collider.gameObject;
                _child = thisBook.transform.GetChild(0).gameObject;
                Books.Add(thisBook);
                Color bookColor = _child.GetComponent<SpriteRenderer>().color;
                bookColor.a = 0.5f;
                _child.GetComponent<SpriteRenderer>().color = bookColor;
                lastBook = thisBook;
            }else if(hit2D.collider.gameObject.CompareTag("ボム"))
            {
                var thisBook = hit2D.collider.gameObject;
                _child = thisBook.transform.GetChild(0).gameObject;
                Books.Add(thisBook);
                Color bookColor = _child.GetComponent<SpriteRenderer>().color;
                bookColor.a = 0.7f;
                _child.GetComponent<SpriteRenderer>().color = bookColor;
                lastBook = thisBook;
            }
        }
    }

    void Dragging()
	{
        GameObject _child;
        RaycastHit2D hit2D = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.5f);
        
        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.tag==lastBook.tag&& lastBook.tag != "ボム")
            {
                var thisBook = hit2D.collider.gameObject;

                Vector2 distance = thisBook.transform.position - lastBook.transform.position;

				if (!Books.Contains(thisBook) && distance.magnitude <= 20.0f)
				{
                    _child = thisBook.transform.GetChild(0).gameObject;
                    Books.Add(thisBook);
                    Color bookColor = _child.GetComponent<SpriteRenderer>().color;
                    bookColor.a = 0.5f;
                    _child.GetComponent<SpriteRenderer>().color = bookColor;
                    lastBook = thisBook;
                }
                _book.BombEx(false);
            }
            else if(lastBook.tag== "ボム")
            {
                var h = Physics2D.CircleCastAll(lastBook.transform.position, 10f,Vector2.zero);
                foreach (var hit in h)
                {
                    if (!hit.collider.gameObject.CompareTag("ボム")
                        &&!hit.collider.gameObject.CompareTag("Frame"))
                    {
                        if (hit != false)
                        {
                            var thisBook = hit.collider.gameObject;
                            Books.Add(thisBook);
                            _child = thisBook.transform.GetChild(0).gameObject;
                            Color bookColor = _child.GetComponent<SpriteRenderer>().color;
                            bookColor.a = 0.5f;
                            _child.GetComponent<SpriteRenderer>().color = bookColor;
                            lastBook = thisBook;
                        }
                    }
                }
                _book.BombEx(true);
            }
        }
    }

    void DeleteBooks()
    {
        bool bomb = false;
        if (Books.Count >= 3)
		{
            foreach(var item in Books)
			{
                if (item.gameObject.CompareTag("ボム"))
                {
                    bomb = true;
                }

                var instantPos = item.gameObject.transform.position;
                StartCoroutine(PlayEffect(effect, instantPos));
                Destroy(item);
            }

			if (bomb)
			{
                _Add.BombAdd( );
                _effect.Bomb_effect();
            }
			else
			{
                _Add.ScoreAdd(Books.Count);
                _effect.Erase_effect();
			}
		}
		else
		{
            GameObject _child;
            foreach(var item in Books)
			{
                _child = item.transform.GetChild(0).gameObject;
                Color bookColor = _child.GetComponent<SpriteRenderer>().color;
                bookColor.a = 1;
                _child.GetComponent<SpriteRenderer>().color = bookColor;
            }
		}
        Books.Clear();
	}

    private IEnumerator PlayEffect(GameObject tmp,Vector3 position )
    {
        position.z = 130f;

        var instant = Instantiate(tmp, position, Quaternion.identity);

        for (int i = 0; i < 60; i++)
        {
            yield return null;
        }

        Destroy(instant);
    }
}
