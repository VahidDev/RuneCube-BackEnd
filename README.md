# RuneCube-BackEnd
			API DOCUMENTATION 

Some notes 
- url - domain/api	
- GPT3 - is a platform that we use to generate a random story. Link--> https://beta.openai.com/
- Code is written with Repository and unit of work pattern.

# url/storys 
- GET METHOD - StroysController works and calls function GenerateStartEndStoryPromptAsync. If gpt3 works, function will send a get request to it, get start and end stories, add it to database and return these stories. If gpt3 doesn’t work, function will send a request to db and get random start and end stories. That’s why there are several saved stories in db beforehand.
# url/leaderboards
- POST METHOD - LeaderBoardsController works and calls function StorePlayers. This function receives data that is posted by the socket at the end of the game which contains game information, to be precise usernames, roles, how much time users spent in the game and if they completed the game or not. Payload example: 
```
{
“username1”: “Narmin”,  
“username2”: “Vahid”, 
“role1”: “explorer”, 
“spent_time”: “0:01:07”, 
“is_finished”: True
}
```
StorePlayers function returns True if data successfully is saved in db, otherwise it returns False. 
# url/players 
- GET METHOD - PlayersController works and calls func GetPlayersAsync. Function gets players from db and filters them by the least spent time to finish the game and returns this players list. 
# url/runes  
- GET METHOD - RunesController works and calls func GetRuneAsync. This function gets all the runes from Runes table from db, all colors from Colors table and maps runes with colors.
# url/settings 
- GET METHOD - SettingsController works and calls func GetSettings which gets all the static settings from db  and returns it. Settings contain the following
```
{
"maxResponseTime": 15,
"count": 3,
"eachSideCount": 3,
"sidesTime": 75
}
```
- maxResponseTime – time in seconds. This is a time limit we set to finish finding one rune. 
- Count – how many runes user has to find in one side.
- eachSideCount – how many sides is set to finish the game.
- sidesTime – how much time is given to finish one side. 

