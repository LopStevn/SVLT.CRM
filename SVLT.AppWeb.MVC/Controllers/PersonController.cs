using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SVLT.DTOs.PersonDTOs;

namespace SVLT.AppWeb.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly HttpClient _httpClientCRMAPI;

        // GET: CustomerController
        public PersonController(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRMAPI = httpClientFactory.CreateClient("CRMAPI");
        }

        public async Task<IActionResult> Index(SearchQueryPersonDTO searchQuerypersonDTO, int CountRow = 0)
        {
            if (searchQuerypersonDTO.SendRowCount == 0)
                searchQuerypersonDTO.SendRowCount = 2;
            if (searchQuerypersonDTO.Take == 0)
                searchQuerypersonDTO.Take = 10;

            var result = new SearchResultPersonDTO();

            var response = await _httpClientCRMAPI.PostAsJsonAsync("/person/search", searchQuerypersonDTO);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultPersonDTO>();

            result = result != null ? result : new SearchResultPersonDTO();

            if (result.CounRow == 0 && searchQuerypersonDTO.SendRowCount == 1)
                result.CounRow = CountRow;

            ViewBag.CountRow = result.CounRow;
            searchQuerypersonDTO.SendRowCount = 0;
            ViewBag.SearchQuery = searchQuerypersonDTO;

            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultPersonDTO();

            var response = await _httpClientCRMAPI.GetAsync("/person/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultPersonDTO>();

            return View(result ?? new GetIdResultPersonDTO());
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePersonDTO createPersonDTO)
        {

            try
            {
                var response = await _httpClientCRMAPI.PostAsJsonAsync("/customer", createPersonDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar crear un nuevo registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: PersonController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultPersonDTO();
            var response = await _httpClientCRMAPI.GetAsync("/customer/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultPersonDTO>();


            return View(new EditPersonDTO(result ?? new GetIdResultPersonDTO()));
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditPersonDTO editPersonDTO)
        {
            try
            {
                var response = await _httpClientCRMAPI.PutAsJsonAsync("/person", editPersonDTO);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar editar el registro";
                return View();

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultPersonDTO();
            var response = await _httpClientCRMAPI.GetAsync("/person/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultPersonDTO>();

            return View(result ?? new GetIdResultPersonDTO());
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultPersonDTO getIdResultPersonDTO)
        {
            try
            {
                var response = await _httpClientCRMAPI.DeleteAsync("person/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar eliminar el registro";
                return View(getIdResultPersonDTO);

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(getIdResultPersonDTO);
            }
        }
    }
}
