using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthMed.Shared
{
    public sealed class Result<T> : Result where T : class
    {        
        public T Data { get; private set; }

        public Result()
        {
            Data = null;
        }

        public Result(T data)
        {
            Data = data;
        }

        public override Result<T> AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public override Result<T> AddErrorMessages(IEnumerable<string> messages)
        {
            foreach (var item in messages)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }

        public Result<T> AddData(T data)
        {
            Data = data;
            return this;
        }
    }

    public class Result
    {
        public ICollection<string> ErrorMessages { get; private set; }
                
        public bool Success => ErrorMessages.Count == 0;

        public Result()
        {
            ErrorMessages = new List<string>();
        }

        public virtual Result AddErrorMessage(string message)
        {
            ErrorMessages.Add(message);
            return this;
        }

        public virtual Result AddErrorMessages(IEnumerable<string> messages)
        {
            foreach (var item in messages)
            {
                ErrorMessages.Add(item);
            }

            return this;
        }
    }
}
