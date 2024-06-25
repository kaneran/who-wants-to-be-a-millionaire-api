@echo off
:: Amend the below path to point to the directory you want to save the files to
pushd <full file path>

for %%x in (animals, brain-teasers, celebrities, entertainment, for-kids, general, geography, history, hobbies, humanities, literature, movies, music, newest, people, rated, religion-faith, science-technology, sports, television, video-games, world) do (
	echo Fetching data for category %%x
	curl -O https://raw.githubusercontent.com/uberspot/OpenTriviaQA/master/categories/%%x
	echo Data fecthed for category %%x

	curl -L -v -X POST "http://localhost:5152/api/QuestionAnswer?category=%%x" 2>&1

	:: Check if curl command succeeded
	if errorlevel 1 (
		echo Curl command failed
	) else (
		echo Curl command succeeded
	)

)

echo Batch import completed
