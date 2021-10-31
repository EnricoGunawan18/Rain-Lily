using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class MakeBook : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Peas;
    [SerializeField]
    private GameObject Bomb;
    [SerializeField]
    private ResultScript _stop;

    private int even = 0;
    private int odd = 0;
    private bool sw;
    private bool bsw = false;
    private int suitable = 0;
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
            &&!_stop.SendStop())
        {
            ReSpawnPeas();
        }
    }

    void SpawnPeas()
    {
        even = 0;
        odd = 0;
        for (int i = 0; i < 7; i++)
        {
			if (i % 2 == 0)
			{
				for (int j = 0; j < 6; j++)
				{
                    //Debug.Log("‹ô”");
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
                    //Debug.Log("Šï”");
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
                    //Debug.Log(i + " " + j);
                    if (suitable >= 6 && sw &&!bsw)
                    {
                        books[i][j] =
                              Instantiate(Bomb, new Vector3(-34f + (i * 11), 34f + (j * 5), 140f), Quaternion.identity);
                        sw = false;
                    }
                    else
                    {
                        int r = Random.Range(0, 5);
                        books[i][j] =
                            Instantiate(Peas[r], new Vector3(-34f + (i * 11), 34f + (j * 5), 140f), Quaternion.identity);
                    }                }
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

    public void BombEx()
    {
        bsw = true;
        //Debug.Log("y");
    }

    public void BombRes()
    {
        bsw = false;
        //Debug.Log("x");
    }
}

/* array
        // Y•ûŒü‚‚³
        Hex_Height = Hex_Width * Mathf.Sin(60.0f * Mathf.Deg2Rad);
        
    	// X•ûŒü‚Ì‚¸‚ê
        Hex_Adjust = Hex_Width * Mathf.Cos(60.0f * Mathf.Deg2Rad);
        
        float grid_X = Hex_Width * hexPos.x + Hex_Adjust * Mathf.Abs(hexPos.y % 2);
        float grid_Y = Hex_Height * hexPos.y;

        return new Vector3(grid_X, grid_Y, 0.0f);

        ----------------

        y = j * 20
        x = i * ( i % 2 * 20 * 0.5 )
 */
