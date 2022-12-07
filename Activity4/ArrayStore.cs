using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Activity.Datastore
{
    public class ArrayStore<T> : AbstractArrayStore<T>
    {
        public ArrayStore(int arraySize) : base(arraySize)
        {
            //No logic
        }

        public override int Add(T argToAdd)
        {
            if (IsFull())
            {
                return NOT_IN_STRUCTURE;
            }
            if(argToAdd == null)
            {
                throw new ArgumentNullException("Arg is null");
            }

            this[Count++] = argToAdd;

            return this.IndexOf(argToAdd);

        }
        public override void RemoveAt(int removeObjectIndex)
        {
            if(removeObjectIndex < 0 || removeObjectIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Specified index out of range");
            }

            Count--;
            for (int i = removeObjectIndex; i < Count; i++)
            {
                //Compressing array
                T arr = this[i];
                this[i] = this[i + 1];
                this[i + 1] = arr;
            }

        }

        public override void Remove(T argToRemove)
        {
            if(argToRemove == null)
            {
                throw new ArgumentNullException("Arg is null");
            }
            
            if(IsEmpty() || !Contains(argToRemove))
            {
                throw new InvalidOperationException("The operation is not possible");
            }
            
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Equals(argToRemove))
                {
                    RemoveAt(i);
                }
            }
        }
        public override int Insert(T argToInsert, int indexToInsert)
        {
            if (argToInsert == null)
            {
                throw new ArgumentNullException("Argument can not be null");
            }

            if (indexToInsert < 0 || indexToInsert >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Argument out of range");
            }

            if (!IsFull())
            {
                for (int i = Count++; i > indexToInsert; i--)
                {
                    this[i] = this[i - 1];
                }

                this[indexToInsert] = argToInsert;

                return indexToInsert;
            }

            return NOT_IN_STRUCTURE;
        }
        
    }
}

