using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class Puzzle : MonoBehaviour
{
    public Drop drop;
    string nameOfGameObject;
    public Button SolveButton;
    public Button ClearButton;
    List<int> Inumber = new List<int> { };
    List<int> Jnumber = new List<int> { };
    List<int> Valnumber = new List<int> { };
    int countCal = 0;

    [SerializeField] No_Solution no_Solution;

    List<List<int>> track = new List<List<int>>()
                            {new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0},
                             new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0}};

    
    
   

    void Start()
    {
        

        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 9; i++)
            {
                Text text = GameObject.Find(i.ToString() + " " + j.ToString()).GetComponentInChildren<Text>();
                if (track[j][i] != 0)
                {
                    text.text = track[j][i].ToString();
                }
                else
                {
                    text.text = " ";
                }
            }
        }


    }

    private void OnEnable()
    {
        SolveButton.onClick.AddListener(() => OnButtonPress1());
        ClearButton.onClick.AddListener(() => OnButtonPress2());
    }

    private void OnButtonPress1()
    {
        countCal = 0;
        Inumber.Clear();
        Jnumber.Clear();
        Valnumber.Clear();

        bool x = Solve(track, 0, 0);
        if (!x)
        {
            Debug.Log("Can't Solve the Puzzle x");
            StartCoroutine(no_Solution.FadeIn());

            StartCoroutine(no_Solution.FadeOut());
            return;
        }
        Debug.Log(Inumber.Count.ToString());
        StartCoroutine(PrintNumber());
    }
    private void OnButtonPress2()
    {
        Debug.Log("Clear");
        ListReset();
    }

    public void UpdateList(int i, int j, int val)
    {
        track[j][i] = val;

    }

    private List<bool> listOfValidNo(List<List<int>> A, int i, int j)
    {
        List<bool> allowed = new List<bool>();
        allowed.AddRange(Enumerable.Repeat(true, 9));
        int boxstart = i / 3;
        int boxend = j / 3;

        for (int p = boxstart * 3; p < boxstart * 3 + 3; p++)
        {
            for (int q = boxend * 3; q < boxend * 3 + 3; q++)
            {
                int check = A[q][p];
                if (A[q][p] != 0)
                {
                    allowed[A[q][p] - 1] = false;
                }
            }
        }

        for (int p = 0; p < 9; p++)
        {
            if (A[j][p] != 0)
            {
                allowed[A[j][p] - 1] = false;
            }
        }

        for (int p = 0; p < 9; p++)
        {
            if (A[p][i] != 0)
            {
                allowed[A[p][i] - 1] = false;
            }
        }

        return allowed;
    }

    private bool Solve(List<List<int>> A, int i, int j)

    {
        if (i == 9)
        {
            return Solve(A, 0, j + 1);
        }
        if (j == 9)
        {
            return true;
        }
        if (A[j][i] != 0)
        {
            return Solve(A, i + 1, j);
        }
        countCal++;
        if (countCal > 50000)
        {
            return false;
        }
        List<bool> B = listOfValidNo(A, i, j);


        bool x = false;

        for (int p = 0; p < B.Count(); p++)
        {
            if (B[p] == true)
            {
                A[j][i] = p + 1;
                Inumber.Add(i);
                Jnumber.Add(j);
                Valnumber.Add(A[j][i]);


                x = Solve(A, i + 1, j);
                if (x)
                {
                    break;
                }
            }
        }
        if (!x)
        {
            A[j][i] = 0;
            Inumber.Add(i);
            Jnumber.Add(j);
            Valnumber.Add(A[j][i]);
        }
        return x;
    }

    private void ListReset()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                track[i][j] = 0;
                Text text = GameObject.Find(i.ToString() + " " + j.ToString()).GetComponentInChildren<Text>();
                text.text = " ";
                text.color = Color.black;
            }
        }
    }

    IEnumerator PrintNumber()
    {
        SolveButton.interactable = false;
        ClearButton.interactable = false;
        for (int i = 0; i < Inumber.Count(); i++)
        {
            Text text = GameObject.Find(Inumber[i].ToString() + " " + Jnumber[i].ToString()).GetComponentInChildren<Text>();
            if (Valnumber[i] == 0)
            {
                text.text = " ";
            }
            else
            {
                text.text = Valnumber[i].ToString();
            }
            yield return null;
        }
        SolveButton.interactable = true;
        ClearButton.interactable = true;
    }

}


