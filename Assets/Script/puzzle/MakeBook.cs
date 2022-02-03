using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class MakeBook : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Peas;
    [SerializeField]
    private GameObject Bomb;

    private bool sw;
    private bool bsw = false;
    private int suitable = 0;
    private PazzleCookMAnager game = new PazzleCookMAnager();
    private GameObject[][] books = new GameObject[7][];

    void Start()
    {
		for (int i = 0; i < books.Length; i++)
		{
			if (i % 2 == 0)
			{
                books[i] = new GameObject[6];
			}
			else
			{
                books[i] = new GameObject[5];
			}
		}

        SpawnPeas();
    }

    void Update()
    {
        NewPeas();

        if (Input.GetMouseButtonDown(1)&&!Input.GetMouseButton(0)
            &&!game.GetGameStop())
        {
            ReSpawnPeas();
        }
    }

    void SpawnPeas()
    {
        int even = 0;
        int odd = 0;
        for (int i = 0; i < 7; i++)
        {
			if (i % 2 == 0)
			{
				for (int j = 0; j < 6; j++)
				{
                    int r = Random.Range(0, 5);
                    books[i][j] =
                        Instantiate(Peas[r], new Vector3(-34f + (even * 22), 22f - (j * 14), 140f), Quaternion.identity);
                }
                even++;
			}
			else
			{
				for (int j = 0; j < 5; j++)
                {
                    int r = Random.Range(0, 5);
                    books[i][j] =
                        Instantiate(Peas[r], new Vector3(-23f + (odd * 22), 15f - (j * 14), 140f), Quaternion.identity);
                }
                odd++;
			}
        }
    }

    private void NewPeas()
    {
        sw = true;
        suitable = 0;
        for (int i = 0; i < books.Length; i++)
        {
            for (int j = 0; j < books[i].Length; j++)
            {
                if (books[i][j] == null)
                {
                    suitable++;
                    if (suitable >= 6 && sw &&!bsw)
                    {
                        books[i][j] =
                              Instantiate(Bomb, new Vector3(-34f + (i * 11), 28f + (j * 5), 140f), Quaternion.identity);
                        sw = false;
                    }
                    else
                    {
                        int r = Random.Range(0, 5);
                        books[i][j] =
                            Instantiate(Peas[r], new Vector3(-34f + (i * 11), 28f + (j * 5), 140f), Quaternion.identity);
                    }                
                }
            }
        }
    }

    public void ReSpawnPeas()
    {
        for (int i = 0; i < books.Length; i++)
        {
            for (int j = 0; j < books[i].Length; j++)
            {
                Destroy(books[i][j]);
            }
        }

        SpawnPeas();
    }

    public void BombEx(bool swich)
    {
        bsw = swich;
    }
}

