namespace Predica.WebApp.Data.Entity.Base
{
    public class BaseEntity<TPrimaryKey>
    {
	    public TPrimaryKey Id { get; set; }
    }
}
