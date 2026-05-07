using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
/*   
    Move beyond:
    
    “iterator = loop helper”
    
    into the deeper systems-level understanding:
    
    “iterator = traversal projection abstraction”
    
    That’s the real power.
*/
  public class BookCollection : IEnumerable
  {
      private string[] _books =
      {
          "Clean Code",
          "Design Patterns",
          "CLR via C#"
      };
  
      public IEnumerator GetEnumerator()
      {
          return new BookIterator(_books);
      }
  }
  
  public class BookIterator : IEnumerator
  {
      private string[] _books;
      private int _position = -1;
  
      public BookIterator(string[] books)
      {
          _books = books;
      }
  
      public bool MoveNext()
      {
          _position++;
          return _position < _books.Length;
      }
  
      public void Reset()
      {
          _position = -1;
      }
  
      public object Current
      {
          get
          {
              return _books[_position];
          }
      }
  }

// Modern C# Version
public class BookCollection
{
    private List<string> _books = new()
    {
        "Clean Code",
        "Design Patterns",
        "CLR via C#"
    };

    public IEnumerable<string> GetBooks()
    {
        foreach (var book in _books)
        {
            yield return book;
        }
    }
  }
}
