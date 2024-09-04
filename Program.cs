using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Queue
{
   
    public class CurcleQueue<T>
    {
        private T[] element;
        private int startindex = 0;
        private int endindex = 0;

        public int Count { get; private set;}
         
        public  CurcleQueue()
        {
            this.element = new T[16];
            this.startindex = 0;
            this.endindex = 0;
        }
        public CurcleQueue (int capacity ) 
        {
            this.element= new T[capacity];  
            this.startindex = 0;
            this.endindex = 0;
        }
        public void Enqueue(T element)
        {
            if (this.Count >= this.element.Length)
            {
                this.Grow();
            }
            this.element[this.endindex] = element;
            this.endindex = ( this.endindex + 1) % this.element.Length;    
            this.Count++;


        }
        public void Grow()
        {
            var NewEllements = new T[2 * this.element.Length];    
            this.CopyAllElementsTo( NewEllements ); 
            this.element = NewEllements;
            this.startindex = 0;
            this.endindex = this.Count;
        }
        private void CopyAllElementsTo(T[] rezultArr)
        {
            int sourceIndex = this.startindex;
            int destinationindex = 0;
            for (int i = 0; i < this.Count; i++)
            {
                rezultArr[destinationindex] = this.element[sourceIndex];
                sourceIndex = (sourceIndex + 1) % this.element.Length;
                destinationindex++;

            }
        }
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty!");
            }
            var result = this.element[startindex];
            this .startindex = (this.startindex+1)% this.element.Length;    
            this.Count--;
            return result;

        }
        public T[] ToArray()
        {
            var arr = new T[this.Count];
            CopyAllElementsTo(arr);
            return arr;
        }

    }

}

