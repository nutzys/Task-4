using System;

namespace CSharp.Activity.Datastore
{
   /// <summary>
   /// Summary description for AbstractArrayStore.
   /// </summary>
   public abstract class AbstractArrayStore<T>
   {
      //This is a constant that represents the code value returned when an object cannot be found in the array
      public const int NOT_IN_STRUCTURE = -1;
      
      //This is a constant that represents the default size of the array
      public const int DEFAULT_SIZE = 5;

      //This is the actual structure that the class uses to store objects
      private T[] storeArray;

      /// <summary>
      /// Returns the maximum size of an array.
      /// </summary>
      public int Capacity
          => this.storeArray.Length;
        
      /// <summary>
      /// Counts the number of objects currently inside the array.
      /// </summary>
      public int Count { get; protected set; }

      #region Abstract Methods - To be implemented in derived class
      
      /// <summary>
      /// Adds an object to the the data structure.
      /// </summary>
      /// <param name="argToAdd">The object to be added.</param>
      /// <returns>Returns NOT_IN_STRUCTURE if array is full, or added element index if addition succeeded.</returns>
      public abstract int Add(T argToAdd);

      /// <summary>
      /// Removes an object from the specified location in the data structure.
      /// </summary>
      /// <param name="removeObjectIndex">The index from which the object has to be removed.</param>
      /// <returns>Throws InvalidOperationException if removal is not possible.</returns>
      public abstract void RemoveAt(int removeObjectIndex);

      /// <summary>
      /// Removes an object from the data structure.
      /// </summary>
      /// <param name="argToRemove">The object to be removed.</param>
      /// <returns>Throws InvalidOperationException if removal is not possible.</returns>
      public abstract void Remove(T argToRemove);

      /// <summary>
      /// Inserts an object at the specified location in the data structure.
      /// </summary>
      /// <param name="argToInsert">The object to be inserted.</param>
      /// <param name="indexToInsert">The index at which the object is to be inserted.</param>
      /// <returns>Returns NOT_IN_STRUCTURE if array is full, or added element index if addition succeeded.</returns>
      public abstract int Insert(T argToInsert, int indexToInsert);

      #endregion Abstract Methods - To be implemented in derived class

      /// <summary>
      /// Default constructor. Initializes the array to the default size.
      /// </summary>
      public AbstractArrayStore() : this(DEFAULT_SIZE)
      {
         //No logic
      }

      /// <summary>
      /// Constructor which takes an integer argument and initializes the array with the input argument.
      /// </summary>
      /// <param name="arraySize">Size for which the array has to be initialized.</param>
      public AbstractArrayStore(int arraySize)
      {
         //Initializes the array to the specified size if it is greater than zero.
         //Else initializes to the default size
         this.storeArray = new T[arraySize > 0 ? arraySize : DEFAULT_SIZE];
      }

      /// <summary>
      /// Checks if the array is empty or not.
      /// </summary>
      public bool IsEmpty()
          => (this.Count <= 0);

      /// <summary>
      /// Method to check if the array is completely filled or not.
      /// </summary>
      /// <returns>A boolean value
      ///            - True if the array is full
      ///            - False otherwise.
      /// </returns>
      public bool IsFull()
          => (this.Count == this.storeArray.Length);

      /// <summary>
      /// Method to check if an object is in the data structure.
      /// </summary>
      /// <param name="argToFind">The argument to be checked for existence in the array</param>
      /// <returns>
      ///      Returns the index at which the input argument if it is found in the array.
      ///      -1 otherwise.
      /// </returns>
      public int IndexOf(T argToFind)
      {
         //Loop through the array
         for (int i = 0; i < this.Count; i++)
         {
            //Check if the argument at the current index is equal to the input argument
            if (this.storeArray[i].Equals(argToFind))
            {
               return i;
            }
         }

         //Input argument is not found.
         return NOT_IN_STRUCTURE;
      }

      /// <summary>
      /// Method to check if the input argument can be found in the array.
      /// </summary>
      /// <param name="argToCheck">The object to be checked for existence in the array</param>
      /// <returns>A boolean value
      ///    - True if the input object is found in the array
      ///    - False otherwise.
      /// </returns>
      public bool Contains(T argToCheck)
         => (this.IndexOf(argToCheck) != NOT_IN_STRUCTURE);

      /// <summary>
      /// Indexer property to return/change the value at the specified index
      /// </summary>
      /// <param name="index">The index from which the value is required</param>
      /// <returns>The value at the specified index.</returns>
      public virtual T this[int index]
      {
         get
         {
             if ((index < 0) || (index >= this.Capacity))
                 throw new IndexOutOfRangeException("Invalid Index");

             return this.storeArray[index];
         }
         protected set
         {
             this.storeArray[index] = value;
         }
      }
   }
}
