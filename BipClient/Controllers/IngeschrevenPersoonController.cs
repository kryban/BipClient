using Microsoft.AspNetCore.Mvc;

namespace Bip.Controllers
{
    public class IngeschrevenPersoonController : Controller
    {
        BipClient client;

        public IngeschrevenPersoonController()
        {
            client = new BipClient(new System.Net.Http.HttpClient());
        }
        // GET: IngeschrevenPersoon
        public ActionResult Index()
        {
            IngeschrevenPersoonHal response = client.IngeschrevenNatuurlijkPersoonAsync("999993653", null,null,null).Result;
            //IngeschrevenPersoonHal response = new IngeschrevenPersoonHal() { Burgerservicenummer = "999993653", Naam = new NaamPersoon() { Geslachtsnaam = "FooKlant" } };

            return View(response);
        }

        // GET: IngeschrevenPersoon/Details/5
        public ActionResult Details(int id)
        {
            IngeschrevenPersoonHal response = client.IngeschrevenNatuurlijkPersoonAsync(id.ToString(),null,null,null).Result;
            //IngeschrevenPersoonHal response = new IngeschrevenPersoonHal() { Burgerservicenummer = id.ToString(), Naam = new NaamPersoon() { Geslachtsnaam = "FooKlantId"+id.ToString() } };

            return View(response);
        }

        public ActionResult IndexEx(int id)
        {
            IngeschrevenPersoonHal response = client.IngeschrevenNatuurlijkPersoonAsync(id.ToString(),null,null,null).Result;
            //IngeschrevenPersoonHal response = new IngeschrevenPersoonHal() { Burgerservicenummer = id.ToString(), Naam = new NaamPersoon() { Geslachtsnaam = "FooKlantId"+id.ToString() } };

            //var foo = client.IngeschrevenpersonenBurgerservicenummerkinderenAsync()
            return View(response);
        }

    }
}