using System;
using System.Web.Http;
using Bliffoscope.Analysis.Core.Analysis;
using Bliffoscope.Analysis.Core.Model.Controller;

namespace Bliffoscope.Analysis.Api.Controller
{
	public class TargetSearchController : ApiController
	{
		private readonly IAnalysis _analysis;
		private static bool _searchInProgress;

		public TargetSearchController(IAnalysis analysis)
		{
			_analysis = analysis;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("api/searchtargets")]
		public IHttpActionResult SearchTargets(TargetSearchModel targetSearchModel)
		{
			if (_searchInProgress)
			{
				return BadRequest("Bliffoscope data analysis in progress, please wait!");
			}

			if(targetSearchModel == null)
			{
				return BadRequest("Invalid target search model");
			}

			int percentage;
			bool slimetorpedoMatchPercentageResult = int.TryParse(targetSearchModel.SlimetorpedoMatchPercentage, out percentage);
			bool starshipMatchPercentageResult = int.TryParse(targetSearchModel.StarshipMatchPercentage, out percentage);

			if(!slimetorpedoMatchPercentageResult || !starshipMatchPercentageResult)
			{
				return BadRequest("Invalid target search model");
			}

			_searchInProgress = true;
			var targetSearch = _analysis.SearchTargets(targetSearchModel);
			targetSearch.ProgressMessage = "Analysis completed successfully!";
			targetSearch.ProgressTime = DateTime.Now.ToLongTimeString();
			_searchInProgress = false;

			 return Ok(targetSearch);
		}
	}
}