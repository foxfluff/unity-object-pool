# Unity Object Pool

This is a simple pooling MonoBehavior script that will take a prefab and instantiate a given number of it.

# Usage

This script requires a parent object for the instantiated objects to fall under, I recommend creating a blank GameObject and attaching this script to that.

After attaching, give it the prefab of the object you wish to have a pool for, and the number of those objects you'd like.

To retrieve an object, call the FetchGameObject() method, and return it to the pool using ReturnGameObject(gameObject).