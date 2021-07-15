using System;
using System.Collections;
using System.Collections.Generic;

// Simple business object.
namespace task_4
{



//4.6. Создать контейнер Persons, который можно было бы использовать в foreach. 
   
    public class People<T>: IEnumerable
    {
        private List<Person> _people;
        private int _index = -1;
        
       
        public People(T[] pArray)
        {
            _people = new List<Person>();

            for (int i = 0; i < pArray.Length; i++)
            {
                _index++;
                _people.Add(pArray[i] as Person);
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people.ToArray());
        }
       public  void Add(T person)
        {
            _index++;
            _people.Add(person as Person);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Person Current
        {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }



}