using System.Collections.Generic;
using System.Collections.Concurrent;
using UnityEngine;

public class Tochmaneger : MonoBehaviour
{
    [SerializeField]
    private AddScore _Add;
    [SerializeField]
    private TimelineStop _stop;
    [SerializeField]
    private ResultScript _result;
    [SerializeField]
    private MakeBook _book;
    [SerializeField]
    private click_right_effect _effect;

    private Camera camera;
    private List<GameObject> Books = new List<GameObject>();
    private List<GameObject> TempList=new List<GameObject>();
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

        if (_stop.StopMorment()||_result.SendStop())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
		{
            //Debug.Log("�ŏ�");
            FirstBook();
		}

		if (Input.GetMouseButton(0) && Books.Count > 0)
        {
            //Debug.Log("��");
            Dragging();
		}

		if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("����");
            DeleteBooks();
		}

        
    }

    void FirstBook()
    {
        GameObject _child;
        RaycastHit2D hit2D = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.5f);
        if (hit2D.collider != null)
        {
            if(hit2D.collider.gameObject.CompareTag("���s�[�X")|| hit2D.collider.gameObject.CompareTag("�΃s�[�X")
                || hit2D.collider.gameObject.CompareTag("�s�[�X")|| hit2D.collider.gameObject.CompareTag("�ԃs�[�X")
                || hit2D.collider.gameObject.CompareTag("���s�[�X"))
            {
                var thisBook = hit2D.collider.gameObject;
                _child = thisBook.transform.GetChild(0).gameObject;
                Books.Add(thisBook);
                Color bookColor = _child.GetComponent<SpriteRenderer>().color;
                bookColor.a = 0.5f;
                _child.GetComponent<SpriteRenderer>().color = bookColor;
                lastBook = thisBook;
            }else if(hit2D.collider.gameObject.CompareTag("�{��"))
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
        
        
        //Debug.Log("�ړ���");
        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.tag==lastBook.tag&& lastBook.tag != "�{��")
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
                _book.BombRes();
            }
            else if(lastBook.tag=="�{��")
            {
                var h = Physics2D.CircleCastAll(lastBook.transform.position, 10f,Vector2.zero);
                Debug.Log(h.Length);
                foreach (var hit in h)
                {
                    Debug.Log(hit.transform.position);
                    if (!hit.collider.gameObject.CompareTag("�{��")
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
                _book.BombEx();
            }
        }
    }

    void DeleteBooks()
    {
        int num = 0;
        bool bomme = false;
        if (Books.Count >= 3)
		{
            foreach(var item in Books)
			{
                if (item.gameObject.CompareTag("�{��"))
                {
                    _effect.Bomb_effect();
                }else
                {
                    _effect.Chain_effect(num++);
                }
                Destroy(item);

                if (num >= 7)
                {
                    num = 6;
                }
            }
			if (bomme)
			{
                _Add.BombAdd(Books.Count);
            }
			else
			{
                _Add.ScoreAdd(Books.Count);
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
}
