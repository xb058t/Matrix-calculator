using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Menu
    {
        private BlockMatrix m = new BlockMatrix(2, 4);
        public void Print () 
        {
            Console.WriteLine("0 - Initialize Matrix"); 
            Console.WriteLine("1 - Print the matrix");
            Console.WriteLine("2 - Set an element");
            Console.WriteLine("3 - Get an element");
            Console.WriteLine("4 - Add to the matrix");
            Console.WriteLine("5 - Multiply to the matrix");
            Console.WriteLine("9 - Exit");
            Console.Write("Make your decision now: ");
            
        }
        public void Run()
        {
            int decision = 8;
            while (decision != 9) 
            {
                this.Print();
                int.TryParse(Console.ReadLine(), out decision);
                switch (decision)
                {
                    case 0: 
                        int b1, b2;
                        Console.Write("Write the size of b1: ");
                        int.TryParse(Console.ReadLine(), out b1);
                        Console.Write("Write the size of b2: ");
                        int.TryParse(Console.ReadLine(), out b2);
                        this.m = new BlockMatrix(b1, b2);
                        this.m.Print();
                        break;
                    case 1: 
                        this.m.Print();
                        break;
                    case 2:
                        int i, j, e;
                        Console.Write("Enter Row: ");
                        int.TryParse(Console.ReadLine(), out i);
                        Console.Write("Enter Column: ");
                        int.TryParse(Console.ReadLine(), out j);
                        Console.Write("Enter Replacement: ");
                        int.TryParse(Console.ReadLine(), out e);
                        try {
                            this.m.Set(i, j, e);
                        this.m.Print();
                        }
                        catch (BlockMatrix.IndexError) {
                            Console.WriteLine("Bad index");
                        }
                        break;
                    case 3: 
                        int k, f;
                        Console.Write("Enter Row: ");
                        int.TryParse(Console.ReadLine(), out k);
                        Console.Write("Enter Column: ");
                        int.TryParse(Console.ReadLine(), out f);
                        try
                        {
                            Console.WriteLine(this.m.Get(k, f));
                        }
                        catch (BlockMatrix.IndexError)
                        {
                            Console.WriteLine("Bad index");
                        }
                        break;
                    case 4:
                        int o, p;
                        
                        // if (o > this.m.GetRowLength() || p > this.m.GetColumnLength())
                            Console.Write("Enter Row: ");
                            int.TryParse(Console.ReadLine(), out o);
                            Console.Write("Enter Column: ");
                            int.TryParse(Console.ReadLine(), out p);
                            BlockMatrix b = new BlockMatrix(o, p);
                        try
                        {
                            this.m.Add(b);
                            this.m.Print();
                        }
                        catch (BlockMatrix.MatrixSizeError) 
                        {
                            Console.WriteLine("Can not add matrixes of different size");
                        } 
                        break;
                    case 5:
                        int l, x;
                        Console.Write("Enter Row: ");
                        int.TryParse(Console.ReadLine(), out l);
                        Console.Write("Enter Column: ");
                        int.TryParse(Console.ReadLine(), out x);
                        BlockMatrix z = new BlockMatrix(l, x);
                        int num = 0;
                        for (int ii = 1; ii <= (l + x); ii += 1)
                        {
                            for (int jj = 1; jj <= (l + x); jj += 1)
                            {
                                try
                                {
                                    z.Set(ii, jj, 0);
                                    Console.Write("Value for i=" + ii + ", j=" + jj + ": ");
                                    num = int.Parse(Console.ReadLine()!);
                                    z.Set(ii, jj, num);
                                }
                                catch (Exception) { }
                            }
                        }
                        try
                        {
                            this.m.Multiply(z);
                            this.m.Print();
                        }
                        catch (BlockMatrix.MatrixSizeError)
                        {
                            Console.WriteLine("Can not add matrixes of different size");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Bye Bye");
                        break;
                        default: break; 
                }
            }
        }
    }
}
