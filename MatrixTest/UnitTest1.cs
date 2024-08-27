using Assignment1;
using System.Runtime.Intrinsics.X86;
using static Assignment1.BlockMatrix;
namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTest()
        {
            BlockMatrix b = new BlockMatrix(2, 4);
            Assert.IsTrue(b.Get(1, 1) == 0);
            Assert.IsTrue(b.Get(1, 2) == 0);
            Assert.IsTrue(b.Get(2, 1) == 0);
            Assert.IsTrue(b.Get(2, 2) == 0);
            b.Set(3, 4, 6);
            Assert.IsTrue(b.Get(3, 4) == 6);
            b.Set(3, 5, 7);
            Assert.IsTrue(b.Get(3, 5) == 7);
            b.Set(3, 6, 8);
            Assert.IsTrue(b.Get(3, 6) == 8);
            b.Set(4, 3, 9);
            Assert.IsTrue(b.Get(4, 3) == 9);
            Assert.IsTrue(b.Get(1, 3) == 0);
        }

        [TestMethod]

        public void SetTest() 
        {
            BlockMatrix b = new BlockMatrix(2, 4);
            b.Set(1, 1, 0);
            Assert.IsTrue(b.Get(1, 1) == 0);
            b.Set(1, 2, 0);
            Assert.IsTrue(b.Get(1, 2) == 0);
            b.Set(2, 1, 0);
            Assert.IsTrue(b.Get(2, 1) == 0);
            b.Set(2, 2, 0);
            Assert.IsTrue(b.Get(2, 2) == 0);
        }

        [TestMethod]

        public void AddTest() 
        {
            BlockMatrix b = new BlockMatrix(2, 4);
            b.Set(1, 1, 1);
            b.Set(1, 2, 2);
            b.Set(2, 1, 3);
            b.Set(2, 2, 4);
            BlockMatrix g = new BlockMatrix(2, 4);
            g.Set(1, 1, 1);
            g.Set(1, 2, 2);
            g.Set(2, 1, 3);
            g.Set(2, 2, 4);
            b.Add(g);
            Assert.IsTrue(b.Get(1, 1) == 2);
            Assert.IsTrue(b.Get(1, 2) == 4);
            Assert.IsTrue(b.Get(2, 1) == 6);
            Assert.IsTrue(b.Get(2, 2) == 8);

        }
        [TestMethod]

        public void MultiplyMatrix()
        {
            BlockMatrix b = new BlockMatrix(2, 4);
            b.Set(1, 1, 1);
            b.Set(1, 2, 2);
            b.Set(2, 1, 3);
            b.Set(2, 2, 4);
            BlockMatrix m = new BlockMatrix(3, 4);
            BlockMatrix g = new BlockMatrix(2, 4);
            g.Set(1, 1, 1);
            g.Set(1, 2, 2);
            g.Set(2, 1, 3);
            g.Set(2, 2, 4);
            b.Multiply(g);
            Assert.IsTrue(b.Get(1, 1) == 7);
            Assert.IsTrue(b.Get(1, 2) == 10);
            Assert.IsTrue(b.Get(2, 1) == 15);
            Assert.IsTrue(b.Get(2, 2) == 22);
            Assert.ThrowsException<MatrixSizeError>(() => b.Multiply(m));
        }
        [TestMethod]
        public void GetIndexTest()
        {
            BlockMatrix b = new BlockMatrix(2, 4);
            int q = b.GetIndex(1, 2);
            Assert.IsTrue(q == 2);
            int l = b.GetIndex(3, 3);
            Assert.IsTrue(l == 5);
            int k = b.GetIndex(1, 5);
            Assert.IsTrue(k == -1); 

        }
        [TestMethod]
        public void asd()
        {
                Assert.ThrowsException<MatrixSizeError>(() => new BlockMatrix(-1, -1));
                Assert.ThrowsException<MatrixSizeError>(() => new BlockMatrix(-1, 10));
                Assert.ThrowsException<MatrixSizeError>(() => new BlockMatrix(-5, -5));
                Assert.ThrowsException<MatrixSizeError>(() => new BlockMatrix(-1000, -10000));

        }
    }
}