using System.Collections.Generic;

namespace Vulcan.DocumentDistance
{
    public interface ISplitter: IEnumerable<string>
    {
        void SetInput(string input); 
        string this[int i] { get;  }
        int Length { get; }
    }
}
