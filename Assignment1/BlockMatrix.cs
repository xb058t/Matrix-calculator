using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class BlockMatrix
    {
        public class MatrixSizeError : Exception { };
        public class IndexError : Exception { };
        private int b1, b2;
        private int[] storage;
        public BlockMatrix(int b1, int b2)
        {
            if (b1 < 2 || b2 < 2)
            {
                throw new MatrixSizeError();
            }
            this.b1 = b1; this.b2 = b2;
            this.storage = new int[(b1 * b1 + b2 * b2) + 1];
            for (int i = 1; i <= b1 * b1 + b2 * b2; i += 1)
            {
                this.storage[i] = 0;
            }
        }
        public int GetRowLength() { return this.b1; }
        public int GetColumnLength() { return this.b2; }
        public void Print()
        {
            int index = 1;
            for (int i = 1; i <= b1 + b2; i += 1)
            {
                if (i <= b1)
                {
                    for (int j = 1; j <= b1; j += 1)
                    {
                        Console.Write(this.storage[index] + "\t");
                        index += 1;

                    }
                    for (int j = 1; j <= b2; j += 1)
                    {
                        Console.Write(0 + "\t");
                    }
                }
                else
                {
                    for (int j = 1; j <= b1; j += 1)
                    {
                        Console.Write(0 + "\t");
                    }
                    for (int j = 1; j <= b2; j += 1)
                    {
                        Console.Write(this.storage[index] + "\t");
                        index += 1;

                    }
                }
                Console.WriteLine();
            }
        }
        public int GetIndex(int i, int j)
        {
            if (i <= this.b1 && j <= this.b1)
            {
                return (i - 1) * this.b1 + j;
            }
            else if (i > this.b1 && j > this.b1)
            {
                return (this.b1 * this.b1) + (i - this.b1 - 1) * this.b2 + (j - this.b1);
            }
            return -1;
        }
        public int Get(int i, int j)
        {
            int index = this.GetIndex(i, j);
            if (index == -1)
            {
                return 0;
            }
            return this.storage[index];
        }
        public void Set(int i, int j, int e)
        {
            int index = this.GetIndex(i, j);
            if (index == -1)
            {
                throw new IndexError();
            }
            this.storage[index] = e;
        }
        public void Add(BlockMatrix matrix2)
        {
            if (matrix2.GetRowLength() != this.GetRowLength() || matrix2.GetColumnLength() != this.GetColumnLength())
            {
                throw new MatrixSizeError();
            }
            for (int i = 1; i <= this.b1 + this.b2; i++)
            {
                for (int j = 1; j <= this.b1 + this.b2; j++)
                {
                    if (this.GetIndex(i, j) != -1)
                    {
                        this.Set(i, j, this.Get(i, j) + matrix2.Get(i, j));

                    }
                }
            }
        }
        public void Multiply(BlockMatrix matrix2)
        {
            if (matrix2.GetRowLength() != this.GetRowLength() || matrix2.GetColumnLength() != this.GetColumnLength())
            {
                throw new MatrixSizeError();
            }
                BlockMatrix result = new BlockMatrix(this.b1, matrix2.b2);
            for (int i = 1; i <= this.b1 + this.b2; i++)
            {
                for (int j = 1; j <= this.b1 + this.b2; j++)
                {
                    if (this.GetIndex(i, j) != -1)
                    {
                        int p  = 0;
                        for(int k = 1; k <= this.b1 + this.b2; k++)
                        {
                            p += this.Get(i, k) * matrix2.Get(k, j);
                        }
                            
                        
                        result.Set(i, j, p);

                    }
                }
            }
            for (int i = 1; i <= (this.b1 * this.b1) + (this.b2 * this.b2); i++)
            {
                this.storage[i] = result.storage[i];
            }
        }
    }   
}