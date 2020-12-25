using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePracticeApp
{


    /*
     There are N students in a class. Some of them are friends, while some are not. Their friendship is transitive in nature. For example, if A is a direct friend of B, and B is a direct friend of C, then A is an indirect friend of C. And we defined a friend circle is a group of students who are direct or indirect friends.

    Given a N*N matrix M representing the friend relationship between students in the class. If M[i][j] = 1, then the ith and jth students are direct friends with each other, otherwise not. And you have to output the total number of friend circles among all the students.

    Example 1:

    Input: 
    [[1,1,0],
     [1,1,0],
     [0,0,1]]
    Output: 2
    Explanation:The 0th and 1st students are direct friends, so they are in a friend circle. 
    The 2nd student himself is in a friend circle. So return 2.


     */
    public class FriendCircle
    {

        public int Execute()
        {
            int[][] M = new int[4][];


            M[0] = new int[] { 1, 0, 0, 1 };
            M[1] = new int[] { 0, 1, 1, 0 };
            M[2] = new int[] { 0, 1, 1, 1 };
            M[3] = new int[] { 1, 0, 1, 1 };
            return findCircleNum(M);
        }

        private void dfs(int[][] M, int[] visited, int i)
        {
            for (int j = 0; j < M.Length; j++)
            {
                if (M[i][j] == 1 && visited[j] == 0)
                {
                    visited[j] = 1;
                    dfs(M, visited, j);
                }
            }
        }
        private int findCircleNum(int[][] M)
        {
            int[] visited = new int[M.Length];
            int count = 0;
            for (int i = 0; i < M.Length; i++)
            {
                if (visited[i] == 0)
                {
                    dfs(M, visited, i);
                    count++;
                }
            }
            return count;
        }
    }
}
