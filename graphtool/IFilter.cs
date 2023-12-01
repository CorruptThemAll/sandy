namespace graphtool;

public interface IFilter
{
    public object Data { get; set; }
    public void Design();
    public void Use(object data);
}

public class FirFilter : IFilter
{
    public object Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public FirFilter(object Data)
    {
        
    }
    public void Design()
    {
    }

    public void Use(object data)
    {
        if(data == typeof(int[])) 
        {

        }
        if(data == typeof(double[]))
        {

        }
    }
}