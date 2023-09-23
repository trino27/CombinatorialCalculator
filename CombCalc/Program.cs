namespace Csh_Kdm_LB3
{
    class Comb
    {
        private int N = 0;
        private int M = 0;
        private int[] ArrN;
        private int[] ArrM;

        private List<int> set = new List<int>();
        private List<int> list = new List<int>();


        public Comb(int N, int M)
        {
            this.N = N;
            this.M = M;
        }
        public Comb()
        {
            N = 1;
            M = 1;
        }

        public void NewVal()
        {
            Console.WriteLine("Enter n: ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter m: ");
            M = Convert.ToInt32(Console.ReadLine());
        }
        public void NewVal(bool P)
        {
            Console.WriteLine("Enter n: ");
            N = Convert.ToInt32(Console.ReadLine());
            M = N;
        }

        private void Print(List<int> lst, int n)
        {
            Console.Write("< ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(lst[i] + " ");
            }
            Console.Write("> ");
        }
        private void Swap(List<int> lst, int i, int j)
        {
            int s = lst[i];
            lst[i] = lst[j];
            lst[j] = s;
        }
        protected double Fact(int x)
        {
            double fact = 1;
            for (int i = 1; i <= x; i++) fact *= i;
            return fact;
        }

        private bool NextA(List<int> lst, int n, int k)
        {
            int j;
            do
            {
                j = n - 1;
                while (j != -1 && (j + 1 > n - 1 || lst[j] >= lst[j + 1]))
                {
                    j--;
                }

                if (j == -1) return false;

                int k_ = n - 1;
                while (lst[j] >= lst[k_])
                {
                    k_--;
                }

                Swap(lst, j, k_);
                int left = j + 1, right = n - 1;

                while (left < right)
                {
                    Swap(lst, left++, right--);
                }

            } while (j > k - 1);
            return true;
        }
        bool NextARep(List<int> lst, int n, int m)
        {
            int j = m - 1;
            while (j >= 0 && lst[j] == n)
            {
                j--;
            }

            if (j < 0) return false;

            if (lst[j] >= n)
            {
                j--;
            }
            lst[j]++;

            if (j == m - 1) return true;

            for (int k = j + 1; k < m; k++)
            {
                lst[k] = 1;
            }
            return true;
        }
        private bool NextC(List<int> lst, int n, int k)
        {
            for (int i = k - 1; i >= 0; --i)
            {
                if (lst[i] < n - k + i + 1)
                {
                    ++lst[i];
                    for (int j = i + 1; j < k; ++j)
                    {
                        lst[j] = lst[j - 1] + 1;
                    }
                    return true;
                }
            }
            return false;
        }
        bool NextCRep(List<int> lst, int n, int m)
        {
            int j = m - 1;
            while (j >= 0 && lst[j] == n)
            {
                j--;
            }

            if (j < 0) return false;

            if (lst[j] >= n)
            {
                j--;
            }
            lst[j]++;

            if (j == m - 1) return true;

            for (int k = j + 1; k < m; k++)
            {
                lst[k] = lst[j];
            }
            return true;
        }
        private bool NextPRep(List<int> lst, int k)
        {
            int j = k - 2;
            while (j != -1 && (j + 1 > N - 1 || lst[j] >= lst[j + 1]))
            {
                j--;
            }

            if (j == -1) return false;

            int n_ = k - 1;
            while (lst[j] >= lst[n_])
            {
                n_--;
            }

            Swap(lst, j, n_);

            int left = j + 1, right = k - 1;

            while (left < right)
            {
                Swap(lst, left++, right--);
            }
            return true;
        }
        public bool NextP(List<int> lst, int n)
        {
            int j = n - 2;
            while (j != -1 && lst[j] >= lst[j + 1])
            {
                j--;
            }

            if (j == -1) return false;

            int k = n - 1;
            while (lst[j] >= lst[k])
            {
                k--;
            }

            Swap(lst, j, k);
            int left = j + 1, right = n - 1;

            while (left < right)
            {
                Swap(lst, left++, right--);
            }
            return true;
        }

        public void A()
        {
            for (int t = 1; t <= N; t++)
            {
                set.Add(t);
            }

            int all = 0;

            all = Convert.ToInt32(Fact(N) / Fact(N - M));

            Console.Write("Number of A combinations: ");
            Console.WriteLine(all);

            foreach (var item in set)
            {
                list.Add(item);
            }

            Print(list, M);

            while (NextA(list, N, M))
            {
                Print(list, M);
            }

            Console.WriteLine();
        }
        public void ARep()
        {
            for (int t = 1; t <= N; t++)
            {
                set.Add(t);
            }

            double all = 0;
            Console.Write("Number of A with repeat combinations: ");
            all = Math.Pow(N, M);
            Console.WriteLine(all);

            List<int> lst = new List<int>();

            int h = N > M ? N : M;

            for (int i = 0; i < h; i++)
            {
                lst.Add(1);
            }
            Print(lst, M);

            while (NextARep(lst, N, M))
            {
                Print(lst, M);
            }
            Console.WriteLine();
        }
        public void C()
        {
            for (int t = 1; t <= N; t++)
            {
                set.Add(t);
            }
            List<int> lst = new List<int>();
            double all = 0;
            Console.Write("Number of C combinations: ");
            all = Fact(N) / (Fact(M) * Fact(N - M));
            Console.WriteLine(all);

            for (int i = 0; i < N; i++)
            {
                lst.Add(i + 1);
            }
            Print(lst, M);

            if (N >= M)
            {
                while (NextC(lst, N, M))
                    Print(lst, M);
            }
            Console.WriteLine();
        }
        public void CRep()
        {
            for (int t = 1; t <= N; t++)
            {
                set.Add(t);
            }

            int Nn = N + M - 1;
            double all = 0;
            Console.Write("Number of C with repeat combinations: ");
            all = Fact(Nn) / (Fact(M) * Fact(Nn - M));
            Console.WriteLine(all);
            List<int> lst = new List<int>();

            for (int i = 0; i < N; i++)
            {
                lst.Add(1);
            }
            Print(lst, M);
            while (NextCRep(lst, N, M))
            {
                Print(lst, M);
            }
            Console.WriteLine();
        }
        public void P()
        {
            for (int t = 1; t <= N; t++)
            {
                set.Add(t);
            }
            double all;
            all = Fact(N);
            Console.Write("Number of P combinations: ");
            Console.WriteLine(all);

            List<int> a = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                a.Add(i + 1);
            }
            Print(a, N);

            while (NextP(a, N))
            {
                Print(a, N);
            }
            Console.WriteLine();
        }
        public void PRep()
        {
            string input;
            Console.WriteLine("Example: x0;x1;x2;x3; ...}");
            Console.Write("P = ");
            input = Console.ReadLine();
            int countX = 1;

            for (int i = input.Length - 2; i > 0; i--)
            {
                if (input[i] == ';')
                {
                    ++countX;
                }
            }

            ArrN = new int[countX];
            int index = countX - 1;
            int key = 1;
            double dot = 0;

            for (int i = input.Length - 2; i > 0; i--)
            {
                if (input[i] == ';')
                {
                    dot = 0;
                    index--;
                    key = 1;
                }
                else
                {
                    if (input[i] == '.')
                    {
                        ArrN[index] /= Convert.ToInt32(Math.Pow(10f, dot));
                        dot = 0;
                        key = 1;
                    }
                    else
                    {
                        ArrN[index] += ((int)input[i] - 48) * key;
                        key *= 10;
                        dot++;
                    }
                }
            }

            N = countX;
            int[] cou = new int[N];
            cou = ArrN;
            ArrM = new int[N];

            for (int i = 0; i < N; i++)
            {
                ArrM[i]++;
            }

            int ind = 0;
            int combsize = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (cou[i] >= 0)
                    {
                        if (cou[i] == cou[j])
                        {
                            cou[j] = -1;
                            ArrM[ind] += 1;
                        }
                    }
                }
                ind++;
            }
            for (int i = 0; i < countX; i++)
            {
                if (ArrN[i] != -1)
                {
                    combsize++;
                }
            }

            int[] combinations = new int[combsize];
            ind = 0;

            for (int i = 0; i < countX; i++)
            {
                if (ArrN[i] != -1)
                {
                    set.Add(ArrN[i]);
                    list.Add(ArrN[i]);
                    ind++;
                }
                else combinations[ind - 1]++;

            }

            M = 1;
            double all;

            for (int i = 0; i < N; i++)
            {
                M *= Convert.ToInt32(Fact(ArrM[i]));
            }

            all = Fact(N) / M;
            Console.Write("Number of  P with repeat combinations: ");
            Console.WriteLine(all);

            for (int i = 0; i < combinations.Length; i++)
            {
                combinations[i]++;
            }

            for (int i = 0; i < set.Count; i++)
            {
                if (combinations[i] == 0)
                {
                    list[i] = -1;
                }

                else if (combinations[i] > 1)
                {
                    for (int j = 0; j < combinations[i] - 1; j++)
                    {
                        list.Add(list[i]);
                    }
                }
            }

            list.Remove(-1);
            list.Sort();

            N = list.Count;
            Console.Write("< ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.Write("> ");

            while (NextPRep(list, N))
            {
                Print(list, N);
            }

            Console.WriteLine();
        }
    }
    class Program
    {
        static int Main()
        {
            int key = -1;
            while (key != 0)
            {
                Comb COMB = new Comb();
                Console.WriteLine(
                    "0 - End!\n" +
                    "1 - A combinations\n" +
                    "2 - A with repeat combinations\n" +
                    "3 - C combinations\n" +
                    "4 - C with repeatcombinations\n" +
                    "5 - P combinations\n" +
                    "6 - P with repeat combinations");
                Console.Write("Enter: ");
                key = int.Parse(Console.ReadLine());
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                switch (key)
                {
                    case 1: COMB.NewVal(); COMB.A(); break;
                    case 2: COMB.NewVal(); COMB.ARep(); break;
                    case 3: COMB.NewVal(); COMB.C(); break;
                    case 4: COMB.NewVal(); COMB.CRep(); break;
                    case 5: COMB.NewVal(true); COMB.P(); break;
                    case 6: COMB.PRep(); break;
                    default: break;
                }
            }
            return 0;
        }
    }

}


