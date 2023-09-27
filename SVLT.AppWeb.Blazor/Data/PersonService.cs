using SVLT.DTOs.PersonDTOs;

namespace SVLT.AppWeb.Blazor.Data
{
    public class PersonService
    {
        readonly HttpClient _httpClientCRMAPI;

        public PersonService(IHttpClientFactory httpClientFactory)
        {
            _httpClientCRMAPI = httpClientFactory.CreateClient("CRMAPI");
        }

        public async Task<SearchResultPersonDTO> Search(SearchQueryPersonDTO searchQueryPersonDTO)
        {
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/person/search", searchQueryPersonDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultPersonDTO>();
                return result ?? new SearchResultPersonDTO();
            }
            return new SearchResultPersonDTO();
        }

        public async Task<GetIdResultPersonDTO> GetById(int id)
        {
            var response = await _httpClientCRMAPI.GetAsync("/person/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultPersonDTO>();
                return result ?? new GetIdResultPersonDTO();
            }

            return new GetIdResultPersonDTO();
        }

        public async Task<int> Create(CreatePersonDTO createPersonDTO)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/person", createPersonDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }

            return result;
        }

        public async Task<int> Edit(EditPersonDTO editPersonDTO)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.PostAsJsonAsync("/person", editPersonDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientCRMAPI.DeleteAsync("/person/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }

            return result;
        }
    }
}
