using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{

	[SerializeField]
	GameObject PooledObject;

	[SerializeField]
	int PoolSize;

	[SerializeField]
	bool EnabledByDefault;

	List<GameObject> objectPool;
	List<GameObject> leasedObjectPool;

	void Start ()
	{
		objectPool = new List<GameObject>();
		leasedObjectPool = new List<GameObject>();

		for (int i = 1; i <= PoolSize; i++)
		{
			GameObject newObject = Instantiate(PooledObject);

			if (EnabledByDefault)
			{
				newObject.SetActive(true);
			} else
			{
				newObject.SetActive(false);
			}

			newObject.name = string.Format("{0}({1})", PooledObject.name, i);
			newObject.transform.SetParent(gameObject.transform);

			objectPool.Add(newObject);
		}
	}
	
	public GameObject FetchGameObject()
	{
		GameObject fetchedObject = objectPool[0];

		objectPool.Remove(fetchedObject);
		leasedObjectPool.Add(fetchedObject);

		return fetchedObject;
	}

	public void ReturnGameObject(GameObject returnedObject)
	{
		leasedObjectPool.Remove(returnedObject);
		objectPool.Add(returnedObject);
	}

}
