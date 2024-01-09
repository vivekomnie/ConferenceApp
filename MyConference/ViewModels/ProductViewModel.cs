using System;
//using Java.Net;
using MyConference.Models;
using MyConference.WebServices;
using Newtonsoft.Json;
//using static Android.Gms.Common.Apis.Api;

namespace MyConference.ViewModels
{

	public class ProductViewModel
	{
        WebService _restService;
        public Conference aaa;
        //public IList<Products> ProductList { get; set; }
        private HttpClient _Client = new HttpClient();
        public ProductViewModel()
        {
            //ServiceCall();
		}
        //  public async Task<List<Products>> GetProductList()
        //{
        //    List<Products> productList = await _restService.GetProductAsync(Constants.ProductEndpoint);

        //    return productList;
        //}
    }
}

