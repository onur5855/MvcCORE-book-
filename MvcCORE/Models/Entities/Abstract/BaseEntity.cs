using MvcCORE.Models.Enum;

namespace MvcCORE.Models.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        
        private DateTime _createdDate=DateTime.Now;
        public DateTime CreatedDate
        { 
            get { return _createdDate; }
            set { _createdDate = value; } 
        }

        public DateTime? UpdateDate { get; set; }//nullable prop
        public DateTime? DeleteDate { get; set; }

        private Status _statu = Status.Active;
        public Status status
        {
            get { return _statu; }
            set { _statu = value; }
        }


    }
}
