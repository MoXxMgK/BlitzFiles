using MediatR;
using BlitzFiles.Models;

namespace BlitzFiles.CQS
{
    public class GenericCommand: IRequest<int>
    {
        public class Create<T> : GenericCommand
        {
            public T DTO { get; set; }
        }

        public class Delete<T> : GenericCommand
        {
            public T DTO { get; set; }
        }

        public class Patch<T> : GenericCommand
        {
            public T DTO { get; set; }
            public List<PatchModel> PatchList { get; set; }
        }
    }
}
