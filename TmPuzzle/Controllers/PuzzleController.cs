using Microsoft.AspNetCore.Mvc;
using TmPuzzle.Entities;
using TmPuzzle.Services;

namespace TmPuzzle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzleController : ControllerBase
    {
        private readonly ILogger<PuzzleController> _logger;
        private readonly IPuzzleService _puzzleService;

        //TODO add the other script dings
        private string maniascript = @$"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes"" ?>
                                        <manialink version=""3"">
		                                        <frame id=""Window"" hidden=""0"">
			                                        <label id=""Title"" pos=""0 58"" z-index=""3"" size=""85.1 9.89"" text=""Text1"" halign=""center"" valign=""center"" style=""TextTitle1""/>
			                                        <quad id=""eImg"" pos=""0 -10.9"" halign=""center"" valign=""center"" z-index=""4"" size=""58 58.1"" image=""""/>		
			                                        <label id=""Close""  pos=""0 -55"" z-index=""3"" halign=""center"" style=""TextButtonMedium"" scriptevents=""1"" text=""Close"" size=""30.3 2.45""/>
		                                        </frame>
                                                <script><!--
                                                    #Include ""TextLib"" as TextLib
                                                    declare Boolean loop = True;
                                                    declare Text username = LocalUser.Name;
                                                    declare Text login = LocalUser.Login;
                                                    declare CMlLabel Title = (Page.GetFirstChild(""Title"") as CMlLabel);
                                                    Title.SetText(""Hello "" ^ username ^ ""$z"");
                                                    declare CMlQuad img = (Page.GetFirstChild(""eImg"") as CMlQuad);
                                                    declare Text requestURL = ""<HOST>/Puzzle/Solve/<mapId>/<easterEggId>.xml?login="" ^ username;
                                                    img.ChangeImageUrl(requestURL);
                                                    while(loop) {{
                                                        foreach (Event in PendingEvents) {{
                                                            if (Event.Type == CMlScriptEvent::Type::MouseClick) {{
                                                                if (Event.ControlId==""Close"") {{
                                                                    declare CMlFrame Window = (Page.GetFirstChild(""Window"") as CMlFrame);
                                                                    Window.Visible = False;
                                                                    loop = False;
                                                                }}
                                                            }}
                                                        }}
                                                        yield;
                                                    }}
                                                    -->
                                                </script>
                                            </manialink>";

        private string successImage = "data:image/png;base64,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";
        private string failImage = "data:image/png;base64,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";



        public PuzzleController(ILogger<PuzzleController> logger, IConfiguration configuration, IPuzzleService puzzleService)
        {
            _logger = logger;
            _puzzleService = puzzleService;
            maniascript = maniascript.Replace("<HOST>", configuration.GetValue<string>("Host"));
        }

        [HttpGet("Init")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> Init()
        {
            var map = new Map { MapUid = "", Name = "EasterEggTestTrack1" };
            await _puzzleService.CreateMap(map);
            var easterEgg = new EasterEgg { 
                Hint = "",
                ImageBlob = "",
                ManiaScript = "",
                MapId = map.Id,
                Map = map,
                MediaUrl = "",
                Name = "FirstEasterEgg",
                Value = "FirstValue"
            };

            await _puzzleService.CreateEasterEgg(easterEgg);

            return Ok();
        }

        [HttpGet("{mapId}/{easterEggId}.xml")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int mapId, int easterEggId)
        {
            //TODO check if mapId / easterEggId exists in db
            var map = await _puzzleService.GetEasterEggsForMap(mapId);
            var easterEgg = await _puzzleService.GetEasterEgg(easterEggId);
            
            if(easterEgg != null && map.Contains(easterEgg))
            {
                string temp = maniascript.Replace("<mapId>", mapId.ToString()).Replace("<easterEggId>", easterEggId.ToString());
                return Ok(temp);
            }
            else
            {
                return NotFound();
            }            
        }

        [HttpGet("Solve/{mapId}/{easterEggId}.xml")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Solve(int mapId, int easterEggId, string login, string name)
        {
            //TODO check if mapId / easterEggId exists in db
            var map = await _puzzleService.GetEasterEggsForMap(mapId);
            var easterEgg = await _puzzleService.GetEasterEgg(easterEggId);

            if (easterEgg != null && map.Contains(easterEgg))
            {
                var existingLogin = await _puzzleService.GetPlayer(login);
                if(existingLogin == null)
                {
                    var newPlayer = new Player { Name = name, Login = login, ContactInfo = "" };

                    existingLogin = await _puzzleService.CreatePlayer(newPlayer); 
                }
                var solve = new PlayerSolves { EasterEgg = easterEgg, Player = existingLogin };
                var solves = new List<PlayerSolves>();
                solves.Add(solve);

                await _puzzleService.CreatePlayerSolve(solve);

                //dbPlayer.SolvedEasterEggs = solves;
                //TODO Set solved = true in db
                return Ok(successImage);
            }
            else
            {
                return Ok(failImage);
            }
        }
    }
}