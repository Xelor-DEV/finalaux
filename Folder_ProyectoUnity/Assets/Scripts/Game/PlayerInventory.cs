using UnityEngine;
using System;

public class PlayerInventory : MonoBehaviour
{
    private DoublyLinkedList<RobotCard> robotList = new DoublyLinkedList<RobotCard>();
    public RobotCard[] displayedRobots;
    [SerializeField] private int currentPage;
    [SerializeField] private int robotsPerPage;
    [SerializeField] private int totalPages;
    public Action<int> OnInventoryUpdated;
    public RobotCard[] DisplayedRobots
    {
        get
        {
            return displayedRobots;
        }
    }
    void Start()
    {
        displayedRobots = new RobotCard[robotsPerPage];
    }
    public void AddRobot(RobotCard newRobot)
    {
        robotList.InsertarNodoAlFinal(newRobot);
        if (robotList.Longitud > robotsPerPage * totalPages)
        {
            totalPages = totalPages + 1;
        }
        UpdateDisplayedRobots();
    }
    public void RemoveRobot(int index)
    {
        if (index < 0 || index >= robotList.Longitud)
        {
            throw new IndexOutOfRangeException("Índice fuera de rango");
        }
        else
        {
            robotList.EliminarNodoPorPosicion(index);
            if (robotList.Longitud <= robotsPerPage * (totalPages - 1) && totalPages > 1)
            {
                totalPages = totalPages - 1;
            }
            if (currentPage > totalPages - 1 && currentPage != 0)
            {
                currentPage = totalPages - 1;
            }
            UpdateDisplayedRobots();
        }
    }
    public void NextPage()
    {
        if (currentPage == totalPages - 1)
        {
            currentPage = 0;
        }
        else
        {
            currentPage = currentPage + 1;
        }
        UpdateDisplayedRobots();
    }
    public void PreviousPage()
    {
        if (currentPage == 0)
        {
            currentPage = totalPages - 1;
        }
        else
        {
            currentPage = currentPage - 1;
        }
        UpdateDisplayedRobots();
    }
    public void UpdateDisplayedRobots()
    {
        if (robotList.Longitud == 0)
        {
            displayedRobots = new RobotCard[0];
            OnInventoryUpdated?.Invoke(0);
        }
        else
        {
            int start = currentPage * robotsPerPage;
            int end = Mathf.Min(start + robotsPerPage, robotList.Longitud) - 1;
            if (start > end)
            {
                start = end;
            }
            displayedRobots = robotList.GetNodesInRange(start, end);
            OnInventoryUpdated?.Invoke(start);
        }
    }
}