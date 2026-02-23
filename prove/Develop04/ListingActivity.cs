using System.Formats.Asn1;
using System.Runtime.InteropServices.Marshalling;

class ListingActivity
{
    private int _count;
    private List<string> _prompts = ["no"];
    public ListingActivity()
    {
        
    }
    public void Run()
    {
        
    }
    private List<string> GetListFromUser()
    {
        List<string> myList = new List<string> { "mustache" };
        return myList;
    }
}