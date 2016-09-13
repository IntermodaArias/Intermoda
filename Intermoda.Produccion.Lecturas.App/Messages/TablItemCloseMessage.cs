namespace Intermoda.Produccion.Lecturas.App.Messages
{
    public class TablItemCloseMessage
    {
        public int Id { get; set; }

        public TablItemCloseMessage(int id)
        {
            Id = id;
        } 
    }
}