using Newtonsoft.Json;
using RestSharp;
using System;

namespace ProyecPOC
{
	public class SituacionTributaria
	{
		public string Rut { get; set; }
		public string Dc { get; set; }
		public string Razon_social { get; set; }
		public bool Inicio_actividades { get; set; }
		public string Message { get; set; }

		public bool Situacion(string rutpyme)
		{
			String token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiNDNiZjJkODE4NDAzZTQ2ZTZlY2JjMWRiNzM5OTExYTcyMWVkYjRkN2M0ZjQ2MTNhMjQ2ZWNjZjg0OTQwMzFkZjNhYmJlZGI1ZDFhMzc4ODEiLCJpYXQiOjE1OTk3NTI3ODUsIm5iZiI6MTU5OTc1Mjc4NSwiZXhwIjoxNjMxMjg4Nzg1LCJzdWIiOiIyODciLCJzY29wZXMiOltdfQ.K0bco0mS74aYrjZNyRWjh31s7oPyIca26V5t4aXOFlf0UbnAowzrLBL4YGgGoFePaOaZHSzb46e2w_U9tYjoi1vfqIPHhnBacm7I5bGjUkFT8JzeXAkeQyV7MzyAs5f5isOQIfql8Qgz0fk7Slc53-OSs0mF8rnl7clDVRJ3mhoGBLxUsNmVODXMFZKZx3UDOSKFdggjfqMGI8n0GNK0koi_2JpRx00WpfmEeK5K4V3dD0yB8R6GiDG5M78yMOUBOarVCT7yAoX6I29g0Q_1nCvBMP5cGZuTGUD4QVgFa2TzkrYEqcHSBH7z6qwRsuircYIJO1797Cxup1L_2TbFjjV43QEoFv5VEuUGGIKrh8PTjLQVKuZJyqMsYG3XFxXfNJA3y7pjPvZ9NuBsBvS81F-el5QN8z-HwF6uAHCTq_zg6ARIBfJZXw2nIitmHED3zSfPW8uzO4qJStCUnlcC11EGx1mVWCxDFFcW8WZ4Y3egSdF1xvpiKUGc6R327EJrp5-eWSwrAsnIg1cxmmV6oQAVqEe0ui3kk7Pryw3yJXrXRg0oiiBylkhwIEqWPP-UUqK9qbrVTrBziwKFHgHghMyWwyCIFUB1Z0PYiBPAMw4IxwHaOkkRULb1dyorlAT_8AJWiyve-CkV-u6TvTroqd_JDDS43jKvPZ53BlZIoDc";
			var client = new RestClient("https://api.libredte.cl/api/v1/sii/contribuyentes/situacion_tributaria/tercero/" + rutpyme + "?formato=json");
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			request.AddHeader("Authorization", "Bearer " + token);
			request.AddHeader("Accept", "application/json");
			IRestResponse response = client.Execute(request);
			var actividades = JsonConvert.DeserializeObject<SituacionTributaria>(response.Content);
			return actividades.Inicio_actividades;

		}



	}



}