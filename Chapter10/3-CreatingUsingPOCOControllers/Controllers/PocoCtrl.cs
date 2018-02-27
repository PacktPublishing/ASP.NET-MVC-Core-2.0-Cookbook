using Microsoft.AspNetCore.Mvc;

[Controller]
public class PocoCtrlBase { }

[Route("api/[controller]")]
public class PocoCtrlInherits : PocoCtrlBase
{
    [HttpGet]
    public string Get()
    {
        return "This is a POCO Controller inherited";
    }
}

//[Controller]
//[Route("api/[controller]")]
//public class PocoCtrl
//{
//    [HttpGet]
//    public string Get()
//    {
//        return "This is a POCO Controller";
//    }
//}
