using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
	public const int 		rows = 10;
	public const int 		columns = 7;

	public float			startX = -7.2f;
	public float			startY = 0;

	public GameObject		EasyBrickTile;
	public GameObject 		HardBrickTile;
	public GameObject 		MediumBrickTile;

	private GameManager 		gameScript;
	private Transform			brickHolder;
	public 	GameObject[][] 		brickArray = new GameObject[rows][];


    // Start is called before the first frame update
    void 	SetupLevel()
    {
    	int rand;
    	int x;
    	int y;
    	
    	y = 0;
    	while (y < rows)
    	{
    		brickArray[y] = new GameObject[columns];
    		x = 0;
    		while (x < columns)
    		{
    			GameObject toInstantiate;

    			rand = Random.Range(0, 40);
    			if (rand == 1)
    				toInstantiate = HardBrickTile;
    			else if (1 < rand && rand <= 4)
    				toInstantiate = MediumBrickTile;
    			else if (4 < rand && rand <= 10)
    				toInstantiate = EasyBrickTile;
    			else
    			{
    				brickArray[y][x] =  Instantiate(EasyBrickTile, new Vector3 (startX + x * 1.7f, startY + y * 0.4f , 0f), Quaternion.identity, brickHolder);
    				brickArray[y][x].GetComponent<BrickBehavior>().gameScript = gameScript;
    				brickArray[y][x].SetActive(false);
    				x++;
    				continue;
    			}
    			brickArray[y][x] =  Instantiate(toInstantiate, new Vector3 (startX + x * 1.7f, startY + y * 0.4f , 0f), Quaternion.identity, brickHolder);
    			brickArray[y][x].GetComponent<BrickBehavior>().gameScript = gameScript;
    			x++;
    		}
    		y++;
    	}
    }


    private void 	ClearAllBricks()
    {
    	int x;
    	int y;

    	y = 0;
    	while (y < rows)
    	{
    		x = 0;
    		while (x < columns)
    		{
    			Destroy(brickArray[y][x]);
    			x++;
    		}
    		y++;
    	}
    }

    public void 	CheckGameOver()
    {
    	int x;
    	int y;
    	int count = 0;

    	y = 0;
    	while (y < rows)
    	{
    		x = 0;
    		while (x < columns)
    		{
    			if (brickArray[y][x].activeInHierarchy)
    			{
    				count++;
    			}
    			x++;
    		}
    		y++;
    	}
    	if (count == 0)
    	{
    		ClearAllBricks();
    		SetupLevel();
    	}
    }

    void	Awake()
    {
    	gameScript = GetComponent<GameManager>();
        brickHolder = new GameObject ("BrickHolder").transform;
        SetupLevel();
    }

 }
