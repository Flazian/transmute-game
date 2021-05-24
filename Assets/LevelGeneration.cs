using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject horizontalCorridor;
    public GameObject verticalCorridor;

    public int[,] roomMap;
    public List<Vector2Int> usedPositions;

    private List<RoomContainer> roomContainers;

    public int gutter = 15;
    public int dimensions = 10;
    public int numberOfRooms = 20;

    public void Awake()
    {
        usedPositions = new List<Vector2Int>();
        roomContainers = new List<RoomContainer>();
        roomMap = new int[dimensions,dimensions];

        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < dimensions; j++)
            {
                roomMap[i, j] = 0;
            }
        }

        AddRoom(new Vector2Int(Mathf.RoundToInt(dimensions/2), Mathf.RoundToInt(dimensions / 2)), 1);
        
        while (usedPositions.Count < numberOfRooms)
        {
            AddRoom(GetNewPosition(), 1);
        }

        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < dimensions; j++)
            {
                if (roomMap[i,j] == 1)
                {
                    RoomContainer room = Instantiate(roomPrefab).GetComponent<RoomContainer>();
                    room.transform.SetParent(transform);
                    room.transform.position = new Vector3(i * gutter, 0, j * gutter);

                    room.index = new Vector2Int(i, j);

                    roomContainers.Add(room);
                }
            }
        }

        for (int i = 0; i < dimensions; i++)
        {
            for (int j = 0; j < dimensions; j++)
            {
                if (usedPositions.Contains(new Vector2Int(i, j)))
                {
                    RoomContainer got = roomContainers.Find(x => x.index == new Vector2Int(i, j));
                    got.neighbours = GetNeighbours(new Vector2Int(i, j));
                    got.Generate();
                    SpawnCorridors(got);
                }
            }
        }

        FindObjectOfType<NavMeshBaker>().Build();
    }

    public bool AddRoom(Vector2Int _position, int _type)
    {
        if (!usedPositions.Contains(_position))
        {
            roomMap[_position.x, _position.y] = _type;
            usedPositions.Add(_position);
            return true;
        }

        return false;
    }

    public Vector2Int GetNewPosition()
    {
        Vector2Int position = usedPositions[Random.Range(0, usedPositions.Count)];

        switch(Random.Range(0, 4))
        {
            case 0:
                position += Vector2Int.up;
                break;
            case 1:
                position += Vector2Int.down;
                break;
            case 2:
                position += Vector2Int.left;
                break;
            case 3:
                position += Vector2Int.right;
                break;
        }

        position.x = Mathf.Clamp(position.x, 0, dimensions - 1);
        position.y = Mathf.Clamp(position.y, 0, dimensions - 1);

        if (!usedPositions.Contains(position)) return position;
        return GetNewPosition();
    }

    public bool[] GetNeighbours(Vector2Int _position)
    {
        bool[] _neighbours = new bool[4];

        if (_position.y > 0)
        {
            if (usedPositions.Contains(new Vector2Int(_position.x, _position.y - 1))) _neighbours[0] = true;
            else _neighbours[0] = false;
        }
        else _neighbours[0] = false;

        if (_position.y < dimensions - 1)
        {
            if (usedPositions.Contains(new Vector2Int(_position.x, _position.y + 1))) _neighbours[1] = true;
            else _neighbours[1] = false;
        }
        else _neighbours[1] = false;

        if (_position.x > 0)
        {
            if (usedPositions.Contains(new Vector2Int(_position.x - 1, _position.y))) _neighbours[2] = true;
            else _neighbours[2] = false;
        }
        else _neighbours[2] = false;

        if (_position.y < dimensions-1)
        {
            if (usedPositions.Contains(new Vector2Int(_position.x + 1, _position.y))) _neighbours[3] = true;
            else _neighbours[3] = false;
        }
        else _neighbours[3] = false;

        return _neighbours;
    }

    public void SpawnCorridors(RoomContainer _room)
    {
        if (_room.neighbours[1])
        {
            GameObject corridor = Instantiate(verticalCorridor);
            corridor.transform.SetParent(transform);
            //corridor.transform.position = new Vector3((_room.index.y * gutter) + ((float)gutter / 2), 0, _room.index.x * gutter);
            corridor.transform.position = new Vector3(_room.index.x * gutter, 0, (_room.index.y * gutter) + ((float)gutter / 2));
        }

        if (_room.neighbours[3])
        {
            GameObject corridor = Instantiate(horizontalCorridor);
            corridor.transform.SetParent(transform);
            //corridor.transform.position = new Vector3((_room.index.y * gutter) + ((float)gutter / 2), 0, _room.index.x * gutter);
            corridor.transform.position = new Vector3((_room.index.x * gutter) + ((float)gutter / 2), 0, _room.index.y * gutter);
        }
    }
}
