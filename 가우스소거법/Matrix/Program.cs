using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix    // 가우스 소거법을 이용해 역행렬 구하기
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            double[,] matrix = new double[3, 3];     // matrix를 3*3 행렬로 설정
            double[,] identity = new double[3, 3];   // identity = 초기엔 단위행렬, 계산후 matrix의 역행렬

            // identity 를 단위행렬로 설정
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    identity[i, j] = (i == j) ? 1 : 0;
                }
            }

            // matrix 행렬 값 입력 받기
            Console.WriteLine("matrix의 행렬 값 입력");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("{0}행 {1}열 값 입력 : ", i, j);
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // 가우스 소거법
            for (int i = 0; i < 3; i++)
            {
                // 대각선 요소를 1로 만드는 과정 
                double constant = matrix[i, i];      // 대각선 요소의 값 저장 
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] /= constant;   // matrix[i][i] 를 1 로 만드는 작업 
                    identity[i, j] /= constant; // i 행 전체를 matrix[i][i] 로 나눔 
                }

                // i 행을 제외한 k 행에서 matrix[k][i] 를 0 으로 만드는 과정 
                for (int k = 0; k < 3; k++)
                {
                    if (k == i) continue;      // 자기 자신의 행은 건너뜀 
                    if (matrix[k, i] == 0) continue;   // 이미 0이 있으면 건너뜀 

                    // matrix[k][i] 행을 0 으로 만드는 과정
                    constant = matrix[k, i];
                    for (int j = 0; j < 3; j++)
                    {
                        matrix[k, j] = matrix[k, j] - matrix[i, j] * constant;
                        identity[k, j] = identity[k, j] - identity[i, j] * constant;
                    }
                }
            }

            // identity 행렬(matrix의 역행렬) 출력
            Console.WriteLine("\nmatrix의 역행렬");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(" {0}  {1}  {2}", identity[i, 0], identity[i, 1], identity[i, 2]);
            }
        }
    }
}
